/*======================================================================
    Daniel.Zhang
    
    文件名：ThreadUtility.cs
    文件功能描述：跟踪日志相关

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Com.Alibaba.Threads
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThreadUtility
    {
        /// <summary>
        /// 异步线程容器
        /// </summary>
        public static Dictionary<string, Thread> AsynThreadCollection = new Dictionary<string, Thread>();//后台运行线程

        /// <summary>
        /// 注册线程
        /// </summary>
        public static void Register()
        {
            if (AsynThreadCollection.Count == 0)
            {
                {
                    AliMessageQueueThreadUtility aliMessageQueue = new AliMessageQueueThreadUtility();
                    Thread aliMessageQueueThread = new Thread(aliMessageQueue.Run) { Name = "AliMessageQueue" };
                    AsynThreadCollection.Add(aliMessageQueueThread.Name, aliMessageQueueThread);
                }

                AsynThreadCollection.Values.ToList().ForEach(z =>
                {
                    z.IsBackground = true;
                    z.Start();
                });//全部运行

            }
        }
    }
}
