/*======================================================================
    Daniel.Zhang
    
    文件名：OrderListForSellerContainer.cs
    文件功能描述：订单列表查看(卖家视角) 结果模型

======================================================================*/
using Com.Alibaba.Entities;
using System;
using System.Collections.Generic;

namespace Com.Alibaba.Trade.Entities
{
    /// <summary>
    /// 订单列表查看(卖家视角) 
    /// 结果模型
    /// </summary>
    [Serializable]
    public class OrderListForSellerContainer : AliJsonResult
    {
        /// <summary>
        /// 查询返回结果
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.TradeInfo> result { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long? totalRecord { get; set; }
    }
}
