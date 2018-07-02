/*======================================================================
    Daniel.Zhang
    
    文件名：CommonJsonSend.cs
    文件功能描述：向需要AccessToken的API发送消息的公共方法

======================================================================*/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Entities;
using Com.Alibaba.Helpers;
using Com.Alibaba.HttpUtility;

namespace Com.Alibaba.Trade.CommonAPIs
{
    /// <summary>
    /// 向需要AccessToken的API发送消息的公共方法
    /// </summary>
    public static class CommonJsonSend
    {
        #region Utility

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static Dictionary<string, object> ArrangeParameter(object data)
        {
            Dictionary<string, object> retDictPara = new Dictionary<string, object>();

            PropertyInfo[] properties = data.GetType().GetProperties();

            foreach (var p in properties)
            {
                var propertyType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                var propertyValue = p.GetValue(data);
                if (propertyValue != null)
                {
                    retDictPara.Add(p.Name, propertyValue);
                }

            }
            return retDictPara;
        }

        #endregion

        #region 同步请求

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static AliJsonResult Send(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            AliJsonResult result = null;

            try
            {
                result = Com.Alibaba.CommonAPIs.CommonJsonSend.Send(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestPolicy"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static T Send<T>(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            T result = default(T);
            try
            {
                var accessToken = requestPolicy.AccessToken;
                var appendixDictPara = new Dictionary<string, object>();
                var url = new StringBuilder();
                url.Append(requestPolicy.SessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestPolicy.RequestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestPolicy.RequestSchema));
                url.Append($"/{requestPolicy.ApiRoot}/{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}");

                var urlPath = $"{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}";

                if (requestPolicy.ValidateSignature)
                {
                    var dictPara = ArrangeParameter(data);

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        dictPara.Add("access_token", accessToken);
                    }

                    byte[] sign = Com.Alibaba.Helpers.SignatureHelper.HmacSha1(urlPath, dictPara, requestPolicy.ClientSecret);
                    String signStr = Com.Alibaba.Helpers.SignatureHelper.ToHex(sign);

                    appendixDictPara.Add("_aop_signature", signStr);
                }

                result = Com.Alibaba.CommonAPIs.CommonJsonSend.Send<T>(accessToken, url.ToString(), data, sendType, timeOut, checkValidationResult, jsonSetting, appendixDictPara);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPolicy"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static string SendRowString(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            string result = string.Empty;
            try
            {
                var accessToken = requestPolicy.AccessToken;
                var appendixDictPara = new Dictionary<string, object>();
                var url = new StringBuilder();
                url.Append(requestPolicy.SessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestPolicy.RequestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestPolicy.RequestSchema));
                url.Append($"/{requestPolicy.ApiRoot}/{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}");

                var urlPath = $"{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}";

                if (requestPolicy.ValidateSignature)
                {
                    var dictPara = ArrangeParameter(data);

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        dictPara.Add("access_token", accessToken);
                    }

                    byte[] sign = Com.Alibaba.Helpers.SignatureHelper.HmacSha1(urlPath, dictPara, requestPolicy.ClientSecret);
                    String signStr = Com.Alibaba.Helpers.SignatureHelper.ToHex(sign);

                    appendixDictPara.Add("_aop_signature", signStr);
                }

                result = Com.Alibaba.CommonAPIs.CommonJsonSend.SendRowString(accessToken, url.ToString(), data, sendType, timeOut, checkValidationResult, jsonSetting, appendixDictPara);

                //Console.WriteLine(" COMMONJSONSEND  "+result);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 发送数据，取得并解析数据（最基本的数据，异步）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<AliJsonResult> SendAsync(
            string accessToken,
            string urlFormat,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT)
        {
            return await Com.Alibaba.CommonAPIs.CommonJsonSend.SendAsync<AliJsonResult>(accessToken, urlFormat, data, sendType, timeOut);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static async Task<AliJsonResult> SendAsync(
            string accessToken,
            string urlFormat,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            return await Com.Alibaba.CommonAPIs.CommonJsonSend.SendAsync<AliJsonResult>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

        /// <summary>
        /// 发送数据，取得并解析数据（泛型  异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestPolicy"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static async Task<T> SendAsync<T>(
            Com.Alibaba.Entities.Request.RequestPolicy requestPolicy,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            var accessToken = requestPolicy.AccessToken;
            var appendixDictPara = new Dictionary<string, object>();
            var url = new StringBuilder();
            url.Append(requestPolicy.SessionType == SessionType.Sandbox ? Com.Alibaba.Config.RequestUriRootSandbox.UriSchemaFill(requestPolicy.RequestSchema) : Com.Alibaba.Config.RequestUriRoot.UriSchemaFill(requestPolicy.RequestSchema));
            url.Append($"/{requestPolicy.ApiRoot}/{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}");

            var urlPath = $"{requestPolicy.Protocol.ToString()}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}";

            if (requestPolicy.ValidateSignature)
            {
                var dictPara = ArrangeParameter(data);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    dictPara.Add("access_token", accessToken);
                }

                byte[] sign = Com.Alibaba.Helpers.SignatureHelper.HmacSha1(urlPath, dictPara, requestPolicy.ClientSecret);
                String signStr = Com.Alibaba.Helpers.SignatureHelper.ToHex(sign);

                appendixDictPara.Add("_aop_signature", signStr);
            }

            return await Com.Alibaba.CommonAPIs.CommonJsonSend.SendAsync<T>(accessToken, url.ToString(), data, sendType, timeOut, checkValidationResult, jsonSetting, appendixDictPara);
        }

        #endregion
    }
}
