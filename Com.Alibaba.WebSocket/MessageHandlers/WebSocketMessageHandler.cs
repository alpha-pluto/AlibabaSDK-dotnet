/*======================================================================
    Daniel.Zhang
    
    文件名：WebSocketMessageHandler.cs
    文件功能描述：WebSocketMessage处理类

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.WebSocket
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class WebSocketMessageHandler
    {
        /// <summary>
        /// 连接时触发事件
        /// </summary>
        /// <param name="webSocketHandler"></param>
        /// <returns></returns>
        public virtual Task OnConnecting(WebSocketHelper webSocketHandler)
        {
            return null;
        }

        /// <summary>
        /// 断开连接时触发事件
        /// </summary>
        /// <param name="webSocketHandler"></param>
        /// <returns></returns>
        public virtual Task OnDisConnected(WebSocketHelper webSocketHandler)
        {
            return null;
        }

        /// <summary>
        /// 收到消息时触发事件
        /// </summary>
        /// <param name="webSocketHandler"></param>
        /// <param name="message">封装好的数据</param>
        /// <param name="originalData">原始数据字符串</param>
        /// <returns></returns>
        public abstract Task OnMessageReceiced(WebSocketHelper webSocketHandler, ReceivedMessage message, string originalData);
    }
}
