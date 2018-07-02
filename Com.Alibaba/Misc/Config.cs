/*======================================================================
    Daniel.Zhang
    
    文件名：Config.cs
    文件功能描述：全局设置

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba
{
    /// <summary>
    /// 全局设置
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 需要考虑分布式的情况，后期需要储存在缓存中
        /// </summary>
        private static bool _isDebug = false;

        /// <summary>
        /// 请求超时设置（以毫秒为单位），默认为10秒。
        /// 说明：此处常量专为提供给方法的参数的默认值，不是方法内所有请求的默认超时时间。
        /// </summary>
        public const int TIME_OUT = 60 * 1000;

        /// <summary>
        /// 指定是否是Debug状态，如果是，系统会自动输出日志
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return _isDebug;
            }

            set
            {
                _isDebug = value;
            }
        }

        /// <summary>
        /// JavaScriptSerializer 类接受的 JSON 字符串的最大长度
        /// </summary>
        public static int MaxJsonLength = int.MaxValue;

        /// <summary>
        /// 默认缓存键的第一级命名空间，默认值：DefaultCache
        /// </summary>
        public static string DefaultCacheNamespace = "DefaultCache";

        /// <summary>
        /// 
        /// </summary>
        public static string PreAuthUriRoot = @"${RequestSchema}://auth.1688.com";

        /// <summary>
        /// 
        /// </summary>
        public static string PreAuthUriRootSandbox = @"${RequestSchema}://auth.1688.com";

        /// <summary>
        /// 
        /// </summary>
        public static string RequestUriRoot = @"${RequestSchema}://gw.open.1688.com";

        /// <summary>
        /// 
        /// </summary>
        public static string RequestUriRootSandbox = @"${RequestSchema}://gw.open.1688.com";


    }
}
