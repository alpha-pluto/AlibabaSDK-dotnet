/*======================================================================
    Daniel.Zhang
    
    文件名：OAuthAccessTokenResult.cs
    文件功能描述：开放平台AccessToken实体

======================================================================*/
using System;
using Com.Alibaba.Entities;

namespace Com.Alibaba.Open.OAuthAPIs
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OAuthAccessTokenResult : AliJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string aliId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string memberId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string resource_owner { get; set; }

        /// <summary>
        /// 访问令牌
        /// 有效期 10 小时
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 刷新令牌
        /// 有效期半年
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 令牌有效期（秒）
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 刷新令牌的有效期
        /// </summary>
        public string refresh_token_timeout { get; set; }

        /// <summary>
        /// 刷新令牌的有效期
        /// </summary>
        public DateTime? RefreshTokenTimeout
        {
            get
            {
                if (!string.IsNullOrEmpty(refresh_token_timeout))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(refresh_token_timeout);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OAuthAccessTokenTestResult : AliJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string aliId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string memberId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string resource_owner { get; set; }

        /// <summary>
        /// 访问令牌
        /// 有效期 10 小时
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 刷新令牌
        /// 有效期半年
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 令牌有效期（秒）
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 刷新令牌的有效期
        /// </summary>
        public string refresh_token_timeout { get; set; }

        /// <summary>
        /// 刷新令牌的有效期
        /// </summary>
        public DateTime? RefreshTokenTimeout
        {
            get
            {
                if (!string.IsNullOrEmpty(refresh_token_timeout))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(refresh_token_timeout);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }
    }

}
