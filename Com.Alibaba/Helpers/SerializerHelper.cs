﻿/*======================================================================
    Daniel.Zhang
    
    文件名：SerializerHelper.cs
    文件功能描述：序列化 处理助手类

======================================================================*/
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// 序列化 处理助手类
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// unicode解码
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static string DecodeUnicode(Match match)
        {
            if (!match.Success)
            {
                return null;
            }

            char outStr = (char)int.Parse(match.Value.Remove(0, 2), NumberStyles.HexNumber);
            return new string(outStr, 1);
        }

        /// <summary>
        /// 将对象转为JSON字符串
        /// </summary>
        /// <param name="data">需要生成JSON字符串的数据</param>
        /// <param name="jsonSetting">JSON输出设置</param>
        /// <returns></returns>
        public string GetJsonString(object data, JsonSetting jsonSetting = null)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            jsSerializer.RegisterConverters(new JavaScriptConverter[]
            {
                new AliJsonConventer(data.GetType(), jsonSetting),
                new ExpandoJsonConverter()
            });

            var jsonString = jsSerializer.Serialize(data);

            //解码Unicode，也可以通过设置App.Config（Web.Config）设置来做，这里只是暂时弥补一下，用到的地方不多
            MatchEvaluator evaluator = new MatchEvaluator(DecodeUnicode);
            var json = Regex.Replace(jsonString, @"\\u[\da-f]{4}", evaluator);//或：[\\u007f-\\uffff]，\对应为\u000a，但一般情况下会保持\
            return json;
        }

        /// <summary>
        /// 反序列化到对象
        /// </summary>
        /// <typeparam name="T">反序列化对象类型</typeparam>
        /// <param name="jsonString">JSON字符串</param>
        /// <returns></returns>
        public T GetObject<T>(string jsonString)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Deserialize<T>(jsonString);
        }

    }
}
