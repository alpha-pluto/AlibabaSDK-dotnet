/*======================================================================
    Daniel.Zhang
    
    文件名：DateTimeHelper.cs
    文件功能描述：时间处理

======================================================================*/
using System;
using System.Globalization;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// 时间处理助手类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 这里定义两个日期格式，由于.Net平台的毫秒格式用fff表示，Ocean平台(Java)的毫秒格式用SSS表示。
        /// </summary>
        public static string DatePattern { get { return "yyyyMMddHHmmssfff"; } }

        /// <summary>
        /// 
        /// </summary>
        public static string DatePatternForOcean { get { return "yyyyMMddHHmmssSSS"; } }

        /// <summary>
        /// Unix时间戳起始时间
        /// </summary>
        public static DateTime BaseTime = new DateTime(1970, 1, 1);

        /// <summary>
        /// 转换DateTime时间到C#时间(UTC+8)
        /// </summary>
        /// <param name="dateTimeFromJson">DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromJson(long dateTimeFromJson)
        {
            return BaseTime.AddTicks((dateTimeFromJson + 8 * 60 * 60) * 10000000);
        }

        /// <summary>
        /// 转换DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromJson">DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromJson(string dateTimeFromJson)
        {
            return GetDateTimeFromJson(long.Parse(dateTimeFromJson));
        }

        /// <summary>
        /// 获取DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetUnixTimestamp(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentTimestamp()
        {
            System.DateTime current = new DateTime();
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            double ms = (current - startTime).TotalMilliseconds;
            long b = Convert.ToInt64(ms);
            return b;
        }

        /// <summary>
        /// 将时间格式化成 yyyyMMddHHmmssfff 字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String Format(DateTime date)
        {
            return date.ToString(DatePattern);
        }

        /// <summary>
        /// 将时间格式化成 yyyyMMddHHmmssSSS 字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String FormatForOcean(DateTime date)
        {
            String value = date.ToString("yyyyMMddHHmmssfffzzz");
            String newValue = value.Replace(":", "");
            return newValue;
        }

        /// <summary>
        /// 将时间字符串格式化成时间
        /// </summary>
        /// <param name="dateDesc"></param>
        /// <returns></returns>
        public static DateTime FormatFromStr(String dateDesc)
        {
            if (dateDesc.Contains("+") || dateDesc.Contains("-"))
            {
                try
                {
                    IFormatProvider culture = new CultureInfo("zh-CN", true);
                    DateTime datetime = DateTime.ParseExact(dateDesc, "yyyyMMddHHmmssfffzzz", culture);
                    return datetime;
                }
                catch (Exception x)
                {

                }
            }

            IFormatProvider newculture = new CultureInfo("zh-CN", true);
            DateTime newdatetime = DateTime.ParseExact(dateDesc, DatePattern, newculture);
            return newdatetime;

        }
    }
}
