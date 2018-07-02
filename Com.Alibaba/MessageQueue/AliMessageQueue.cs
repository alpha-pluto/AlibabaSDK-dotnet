/*======================================================================
    Daniel.Zhang
    
    文件名：AliMessageQueue.cs
    文件功能描述：消息队列

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;


namespace Com.Alibaba.MessageQueue
{
    /// <summary>
    /// 消息队列
    /// </summary>
    public class AliMessageQueue
    {
        /// <summary>
        /// 队列数据集合
        /// </summary>
        private static Dictionary<string, AliMessageQueueItem> _messageQueueDictionary = new Dictionary<string, AliMessageQueueItem>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 同步执行锁
        /// </summary>
        private static object _messageQueueSyncLock = new object();

        /// <summary>
        /// 立即同步所有缓存执行锁（给OperateQueue()使用）
        /// </summary>
        private static object _flushCacheLock = new object();

        /// <summary>
        /// 生成Key
        /// </summary>
        /// <param name="name">队列应用名称，如“ContainerBag”</param>
        /// <param name="senderType">操作对象类型</param>
        /// <param name="identityKey">对象唯一标识Key</param>
        /// <param name="actionName">操作名称，如“UpdateContainerBag”</param>
        /// <returns></returns>
        public static string GenerateKey(string name, Type senderType, string identityKey, string actionName)
        {
            var key = string.Format("Name@{0}||Type@{1}||Key@{2}||ActionName@{3}", name, senderType, identityKey, actionName);
            return key;
        }

        /// <summary>
        /// 获取当前等待执行的Key
        /// </summary>
        /// <returns></returns>
        public string GetCurrentKey()
        {
            lock (_messageQueueSyncLock)
            {
                return _messageQueueDictionary.Keys.FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取AliMessageQueueItem
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AliMessageQueueItem GetItem(string key)
        {
            lock (_messageQueueSyncLock)
            {
                if (_messageQueueDictionary.ContainsKey(key))
                {
                    return _messageQueueDictionary[key];
                }
                return null;
            }
        }

        /// <summary>
        /// 添加队列成员
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        /// <param name="description"></param>
        public AliMessageQueueItem Add(string key, Action action, string description = null)
        {
            lock (_messageQueueSyncLock)
            {
                var mqItem = new AliMessageQueueItem(key, action, description);
                _messageQueueDictionary[key] = mqItem;
                return mqItem;
            }
        }

        /// <summary>
        /// 移除队列成员
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            lock (_messageQueueSyncLock)
            {
                if (_messageQueueDictionary.ContainsKey(key))
                {
                    _messageQueueDictionary.Remove(key);
                }
            }
        }

        /// <summary>
        /// 操作队列
        /// </summary>
        public static void OperateQueue()
        {
            lock (_flushCacheLock)
            {
                var mq = new AliMessageQueue();
                var key = mq.GetCurrentKey();//获取最新的Key
                while (!string.IsNullOrEmpty(key))
                {
                    var mqItem = mq.GetItem(key);//获取任务项
                    mqItem.Action();//执行
                    mq.Remove(key);//清除
                    key = mq.GetCurrentKey();//获取最新的Key
                }
            }
        }

        /// <summary>
        /// 获得当前队列数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            lock (_messageQueueSyncLock)
            {
                return _messageQueueDictionary.Count;
            }
        }
    }
}
