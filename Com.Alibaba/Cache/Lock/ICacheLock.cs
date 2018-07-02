/*======================================================================
    Daniel.Zhang
    
    文件名：ICacheLock.cs
    文件功能描述：缓存锁接口

======================================================================*/
using System;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 缓存锁接口
    /// </summary>
    public interface ICacheLock : IDisposable
    {
        /// <summary>
        /// 是否成功获得锁
        /// </summary>
        bool LockSuccessful { get; set; }

        /// <summary>
        /// 开始锁
        /// </summary>
        /// <param name="resourceName">资源名称，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]</param>
        bool Lock(string resourceName);

        /// <summary>
        /// 开始锁，并设置重试条件
        /// </summary>
        /// <param name="resourceName">资源名称，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]</param>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryDelay">每次重试延时</param>
        /// <returns></returns>
        bool Lock(string resourceName, int retryCount, TimeSpan retryDelay);

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="resourceName">需要释放锁的 Key，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]资源名称，和 Lock() 方法中的 resourceName 对应</param>
        void UnLock(string resourceName);

    }
}
