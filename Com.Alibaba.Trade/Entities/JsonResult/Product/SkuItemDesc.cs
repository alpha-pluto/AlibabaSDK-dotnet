/*======================================================================
    Daniel.Zhang
    
    文件名：SkuItemDesc.cs
    文件功能描述：SKU属性描述模型

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.Product
{
    /// <summary>
    /// SKU属性描述
    /// </summary>
    [Serializable]
    public class SkuItemDesc
    {
        /// <summary>
        /// 属性名
        /// 是否隐私：否
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 属性值
        /// 是否隐私：否
        /// </summary>
        public String value { get; set; }
    }
}
