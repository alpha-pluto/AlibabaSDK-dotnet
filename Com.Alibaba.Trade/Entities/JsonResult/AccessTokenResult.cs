using Com.Alibaba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.Trade.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AccessTokenResult : AliJsonResult
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
        /// 
        /// </summary>
        public DateTime? AccessTokenTimeout { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        public static implicit operator AccessTokenResult(Com.Alibaba.Open.OAuthAPIs.OAuthAccessTokenResult accessToken)
        {
            return new AccessTokenResult
            {
                aliId = accessToken.aliId,
                memberId = accessToken.memberId,
                resource_owner = accessToken.resource_owner,
                access_token = accessToken.access_token,
                refresh_token = accessToken.refresh_token,
                expires_in = accessToken.expires_in,
                refresh_token_timeout = accessToken.refresh_token_timeout

            };
        }

    }
}
