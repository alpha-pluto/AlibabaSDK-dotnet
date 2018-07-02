/*======================================================================
    Daniel.Zhang
    
    文件名：KeyValuePair.cs
    文件功能描述：订单附加属性键值对 模型

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 订单附加属性键值对
    /// </summary>
    [Serializable]
    public class KeyValuePair
    {
        /// <summary>
        /// 键	
        /// 是否隐私: 否
        /// </summary>
        public String key { get; set; }

        /// <summary>
        /// 值	
        /// 是否隐私: 否
        /// </summary>
        public String value { get; set; }

        /// <summary>
        /// 描述
        /// 是否隐私: 否
        /// </summary>
        public String description { get; set; }
    }
}
