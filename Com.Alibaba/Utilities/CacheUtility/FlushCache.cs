/*======================================================================
    Daniel.Zhang
    
    文件名：FlushCache.cs
    文件功能描述：缓存刷新

======================================================================*/
using System;
using Com.Alibaba.MessageQueue;

namespace Com.Alibaba.CacheUtility
{
    /// <summary>
    /// 缓存刷新
    /// </summary>
    public class FlushCache : IDisposable
    {
        /// <summary>
        /// 是否立即更新到缓存
        /// </summary>
        public bool DoFlush { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="doFlush">是否立即更新到缓存</param>
        public FlushCache(bool doFlush = true)
        {
            DoFlush = doFlush;
        }

        /// <summary>
        /// 释放，开始立即更新所有缓存
        /// </summary>
        public void Dispose()
        {
            if (DoFlush)
            {
                AliMessageQueue.OperateQueue();
            }
        }

        /// <summary>
        /// 创建一个FlushCache实例
        /// </summary>
        /// <param name="doFlush">是否立即更新到缓存</param>
        /// <returns></returns>
        public static FlushCache CreateInstance(bool doFlush = true)
        {
            return new FlushCache(doFlush);
        }

    }
}
