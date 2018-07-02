/*======================================================================
    Daniel.Zhang
    
    文件名：OAuthAPI.cs
    文件功能描述：获得访问令牌

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Open;
using Com.Alibaba.HttpUtility;
using Com.Alibaba.CommonAPIs;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.Open.OAuthAPIs
{
    /// <summary>
    /// 授权、令牌相关 Api
    /// </summary>
    public static class OAuthApi
    {
        #region 同步请求

        /*此接口不提供异步方法*/
        /// <summary>
        /// 获取验证地址
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="site"></param>
        /// <param name="redirectUrl">Your app's redirect uri that you specified when you created the app</param>
        /// <param name="state"></param>
        /// <param name="grantType"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <returns></returns>
        public static string GetAuthorizeUrl(
            string clientId,
            string site = "1688",
            string redirectUrl = "http://localhost:12305",
            string state = null,
            string grantType = "authorization_code",
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {

            var url = string.Format("{0}/oauth/authorize?client_id={1}&site={2}&redirect_uri={3}&state={4}"
                                , sessionType == SessionType.Sandbox ? Com.Alibaba.Config.PreAuthUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.PreAuthUriRoot.UriSchemaFill(requestSchema)
                                , clientId.AsUrlData()
                                , site.AsUrlData()
                                , redirectUrl.AsUrlData()
                                , state.AsUrlData()
                                );

            /* 这一步发送之后，客户会得到授权页面，无论同意或拒绝，都会返回redirectUrl页面。
             * 如果用户同意授权，页面将跳转至 redirect_uri?code={authorization_code}。这里的code用于换取access_token 
             * 若用户禁止授权，则重定向后不会带上code参数 
             */
            return url;
        }

        /// <summary>
        /// 获取AccessToken
        /// 
        /// 范例
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208014.0.0.iacZUD&aamp;ns=cn.alibaba.open
        /// </summary>
        /// <param name="clientId">appKey</param>
        /// <param name="clientSecret">app密钥</param>
        /// <param name="preAuthCode">临时令牌 code</param>
        /// <param name="apiRoot">api 目录 </param>
        /// <param name="apiVersion">api 版本号</param>
        /// <param name="apiNamespace">api 命名空间</param>
        /// <param name="apiName">api 名称</param>
        /// <param name="protocol">调用协议</param>
        /// <param name="redirectUrl">回调地址</param>
        /// <param name="grantType">授权类型</param>
        /// <param name="needRefreshToken">是否需要刷新token</param>
        /// <param name="sessionType">请求环境</param>
        /// <param name="requestSchema">请求协议</param>
        /// <returns></returns>
        public static OAuthAccessTokenResult GetAccessToken(
            string clientId,
            string clientSecret,
            string preAuthCode,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "getToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.http,
            string redirectUrl = "http://localhost:12305",
            string grantType = "authorization_code",
            bool needRefreshToken = true,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                grant_type = grantType,
                need_refresh_token = needRefreshToken.ToString(),
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                redirect_uri = redirectUrl,
                code = preAuthCode//    The authorization code you received
            };
            return CommonJsonSend.Send<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Access Tokens
        /// 
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208020.0.0.ZL0di5&amp;ns=cn.alibaba.open
        /// 
        /// 注意：1688并未在结果中包含refresh_token,所以不要用返回数据中的refresh_token覆盖
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="grantType"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <returns></returns>
        public static OAuthAccessTokenResult RefreshAccessToken(
            string clientId,
            string clientSecret,
            string refreshToken,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "getToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            string grantType = "refresh_token",
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                grant_type = "refresh_token",
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken//    The authorization code you received
            };
            return CommonJsonSend.Send<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Refresh Tokens
        /// 如果当前时间离refreshToken过期时间在30天以内，那么可以调用postponeToken接口换取新的refreshToken；否则会报错
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208020.0.0.ZL0di5&amp;ns=cn.alibaba.open
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="refreshToken"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <returns></returns>
        public static OAuthAccessTokenResult RenewRefreshToken(
            string clientId,
            string clientSecret,
            string accessToken,
            string refreshToken,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "postponeToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken,//    The authorization code you received
                access_token = accessToken
            };
            return CommonJsonSend.Send<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 测试token
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#introduction
        /// 
        /// Test Authentication
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        [Obsolete("1688 没有测试令牌有效性的Api")]
        public static OAuthAccessTokenTestResult TestAccessToken(string accessToken, SessionType sessionType = SessionType.Prod)
        {
            //var url =
            //    string.Format("{0}/api/v2/auth_test",
            //                    sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox : Com.Alibaba.Config.RequestUriRoot);

            //var data = new
            //{
            //    access_token = accessToken
            //};
            //return CommonJsonSend.Send<OAuthAccessTokenTestResult>(null, url, data, CommonJsonSendType.POST);
            throw new NotImplementedException("1688 没有测试令牌有效性的Api");
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 获取AccessToken (异步)
        /// 
        /// 范例
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208014.0.0.iacZUD&aamp;ns=cn.alibaba.open
        /// </summary>
        /// <param name="clientId">appKey</param>
        /// <param name="clientSecret">app密钥</param>
        /// <param name="preAuthCode">临时令牌 code</param>
        /// <param name="apiRoot">api 目录 </param>
        /// <param name="apiVersion">api 版本号</param>
        /// <param name="apiNamespace">api 命名空间</param>
        /// <param name="apiName">api 名称</param>
        /// <param name="protocol">调用协议</param>
        /// <param name="redirectUrl">回调地址</param>
        /// <param name="grantType">授权类型</param>
        /// <param name="needRefreshToken">是否需要刷新token</param>
        /// <param name="sessionType">请求环境</param>
        /// <param name="requestSchema">请求协议</param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> GetAccessTokenAsync(
            string clientId,
            string clientSecret,
            string preAuthCode,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "getToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.http,
            string redirectUrl = "http://localhost:12305",
            string grantType = "authorization_code",
            bool needRefreshToken = true,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                grant_type = grantType,
                need_refresh_token = needRefreshToken.ToString(),
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                redirect_uri = redirectUrl,
                code = preAuthCode//    The authorization code you received
            };

            return await CommonJsonSend.SendAsync<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Access Tokens(Async)
        /// 
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208020.0.0.ZL0di5&amp;ns=cn.alibaba.open
        /// 
        /// 注意：1688并未在结果中包含refresh_token,所以不要用返回数据中的refresh_token覆盖
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="grantType"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> RefreshAccessTokenAsync(
            string clientId,
            string clientSecret,
            string refreshToken,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "getToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            string grantType = "refresh_token",
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                grant_type = "refresh_token",
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken//    The authorization code you received
            };
            return await CommonJsonSend.SendAsync<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Refresh Tokens
        /// 如果当前时间离refreshToken过期时间在30天以内，那么可以调用postponeToken接口换取新的refreshToken；否则会报错
        /// https://open.1688.com/api/sysAuth.htm?spm=a260s.8208020.0.0.ZL0di5&amp;ns=cn.alibaba.open
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="refreshToken"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> RenewRefreshTokenAsync(
            string clientId,
            string clientSecret,
            string accessToken,
            string refreshToken,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "system.oauth2",
            string apiName = "postponeToken",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https)
        {
            var url = new StringBuilder();
            url.Append(sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestSchema));
            url.Append($"/{apiRoot}/{protocol.ToString()}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}");

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken,//    The authorization code you received
                access_token = accessToken
            };
            return await CommonJsonSend.SendAsync<OAuthAccessTokenResult>(null, url.ToString(), data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 测试token (测试)
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#introduction
        /// 
        /// Test Authentication
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        [Obsolete("1688 没有测试令牌有效性的Api")]
        public static async Task<OAuthAccessTokenTestResult> TestAccessTokenAsync(string accessToken, SessionType sessionType = SessionType.Prod)
        {
            //var url =
            //    string.Format("{0}/api/v2/auth_test",
            //                    sessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox : Com.Alibaba.Config.RequestUriRoot);

            //var data = new
            //{
            //    access_token = accessToken
            //};
            //return await CommonJsonSend.SendAsync<OAuthAccessTokenTestResult>(null, url, data, CommonJsonSendType.POST);
            throw new NotImplementedException("1688 没有测试令牌有效性的Api");
        }

        #endregion
    }
}
