/*======================================================================
    Daniel.Zhang
    
    文件名：Enums.cs
    文件功能描述：枚举类型

======================================================================*/
using System;
using System.ComponentModel;

namespace Com.Alibaba
{
    /// <summary>
    /// 
    /// </summary>
    public enum UriSchema
    {
        /// <summary>
        /// 
        /// </summary>
        http,

        /// <summary>
        /// 
        /// </summary>
        https
    }

    /// <summary>
    /// 会话类型
    /// </summary>
    public enum SessionType
    {
        /// <summary>
        /// 使用沙盒环境，测试用
        /// </summary>
        [Description("沙盒环境，测试用")]
        Sandbox = 0,

        /// <summary>
        /// 正式环境
        /// </summary>
        [Description("正式环境")]
        Prod = 1
    }

    /// <summary>
    /// CommonJsonSend中的http提交类型
    /// </summary>
    public enum CommonJsonSendType
    {
        /// <summary>
        /// 
        /// </summary>
        GET,

        /// <summary>
        /// 
        /// </summary>
        POST
    }

    /// <summary>
    /// 返回码（JSON）
    /// </summary>
    public enum ReturnCode
    {
        /// <summary>
        /// 
        /// </summary>
        Busy = -1,

        /// <summary>
        /// 
        /// </summary>
        Success = 0

    }

    /// <summary>
    /// 请求的协议或是参数传递（返回）的格式
    /// </summary>
    public enum Protocol
    {
        /// <summary>
        /// 
        /// </summary>
        param,

        /// <summary>
        /// 
        /// </summary>
        param2,

        /// <summary>
        /// 
        /// </summary>
        json,

        /// <summary>
        /// 
        /// </summary>
        json2,

        /// <summary>
        /// 
        /// </summary>
        xml,

        /// <summary>
        /// 
        /// </summary>
        xml2,

        /// <summary>
        /// 
        /// </summary>
        http,

        /// <summary>
        /// 
        /// </summary>
        https
    }

    /// <summary>
    /// 获取授权的方式
    /// </summary>
    public enum GrantType
    {
        /// <summary>
        /// 请求参数通过json串的方式传递,默认格式_data_={"key":"value"}
        /// </summary>
        get_token,

        /// <summary>
        /// 刷新token
        /// </summary>
        refresh_token
    }
}
