/*======================================================================
    Daniel.Zhang
    
    文件名：ReqModelOrderListForSeller.cs
    文件功能描述：未注册ClientId异常

======================================================================*/
using System;

namespace Com.Alibaba.Exceptions
{
    /// <summary>
    /// 未注册ClientId异常
    /// </summary>
    public class UnRegisterClientIdException : AliException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public UnRegisterClientIdException(string clientId, string message, Exception inner = null)
            : base(message, inner)
        {
            ClientId = clientId;
        }
    }
}
