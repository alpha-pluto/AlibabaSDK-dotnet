﻿/*======================================================================
    Daniel.Zhang
    
    文件名：FileHelper.cs
    文件功能描述：处理文件

======================================================================*/
using System;
using System.Reflection;
using System.Globalization;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.EntityUtility
{
    /// <summary>
    /// 
    /// </summary>
    public static class EntityUtility
    {
        /// <summary>
        /// 将对象转换到指定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="convertibleValue"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this IConvertible convertibleValue)
        {
            if (null == convertibleValue)
            {
                return default(T);
            }

            //如果不是泛型
            if (!typeof(T).IsGenericType)
            {
                return (T)Convert.ChangeType(convertibleValue, typeof(T));
            }
            else
            {
                Type genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    return (T)Convert.ChangeType(convertibleValue, Nullable.GetUnderlyingType(typeof(T)));
                }
            }

            throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", convertibleValue.GetType().FullName, typeof(T).FullName));
        }

        /// <summary>
        /// 向属性填充值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        public static void FillSystemType<T>(T entity, PropertyInfo prop, IConvertible value)
        {
            FillSystemType(entity, prop, value, prop.PropertyType);
        }

        /// <summary>
        /// 向属性填充值（强制使用指定的类型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        /// <param name="specialType"></param>
        public static void FillSystemType<T>(T entity, PropertyInfo prop, IConvertible value, Type specialType)
        {
            object setValue = null;
            if (value.GetType() != specialType)
            {
                switch (specialType.Name)
                {
                    case "Boolean":
                        setValue = value.ConvertTo<bool>();
                        break;
                    case "DateTime":
                        setValue = DateTimeHelper.GetDateTimeFromJson(value.ToString());
                        break;
                    case "Int32":
                        setValue = value.ConvertTo<int>();
                        break;
                    case "Int64":
                        setValue = value.ConvertTo<long>();
                        break;
                    case "Double":
                        setValue = value.ConvertTo<double>();
                        break;
                    case "String":
                        setValue = value.ToString(CultureInfo.InvariantCulture);
                        break;
                    default:
                        setValue = value;
                        break;
                }
            }

            switch (specialType.Name)
            {
                case "Nullable`1": //可为空对象
                    {
                        if (!string.IsNullOrEmpty(value as string))
                        {
                            var genericArguments = prop.PropertyType.GetGenericArguments();
                            FillSystemType(entity, prop, value, genericArguments[0]);
                        }
                        else
                        {
                            prop.SetValue(entity, null, null);//默认通常为null
                        }
                        break;
                    }
                //case "String":
                //case "Boolean":
                //case "DateTime":
                //case "Int32":
                //case "Int64":
                //case "Double":
                default:
                    prop.SetValue(entity, setValue ?? value, null);
                    break;
            }

        }
    }
}
