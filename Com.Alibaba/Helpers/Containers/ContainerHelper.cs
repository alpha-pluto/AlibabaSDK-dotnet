/*======================================================================
    Daniel.Zhang
    
    文件名：ContainerHelper.cs
    文件功能描述：Container 的补充方法

======================================================================*/
using System;
using Com.Alibaba.Containers;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// Container 的补充方法
    /// </summary>
    public class ContainerHelper
    {
        /// <summary>
        /// 获取缓存Key（命名空间，形如：Container:Com.Alibaba.Containers.SomethingBag）
        /// </summary>
        /// <returns></returns>
        public static string GetCacheKeyNamespace(Type bagType)
        {
            return string.Format("Container:{0}", bagType);
        }

        /// <summary>
        /// 获取ContainerBag缓存Key，包含命名空间（形如：Container:Com.Alibaba.Containers.SomethingBag:5f31b4a6fd2c332）
        /// </summary>
        /// <param name="bagType"></param>
        /// <param name="shortKey">最简短的Key，比如ClientId，不需要考虑容器前缀</param>
        /// <returns></returns>
        public static string GetItemCacheKey(Type bagType, string shortKey)
        {
            return string.Format("{0}:{1}", GetCacheKeyNamespace(bagType), shortKey);
        }

        /// <summary>
        /// 获取ContainerBag缓存Key，包含命名空间（形如：Container:Com.Alibaba.Containers.SomethingBag:5f31b4a6fd2c332）
        /// </summary>
        /// <param name="bag"></param>
        /// <returns></returns>
        public static string GetItemCacheKey(IBaseContainerBag bag)
        {
            return GetItemCacheKey(bag, bag.Key);
        }

        /// <summary>
        /// 获取ContainerBag缓存Key，包含命名空间（形如：Container:Com.Alibaba.Containers.SomethingBag:5f31b4a6fd2c332）
        /// </summary>
        /// <param name="bag"></param>
        /// <param name="shortKey"></param>
        /// <returns></returns>
        public static string GetItemCacheKey(IBaseContainerBag bag, string shortKey)// where T : IBaseContainerBag
        {
            return GetItemCacheKey(bag.GetType(), shortKey);
        }
    }
}
