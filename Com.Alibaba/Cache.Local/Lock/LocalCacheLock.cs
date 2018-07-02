/*======================================================================
    Daniel.Zhang
    
    文件名：IBaseCacheStrategy.cs
    文件功能描述：本地锁

======================================================================*/
using System;
using System.Collections.Generic;
using System.Threading;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 本地锁
    /// </summary>
    public class LocalCacheLock : BaseCacheLock
    {
        private IBaseCacheStrategy _localStrategy;

        private static Dictionary<string, object> LockPool = new Dictionary<string, object>();

        private static Random _rnd = new Random();

        private static object lookPoolLock = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="resourceName"></param>
        /// <param name="key"></param>
        /// <param name="retryCount"></param>
        /// <param name="retryDelay"></param>
        public LocalCacheLock(IBaseCacheStrategy strategy
            , string resourceName
            , string key
            , int? retryCount = null,
            TimeSpan? retryDelay = null) : base(strategy, resourceName, key, retryCount ?? 0, retryDelay ?? TimeSpan.FromMilliseconds(10))
        {
            _localStrategy = strategy;
            LockNow();//立即等待并抢夺锁
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public override bool Lock(string resourceName)
        {
            return Lock(resourceName, 99999/*暂时不限制*/, new TimeSpan(0, 0, 0, 0, 10));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="retryCount"></param>
        /// <param name="retryDelay"></param>
        /// <returns></returns>
        public override bool Lock(string resourceName, int retryCount, TimeSpan retryDelay)
        {
            int currentRetry = 0;
            int maxRetryDelay = (int)retryDelay.TotalMilliseconds;
            while (currentRetry++ < retryCount)
            {
                #region 尝试并获得锁

                var getLock = false;
                try
                {
                    lock (lookPoolLock)
                    {
                        if (LockPool.ContainsKey(resourceName))
                        {
                            getLock = false;//已被别人锁住，没有取得锁
                        }
                        else
                        {
                            LockPool.Add(resourceName, new object());//创建锁
                            getLock = true;//取得锁
                        }
                    }
                }
                catch (Exception ex)
                {
                    AliTrace.Log("本地同步锁发生异常：" + ex.Message); ;
                    getLock = false;
                }

                #endregion

                if (getLock)
                {
                    return true;//取得锁
                }
                Thread.Sleep(_rnd.Next(maxRetryDelay));
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        public override void UnLock(string resourceName)
        {
            lock (lookPoolLock)
            {
                LockPool.Remove(resourceName);
            }
        }
    }
}
