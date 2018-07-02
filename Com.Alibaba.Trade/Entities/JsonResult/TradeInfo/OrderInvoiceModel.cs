/*======================================================================
    Daniel.Zhang
    
    文件名：OrderInvoiceModel.cs
    文件功能描述：绑定在订单上的发票信息

======================================================================*/

using Com.Alibaba.Helpers;
using System;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 绑定在订单上的发票信息
    /// </summary>
    [Serializable]
    public class OrderInvoiceModel
    {
        /// <summary>
        /// 发票公司名称(即发票抬头-title)	
        /// 是否隐私: 否
        /// </summary>
        public String invoiceCompanyName { get; set; }

        /// <summary>
        /// 发票类型. 0：普通发票，1:增值税发票，9未知类型	
        /// 是否隐私: 否
        /// </summary>
        public int? invoiceType { get; set; }

        /// <summary>
        /// 发票类型. 0：普通发票，1:增值税发票，9未知类型	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.InvoiceType? InvoiceType
        {
            get
            {
                if (invoiceType.HasValue)
                {
                    return Com.Alibaba.Helpers.EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.InvoiceType>(invoiceType.Value);
                }
                return null;
            }
        }

        /// <summary>
        /// 发票类型. 0：普通发票，1:增值税发票，9未知类型	
        /// 是否隐私: 否
        /// </summary>
        public String InvoiceTypeDesc
        {
            get
            {
                return InvoiceType?.GetDescription();
            }
        }

        /// <summary>
        /// 本地发票号	
        /// 是否隐私: 否
        /// </summary>
        public long? localInvoiceId { get; set; }

        /// <summary>
        /// 订单Id	
        /// 是否隐私: 否
        /// </summary>
        public long? orderId { get; set; }

        /// <summary>
        /// (收件人)址区域编码	
        /// 是否隐私: 否
        /// </summary>
        public String receiveCode { get; set; }

        /// <summary>
        /// (收件人) 省市区编码对应的文案(增值税发票信息)	
        /// 是否隐私: 否
        /// </summary>
        public String receiveCodeText { get; set; }

        /// <summary>
        /// （收件者）发票收货人手机	
        /// 是否隐私: 否
        /// </summary>
        public String receiveMobile { get; set; }

        /// <summary>
        /// （收件者）发票收货人	
        /// 是否隐私: 否
        /// </summary>
        public String receiveName { get; set; }

        /// <summary>
        /// （收件者）发票收货人电话	
        /// 是否隐私: 否
        /// </summary>
        public String receivePhone { get; set; }

        /// <summary>
        /// （收件者）发票收货地址邮编	
        /// 是否隐私: 否
        /// </summary>
        public String receivePost { get; set; }

        /// <summary>
        /// (收件人) 街道地址(增值税发票信息)	
        /// 是否隐私: 否
        /// </summary>
        public String receiveStreet { get; set; }

        /// <summary>
        /// (公司)银行账号	
        /// 是否隐私: 否
        /// </summary>
        public String registerAccountId { get; set; }

        /// <summary>
        /// (公司)开户银行	
        /// 是否隐私: 否
        /// </summary>
        public String registerBank { get; set; }

        /// <summary>
        /// (注册)省市区编码	
        /// 是否隐私: 否
        /// </summary>
        public String registerCode { get; set; }

        /// <summary>
        /// (注册)省市区文本	
        /// 是否隐私: 否
        /// </summary>
        public String registerCodeText { get; set; }

        /// <summary>
        /// （公司）注册电话	
        /// 是否隐私: 否
        /// </summary>
        public String registerPhone { get; set; }

        /// <summary>
        /// (注册)街道地址	
        /// 是否隐私: 否
        /// </summary>
        public String registerStreet { get; set; }

        /// <summary>
        /// 纳税人识别号
        /// 是否隐私: 否
        /// </summary>
        public String taxpayerIdentify { get; set; }

    }
}
