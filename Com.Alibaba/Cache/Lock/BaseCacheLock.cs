/*======================================================================
    Daniel.Zhang
    
    文件名：BaseCacheLock.cs
    文件功能描述：缓存同步锁基类

======================================================================*/
using System;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 缓存同步锁基类
    /// </summary>
    public abstract class BaseCacheLock : ICacheLock
    {
        #region protected members

        /// <summary>
        /// 
        /// </summary>
        protected string _resourceName;

        /// <summary>
        /// 
        /// </summary>
        protected IBaseCacheStrategy _cacheStrategy;

        /// <summary>
        /// 
        /// </summary>
        protected int _retryCount;

        /// <summary>
        /// 
        /// </summary>
        protected TimeSpan _retryDelay;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stategy"></param>
        /// <param name="resourceName"></param>
        /// <param name="key"></param>
        /// <param name="retryCount"></param>
        /// <param name="retryDelay"></param>
        protected BaseCacheLock(IBaseCacheStrategy stategy, string resourceName, string key, int retryCount, TimeSpan retryDelay)
        {
            _cacheStrategy = stategy;
            _resourceName = resourceName + key;//加上Key可以针对某个AppId加锁
            _retryCount = retryCount;
            _retryDelay = retryDelay;
        }

        /// <summary>
        /// 立即开始锁定，需要在子类的构造函数中执行
        /// </summary>
        /// <returns></returns>
        protected ICacheLock LockNow()
        {
            if (_retryCount != 0 && _retryDelay.Ticks != 0)
            {
                LockSuccessful = Lock(_resourceName, _retryCount, _retryDelay);
            }
            else
            {
                LockSuccessful = Lock(_resourceName);
            }
            return this;
        }

        #endregion

        #region interface

        /// <summary>
        /// 是否成功获得锁
        /// </summary>
        public bool LockSuccessful { get; set; }

        /// <summary>
        /// 开始锁
        /// </summary>
        /// <param name="resourceName">资源名称，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]</param>
        public abstract bool Lock(string resourceName);

        /// <summary>
        /// 开始锁，并设置重试条件
        /// </summary>
        /// <param name="resourceName">资源名称，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]</param>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryDelay">每次重试延时</param>
        /// <returns></returns>
        public abstract bool Lock(string resourceName, int retryCount, TimeSpan retryDelay);

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="resourceName">需要释放锁的 Key，即锁的标识，实际值为IBaseCacheStrategy接口中的 BeginCacheLock() 方法中的 [resourceName.key]资源名称，和 Lock() 方法中的 resourceName 对应</param>
        public abstract void UnLock(string resourceName);

        #endregion

        #region dispose

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            UnLock(_resourceName);
        }

        #endregion
    }
}
