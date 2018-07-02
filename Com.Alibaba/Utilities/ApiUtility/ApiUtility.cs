/*======================================================================
    Daniel.Zhang
    
    文件名：CacheUtility.cs
    文件功能描述：缓存工具类

======================================================================*/
using System;

namespace Com.Alibaba.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiUtility
    {
        /// <summary>
        /// 判断accessTokenOrClientId参数是否是ClinetId
        /// </summary>
        /// <param name="accessTokenOrClientId"></param>
        /// <returns></returns>
        public static bool IsClientId(string accessTokenOrClientId)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(accessTokenOrClientId ?? "", @"(?i)^[a-f\d]{24}$");
        }

        /// <summary>
        /// 判断accessTokenOrClientId参数是否是AccessToken
        /// </summary>
        /// <param name="accessTokenOrClientId"></param>
        /// <returns></returns>
        public static bool IsAccessToken(string accessTokenOrClientId)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(accessTokenOrClientId ?? "", @"(?i)^[a-f\d]{32}$");
        }

        /// <summary>
        /// 获取过期时间
        /// </summary>
        /// <param name="expireInSeconds">有效时间（秒）</param>
        /// <returns></returns>
        public static DateTime GetExpireTime(int expireInSeconds)
        {
            if (expireInSeconds > 3600)
            {
                expireInSeconds -= 600;//提前10分钟过期
            }
            else if (expireInSeconds > 1800)
            {
                expireInSeconds -= 300;//提前5分钟过期
            }
            else if (expireInSeconds > 300)
            {
                expireInSeconds -= 30;//提前1分钟过期
            }

            return DateTime.Now.AddSeconds(expireInSeconds);//提前2分钟重新获取
        }
    }
}
