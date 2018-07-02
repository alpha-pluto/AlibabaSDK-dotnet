using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsExpandoPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }


        /// <summary>
        /// 获取 属性
        /// </summary>
        /// <param name="o"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static object GetProperty(object o, string member)
        {
            if (o == null) throw new ArgumentNullException("o");
            if (member == null) throw new ArgumentNullException("member");
            Type scope = o.GetType();
            IDynamicMetaObjectProvider provider = o as IDynamicMetaObjectProvider;
            if (provider != null)
            {
                ParameterExpression param = Expression.Parameter(typeof(object));
                DynamicMetaObject mobj = provider.GetMetaObject(param);
                GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null) });
                DynamicMetaObject ret = mobj.BindGetMember(binder);
                BlockExpression final = Expression.Block(
                    Expression.Label(CallSiteBinder.UpdateLabel),
                    ret.Expression
                );
                LambdaExpression lambda = Expression.Lambda(final, param);
                Delegate del = lambda.Compile();
                return del.DynamicInvoke(o);
            }
            else
            {
                return o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
            }
        }


        /// <summary>
        /// 将 expando对象中的 某个 属性值  加入 到字典 中
        /// 并先判断 属性 是否存在
        /// </summary>
        /// <param name="thisDict"></param>
        /// <param name="errMsg"></param>
        /// <param name="key"></param>
        /// <param name="valueType"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataProperty"></param>
        public static bool AddDictionaryItem<T>(out string errMsg, Dictionary<string, object> thisDict, string key, dynamic dataSource, string dataProperty)
        {
            bool result = false;
            errMsg = string.Empty;

            if (null != thisDict && !string.IsNullOrWhiteSpace(dataProperty) && null != dataSource)
            {
                var dynamicValue = GetProperty(dataSource, dataProperty);

                if (null != dynamicValue)
                {
                    key = string.IsNullOrWhiteSpace(key) ? dataProperty : key;
                    if (!thisDict.ContainsKey(key))
                    {
                        thisDict.Add(key, (T)dynamicValue);
                        result = true;
                    }
                    else
                    {
                        //thisDict[key] = dynamicValue;
                        errMsg = string.Format("{0} exists ", key);
                    }

                }

            }

            return result;
        }
    }
}
