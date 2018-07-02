/*======================================================================
    Daniel.Zhang
    
    文件名：AliJsonConventer.cs
    文件功能描述：JSON输出设置/JSON转换器

======================================================================*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web.Script.Serialization;
using Com.Alibaba.Entities;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// JSON输出设置
    /// </summary>
    public class JsonSetting
    {
        /// <summary>
        /// 是否忽略当前类型以及具有IJsonIgnoreNull接口，且为Null值的属性。如果为true，符合此条件的属性将不会出现在Json字符串中
        /// </summary>
        public bool IgnoreNulls { get; set; }

        /// <summary>
        /// 需要特殊忽略null值的属性名称
        /// </summary>
        public List<string> PropertiesToIgnore { get; set; }

        /// <summary>
        /// 指定类型（Class，非Interface）下的为null属性不生成到Json中
        /// </summary>
        public List<Type> TypesToIgnore { get; set; }

        #region Attributes

        /// <summary>
        /// 可忽略的属性
        /// </summary>
        public class IgnoreValueAttribute : Attribute
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            public IgnoreValueAttribute(object value)
            {
                this.Value = value;
            }

            /// <summary>
            /// 
            /// </summary>
            public object Value { get; set; }
        }

        /// <summary>
        /// 例外属性，即不排除的属性值
        /// </summary>
        public class ExcludedAttribute : Attribute
        {

        }

        /// <summary>
        /// 枚举类型显示字符串
        /// </summary>
        public class EnumStringAttribute : Attribute
        {

        }

        #endregion

        /// <summary>
        /// JSON输出设置 构造函数
        /// </summary>
        /// <param name="ignoreNulls">是否忽略当前类型以及具有IJsonIgnoreNull接口，且为Null值的属性。如果为true，符合此条件的属性将不会出现在Json字符串中</param>
        /// <param name="propertiesToIgnore">需要特殊忽略null值的属性名称</param>
        /// <param name="typesToIgnore">指定类型（Class，非Interface）下的为null属性不生成到Json中</param>
        public JsonSetting(bool ignoreNulls = false, List<string> propertiesToIgnore = null, List<Type> typesToIgnore = null)
        {
            IgnoreNulls = ignoreNulls;
            PropertiesToIgnore = propertiesToIgnore ?? new List<string>();
            TypesToIgnore = typesToIgnore ?? new List<Type>();
        }


    }

    /// <summary>
    /// JSON转换器
    /// </summary>
    public class AliJsonConventer : JavaScriptConverter
    {
        private readonly JsonSetting _jsonSetting;
        private readonly Type _type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="jsonSetting"></param>
        public AliJsonConventer(Type type, JsonSetting jsonSetting = null)
        {
            this._jsonSetting = jsonSetting ?? new JsonSetting();
            this._type = type;
        }

        /// <summary>
        /// 支持的类型
        /// </summary>
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                var typeList = new List<Type>(new[] { typeof(IJsonIgnoreNull), typeof(IJsonEnumString)/*,typeof(JsonIgnoreNull)*/ });

                if (_jsonSetting.TypesToIgnore.Count > 0)
                {
                    typeList.AddRange(_jsonSetting.TypesToIgnore);
                }

                if (_jsonSetting.IgnoreNulls)
                {
                    typeList.Add(_type);
                }

                return new ReadOnlyCollection<Type>(typeList);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var result = new Dictionary<string, object>();
            if (obj == null)
            {
                return result;
            }

            var properties = obj.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                //continue;
                //排除的属性
                bool excludedProp = propertyInfo.IsDefined(typeof(JsonSetting.ExcludedAttribute), true);
                if (excludedProp)
                {
                    result.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
                }
                else
                {
                    if (!this._jsonSetting.PropertiesToIgnore.Contains(propertyInfo.Name))
                    {
                        bool ignoreProp = propertyInfo.IsDefined(typeof(ScriptIgnoreAttribute), true);
                        if ((this._jsonSetting.IgnoreNulls || ignoreProp) && propertyInfo.GetValue(obj, null) == null)
                        {
                            continue;
                        }


                        //当值匹配时需要忽略的属性
                        JsonSetting.IgnoreValueAttribute attri = propertyInfo.GetCustomAttribute<JsonSetting.IgnoreValueAttribute>();
                        if (attri != null && attri.Value.Equals(propertyInfo.GetValue(obj)))
                        {
                            continue;
                        }

                        JsonSetting.EnumStringAttribute enumStringAttri = propertyInfo.GetCustomAttribute<JsonSetting.EnumStringAttribute>();
                        if (enumStringAttri != null)
                        {
                            //枚举类型显示字符串
                            result.Add(propertyInfo.Name, propertyInfo.GetValue(obj).ToString());
                        }
                        else
                        {
                            result.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="type"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException(); //Converter is currently only used for ignoring properties on serialization
        }
    }
}
