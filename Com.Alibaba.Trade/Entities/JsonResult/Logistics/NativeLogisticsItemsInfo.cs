/*======================================================================
    Daniel.Zhang
    
    文件名：NativeLogisticsItemsInfo.cs
    文件功能描述：运单明细模型

======================================================================*/
using Com.Alibaba.Helpers;
using System;

namespace Com.Alibaba.Trade.Entities.Logistics
{

    /// <summary>
    /// 运单明细模型
    /// </summary>
    [Serializable]
    public class NativeLogisticsItemsInfo
    {
        /// <summary>
        /// 发货时间	
        /// 是否隐私: 否
        /// </summary>
        public String deliveredTime { get; set; }

        /// <summary>
        /// 发货时间
        /// 
        /// </summary>
        public DateTime? DeliveredTime
        {
            get
            {
                if (!string.IsNullOrEmpty(deliveredTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(deliveredTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 物流编号	
        /// 是否隐私: 否
        /// </summary>
        public String logisticsCode { get; set; }

        /// <summary>
        /// SELF_SEND_GOODS("0")自行发货，在线发货ONLINE_SEND_GOODS("1"，不需要物流的发货 NO_LOGISTICS_SEND_GOODS("2")	
        /// 是否隐私: 否
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// SELF_SEND_GOODS("0")自行发货，在线发货ONLINE_SEND_GOODS("1"，不需要物流的发货 NO_LOGISTICS_SEND_GOODS("2")	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.NativeLogisticsType? Type
        {
            get
            {
                if (!string.IsNullOrEmpty(type))
                {
                    var nativeLogisticsTypeEnum = EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.NativeLogisticsType>(type);
                    return nativeLogisticsTypeEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// SELF_SEND_GOODS("0")自行发货，在线发货ONLINE_SEND_GOODS("1"，不需要物流的发货 NO_LOGISTICS_SEND_GOODS("2")	
        /// 是否隐私: 否
        /// </summary>
        public String TypeDesc
        {
            get
            {
                var typeDesc = string.Empty;

                if (Type.HasValue)
                {
                    typeDesc = Type.GetDescription();
                }
                return typeDesc;

            }
        }

        /// <summary>
        /// 主键id	
        /// 是否隐私: 否
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 状态	
        /// 是否隐私: 否
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// 修改时间	
        /// 是否隐私: 否
        /// </summary>
        public String gmtModified { get; set; }

        /// <summary>
        /// 修改时间	
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
        /// 创建时间	
        /// 是否隐私: 否
        /// </summary>
        public String gmtCreate { get; set; }

        /// <summary>
        /// 创建时间	
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
        /// 运费(单位为元)	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? carriage { get; set; }

        /// <summary>
        /// 发货省	
        /// 是否隐私: 否
        /// </summary>
        public String fromProvince { get; set; }

        /// <summary>
        /// 发货市	
        /// 是否隐私: 否
        /// </summary>
        public String fromCity { get; set; }

        /// <summary>
        /// 发货区	
        /// 是否隐私: 否
        /// </summary>
        public String fromArea { get; set; }

        /// <summary>
        /// 发货街道地址	
        /// 是否隐私: 否
        /// </summary>
        public String fromAddress { get; set; }

        /// <summary>
        /// 发货联系电话	
        /// 是否隐私: 否
        /// </summary>
        public String fromPhone { get; set; }

        /// <summary>
        /// 发货联系手机	
        /// 是否隐私: 否
        /// </summary>
        public String fromMobile { get; set; }

        /// <summary>
        /// 发货地址邮编	
        /// 是否隐私: 否
        /// </summary>
        public String fromPost { get; set; }

        /// <summary>
        /// 物流公司Id	
        /// 是否隐私: 否
        /// </summary>
        public long? logisticsCompanyId { get; set; }

        /// <summary>
        /// 物流公司编号	
        /// 是否隐私: 否
        /// </summary>
        public String logisticsCompanyNo { get; set; }

        /// <summary>
        /// 物流公司名称	
        /// 是否隐私: 否
        /// </summary>
        public String logisticsCompanyName { get; set; }

        /// <summary>
        /// 物流公司运单号	
        /// 是否隐私: 否
        /// </summary>
        public String logisticsBillNo { get; set; }

        /// <summary>
        /// 商品明细条目id，如有多个以,分隔	
        /// 是否隐私: 否
        /// </summary>
        public String subItemIds { get; set; }

        /// <summary>
        /// 收货省	
        /// 是否隐私: 否
        /// </summary>
        public String toProvince { get; set; }

        /// <summary>
        /// 收货市	
        /// 是否隐私: 否
        /// </summary>
        public String toCity { get; set; }

        /// <summary>
        /// 收货区	
        /// 是否隐私: 否
        /// </summary>
        public String toArea { get; set; }

        /// <summary>
        /// 收货街道地址	
        /// 是否隐私: 否
        /// </summary>
        public String toAddress { get; set; }

        /// <summary>
        /// 收货联系电话	
        /// 是否隐私: 否
        /// </summary>
        public String toPhone { get; set; }

        /// <summary>
        /// 收货联系手机	
        /// 是否隐私: 否
        /// </summary>
        public String toMobile { get; set; }

        /// <summary>
        /// 收货地址邮编
        /// 是否隐私: 否
        /// </summary>
        public String toPost { get; set; }

    }
}
