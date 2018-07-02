/*======================================================================
    Daniel.Zhang
    
    文件名：OverseasExtraAddress.cs
    文件功能描述：跨境代发新增地址信息模型

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.Logistics
{
    /// <summary>
    /// 跨境代发新增地址信息模型
    /// </summary>
    [Serializable]
    public class OverseasExtraAddress
    {
        /// <summary>
        /// 路线名称	欧洲小包
        /// 是否隐私: 否
        /// </summary>
        public String channelName { get; set; }

        /// <summary>
        /// 路线id	1
        /// 是否隐私: 否
        /// </summary>
        public String channelId { get; set; }

        /// <summary>
        /// 货代公司id	222
        /// 是否隐私: 否
        /// </summary>
        public String shippingCompanyId { get; set; }

        /// <summary>
        /// 货代公司名称	货代公司1
        /// 是否隐私: 否
        /// </summary>
        public String shippingCompanyName { get; set; }

        /// <summary>
        /// 国家code	UK
        /// 是否隐私: 否
        /// </summary>
        public String countryCode { get; set; }

        /// <summary>
        /// 国家	英国
        /// 是否隐私: 否
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// 买家邮箱	aaa@gmail.com
        /// 是否隐私: 否
        /// </summary>
        public String email { get; set; }

    }
}
