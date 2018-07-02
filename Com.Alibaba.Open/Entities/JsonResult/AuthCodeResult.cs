/*======================================================================
    Daniel.Zhang
    
    文件名：AuthCodeResult.cs
    文件功能描述：获取授权码返回结果

======================================================================*/
using System;
using Com.Alibaba.Entities;

namespace Com.Alibaba.Open.Entities
{
    /// <summary>
    /// 获取预授权码返回结果
    /// Receiving the Authorization Code
    /// </summary>
    [Serializable]
    public class AuthCodeResult : AliJsonResult
    {
        /// <summary>
        /// 预授权码
        /// </summary>
        public string authorization_code { get; set; }

        /// <summary>
        /// 有效期，为5分钟
        /// </summary>
        public virtual int expires_in { get; set; }
    }
}
