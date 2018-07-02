/*======================================================================
    Daniel.Zhang
    
    文件名：GuaranteeTermsInfo.cs
    文件功能描述：保障条款模型

======================================================================*/
using System;
using Com.Alibaba.Entities;
using Newtonsoft.Json;

namespace Com.Alibaba.Trade.Entities.PaymentInfo
{

    /// <summary>
    /// 保障条款模型
    /// </summary>
    [Serializable]
    public class GuaranteeTermsInfo
    {
        /// <summary>
        /// 保障条款
        /// </summary>
        public string assuranceInfo { get; set; }

        /// <summary>
        /// 保障方式。国际站：TA(信保)
        /// </summary>
        public string assuranceType { get; set; }

        /// <summary>
        /// 质量保证类型。国际站：pre_shipment(发货前),post_delivery(发货后)
        /// </summary>
        public string qualityAssuranceType { get; set; }
    }
}
