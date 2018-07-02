/*======================================================================
    Daniel.Zhang
    
    文件名：ReceivedMessage.cs
    文件功能描述：接收消息类

======================================================================*/
using System;

namespace Com.Alibaba.WebSocket
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ReceivedMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FormId { get; set; }
    }
}
