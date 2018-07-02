/*======================================================================
    Daniel.Zhang
    
    文件名：Post.cs
    文件功能描述：以POST方式获取请求结果

======================================================================*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Com.Alibaba.Exceptions;
using Com.Alibaba.Entities;
using System.Reflection;
using Com.Alibaba.Utilities;

namespace Com.Alibaba.HttpUtility
{
    /// <summary>
    /// 
    /// </summary>
    public static class Post
    {
        /// <summary>
        /// 获取Post结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnText"></param>
        /// <returns></returns>
        public static T GetResult<T>(string returnText)
        {
            var t = typeof(T);

            JavaScriptSerializer js = new JavaScriptSerializer();

            //if (returnText.Contains("errcode"))
            //当错误代码不为0时，发生错误
            if (System.Text.RegularExpressions.Regex.IsMatch(returnText, @"(?isx)\x22error_?code\x22[\s\r\n]*\:[\s\r\n]*(\x22?)\w+\1"))
            {
                //可能发生错误
                AliJsonResult errorResult = js.Deserialize<AliJsonResult>(returnText);
                if (errorResult.code != (int)ReturnCode.Success || !string.IsNullOrEmpty(errorResult.errorCode))
                {
                    //发生错误
                    throw new ErrorJsonResultException(
                        string.Format("Post请求发生错误！错误代码：{0}，说明：{1}",
                                      errorResult.errorCode,
                                      errorResult.errorMessage),
                        null, errorResult);
                }
            }

            T result = Activator.CreateInstance<T>();

            if (t.FullName.Equals("Com.Alibaba.Entities.Response.EntityBase"))
            {
                PropertyInfo propertyInfo = t.GetProperty("ReturnObject");
                var retObject = JsonUtility.DynamicDeserialize(returnText);
                propertyInfo.SetValue(result, retObject, null);
    
            }
            else
            {
                result = js.Deserialize<T>(returnText);
            }


            //TODO:加入特殊情况下的回调处理


            return result;
        }


        #region 同步方法

        /// <summary>
        /// 发起Post请求，可上传文件
        /// </summary>
        /// <typeparam name="T">返回数据类型（Json对应的实体）</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="cookieContainer">CookieContainer，如果不需要则设为null</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="fileDictionary"></param>
        /// <param name="postDataDictionary"></param>
        /// <returns></returns>
        public static T PostFileGetJson<T>(string url
            , CookieContainer cookieContainer = null
            , Dictionary<string, string> fileDictionary = null
            , Dictionary<string, string> postDataDictionary = null
            , Encoding encoding = null
            , X509Certificate cer = null
            , int timeOut = Config.TIME_OUT)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                postDataDictionary.FillFormDataStream(ms); //填充formData
                string returnText = RequestUtility.HttpPost(url, cookieContainer, ms, fileDictionary, null, encoding, cer, timeOut);
                var result = GetResult<T>(returnText);
                return result;
            }
        }

        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="T">返回数据类型（Json对应的实体）</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="cookieContainer">CookieContainer，如果不需要则设为null</param>
        /// <param name="fileStream">文件流</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <returns></returns>
        public static T PostGetJson<T>(string url
            , CookieContainer cookieContainer = null
            , Stream fileStream = null
            , Encoding encoding = null
            , X509Certificate cer = null
            , int timeOut = Config.TIME_OUT
            , bool checkValidationResult = false)
        {
            string returnText = RequestUtility.HttpPost(url, cookieContainer, fileStream, null, null, encoding, cer, timeOut, checkValidationResult);

            AliTrace.SendApiLog(url, returnText);

            var result = GetResult<T>(returnText);
            return result;
        }

        /// <summary>
        /// PostGetJson
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="formData"></param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T PostGetJson<T>(string url
            , CookieContainer cookieContainer = null
            , Dictionary<string, string> formData = null
            , Encoding encoding = null
            , X509Certificate cer = null
            , int timeOut = Config.TIME_OUT)
        {
            string returnText = RequestUtility.HttpPost(url, cookieContainer, formData, encoding, cer, timeOut);
            var result = GetResult<T>(returnText);
            return result;
        }

        /// <summary>
        /// 使用Post方法上传数据并下载文件或结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="stream"></param>
        public static void Download(string url, string data, Stream stream)
        {
            WebClient wc = new WebClient();
            var file = wc.UploadData(url, "POST", Encoding.UTF8.GetBytes(string.IsNullOrEmpty(data) ? "" : data));
            foreach (var b in file)
            {
                stream.WriteByte(b);
            }
        }

        #endregion

        #region 异步方法


        /// <summary>
        /// 【异步方法】发起Post请求，可上传文件
        /// </summary>
        /// <typeparam name="T">返回数据类型（Json对应的实体）</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="cookieContainer">CookieContainer，如果不需要则设为null</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <param name="fileDictionary"></param>
        /// <param name="postDataDictionary"></param>
        /// <returns></returns>
        public static async Task<T> PostFileGetJsonAsync<T>(string url
            , CookieContainer cookieContainer = null
            , Dictionary<string, string> fileDictionary = null
            , Dictionary<string, string> postDataDictionary = null
            , Encoding encoding = null
            , X509Certificate cer = null
            , int timeOut = Config.TIME_OUT)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                postDataDictionary.FillFormDataStream(ms); //填充formData
                string returnText = await RequestUtility.HttpPostAsync(url, cookieContainer, ms, fileDictionary, null, encoding, cer, timeOut);
                var result = GetResult<T>(returnText);
                return result;
            }
        }


        /// <summary>
        /// 【异步方法】PostGetJson的异步版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="fileStream"></param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <returns></returns>
        public static async Task<T> PostGetJsonAsync<T>(string url
            , CookieContainer cookieContainer = null
            , Stream fileStream = null
            , Encoding encoding = null
            , X509Certificate cer = null
            , int timeOut = Config.TIME_OUT
            , bool checkValidationResult = false)
        {
            string returnText = await RequestUtility.HttpPostAsync(url, cookieContainer, fileStream, null, null, encoding, cer, timeOut, checkValidationResult);

            AliTrace.SendApiLog(url, returnText);

            var result = GetResult<T>(returnText);
            return result;
        }


        /// <summary>
        /// PostGetJson的异步版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="formData"></param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<T> PostGetJsonAsync<T>(string url, CookieContainer cookieContainer = null, Dictionary<string, string> formData = null, Encoding encoding = null, X509Certificate cer = null, int timeOut = Config.TIME_OUT)
        {
            string returnText = await RequestUtility.HttpPostAsync(url, cookieContainer, formData, encoding, cer, timeOut);
            var result = GetResult<T>(returnText);
            return result;
        }


        /// <summary>
        /// 使用Post方法上传数据并下载文件或结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="stream"></param>
        public static async Task DownloadAsync(string url, string data, Stream stream)
        {
            WebClient wc = new WebClient();

            var fileBytes = await wc.UploadDataTaskAsync(url, "POST", Encoding.UTF8.GetBytes(string.IsNullOrEmpty(data) ? "" : data));
            await stream.WriteAsync(fileBytes, 0, fileBytes.Length);//也可以分段写入
        }

        #endregion
    }
}
