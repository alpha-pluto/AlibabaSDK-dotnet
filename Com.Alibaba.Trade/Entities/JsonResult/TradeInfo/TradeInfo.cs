/*======================================================================
    Daniel.Zhang
    
    文件名：TradeInfo.cs
    文件功能描述：通用订单模型

======================================================================*/
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 通用订单模型
    /// </summary>
    [Serializable]
    public class TradeInfo
    {

        /// <summary>
        /// 保障条款	
        /// 是否隐私: 否
        /// </summary>
 
        public Com.Alibaba.Trade.Entities.PaymentInfo.GuaranteeTermsInfo guaranteesTerms { get; set; }

        /// <summary>
        /// 国际物流	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.Logistics.InternationalLogisticsInfo internationalLogistics { get; set; }

        /// <summary>
        /// 国内物流	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.Logistics.NativeLogisticsInfo nativeLogistics { get; set; }

        /// <summary>
        /// 商品条目信息	
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.Product.ProductItemInfo> productItems { get; set; }

        /// <summary>
        /// 交易条款	
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.TradeTermsInfo> tradeTerms { get; set; }

        /// <summary>
        /// 订单扩展属性	
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.TradeInfo.KeyValuePair> extAttributes { get; set; }

        /// <summary>
        /// 订单评价信息	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.OrderRateInfo orderRateInfo { get; set; }

        /// <summary>
        /// 发票信息	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.OrderInvoiceModel orderInvoiceInfo { get; set; }

        /// <summary>
        /// 跨境报关信息	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.CustomsDeclaration.CustomsDeclarationForm customs { get; set; }

        /// <summary>
        /// 跨境地址扩展信息	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.Logistics.OverseasExtraAddress overseasExtraAddress { get; set; }

        /// <summary>
        /// 订单基础信息
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.OrderBaseInfo baseInfo { get; set; }

    }
}
