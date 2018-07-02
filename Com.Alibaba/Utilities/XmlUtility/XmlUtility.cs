﻿/*======================================================================
    Daniel.Zhang
    
    文件名：XmlUtility.cs
    文件功能描述：Xml工具

======================================================================*/
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Com.Alibaba.Utilities
{
    /// <summary>
    /// Xml工具
    /// </summary>
    public class XmlUtility
    {
        #region 反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize<T>(string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                AliTrace.Log("Deserialize Exception [Com.Alibaba.Utilities.XmlUtility.Deserialize]", e);
                return null;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object Deserialize<T>(Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(T));
            return xmldes.Deserialize(stream);
        }

        #endregion

        #region 序列化

        /// <summary>
        /// 序列化
        /// 说明：此方法序列化复杂类，如果没有声明XmlInclude等特性，可能会引发“使用 XmlInclude 或 SoapInclude 特性静态指定非已知的类型。”的错误。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serializer<T>(T obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(T));
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion

        /// <summary>
        /// 序列化将流转成XML字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static XDocument Convert(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);//强制调整指针位置
            using (XmlReader xr = XmlReader.Create(stream))
            {
                return XDocument.Load(xr);
            }
        }
    }
}
