/*======================================================================
    Daniel.Zhang
    
    文件名：OrderReceiverInfo.cs
    文件功能描述：订单收件人信息

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 订单收件人信息
    /// </summary>
    [Serializable]
    public class OrderReceiverInfo
    {
        /// <summary>
        /// 收件人	
        /// 是否隐私: 否
        /// </summary>
        public String toFullName { get; set; }

        /// <summary>
        /// 收货人地址区域编码	
        /// 是否隐私: 否
        /// </summary>
        public String toDivisionCode { get; set; }

        /// <summary>
        /// 收件人移动电话	
        /// 是否隐私: 否
        /// </summary>
        public String toMobile { get; set; }

        /// <summary>
        /// 收件人电话	
        /// 是否隐私: 否
        /// </summary>
        public String toPhone { get; set; }

        /// <summary>
        /// 邮编	
        /// 是否隐私: 否
        /// </summary>
        public String toPost { get; set; }

        /// <summary>
        /// 收货人街道或镇区域编码，可能为空	
        /// 是否隐私: 否
        /// </summary>
        public String toTownCode { get; set; }

        /// <summary>
        /// 收货地址	
        /// 是否隐私: 否
        /// </summary>
        public String toArea { get; set; }

    }
}
