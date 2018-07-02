/*======================================================================
    Daniel.Zhang
    
    文件名：NativeLogisticsItemsInfo.cs
    文件功能描述：国内物流模型

======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.Trade.Entities.Logistics
{
    /// <summary>
    /// 国内物流模型
    /// </summary>
    [Serializable]
    public class NativeLogisticsInfo
    {
        /// <summary>
        /// 详细地址	
        /// 是否隐私: 否
        /// </summary>
        public String address { get; set; }

        /// <summary>
        /// 县，区	
        /// 是否隐私: 否
        /// </summary>
        public String area { get; set; }

        /// <summary>
        /// 省市区编码	
        /// 是否隐私: 否
        /// </summary>
        public String areaCode { get; set; }

        /// <summary>
        /// 城市	
        /// 是否隐私: 否
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// 联系人姓名	
        /// 是否隐私: 否
        /// </summary>
        public String contactPerson { get; set; }

        /// <summary>
        /// 传真	
        /// 是否隐私: 否
        /// </summary>
        public String fax { get; set; }

        /// <summary>
        /// 手机	
        /// 是否隐私: 否
        /// </summary>
        public String mobile { get; set; }

        /// <summary>
        /// 省份	
        /// 是否隐私: 否
        /// </summary>
        public String province { get; set; }

        /// <summary>
        /// 电话	
        /// 是否隐私: 否
        /// </summary>
        public String telephone { get; set; }

        /// <summary>
        /// 邮编	
        /// 是否隐私: 否
        /// </summary>
        public String zip { get; set; }

        /// <summary>
        /// 运单明细
        /// 是否隐私: 否
        /// </summary>
        public List<NativeLogisticsItemsInfo> logisticsItems { get; set; }

        /// <summary>
        /// 镇，街道地址码	
        /// 是否隐私: 否
        /// </summary>
        public String townCode { get; set; }

        /// <summary>
        /// 镇，街道
        /// 是否隐私: 否
        /// </summary>
        public String town { get; set; }

    }
}
