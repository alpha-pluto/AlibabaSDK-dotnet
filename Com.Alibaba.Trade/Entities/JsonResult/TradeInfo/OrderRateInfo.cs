/*======================================================================
    Daniel.Zhang
    
    文件名：OrderRateInfo.cs
    文件功能描述：订单评价信息

======================================================================*/

using System;
using System.Collections.Generic;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{

    /// <summary>
    /// 订单评价信息
    /// </summary>
    [Serializable]
    public class OrderRateInfo
    {
        /// <summary>
        /// 买家评价状态(4:已评论,5:未评论,6;不需要评论)	
        /// 是否隐私: 否
        /// </summary>
        public int? buyerRateStatus { get; set; }

        /// <summary>
        /// 买家评价状态
        /// </summary>
        public Com.Alibaba.Trade.RateStatus? BuyerRateStatus
        {
            get
            {
                if (buyerRateStatus.HasValue)
                {
                    var buyerRateStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.RateStatus>(buyerRateStatus.Value);
                    return buyerRateStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 买家评价状态
        /// </summary>
        public String BuyerRateStatusDesc
        {
            get
            {
                return BuyerRateStatus?.GetDescription();
            }
        }

        /// <summary>
        /// 卖家评价状态(4:已评论,5:未评论,6;不需要评论)	
        /// 是否隐私: 否
        /// </summary>
        public int? sellerRateStatus { get; set; }

        /// <summary>
        /// 卖家评价状态(4:已评论,5:未评论,6;不需要评论)	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.RateStatus? SellerRateStatus
        {
            get
            {
                if (sellerRateStatus.HasValue)
                {
                    var sellerRateStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.RateStatus>(sellerRateStatus.Value);
                    return sellerRateStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 卖家评价状态
        /// </summary>
        public String SellerRateStatuDesc
        {
            get
            {
                return SellerRateStatus?.GetDescription();
            }
        }

        /// <summary>
        /// 卖家給买家的评价	
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.RateDetail> buyerRateList { get; set; }

        /// <summary>
        /// 买家給卖家的评价
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.RateDetail> sellerRateList { get; set; }
    }
}
