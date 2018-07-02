/*======================================================================
    Daniel.Zhang
    
    文件名：TradeContact.cs
    文件功能描述：交易联系人信息

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 交易联系人信息
    /// </summary>
    [Serializable]
    public class TradeContact
    {
        /// <summary>
        /// 联系电话	
        /// 是否隐私: 否
        /// </summary>
        public String phone { get; set; }

        /// <summary>
        /// 传真	
        /// 是否隐私: 否
        /// </summary>
        public String fax { get; set; }

        /// <summary>
        /// 邮箱	
        /// 是否隐私: 否
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// 联系人在平台的IM账号	
        /// 是否隐私: 否
        /// </summary>
        public String imInPlatform { get; set; }

        /// <summary>
        /// 联系人名称	
        /// 是否隐私: 否
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 联系人手机号	
        /// 是否隐私: 否
        /// </summary>
        public String mobile { get; set; }

        /// <summary>
        /// 公司名称
        /// 是否隐私: 否
        /// </summary>
        public String companyName { get; set; }

    }
}
