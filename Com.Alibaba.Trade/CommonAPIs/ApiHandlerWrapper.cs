/*======================================================================
    Daniel.Zhang
    
    文件名：ApiHandlerWrapper.cs
    文件功能描述：使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试

======================================================================*/
using System;
using System.Threading.Tasks;
using Com.Alibaba.Entities;
using Com.Alibaba.Exceptions;
using Com.Alibaba.Trade.Containers;
namespace Com.Alibaba.Trade.CommonAPIs
{
    /// <summary>
    /// 针对AccessToken无效或过期的自动处理类
    /// </summary>
    public static class ApiHandlerWrapper
    {
        #region 同步方法

        /// <summary>
        /// 使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试。
        /// 使用此方法之前必须使用AccessTokenContainer.Register(_clientId, _clientSecret); 
        /// 
        /// AccessToken 如果为null，则自动取已经注册的第一个clientId/appSecret来信息获取AccessToken。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <param name="requestPolicy"></param>
        /// <param name="retryIfFaild">请保留默认值</param>
        /// <returns></returns>
        public static T TryCommonApi<T>(
            Func<Com.Alibaba.Entities.Request.RequestPolicy, T> fun,
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            bool retryIfFaild = true) where T : AliJsonResult
        {

            if (string.IsNullOrEmpty(requestPolicy.ClientId))
            {
                requestPolicy.ClientId = AccessTokenContainer.GetFirstOrDefaultClientId();
                if (string.IsNullOrEmpty(requestPolicy.ClientId))
                {
                    throw new UnRegisterClientIdException(null, "尚无已经注册的ClientId，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！");
                }
            }
            else
            {
                if (!AccessTokenContainer.CheckRegistered(requestPolicy.ClientId))
                {
                    throw new UnRegisterClientIdException(requestPolicy.ClientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", requestPolicy.ClientId));
                }
            }


            T result = null;

            try
            {

                if (string.IsNullOrEmpty(requestPolicy.AccessToken))
                {
                    var accessTokenResult = AccessTokenContainer.GetAccessTokenResult(requestPolicy.ClientId, false, requestPolicy.SessionType, requestPolicy.RequestSchema);
                    requestPolicy.AccessToken = accessTokenResult.access_token;
                }
                result = fun(requestPolicy);

            }
            catch (ErrorJsonResultException ex)
            {
                //Console.WriteLine($"clientId:{requestPolicy.ClientId},code:{ex.JsonResult.code},errorCode:{ex.JsonResult.errorCode}");
                if (retryIfFaild
                    && !string.IsNullOrEmpty(requestPolicy.ClientId)
                    && (ex.JsonResult.code > 0 || !string.IsNullOrEmpty(ex.JsonResult.errorCode)))
                {

                    //尝试重新验证
                    //var accessTokenResult = AccessTokenContainer.GetAccessTokenResult(clientId, true);
                    var accessTokenResult = AccessTokenContainer.RefreshAccessTokenResult(
                        requestPolicy.ClientId,
                        requestPolicy.SessionType,
                        requestPolicy.RequestSchema);

                    //强制获取并刷新最新的AccessToken
                    requestPolicy.AccessToken = accessTokenResult.access_token;
                    //Console.WriteLine($"refresh access token {requestPolicy.AccessToken}");
                    result = TryCommonApi(fun, requestPolicy, false);
                }
                else
                {
                    ex.ClientId = requestPolicy.ClientId;
                    throw;
                }
            }
            catch (AliException ex)
            {
                ex.ClientId = requestPolicy.ClientId;
                throw;
            }

            return result;
        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 异步方法】使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试。
        /// 使用此方法之前必须使用AccessTokenContainer.Register(_clientId, _clientSecret);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <param name="requestPolicy"></param>
        /// <param name="retryIfFaild"></param>
        /// <returns></returns>
        public static async Task<T> TryCommonApiAsync<T>(
            Func<Com.Alibaba.Entities.Request.RequestPolicy, Task<T>> fun,
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            bool retryIfFaild = true) where T : AliJsonResult
        {
            if (string.IsNullOrEmpty(requestPolicy.ClientId))
            {
                requestPolicy.ClientId = AccessTokenContainer.GetFirstOrDefaultClientId();
                if (string.IsNullOrEmpty(requestPolicy.ClientId))
                {
                    throw new UnRegisterClientIdException(null, "尚无已经注册的ClientId，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！");
                }
            }
            else
            {
                if (!AccessTokenContainer.CheckRegistered(requestPolicy.ClientId))
                {
                    throw new UnRegisterClientIdException(requestPolicy.ClientId,
                        string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！",
                            requestPolicy.ClientId));
                }
            }



            Task<T> result = null;

            try
            {
                if (string.IsNullOrEmpty(requestPolicy.AccessToken))
                {
                    var accessTokenResult = await AccessTokenContainer.GetAccessTokenResultAsync(requestPolicy.ClientId, false, requestPolicy.SessionType, requestPolicy.RequestSchema);
                    requestPolicy.AccessToken = accessTokenResult.access_token;
                }
                result = fun(requestPolicy);
            }
            catch (ErrorJsonResultException ex)
            {
                if (retryIfFaild
                    && !string.IsNullOrEmpty(requestPolicy.ClientId)
                    && (ex.JsonResult.code > 0 || !string.IsNullOrEmpty(ex.JsonResult.errorCode)))
                {
                    //尝试重新验证
                    //var accessTokenResult = AccessTokenContainer.GetAccessTokenResultAsync(clientId, true, sessionType);
                    var accessTokenResult = AccessTokenContainer.RefreshAccessTokenResultAsync(requestPolicy.ClientId, requestPolicy.SessionType, requestPolicy.RequestSchema);
                    //强制获取并刷新最新的AccessToken
                    requestPolicy.AccessToken = accessTokenResult.Result.access_token;
                    result = TryCommonApiAsync(fun, requestPolicy, false);
                }
                else
                {
                    throw;
                }
            }

            return await result;
        }

        #endregion

    }
}
