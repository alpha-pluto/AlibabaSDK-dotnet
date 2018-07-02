/*======================================================================
    Daniel.Zhang
    
    文件名：AliJsonResult.cs
    文件功能描述：JSON返回结果基类（用于API的接口调用等）

======================================================================*/
using System;

namespace Com.Alibaba.Entities
{
    /// <summary>
    /// 所有JSON格式返回值的API返回结果中分页结果接口
    /// </summary>
    public interface IJsonPagingResult
    {
        /// <summary>
        /// 
        /// </summary>
        string next { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string previous { get; set; }
    }

    /// <summary>
    /// 所有JSON格式返回值的API返回结果接口
    /// </summary>
    public interface IJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        string error { get; set; }


        /// <summary>
        /// 错误码
        /// </summary>
        string errorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        string errorMessage { get; set; }

        #region webexception

        /// <summary>
        /// 请求标识
        /// </summary>
        string request_id { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        string error_description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string error_code { get; set; }

        /// <summary>
        /// 异常描述 
        /// </summary>
        string exception { get; set; }

        #endregion
    }

    /// <summary>
    /// JSON返回结果
    /// </summary>
    [Serializable]
    public class AliJsonResult : IJsonResult
    {

        private string _code;

        private string _error;

        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int code
        {
            get
            {
                int c = -1;
                int.TryParse(_code, out c);
                return c;
            }
            set { _code = Convert.ToString(value); }
        }

        //public virtual object data { get; set; }

        /// <summary>
        /// 错误代码或是简述
        /// </summary>
        public string error
        {
            get { return _error; }
            set { _error = value; }
        }


        /// <summary>
        /// 错误码
        /// </summary>
        public string errorCode
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errorMessage
        {
            get { return _error; }
            set { _error = value; }
        }

        #region webexception

        /// <summary>
        /// 请求标识
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string error_description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string error_code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// 异常描述 
        /// </summary>
        public string exception { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("AliJsonResult:{{message:'{0}',code:'{1}', errorCode:'{2}',errorMessage:'{3}'}}", message, code, errorCode, errorMessage);
        }

    }

    /// <summary>
    /// JSON分页结果
    /// </summary>
    [Serializable]
    public class Paging : IJsonPagingResult
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string next { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string previous { get; set; }
    }
}
