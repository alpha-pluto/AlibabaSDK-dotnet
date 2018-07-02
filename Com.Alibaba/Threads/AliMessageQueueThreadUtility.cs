/*======================================================================
    Daniel.Zhang
    
    文件名：AliMessageQueueThreadUtility.cs
    文件功能描述：消息队列线程处理

======================================================================*/
using System;
using System.Threading;
using Com.Alibaba.MessageQueue;

namespace Com.Alibaba.Threads
{
    /// <summary>
    /// AliMessageQueue线程自动处理
    /// </summary>
    public class AliMessageQueueThreadUtility
    {
        private readonly int _sleepMilliSeconds;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sleepMilliSeconds"></param>
        public AliMessageQueueThreadUtility(int sleepMilliSeconds = 1000)
        {
            _sleepMilliSeconds = sleepMilliSeconds;
        }

        /// <summary>
        /// 析构函数，将未处理的队列处理掉
        /// </summary>
        ~AliMessageQueueThreadUtility()
        {
            try
            {
                var mq = new AliMessageQueue();
                System.Diagnostics.Trace.WriteLine(string.Format("AliMessageQueueThreadUtility执行析构函数"));
                System.Diagnostics.Trace.WriteLine(string.Format("当前队列数量：{0}", mq.GetCount()));

                AliMessageQueue.OperateQueue();//处理队列
            }
            catch (Exception ex)
            {
                //此处添加日志
                System.Diagnostics.Trace.WriteLine(string.Format("AliMessageQueueThreadUtility执行析构函数错误：{0}", ex.Message));
            }
        }

        /// <summary>
        /// 启动线程轮询
        /// </summary>
        public void Run()
        {
            do
            {
                AliMessageQueue.OperateQueue();
                Thread.Sleep(_sleepMilliSeconds);
            } while (true);
        }
    }
}
