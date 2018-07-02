/*======================================================================
    Daniel.Zhang
    
    文件名：BaseContainerBag.cs
    文件功能描述：容器接口中的封装Value（如Ticket、AccessToken等数据集合）。

======================================================================*/

using System;
using System.Runtime.CompilerServices;
using Com.Alibaba.Cache;
using Com.Alibaba.Entities;
using Com.Alibaba.Helpers;
using Com.Alibaba.MessageQueue;

namespace Com.Alibaba.Containers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseContainerBag
    {
        /// <summary>
        /// 用于标记，方便管理
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 缓存键，形如：wx669ef95216eef885，最底层的Key，不考虑命名空间等
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// 当前对象被缓存的时间
        /// </summary>
        DateTime CacheTime { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IBaseContainerBag_ClientId
    {

        /// <summary>
        /// Ali(1688) 上开通的App Name
        /// </summary>
        string AppName { get; set; }

        /// <summary>
        /// Ali(1688)上的 ClientId
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// Ali(1688)客户密钥
        /// </summary>
        string ClientSecret { get; set; }

    }

    /// <summary>
    /// BaseContainer容器中的Value类型
    /// </summary>
    [Serializable]
    public class BaseContainerBag : BindableBase, IBaseContainerBag
    {
        private string _key;
        private string _name;

        /// <summary>
        /// 通常为AppId
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }

            set
            {
                _key = value;
            }
        }

        /// <summary>
        /// 用于标记，方便管理
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 缓存时间，不使用属性变化监听
        /// </summary>
        public DateTime CacheTime { get; set; }

        private void BaseContainerBag_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var containerBag = (IBaseContainerBag)sender;
            var mqKey = AliMessageQueue.GenerateKey("ContainerBag", sender.GetType(), containerBag.Key, "UpdateContainerBag");

            //加入消息队列，每过一段时间进行自动更新，防止属性连续被编辑，短时间内反复更新缓存。
            AliMessageQueue mq = new AliMessageQueue();

            mq.Add(mqKey, () =>
            {
                //var containerCacheStrategy = CacheStrategyFactory.GetContainerCacheStrategyInstance();
                var containerCacheStrategy = CacheStrategyFactory.GetObjectCacheStrategyInstance().ContainerCacheStrategy;
                var itemCacheKey = ContainerHelper.GetItemCacheKey(containerBag);
                containerBag.CacheTime = DateTime.Now;//记录缓存时间

                //cacheKey形如:Container:Com.Alibaba.MP.Containers.AccessTokenBag:wx669ef95216eef885
                containerCacheStrategy.UpdateContainerBag(itemCacheKey, containerBag);
            });
        }

        /// <summary>
        /// 设置Container属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetContainerProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            var result = base.SetProperty(ref storage, value, propertyName);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseContainerBag()
        {
            base.PropertyChanged += BaseContainerBag_PropertyChanged;
        }

    }
}
