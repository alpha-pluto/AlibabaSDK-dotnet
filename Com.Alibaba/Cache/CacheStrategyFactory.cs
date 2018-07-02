/*======================================================================
    Daniel.Zhang
    
    文件名：CacheStrategyFactory.cs
    文件功能描述：缓存策略工厂。

======================================================================*/
using System;

namespace Com.Alibaba.Cache
{
    /// <summary>
    /// 缓存策略工厂
    /// </summary>
    public class CacheStrategyFactory
    {
        /// <summary>
        /// 
        /// </summary>
        internal static Func<IContainerCacheStrategy> ContainerCacheStrateFunc;

        internal static Func<IObjectCacheStrategy> ObjectCacheStrateFunc;

        /// <summary>
        /// 注册缓存策略
        /// </summary>
        /// <param name="func"></param>
        public static void RegisterObjectCacheStrategy(Func<IObjectCacheStrategy> func)
        {
            ObjectCacheStrateFunc = func;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IObjectCacheStrategy GetObjectCacheStrategyInstance()
        {
            if (ObjectCacheStrateFunc == null)
            {
                //默认状态
                return LocalObjectCacheStrategy.Instance;
            }
            else
            {
                //自定义类型
                var instance = ObjectCacheStrateFunc();
                return instance;
            }
        }
    }
}
