/*======================================================================
    Daniel.Zhang
    
    文件名：OrderApi.cs
    文件功能描述：订单相关的api

======================================================================*/
using Com.Alibaba.Trade.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Utilities;

namespace Com.Alibaba.Trade.TradeAPIs
{
    /// <summary>
    /// 订单相关的api
    /// </summary>
    public partial class OrderApi
    {
        #region order list 

        #region seller view 

        #region 同步

        /// <summary>
        /// 订单列表查看(卖家视角) 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="reqModelOrderListOnSellerView"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <param name="validateSignature"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Com.Alibaba.Trade.Entities.OrderListForSellerContainer OrderListOnSellerViewRetrieve(
            string clientId,
            string clientSecret,
            string accessToken,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderListForSeller reqModelOrderListOnSellerView,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "com.alibaba.trade",
            string apiName = "alibaba.trade.getSellerOrderList",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https,
            bool validateSignature = true,
            int timeOut = Config.TIME_OUT)
        {
            var requestPolicy = new Com.Alibaba.Entities.Request.RequestPolicy
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken,
                ApiRoot = apiRoot,
                ApiVersion = apiVersion,
                ApiNamespace = apiNamespace,
                ApiName = apiName,
                Protocol = protocol,
                SessionType = sessionType,
                RequestSchema = requestSchema,
                ValidateSignature = validateSignature
            };

            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var result = CommonJsonSend.Send<Com.Alibaba.Trade.Entities.OrderListForSellerContainer>(requestPolicy, reqModelOrderListOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 订单列表查看(卖家视角)
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderListOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Com.Alibaba.Trade.Entities.OrderListForSellerContainer OrderListOnSellerViewRetrieve(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderListForSeller reqModelOrderListOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            return ApiHandlerWrapper.TryCommonApi(reqPoli =>
            {
                var result = CommonJsonSend.Send<Com.Alibaba.Trade.Entities.OrderListForSellerContainer>(requestPolicy, reqModelOrderListOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderListOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Dictionary<string, object> OrderListOnSellerViewRetrieveRowString(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderListForSeller reqModelOrderListOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            var retObject = ApiHandlerWrapper.TryCommonApi(reqPoli =>
             {
                 var result = CommonJsonSend.Send<Com.Alibaba.Entities.Response.EntityBase>(requestPolicy, reqModelOrderListOnSellerView, timeOut: timeOut);
                 return result;

             }, requestPolicy: requestPolicy);

            dynamic coreObject = retObject.ReturnObject;

            var retDict = new Dictionary<string, object>(coreObject._dictionary);
            return retDict;
        }

        #endregion

        #region 异步

        /// <summary>
        /// 订单列表查看(卖家视角) 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="reqModelOrderListOnSellerView"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <param name="validateSignature"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<Com.Alibaba.Trade.Entities.OrderListForSellerContainer> OrderListOnSellerViewAsyncRetrieve(
            string clientId,
            string clientSecret,
            string accessToken,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderListForSeller reqModelOrderListOnSellerView,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "com.alibaba.trade",
            string apiName = "alibaba.trade.getSellerOrderList",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https,
            bool validateSignature = true,
            int timeOut = Config.TIME_OUT)
        {
            var requestPolicy = new Com.Alibaba.Entities.Request.RequestPolicy
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken,
                ApiRoot = apiRoot,
                ApiVersion = apiVersion,
                ApiNamespace = apiNamespace,
                ApiName = apiName,
                Protocol = protocol,
                SessionType = sessionType,
                RequestSchema = requestSchema,
                ValidateSignature = validateSignature
            };

            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var result = CommonJsonSend.SendAsync<Com.Alibaba.Trade.Entities.OrderListForSellerContainer>(requestPolicy, reqModelOrderListOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 订单列表查看(卖家视角)
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderListOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<Com.Alibaba.Trade.Entities.OrderListForSellerContainer> OrderListOnSellerViewAsyncRetrieve(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderListForSeller reqModelOrderListOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            return await ApiHandlerWrapper.TryCommonApiAsync(reqPoli =>
            {
                var result = CommonJsonSend.SendAsync<Com.Alibaba.Trade.Entities.OrderListForSellerContainer>(requestPolicy, reqModelOrderListOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        #endregion

        #endregion

        #endregion

        #region order detail 

        #region seller view

        #region 同步

        /// <summary>
        /// 订单详情查看(卖家视角) 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="reqModelOrderDetailOnSellerView"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <param name="validateSignature"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer OrderListOnSellerViewRetrieve(
            string clientId,
            string clientSecret,
            string accessToken,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderDetailForSeller reqModelOrderDetailOnSellerView,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "com.alibaba.trade",
            string apiName = "alibaba.trade.get.sellerView",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https,
            bool validateSignature = true,
            int timeOut = Config.TIME_OUT)
        {
            var requestPolicy = new Com.Alibaba.Entities.Request.RequestPolicy
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken,
                ApiRoot = apiRoot,
                ApiVersion = apiVersion,
                ApiNamespace = apiNamespace,
                ApiName = apiName,
                Protocol = protocol,
                SessionType = sessionType,
                RequestSchema = requestSchema,
                ValidateSignature = validateSignature
            };

            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var result = CommonJsonSend.Send<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer>(requestPolicy, reqModelOrderDetailOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 订单详情查看(卖家视角)
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderDetailOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer OrderDetailOnSellerViewRetrieve(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderDetailForSeller reqModelOrderDetailOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            return ApiHandlerWrapper.TryCommonApi(reqPoli =>
            {
                var result = CommonJsonSend.Send<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer>(requestPolicy, reqModelOrderDetailOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderDetailOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static Dictionary<string, object> OrderDetailOnSellerViewRetrieveRowString(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderDetailForSeller reqModelOrderDetailOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            var retObject = ApiHandlerWrapper.TryCommonApi(reqPoli =>
            {
                var result = CommonJsonSend.Send<Com.Alibaba.Entities.Response.EntityBase>(requestPolicy, reqModelOrderDetailOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);

            dynamic coreObject = retObject.ReturnObject;

            var retDict = new Dictionary<string, object>(coreObject._dictionary);
            return retDict;

        }

        #endregion

        #region 异步

        /// <summary>
        /// 订单详情查看(卖家视角) 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="reqModelOrderDetailOnSellerView"></param>
        /// <param name="apiRoot"></param>
        /// <param name="apiVersion"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="protocol"></param>
        /// <param name="sessionType"></param>
        /// <param name="requestSchema"></param>
        /// <param name="validateSignature"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer> OrderListOnSellerViewAsyncRetrieve(
            string clientId,
            string clientSecret,
            string accessToken,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderDetailForSeller reqModelOrderDetailOnSellerView,
            string apiRoot = "openapi",
            string apiVersion = "1",
            string apiNamespace = "com.alibaba.trade",
            string apiName = "alibaba.trade.get.sellerView",
            Com.Alibaba.Protocol protocol = Com.Alibaba.Protocol.param2,
            SessionType sessionType = SessionType.Prod,
            UriSchema requestSchema = UriSchema.https,
            bool validateSignature = true,
            int timeOut = Config.TIME_OUT)
        {
            var requestPolicy = new Com.Alibaba.Entities.Request.RequestPolicy
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                AccessToken = accessToken,
                ApiRoot = apiRoot,
                ApiVersion = apiVersion,
                ApiNamespace = apiNamespace,
                ApiName = apiName,
                Protocol = protocol,
                SessionType = sessionType,
                RequestSchema = requestSchema,
                ValidateSignature = validateSignature
            };

            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var result = CommonJsonSend.SendAsync<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer>(requestPolicy, reqModelOrderDetailOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        /// <summary>
        /// 订单详情查看(卖家视角)
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="reqModelOrderDetailOnSellerView"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer> OrderDetailOnSellerViewAsyncRetrieve(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            Com.Alibaba.Trade.Entities.Request.ReqModelOrderDetailForSeller reqModelOrderDetailOnSellerView,
            int timeOut = Config.TIME_OUT)
        {

            return await ApiHandlerWrapper.TryCommonApiAsync(reqPoli =>
            {
                var result = CommonJsonSend.SendAsync<Com.Alibaba.Trade.Entities.OrderDetailForSellerContainer>(requestPolicy, reqModelOrderDetailOnSellerView, timeOut: timeOut);
                return result;

            }, requestPolicy: requestPolicy);
        }

        #endregion

        #endregion

        #endregion

    }
}
