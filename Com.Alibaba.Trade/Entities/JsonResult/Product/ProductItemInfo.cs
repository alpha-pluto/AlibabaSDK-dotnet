/*======================================================================
    Daniel.Zhang
    
    文件名：ProductItemInfo.cs
    文件功能描述：商品条目模型

======================================================================*/
using System;
using System.Collections.Generic;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.Trade.Entities.Product
{
    /// <summary>
    /// 商品条目模型
    /// </summary>
    [Serializable]
    public class ProductItemInfo
    {
        /// <summary>
        /// 指定单品货号，国际站无需关注。
        /// 该字段不一定有值，仅仅在下单时才会把货号记录(如果卖家设置了单品货号的话)。
        /// 别的订单类型的货号只能通过商品接口去获取。
        /// 请注意：通过商品接口获取时的货号和下单时的货号可能不一致，因为下单完成后卖家可能修改商品信息，改变了货号。	
        /// 是否隐私: 否
        /// </summary>
        public String cargoNumber { get; set; }

        /// <summary>
        /// 描述,1688无此信息	
        /// 是否隐私: 否
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// 实付金额，单位为元	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? itemAmount { get; set; }

        /// <summary>
        /// 商品名称	
        /// 是否隐私: 否
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 原始单价，以元为单位	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? price { get; set; }

        /// <summary>
        /// 产品ID（非在线产品为空）	
        /// 是否隐私: 否
        /// </summary>
        public long? productID { get; set; }

        /// <summary>
        /// 商品图片url	
        /// 是否隐私: 否
        /// </summary>
        public List<String> productImgUrl { get; set; }

        /// <summary>
        /// 产品快照url，交易订单产生时会自动记录下当时的商品快照，供后续纠纷时参考	
        /// 是否隐私: 否
        /// </summary>
        public String productSnapshotUrl { get; set; }

        /// <summary>
        /// 以unit为单位的数量，例如多少个、多少件、多少箱、多少吨	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? quantity { get; set; }

        /// <summary>
        /// 退款金额，单位为元	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? refund { get; set; }

        /// <summary>
        /// skuID	
        /// 是否隐私: 否
        /// </summary>
        public long? skuID { get; set; }

        /// <summary>
        /// 排序字段，商品列表按此字段进行排序，从0开始，1688不提供	
        /// 是否隐私: 否
        /// </summary>
        public int? sort { get; set; }

        /// <summary>
        /// 子订单状态	
        /// 是否隐私: 否
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// 商品明细条目ID	
        /// 是否隐私: 否
        /// </summary>
        public long? subItemID { get; set; }

        /// <summary>
        /// 类型，国际站使用，供卖家标注商品所属类型	
        /// 是否隐私: 否
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// 售卖单位	例如：个、件、箱、吨	
        /// 是否隐私: 否
        /// </summary>
        public String unit { get; set; }

        /// <summary>
        /// 重量	按重量单位计算的重量，例如：100	
        /// 是否隐私: 否
        /// </summary>
        public String weight { get; set; }

        /// <summary>
        /// 重量单位	例如：g，kg，t	
        /// 是否隐私: 否
        /// </summary>
        public String weightUnit { get; set; }

        /// <summary>
        /// 保障条款，此字段仅针对1688	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.PaymentInfo.GuaranteeTermsInfo guaranteesTerms { get; set; }

        /// <summary>
        /// 指定商品货号，该字段不一定有值，在下单时才会把货号记录。
        /// 别的订单类型的货号只能通过商品接口去获取。
        /// 请注意：通过商品接口获取时的货号和下单时的货号可能不一致，因为下单完成后卖家可能修改商品信息，改变了货号。
        /// 该字段和cargoNUmber的区别是：该字段是定义在商品级别上的货号，cargoNUmber是定义在单品级别的货号	
        /// 是否隐私: 否
        /// </summary>
        public String productCargoNumber { get; set; }

        /// <summary>
        /// 	
        /// 是否隐私: 否
        /// </summary>
        public List<SkuItemDesc> skuInfos { get; set; }

        /// <summary>
        /// 订单明细涨价或降价的金额
        /// 否隐私: 否
        /// </summary>
        public long? entryDiscount { get; set; }

        /// <summary>
        /// 订单销售属性ID	
        /// 是否隐私: 否
        /// </summary>
        public String specId { get; set; }

        /// <summary>
        /// 以unit为单位的quantity精度系数，值为10的幂次，例如:quantityFactor=1000,unit=吨，那么quantity的最小精度为0.001吨	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? quantityFactor { get; set; }

        /// <summary>
        /// 子订单状态描述	
        /// 是否隐私: 否
        /// </summary>
        public String statusStr { get; set; }

        /// <summary>
        /// WAIT_SELLER_AGREE 等待卖家同意 
        /// REFUND_SUCCESS 退款成功 
        /// REFUND_CLOSED 退款关闭 
        /// WAIT_BUYER_MODIFY 待买家修改 
        /// WAIT_BUYER_SEND 等待买家退货 
        /// WAIT_SELLER_RECEIVE 等待卖家确认收货	
        /// 
        /// 是否隐私: 否
        /// </summary>
        public String refundStatus { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public Com.Alibaba.Trade.RefundStatus? RefundStatus
        {
            get
            {
                if (!string.IsNullOrEmpty(refundStatus))
                {
                    var refundStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.RefundStatus>(refundStatus);
                    return refundStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 退款状态 描述
        /// </summary>
        public String RefundStatusDesc
        {
            get
            {
                if (RefundStatus.HasValue)
                {
                    return RefundStatus?.GetDescription();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 关闭原因	
        /// 是否隐私: 否
        /// </summary>
        public String closeReason { get; set; }

        /// <summary>
        /// 1 未发货 
        /// 2 已发货 
        /// 3 已收货 
        /// 4 已经退货 
        /// 5 部分发货 
        /// 8 还未创建物流订单	
        /// 是否隐私: 否
        /// </summary>
        public int? logisticsStatus { get; set; }

        /// <summary>
        /// 物流状态
        /// </summary>
        public Com.Alibaba.Trade.LogisticsStatus? LogisticsStatus
        {
            get
            {
                if (logisticsStatus.HasValue)
                {
                    var logisticsStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.LogisticsStatus>(logisticsStatus.Value);
                    return logisticsStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 物流状态
        /// </summary>
        public String LogisticsStatusDesc
        {
            get
            {
                if (LogisticsStatus.HasValue)
                {
                    var logisticsStatusDesc = LogisticsStatus.Value.GetDescription();
                    return logisticsStatusDesc;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 创建时间	
        /// 是否隐私: 否
        /// </summary>
        public String gmtCreate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GmtCreate
        {
            get
            {
                if (!string.IsNullOrEmpty(gmtCreate))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(gmtCreate);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 修改时间	
        /// 是否隐私: 否
        /// </summary>
        public String gmtModified { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? GmtModified
        {
            get
            {
                if (!string.IsNullOrEmpty(gmtModified))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(gmtModified);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 完成时间	
        /// 是否隐私: 否
        /// </summary>
        public String gmtCompleted { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? GmtCompleted
        {
            get
            {
                if (!string.IsNullOrEmpty(gmtCompleted))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(gmtCompleted);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 支付超时时间
        /// 是否隐私: 否
        /// </summary>
        public String gmtPayExpireTime { get; set; }

        /// <summary>
        /// 退款Id
        /// 是否隐私: 否
        /// </summary>
        public String refundId { get; set; }

        /// <summary>
        /// 商品明细条目ID
        /// 是否隐私: 否
        /// </summary>
        public String subItemIDString { get; set; }

    }
}
