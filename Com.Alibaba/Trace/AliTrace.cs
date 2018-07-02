/*======================================================================
    Daniel.Zhang
    
    文件名：AliTrace.cs
    文件功能描述：跟踪日志相关

======================================================================*/

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Com.Alibaba.Exceptions;
using Com.Alibaba.Cache;

namespace Com.Alibaba
{
    /// <summary>
    /// 跟踪日志
    /// </summary>
    public static class AliTrace
    {
        /// <summary>
        /// TraceListener
        /// </summary>
        private static TraceListener _traceListener = null;

        /// <summary>
        /// 统一日志锁名称
        /// </summary>
        const string LockName = "AliTraceLock";

        /// <summary>
        /// Com.Alibaba全局统一的缓存策略
        /// </summary>
        private static IObjectCacheStrategy Cache
        {
            get
            {
                //使用工厂模式或者配置进行动态加载
                return CacheStrategyFactory.GetObjectCacheStrategyInstance();
            }
        }

        /// <summary>
        /// 记录AliException日志时需要执行的任务
        /// </summary>
        public static Action<AliException> OnAliExceptionFunc;

        /// <summary>
        /// 执行所有日志记录操作时执行的任务（发生在Com.Alibaba记录日志之后）
        /// </summary>
        public static Action OnLogFunc;

        /// <summary>
        /// 打开日志开始记录
        /// </summary>
        internal static void Open()
        {
            Close();

            using (Cache.BeginCacheLock(LockName, ""))
            {
                var logDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data", "AliTraceLog");

                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string logFile = Path.Combine(logDir, string.Format("AliTrace-{0}.log", DateTime.Now.ToString("yyyyMMdd")));

                System.IO.TextWriter logWriter = new System.IO.StreamWriter(logFile, true);
                _traceListener = new TextWriterTraceListener(logWriter);
                System.Diagnostics.Trace.Listeners.Add(_traceListener);
                System.Diagnostics.Trace.AutoFlush = true;
            }
        }

        /// <summary>
        /// 关闭日志记录
        /// </summary>
        internal static void Close()
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                if (_traceListener != null && System.Diagnostics.Trace.Listeners.Contains(_traceListener))
                {
                    _traceListener.Close();
                    System.Diagnostics.Trace.Listeners.Remove(_traceListener);
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 统一时间格式
        /// </summary>
        private static void TimeLog()
        {
            Log("[{0}]", DateTime.Now);
        }

        /// <summary>
        /// 当前线程记录
        /// </summary>
        private static void ThreadLog()
        {
            Log("[线程：{0}]", Thread.CurrentThread.GetHashCode());
        }


        /// <summary>
        /// 退回一次缩进
        /// </summary>
        private static void Unindent()
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                System.Diagnostics.Trace.Unindent();
            }
        }

        /// <summary>
        /// 缩进一次
        /// </summary>
        private static void Indent()
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                System.Diagnostics.Trace.Indent();
            }
        }

        /// <summary>
        /// 写入缓存到系统Trace
        /// </summary>
        private static void Flush()
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                System.Diagnostics.Trace.Flush();
            }
        }

        /// <summary>
        /// 开始记录日志
        /// </summary>
        /// <param name="title"></param>
        private static void LogBegin(string title = null)
        {
            Open();
            Log("");
            if (title != null)
            {
                Log("[{0}]", title);
            }
            TimeLog();//记录时间
            ThreadLog();//记录线程
            Indent();
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="messageFormat">日志内容格式</param>
        /// <param name="args">日志内容参数</param>
        public static void Log(string messageFormat, params object[] args)
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                System.Diagnostics.Trace.WriteLine(string.Format(messageFormat, args));
            }
        }

        /// <summary>
        /// 结束日志记录
        /// </summary>
        private static void LogEnd()
        {
            Unindent();
            Flush();
            Close();

            if (OnLogFunc != null)
            {
                try
                {
                    OnLogFunc();
                }
                catch
                {
                }
            }
        }

        #endregion

        #region 日志记录

        /// <summary>
        /// 记录日志（建议使用SendXXLog()方法，以符合统一的记录规则）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Log(string message)
        {
            using (Cache.BeginCacheLock(LockName, ""))
            {
                System.Diagnostics.Trace.WriteLine(message);
            }
        }


        /// <summary>
        /// 自定义日志
        /// </summary>
        /// <param name="typeName">日志类型</param>
        /// <param name="content">日志内容</param>
        public static void SendCustomLog(string typeName, string content)
        {
            if (!Config.IsDebug)
            {
                return;
            }

            LogBegin(string.Format("[[{0}]]", typeName));
            Log(content);
            LogEnd();
        }

        /// <summary>
        /// API请求日志
        /// </summary>
        /// <param name="url"></param>
        /// <param name="returnText"></param>
        public static void SendApiLog(string url, string returnText)
        {
            if (!Config.IsDebug)
            {
                return;
            }

            LogBegin("[[接口调用]]");
            //TODO:从源头加入AppId
            Log("URL：{0}", url);
            Log("Result：\r\n{0}", returnText);
            LogEnd();
        }

        #endregion

        #region AliException 相关日志

        /// <summary>
        /// AliException 日志
        /// </summary>
        /// <param name="ex"></param>
        public static void AliExceptionLog(AliException ex)
        {
            if (!Config.IsDebug)
            {
                return;
            }

            LogBegin("[[AliException]]");
            LogBegin(ex.GetType().Name);
            Log("AppNameAndClientId：{0},{1}", ex.AppName, ex.ClientId);
            Log("Message：{0}", ex.Message);
            Log("StackTrace：{0}", ex.StackTrace);
            if (ex.InnerException != null)
            {
                Log("InnerException：{0}", ex.InnerException.Message);
                Log("InnerException.StackTrace：{0}", ex.InnerException.StackTrace);
            }

            if (OnAliExceptionFunc != null)
            {
                try
                {
                    OnAliExceptionFunc.Invoke(ex);
                }
                catch
                {
                }
            }

            LogEnd();

        }

        /// <summary>
        /// ErrorJsonResultException 日志
        /// </summary>
        /// <param name="ex"></param>
        public static void ErrorJsonResultExceptionLog(ErrorJsonResultException ex)
        {
            if (!Config.IsDebug)
            {
                return;
            }

            LogBegin("[[ErrorJsonResultException]]");
            LogBegin("ErrorJsonResultException");
            Log("AppNameAndClient：{0},{1}", ex.AppName, ex.ClientId);
            Log("URL：{0}", ex.Url);
            Log("errcode：{0}", ex.JsonResult.code);
            Log("errmsg：{0}", ex.JsonResult.message);

            if (OnAliExceptionFunc != null)
            {
                try
                {
                    OnAliExceptionFunc(ex);
                }
                catch
                {
                }
            }

            LogEnd();
        }

        #endregion


    }
}
