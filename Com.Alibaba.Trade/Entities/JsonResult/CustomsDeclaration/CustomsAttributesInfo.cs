/*======================================================================
    Daniel.Zhang
    
    文件名：CustomsAttributesInfo.cs
    文件功能描述：跨境代发报关单属性信息

======================================================================*/

using System;

namespace Com.Alibaba.Trade.Entities.CustomsDeclaration
{
    /// <summary>
    /// 跨境代发报关单属性信息
    /// </summary>
    [Serializable]
    public class CustomsAttributesInfo
    {
        /// <summary>
        /// sku标识	1234
        /// 是否隐私: 否
        /// </summary>
        public String sku { get; set; }

        /// <summary>
        /// 中文名称	测试
        /// 是否隐私: 否
        /// </summary>
        public String cName { get; set; }

        /// <summary>
        /// 英文名称	test
        /// 是否隐私: 否
        /// </summary>
        public String enName { get; set; }

        /// <summary>
        /// 申报价值	3000.0
        /// 是否隐私: 否
        /// </summary>
        public Double? amount { get; set; }

        /// <summary>
        /// 数量	1.0
        /// 是否隐私: 否
        /// </summary>
        public Double? quantity { get; set; }

        /// <summary>
        /// 重量（kg）	0.5
        /// 是否隐私: 否
        /// </summary>
        public Double? weight { get; set; }

        /// <summary>
        /// 报关币种	CNY
        /// 是否隐私: 否
        /// </summary>
        public String currency { get; set; }
    }
}
