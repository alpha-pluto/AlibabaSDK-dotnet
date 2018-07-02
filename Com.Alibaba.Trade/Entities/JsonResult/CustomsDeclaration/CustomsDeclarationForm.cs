/*======================================================================
    Daniel.Zhang
    
    文件名：CustomsDeclarationForm.cs
    文件功能描述：跨境代发报关单信息

======================================================================*/
using System;
using System.Collections.Generic;

namespace Com.Alibaba.Trade.Entities.CustomsDeclaration
{
    /// <summary>
    /// 跨境代发报关单信息
    /// </summary>
    [Serializable]
    public class CustomsDeclarationForm
    {
        /// <summary>
        /// id	1
        /// 是否隐私: 否
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 创建时间	20170806114526000+0800
        /// 是否隐私: 否
        /// </summary>
        public String gmtCreate { get; set; }

        /// <summary>
        /// 创建时间	20170806114526000+0800
        /// 是否隐私: 否
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
        /// 修改时间	20170806114526000+0800
        /// 是否隐私: 否
        /// </summary>
        public String gmtModified { get; set; }

        /// <summary>
        /// 修改时间	20170806114526000+0800
        /// 是否隐私: 否
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
        /// 买家id	123456
        /// 是否隐私: 否
        /// </summary>
        public long? buyerId { get; set; }

        /// <summary>
        /// 主订单id	12312312312312
        /// 是否隐私: 否
        /// </summary>
        public String orderId { get; set; }

        /// <summary>
        /// 业务数据类型,默认1：报关单	1
        /// 是否隐私: 否
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// 报关信息列表
        /// 是否隐私: 否
        /// </summary>
        public List<Com.Alibaba.Trade.Entities.CustomsDeclaration.CustomsAttributesInfo> attributes { get; set; }
    }
}
