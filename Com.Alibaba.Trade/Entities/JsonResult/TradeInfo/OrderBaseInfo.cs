/*======================================================================
    Daniel.Zhang
    
    文件名：OrderBaseInfo.cs
    文件功能描述：订单基础信息

======================================================================*/
using Com.Alibaba.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 订单基础信息
    /// </summary>
    [Serializable]
    public class OrderBaseInfo
    {
        /// <summary>
        /// 完全发货时间	
        /// 是否隐私: 否
        /// </summary>
        public String allDeliveredTime { get; set; }

        /// <summary>
        /// 完全发货时间
        /// </summary>
        public DateTime? AllDeliveredTime
        {
            get
            {
                if (!string.IsNullOrEmpty(allDeliveredTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(allDeliveredTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 业务类型。
        /// 国际站：
        /// ta(信保),
        /// wholesale(在线批发)。 
        /// 
        /// 中文站：
        /// 普通订单类型 = "cn"; 
        /// 大额批发订单类型 = "ws"; 
        /// 普通拿样订单类型 = "yp"; 
        /// 一分钱拿样订单类型 = "yf"; 
        /// 倒批(限时折扣)订单类型 = "fs"; 
        /// 加工定制订单类型 = "cz"; 
        /// 协议采购订单类型 = "ag"; 
        /// 伙拼订单类型 = "hp"; 
        /// 供销订单类型 = "supply"; 
        /// 淘工厂订单 = "factory"; 
        /// 快订下单 = "quick"; 
        /// 享拼订单 = "xiangpin"; 
        /// 当面付 = "f2f"; 
        /// 存样服务 = "cyfw"; 
        /// 代销订单 = "sp"; 
        /// 微供订单 = "wg";
        /// 零售通 = "lst";	
        /// 是否隐私: 否
        /// </summary>
        public String businessType { get; set; }

        /// <summary>
        /// 业务类型。
        /// 国际站：
        /// ta(信保),
        /// wholesale(在线批发)。 
        /// 
        /// 中文站：
        /// 普通订单类型 = "cn"; 
        /// 大额批发订单类型 = "ws"; 
        /// 普通拿样订单类型 = "yp"; 
        /// 一分钱拿样订单类型 = "yf"; 
        /// 倒批(限时折扣)订单类型 = "fs"; 
        /// 加工定制订单类型 = "cz"; 
        /// 协议采购订单类型 = "ag"; 
        /// 伙拼订单类型 = "hp"; 
        /// 供销订单类型 = "supply"; 
        /// 淘工厂订单 = "factory"; 
        /// 快订下单 = "quick"; 
        /// 享拼订单 = "xiangpin"; 
        /// 当面付 = "f2f"; 
        /// 存样服务 = "cyfw"; 
        /// 代销订单 = "sp"; 
        /// 微供订单 = "wg";
        /// 零售通 = "lst";	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.BizType? BusinessType
        {
            get
            {
                if (!string.IsNullOrEmpty(businessType))
                {
                    var businessTypeEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.BizType>(businessType);
                    return businessTypeEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String BusinessTypeDesc
        {
            get
            {
                return BusinessType?.GetDescription();
            }
        }

        /// <summary>
        /// 买家主账号id	
        /// 是否隐私: 否
        /// </summary>
        public String buyerID { get; set; }

        /// <summary>
        /// 买家子账号id，1688无此内容	
        /// 是否隐私: 否
        /// </summary>
        public long? buyerSubID { get; set; }

        /// <summary>
        /// 完成时间	
        /// 是否隐私: 否
        /// </summary>
        public String completeTime { get; set; }

        /// <summary>
        /// 完成时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? CompleteTime
        {
            get
            {
                if (!string.IsNullOrEmpty(completeTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(completeTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 创建时间	
        /// 是否隐私: 否
        /// </summary>
        public String createTime { get; set; }

        /// <summary>
        /// 创建时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? CreateTime
        {
            get
            {
                if (!string.IsNullOrEmpty(createTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(createTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 币种，币种，整个交易单使用同一个币种。值范围：USD,RMB,HKD,GBP,CAD,AUD,JPY,KRW,EUR	
        /// 是否隐私: 否
        /// </summary>
        public String currency { get; set; }

        /// <summary>
        /// 交易id	
        /// 是否隐私: 否
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 修改时间	
        /// 是否隐私: 否
        /// </summary>
        public String modifyTime { get; set; }

        /// <summary>
        /// 修改时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? ModifyTime
        {
            get
            {
                if (!string.IsNullOrEmpty(modifyTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(modifyTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 付款时间，如果有多次付款，这里返回的是首次付款时间	
        /// 是否隐私: 否
        /// </summary>
        public String payTime { get; set; }

        /// <summary>
        /// 付款时间，如果有多次付款，这里返回的是首次付款时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? PayTime
        {
            get
            {
                if (!string.IsNullOrEmpty(payTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(payTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 收货时间，这里返回的是完全收货时间	
        /// 是否隐私: 否
        /// </summary>
        public String receivingTime { get; set; }

        /// <summary>
        /// 收货时间，这里返回的是完全收货时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? ReceivingTime
        {
            get
            {
                if (!string.IsNullOrEmpty(receivingTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(receivingTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 退款金额，单位为元	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? refund { get; set; }

        /// <summary>
        /// 备注，1688指下单时的备注	
        /// 是否隐私: 否
        /// </summary>
        public String remark { get; set; }

        /// <summary>
        /// 卖家主账号id	
        /// 是否隐私: 否
        /// </summary>
        public String sellerID { get; set; }

        /// <summary>
        /// 卖家备忘信息	
        /// 是否隐私: 否
        /// </summary>
        public String sellerMemo { get; set; }

        /// <summary>
        /// 卖家子账号id，1688无此内容	
        /// 是否隐私: 否
        /// </summary>
        public long? sellerSubID { get; set; }

        /// <summary>
        /// 运费，单位为元	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? shippingFee { get; set; }

        /// <summary>
        /// 交易状态，
        /// waitbuyerpay:等待买家付款;
        /// waitsellersend:等待卖家发货;
        /// waitlogisticstakein:等待物流公司揽件;
        /// waitbuyerreceive:等待买家收货;
        /// waitbuyersign:等待买家签收;
        /// signinsuccess:买家已签收;
        /// confirm_goods:已收货;
        /// success:交易成功;
        /// cancel:交易取消;
        /// terminated:交易终止;
        /// 未枚举:其他状态	
        /// 是否隐私: 否
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public Com.Alibaba.Trade.OrderStatus? Status
        {
            get
            {
                if (!string.IsNullOrEmpty(status))
                {
                    return Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.OrderStatus>(status);
                }
                return null;
            }
        }

        /// <summary>
        /// 应付款总金额，totalAmount = ∑itemAmount + shippingFee，单位为元	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? totalAmount { get; set; }

        /// <summary>
        /// 买家备忘标志	
        /// 是否隐私: 否
        /// </summary>
        public String buyerRemarkIcon { get; set; }

        /// <summary>
        /// 卖家备忘标志	
        /// 是否隐私: 否
        /// </summary>
        public String sellerRemarkIcon { get; set; }

        /// <summary>
        /// 折扣信息，单位分	
        /// 是否隐私: 否
        /// </summary>
        public long? discount { get; set; }

        /// <summary>
        /// 买家联系人	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.TradeContact buyerContact { get; set; }

        /// <summary>
        /// 卖家联系人	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.TradeContact sellerContact { get; set; }

        /// <summary>
        /// 1:担保交易 
        /// 2:预存款交易 
        /// 3:ETC境外收单交易 
        /// 4:即时到帐交易 
        /// 5:保障金安全交易 
        /// 6:统一交易流程 
        /// 7:分阶段付款 
        /// 8.货到付款交易 
        /// 9.信用凭证支付交易 
        /// 10.账期支付交易	
        /// 是否隐私: 否
        /// </summary>
        public String tradeType { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public Com.Alibaba.Trade.TradeType? TradeType
        {
            get
            {
                if (!string.IsNullOrEmpty(tradeType) && Regex.IsMatch(tradeType, @"\d+"))
                {
                    var tradeTypeEnumValue = 0;
                    int.TryParse(tradeType, out tradeTypeEnumValue);
                    return Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.TradeType>(tradeTypeEnumValue);
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String TradeTypeDesc
        {
            get
            {
                return TradeType?.GetDescription();
            }
        }

        /// <summary>
        /// 订单的售中退款状态	
        /// 是否隐私: 否
        /// </summary>
        public String refundStatus { get; set; }

        /// <summary>
        /// 订单的售后退款状态	
        /// 是否隐私: 否
        /// </summary>
        public String refundStatusForAs { get; set; }

        /// <summary>
        /// 退款金额	
        /// 是否隐私: 否
        /// </summary>
        public long? refundPayment { get; set; }

        /// <summary>
        /// 交易id(字符串格式)	
        /// 是否隐私: 否
        /// </summary>
        public String idOfStr { get; set; }

        /// <summary>
        /// 外部支付交易Id	
        /// 是否隐私: 否
        /// </summary>
        public String alipayTradeId { get; set; }

        /// <summary>
        /// 收件人信息	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.Entities.TradeInfo.OrderReceiverInfo receiverInfo { get; set; }

        /// <summary>
        /// 买家loginId，旺旺Id	
        /// 是否隐私: 否
        /// </summary>
        public String buyerLoginId { get; set; }

        /// <summary>
        /// 卖家oginId，旺旺Id	
        /// 是否隐私: 否
        /// </summary>
        public String sellerLoginId { get; set; }

        /// <summary>
        /// 买家数字id	
        /// 是否隐私: 否
        /// </summary>
        public long? buyerUserId { get; set; }

        /// <summary>
        /// 卖家数字id	
        /// 是否隐私: 否
        /// </summary>
        public long? sellerUserId { get; set; }

        /// <summary>
        /// 买家支付宝id	
        /// 是否隐私: 否
        /// </summary>
        public String buyerAlipayId { get; set; }

        /// <summary>
        /// 卖家支付宝id	
        /// 是否隐私: 否
        /// </summary>
        public String sellerAlipayId { get; set; }

        /// <summary>
        /// 确认时间	
        /// 是否隐私: 否
        /// </summary>
        public String confirmedTime { get; set; }

        /// <summary>
        /// 确认时间	
        /// 是否隐私: 否
        /// </summary>
        public DateTime? ConfirmedTime
        {
            get
            {
                if (!string.IsNullOrEmpty(confirmedTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(confirmedTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 预订单ID	
        /// 是否隐私: 否
        /// </summary>
        public long? preOrderId { get; set; }

        /// <summary>
        /// 退款单ID	
        /// 是否隐私: 否
        /// </summary>
        public String refundId { get; set; }

        /// <summary>
        /// 4.0交易流程模板code
        /// 是否隐私: 否
        /// </summary>
        public String flowTemplateCode { get; set; }

    }
}
