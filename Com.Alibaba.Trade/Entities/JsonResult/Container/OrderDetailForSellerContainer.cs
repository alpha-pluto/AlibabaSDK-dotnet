/*======================================================================
    Daniel.Zhang
    
    文件名：OrderDetailForSellerContainer.cs
    文件功能描述：订单详情查看(卖家视角) 结果模型

======================================================================*/
using Com.Alibaba.Entities;
using System;
using System.Collections.Generic;

namespace Com.Alibaba.Trade.Entities
{
    /// <summary>
    /// 订单详情查看(卖家视角) 结果模型
    /// </summary>
    [Serializable]
    public class OrderDetailForSellerContainer : AliJsonResult
    {
        /// <summary>
        /// 查询返回结果
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.TradeInfo> result { get; set; }
    }
}
