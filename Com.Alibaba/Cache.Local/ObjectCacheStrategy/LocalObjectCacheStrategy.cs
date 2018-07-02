/*======================================================================
    Daniel.Zhang
    
    文件名：LocalObjectCacheStrategy.cs
    文件功能描述：本地容器缓存。

======================================================================*/
using System;
using System.Collections.Generic;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 全局静态数据源帮助类
    /// </summary>
    public static class LocalObjectCacheHelper
    {
        /// <summary>
        /// 所有数据集合的列表
        /// </summary>
        internal static IDictionary<string, object> LocalObjectCache { get; set; }

        /// <summary>
        /// 
        /// </summary>
        static LocalObjectCacheHelper()
        {
            LocalObjectCache = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// 本地容器缓存策略
    /// </summary>
    public class LocalObjectCacheStrategy : BaseCacheStrategy, IObjectCacheStrategy
    {
        #region 数据源

        private IDictionary<string, object> _cache = LocalObjectCacheHelper.LocalObjectCache;

        #endregion

        #region 单例

        /// <summary>
        /// LocalCacheStrategy的构造函数
        /// </summary>
        //LocalObjectCacheStrategy()
        //{
        //}

        //静态LocalCacheStrategy
        public static LocalObjectCacheStrategy Instance
        {
            get
            {
                return Nested.instance;//返回Nested类中的静态成员instance
            }
        }

        class Nested
        {
            static Nested()
            {

            }
            //将instance设为一个初始化的LocalCacheStrategy新实例
            internal static readonly LocalObjectCacheStrategy instance = new LocalObjectCacheStrategy();
        }


        #endregion

        #region IObjectCacheStrategy 成员

        /// <summary>
        /// 
        /// </summary>
        public IContainerCacheStrategy ContainerCacheStrategy
        {
            get { return LocalContainerCacheStrategy.Instance; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void InsertToCache(string key, object value)
        {
            if (key == null || value == null)
            {
                return;
            }
            _cache[key] = value;
        }

        /// <summary>
        /// void => virtual void
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isFullKey"></param>
        public virtual void RemoveFromCache(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            _cache.Remove(cacheKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isFullKey"></param>
        /// <returns></returns>
        public object Get(string key, bool isFullKey = false)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            if (!CheckExisted(key, isFullKey))
            {
                return null;
                //InsertToCache(key, new ContainerItemCollection());
            }

            var cacheKey = GetFinalKey(key, isFullKey);
            return _cache[cacheKey];
        }

        //public IDictionary<string, TBag> GetAll<TBag>() where TBag : IBaseContainerBag
        //{
        //    var dic = new Dictionary<string, TBag>();
        //    var cacheList = GetAll();
        //    foreach (var baseContainerBag in cacheList)
        //    {
        //        if (baseContainerBag.Value is TBag)
        //        {
        //            dic[baseContainerBag.Key] = (TBag)baseContainerBag.Value;
        //        }
        //    }
        //    return dic;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetAll()
        {
            return _cache;
        }

        /// <summary>
        /// bool=> virtual bool
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isFullKey"></param>
        /// <returns></returns>
        public virtual bool CheckExisted(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            return _cache.ContainsKey(cacheKey);
        }

        /// <summary>
        /// long => virtual long
        /// </summary>
        /// <returns></returns>
        public virtual long GetCount()
        {
            return _cache.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="isFullKey"></param>
        public void Update(string key, object value, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            _cache[cacheKey] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bag"></param>
        /// <param name="isFullKey"></param>
        public void UpdateContainerBag(string key, object bag, bool isFullKey = false)
        {
            Update(key, bag, isFullKey);
        }

        #endregion

        #region ICacheLock

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="key"></param>
        /// <param name="retryCount"></param>
        /// <param name="retryDelay"></param>
        /// <returns></returns>
        public override ICacheLock BeginCacheLock(string resourceName, string key, int retryCount = 0, TimeSpan retryDelay = new TimeSpan())
        {
            return new LocalCacheLock(this, resourceName, key, retryCount, retryDelay);
        }

        #endregion
    }
}
