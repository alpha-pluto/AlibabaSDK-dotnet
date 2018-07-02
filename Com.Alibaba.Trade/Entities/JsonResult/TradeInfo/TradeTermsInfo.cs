/*======================================================================
    Daniel.Zhang
    
    文件名：TradeTermsInfo.cs
    文件功能描述：交易条款

======================================================================*/
using Com.Alibaba.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{

    /// <summary>
    /// 交易条款
    /// </summary>
    [Serializable]
    public class TradeTermsInfo
    {
        /// <summary>
        /// 支付状态。
        /// 国际站：WAIT_PAY(未支付),PAYER_PAID(已完成支付),PART_SUCCESS(部分支付成功),PAY_SUCCESS(支付成功),CLOSED(风控关闭),CANCELLED(支付撤销),SUCCESS(成功),FAIL(失败)。 
        /// 1688:1(未付款);2(已付款);4(全额退款);6(卖家有收到钱，回款完成) ;7(未创建外部支付单);8 (付款前取消) ; 9(正在支付中);12(账期支付,待到账)	
        /// 是否隐私: 否
        /// </summary>
        public String payStatus { get; set; }

        /// <summary>
        /// 支付状态。
        /// 国际站：WAIT_PAY(未支付),PAYER_PAID(已完成支付),PART_SUCCESS(部分支付成功),PAY_SUCCESS(支付成功),CLOSED(风控关闭),CANCELLED(支付撤销),SUCCESS(成功),FAIL(失败)。 
        /// </summary>
        public Com.Alibaba.Trade.PayStatusIntl? PayStatusIntl
        {
            get
            {
                if (!string.IsNullOrEmpty(payStatus) && !Regex.IsMatch(payStatus, @"\d+"))
                {
                    var payStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.PayStatusIntl>(payStatus);
                    return payStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 支付状态。
        /// 1688:1(未付款);2(已付款);4(全额退款);6(卖家有收到钱，回款完成) ;7(未创建外部支付单);8 (付款前取消) ; 9(正在支付中);12(账期支付,待到账)	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.PayStatus? PayStatus
        {
            get
            {
                if (!string.IsNullOrEmpty(payStatus) && Regex.IsMatch(payStatus, @"\d+"))
                {
                    var payStatusEnumValue = 0;
                    int.TryParse(payStatus, out payStatusEnumValue);
                    var payStatusEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.PayStatus>(payStatusEnumValue);
                    return payStatusEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 支付状态 描述 
        /// </summary>
        public String PayStatusDesc
        {
            get
            {
                if (PayStatusIntl.HasValue)
                {
                    return PayStatusIntl?.GetDescription();
                }
                if (PayStatus.HasValue)
                {
                    return PayStatus?.GetDescription();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 完成阶段支付时间	
        /// 是否隐私: 否
        /// </summary>
        public String payTime { get; set; }

        /// <summary>
        /// 完成阶段支付时间	
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
        /// 支付方式。 国际站：ECL(融资支付),CC(信用卡),TT(线下TT),ACH(echecking支付)。 1688:1-支付宝,2-网商银行信任付,3-诚e赊,4-银行转账,5-赊销宝,6-电子承兑票据,7-账期支付,8-合并支付渠道,9-无打款,10-零售通赊购,13-支付平台,12-声明付款	
        /// 是否隐私: 否
        /// </summary>
        public String payWay { get; set; }

        /// <summary>
        /// 支付方式。 国际站：ECL(融资支付),CC(信用卡),TT(线下TT),ACH(echecking支付)。  
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.PayWayIntl? PayWayIntl
        {
            get
            {
                if (!string.IsNullOrEmpty(payWay) && !Regex.IsMatch(payWay, @"\d+"))
                {
                    var payWayEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.PayWayIntl>(payWay);
                    return payWayEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 支付方式。 
        /// 1688:1-支付宝,2-网商银行信任付,3-诚e赊,4-银行转账,5-赊销宝,6-电子承兑票据,7-账期支付,8-合并支付渠道,9-无打款,10-零售通赊购,13-支付平台,12-声明付款	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.PayWay? PayWay
        {
            get
            {
                if (!string.IsNullOrEmpty(payWay) && Regex.IsMatch(payWay, @"\d+"))
                {
                    var payWayEnumValue = 0;
                    int.TryParse(payStatus, out payWayEnumValue);
                    var payWayEnum = Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.PayWay>(payWayEnumValue);
                    return payWayEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PayWayDesc
        {
            get
            {
                if (PayWayIntl.HasValue)
                {
                    return PayWayIntl?.GetDescription();
                }
                if (PayWay.HasValue)
                {
                    return PayWay?.GetDescription();
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 付款额	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? phasAmount { get; set; }

        /// <summary>
        /// 阶段单id	
        /// 是否隐私: 否
        /// </summary>
        public long? phase { get; set; }

        /// <summary>
        /// 阶段条件，1688无此内容	
        /// 是否隐私: 否
        /// </summary>
        public String phaseCondition { get; set; }

        /// <summary>
        /// 阶段时间，1688无此内容	
        /// 是否隐私: 否
        /// </summary>
        public String phaseDate { get; set; }

        /// <summary>
        /// 是否银行卡支付	
        /// 是否隐私: 否
        /// </summary>
        public Boolean cardPay { get; set; }

        /// <summary>
        /// 是否快捷支付
        /// 是否隐私: 否
        /// </summary>
        public Boolean expressPay { get; set; }
    }

}
