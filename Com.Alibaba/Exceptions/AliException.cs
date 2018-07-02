/*======================================================================
    Daniel.Zhang
    
    文件名：AlibabaException.cs
    文件功能描述：AlibabaSdk自定义异常基类

======================================================================*/
using System;

namespace Com.Alibaba.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class AliException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logged"></param>
        public AliException(string message, bool logged = false)
            : this(message, null, logged) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="logged"></param>
        public AliException(string message, Exception exception, bool logged = false)
            : base(message, exception)
        {
            if (!logged)
            {

            }
        }
    }
}
