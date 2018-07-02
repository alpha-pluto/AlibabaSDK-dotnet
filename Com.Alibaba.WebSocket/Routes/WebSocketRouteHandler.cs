/*======================================================================
    Daniel.Zhang
    
    文件名：WebSocketRouteHandler.cs
    文件功能描述：WebSocketRouteHandler，处理WebSocket请求

======================================================================*/
using System;
using System.Web;
using System.Web.Routing;

namespace Com.Alibaba.WebSocket
{
    /// <summary>
    /// WebSocketHansler，处理WebSocket请求
    /// </summary>
    public class WebSocketRouteHandler : IRouteHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new WebSocketHandler(requestContext);
        }
    }
}
