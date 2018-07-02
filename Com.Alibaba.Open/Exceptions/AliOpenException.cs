/*======================================================================
    Daniel.Zhang
    
    文件名：AliOpenException.cs
    文件功能描述：开放平台授权异常处理类

======================================================================*/
using System;
using Com.Alibaba.Exceptions;
using Com.Alibaba.Open.Containers;

namespace Com.Alibaba.Open.Exceptions
{
    /// <summary>
    /// 开放平台授权异常处理类
    /// </summary>
    public class AliOpenException : AliException
    {
        /// <summary>
        /// ComponentBag
        /// </summary>
        public AuthrizationBag AuthBag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="authBag"></param>
        /// <param name="inner"></param>
        public AliOpenException(string message, AuthrizationBag authBag = null, Exception inner = null)
                : base(message, inner)
        {
            AuthBag = authBag;
        }
    }
}
