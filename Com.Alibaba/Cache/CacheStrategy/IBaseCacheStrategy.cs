/*======================================================================
    Daniel.Zhang
    
    文件名：IBaseCacheStrategy.cs
    文件功能描述：底层缓存策略接口

======================================================================*/
using System;
using System.Collections.Generic;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 底层缓存策略接口
    /// </summary>
    public interface IBaseCacheStrategy
    {
        /// <summary>
        /// 创建一个（分布）锁
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <param name="key">Key标识</param>
        /// <param name="retryCount">重试次数</param>
        /// <param name="retryDelay">重试延时</param>
        /// <returns></returns>
        ICacheLock BeginCacheLock(string resourceName, string key, int retryCount = 0, TimeSpan retryDelay = new TimeSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IBaseCacheStrategy<Tkey, TValue> : IBaseCacheStrategy
    {
        /// <summary>
        /// 获取缓存中最终的键，如Container建议格式： return String.Format("{0}:{1}", "ComAlibabaContainer", key);
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        string GetFinalKey(string key, bool isFullKey = false);

        /// <summary>
        /// 添加指定ID的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        void InsertToCache(Tkey key, TValue value);

        /// <summary>
        /// 移除指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        void RemoveFromCache(Tkey key, bool isFullKey = false);

        /// <summary>
        /// 返回指定缓存键的对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        TValue Get(Tkey key, bool isFullKey = false);

        /// <summary>
        /// 获取所有缓存信息集合
        /// </summary>
        /// <returns></returns>
        IDictionary<Tkey, TValue> GetAll();

        /// <summary>
        /// 检查是否存在Key及对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        /// <returns></returns>
        bool CheckExisted(Tkey key, bool isFullKey = false);

        /// <summary>
        /// 获取缓存集合总数（注意：每个缓存框架的计数对象不一定一致！）
        /// </summary>
        /// <returns></returns>
        long GetCount();

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        void Update(Tkey key, TValue value, bool isFullKey = false);
    }
}


