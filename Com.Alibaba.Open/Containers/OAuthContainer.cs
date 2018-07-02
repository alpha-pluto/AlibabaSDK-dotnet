/*======================================================================
    Daniel.Zhang
    
    文件名：OAuthContainer.cs
    文件功能描述：OAuth容器

======================================================================*/
using System;
using Com.Alibaba.Containers;
using Com.Alibaba.CacheUtility;
using Com.Alibaba.Open.OAuthAPIs;

namespace Com.Alibaba.Open.Containers
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AuthrizationBag : BaseContainerBag
    {
        #region parameter

        /// <summary>
        /// 只针对这个ClientId的锁
        /// </summary>
        internal object Lock = new object();

        private string _clientId;

        private string _clientSecret;

        private string _appName;

        private string _accessToken;

        private string _refreshToken;

        private DateTime _accessTokenExpiryTime;

        private OAuthAccessTokenResult _oAuthAccessTokenResult;

        #endregion

        /// <summary>
        /// ClientId，缓存中实际的Key
        /// </summary>
        public string AuthorizerClientId
        {
            get { return _clientId; }
            set { base.SetContainerProperty(ref _clientId, value); }
        }

        /// <summary>
        /// ClientSecret
        /// </summary>
        public string AuthorizerClientSecret
        {
            get { return _clientSecret; }
            set { base.SetContainerProperty(ref _clientSecret, value); }
        }

        /// <summary>
        /// AppName
        /// </summary>
        public string AuthorizerAppName
        {
            get { return _appName; }
            set { base.SetContainerProperty(ref _appName, value); }
        }

        /// <summary>
        /// AccessToken
        /// </summary>
        public string AuthorizerAccessToken
        {
            get { return _accessToken; }
            set { base.SetContainerProperty(ref _accessToken, value); }
        }

        /// <summary>
        /// RefreshToken
        /// </summary>
        public string AuthorizerRefreshToken
        {
            get { return _refreshToken; }
            set { base.SetContainerProperty(ref _refreshToken, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AccessTokenExpiryTime
        {
            get { return _accessTokenExpiryTime; }
            set { base.SetContainerProperty(ref _accessTokenExpiryTime, value); }
        }

        /// <summary>
        /// OAuthAccessTokenResult
        /// </summary>
        public OAuthAccessTokenResult OAuthAccessTokenResult
        {
            get { return _oAuthAccessTokenResult; }
            set { base.SetContainerProperty(ref _oAuthAccessTokenResult, value); }
        }

    }

    /// <summary>
    /// 授权信息
    /// 包括AccessToken，如果过期会重新获取
    /// </summary>
    public class OAuthContainer : BaseContainer<AuthrizationBag>
    {
        const string LockResourceName = "Open.AuthorizerContainer";

        /// <summary>
        /// 注册应用凭证信息，此操作只是注册，不会马上获取Ticket，并将清空之前的Ticket，
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="name">标记Authorizer名称，帮助管理员识别</param>
        private static void Register(string clientId, string clientSecret, string name = null)
        {

            RegisterFunc = () =>
            {
                using (FlushCache.CreateInstance())
                {
                    var bag = new AuthrizationBag()
                    {
                        Name = name,

                        AuthorizerClientId = clientId,
                        AuthorizerClientSecret = clientSecret,
                        OAuthAccessTokenResult = new OAuthAccessTokenResult(),
                        AccessTokenExpiryTime = DateTime.MinValue,
                    };
                    Update(clientId, bag);
                    return bag;
                }
            };
            RegisterFunc();

            //TODO：这里也可以考虑尝试进行授权（会影响速度）
        }


        #region 同步方法


        /// <summary>
        /// 尝试注册
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        private static void TryRegister(string clientId, string clientSecret)
        {
            if (!CheckRegistered(clientSecret))
            {
                Register(clientId, clientSecret);
            }
        }


        #endregion

        #region 异步方法





        #endregion
    }
}
