/*======================================================================
    Daniel.Zhang
    
    文件名：RequestPolicy.cs
    文件功能描述：请求api时的环境参数集成基类

======================================================================*/
using System;

namespace Com.Alibaba.Entities.Request
{
    /// <summary>
    /// 请求api时的环境参数集成基类
    /// </summary>
    public class RequestPolicy
    {

        /// <summary>
        /// 
        /// </summary>
        public RequestPolicy()
        {
            ApiRoot = "openapi";
            ApiVersion = "1";
            Protocol = Com.Alibaba.Protocol.http;
            SessionType = SessionType.Prod;
            RequestSchema = UriSchema.https;
            ValidateSignature = true;
        }

        /// <summary>
        /// appKey
        /// </summary>
        public String ClientId { get; set; }

        /// <summary>
        /// app密钥
        /// </summary>
        public String ClientSecret { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public String AccessToken { get; set; }

        /// <summary>
        /// Api根目录 
        /// </summary>
        public String ApiRoot { get; set; }

        /// <summary>
        /// Api版本
        /// </summary>
        public String ApiVersion { get; set; }

        /// <summary>
        /// Api命名空间
        /// </summary>
        public String ApiNamespace { get; set; }

        /// <summary>
        /// Api名称
        /// </summary>
        public String ApiName { get; set; }

        /// <summary>
        /// 请求协议格式
        /// </summary>
        public Com.Alibaba.Protocol Protocol { get; set; }

        /// <summary>
        /// 请求 正式 / 沙盒
        /// </summary>
        public SessionType SessionType { get; set; }

        /// <summary>
        /// Api Uri 是否安全协议
        /// </summary>
        public UriSchema RequestSchema { get; set; }

        /// <summary>
        /// 是否验证签名
        /// </summary>
        public bool ValidateSignature { get; set; }
    }
}
