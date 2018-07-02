﻿/*======================================================================
    Daniel.Zhang
    
    文件名：EnumHelper.cs
    文件功能描述：枚举助手类

======================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// 枚举 帮助 类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 将 字符串 转换 为 对应 的枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumItemName"></param>
        /// <returns></returns>
        public static T ConvertToEnumItem<T>(string enumItemName)
        {
            Type t = typeof(T);
            T newEnumItem = (T)Activator.CreateInstance(t);

            try
            {
                newEnumItem = (T)(Enum.Parse(t, enumItemName));
            }
            catch
            {

            }
            return newEnumItem;
        }

        /// <summary>
        /// 将 按值  转换 为 对应 的枚举项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumItemValue"></param>
        /// <returns></returns>
        public static T ConvertToEnumItem<T>(int enumItemValue)
        {
            Type t = typeof(T);
            T newEnumItem = (T)Activator.CreateInstance(t);

            try
            {
                newEnumItem = (T)(Enum.Parse(t, Convert.ToString(enumItemValue)));
            }
            catch
            {

            }
            return newEnumItem;
        }

        /// <summary>
		/// 从枚举中获取Description
		/// 说明：
		/// 单元测试-->通过
		/// </summary>
		/// <param name="enumName">需要获取枚举描述的枚举</param>
		/// <returns>描述内容</returns>
		public static string GetDescription(this Enum enumName)
        {
            string _description = string.Empty;
            FieldInfo _fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] _attributes = _fieldInfo.GetDescriptAttr();
            if (_attributes != null && _attributes.Length > 0)
                _description = _attributes[0].Description;
            else
                _description = enumName.ToString();
            return _description;
        }

        /// <summary>
        /// 获取字段Description
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>DescriptionAttribute[] </returns>
        public static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            if (fieldInfo != null)
            {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }

        /// <summary>
        /// 根据Description获取枚举
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举</returns>
        public static T GetEnumName<T>(string description)
        {
            Type _type = typeof(T);
            foreach (FieldInfo field in _type.GetFields())
            {
                DescriptionAttribute[] _curDesc = field.GetDescriptAttr();
                if (_curDesc != null && _curDesc.Length > 0)
                {
                    if (_curDesc[0].Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }

        /// <summary>
        /// 将枚举转换为ArrayList
        /// 说明：
        /// 若不是枚举类型，则返回NULL
        /// 单元测试-->通过
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>ArrayList</returns>
        public static ArrayList ToArrayList(this Type type)
        {
            if (type.IsEnum)
            {
                ArrayList _array = new ArrayList();
                Array _enumValues = Enum.GetValues(type);
                foreach (Enum value in _enumValues)
                {
                    _array.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
                }
                return _array;
            }
            return null;
        }
    }
}
