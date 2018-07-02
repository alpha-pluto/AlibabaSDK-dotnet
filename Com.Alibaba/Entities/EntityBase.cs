/*======================================================================
    Daniel.Zhang
    
    文件名：EntityBase.cs
    文件功能描述：实体基类

======================================================================*/
using System;

namespace Com.Alibaba.Entities
{
    /// <summary>
    /// 所有自定义实体的基础接口
    /// </summary>
    public interface IEntityBase
    {

    }

    /// <summary>
    /// 生成JSON时忽略NULL对象
    /// </summary>
    public interface IJsonIgnoreNull : IEntityBase
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class JsonIgnoreNull : IJsonIgnoreNull
    {

    }

    /// <summary>
    /// 类中有枚举在序列化的时候，需要转成字符串
    /// </summary>
    public interface IJsonEnumString : IEntityBase
    {
    }
}
