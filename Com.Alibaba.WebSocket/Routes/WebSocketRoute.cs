/*======================================================================
    Daniel.Zhang
    
    文件名：WebSocketRoute.cs
    文件功能描述：WebSocket的Route类（主要为了重写GetVirtualPath，
                  返回null，从而不影响正常的URL生成）

======================================================================*/
using System;
using System.Web.Routing;

namespace Com.Alibaba.WebSocket
{
    /// <summary>
    /// WebSocket的Route类
    /// </summary>
    public class WebSocketRoute : Route
    {
        /// <summary>
        /// WebSocketRoute
        /// </summary>
        /// <param name="url"></param>
        /// <param name="routeHandler"></param>
        public WebSocketRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {

        }

        /// <summary>
        /// GetVirtualPath
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
