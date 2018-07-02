/*======================================================================
    Daniel.Zhang
    
    文件名：IJsonResultCallback.cs
    文件功能描述：JSON数据（序列化）回调接口

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.Entities
{
    /// <summary>
    /// JSON数据（序列化）回调接口
    /// </summary>
    public interface IJsonResultCallback
    {
        /// <summary>
        /// 序列化前回调
        /// </summary>
        void SerializingCallback();

        /// <summary>
        /// 序列化后回调
        /// </summary>
        /// <param name="json"></param>
        void SrializedCallback(string json);

        /// <summary>
        /// 反序列化前回调
        /// </summary>
        /// <param name="json"></param>
        void DeserializingCallback(string json);

        /// <summary>
        /// 反序列化后回调
        /// </summary>
        /// <param name="json"></param>
        void DeserializedCallback(string json);
    }
}
