/*======================================================================
    Daniel.Zhang
    
    文件名：CommonJsonSend.cs
    文件功能描述：向需要AccessToken的API发送消息的公共方法

======================================================================*/
using System;
using Com.Alibaba.Entities;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.Open.CommonAPIs
{
    /// <summary>
    /// 向需要AccessToken的API发送消息的公共方法
    /// </summary>
    public static class CommonJsonSend
    {
        /// <summary>
        /// 向需要AccessToken的API发送消息的公共方法
        /// </summary>
        /// <param name="accessToken">这里的AccessToken是通用接口的AccessToken，非OAuth的。如果不需要，可以为null，此时urlFormat不要提供{0}参数</param>
        /// <param name="urlFormat"></param>
        /// <param name="data">如果是Get方式，可以为null</param>
        /// <param name="sendType"></param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        [Obsolete("建议使用Com.Alibaba.CommonAPIs.CommonJsonSend.Send()方法")]
        public static AliJsonResult Send(
            string accessToken,
            string urlFormat,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            return Com.Alibaba.CommonAPIs.CommonJsonSend.Send(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

        /// <summary>
        /// 向需要AccessToken的API发送消息的公共方法
        /// </summary>
        /// <param name="accessToken">这里的AccessToken是通用接口的AccessToken，非OAuth的。如果不需要，可以为null，此时urlFormat不要提供{0}参数</param>
        /// <param name="urlFormat">用accessToken参数填充{0}</param>
        /// <param name="data">如果是Get方式，可以为null</param>
        /// <param name="sendType"></param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        [Obsolete("建议使用Com.Alibaba.CommonAPIs.CommonJsonSend.Send()方法")]
        public static T Send<T>(
            string accessToken,
            string urlFormat,
            object data,
            CommonJsonSendType sendType = CommonJsonSendType.POST,
            int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false,
            JsonSetting jsonSetting = null)
        {
            return Com.Alibaba.CommonAPIs.CommonJsonSend.Send<T>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

    }
}
