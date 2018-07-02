/*======================================================================
    Daniel.Zhang
    
    文件名：InternationalLogisticsInfo.cs
    文件功能描述：国际物流模型

======================================================================*/
using System;
using Com.Alibaba.Helpers;

namespace Com.Alibaba.Trade.Entities.Logistics
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class InternationalLogisticsInfo
    {
        /// <summary>
        /// 详细地址	
        /// 是否隐私: 否
        /// </summary>
        public String address { get; set; }

        /// <summary>
        /// 完全发货时间	
        /// 是否隐私: 否
        /// </summary>
        public String allDeliveredTime { get; set; }

        /// <summary>
        /// 
        /// 
        /// </summary>
        public DateTime? AllDeliveredTime
        {
            get
            {
                if (!string.IsNullOrEmpty(allDeliveredTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(allDeliveredTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 备用地址	
        /// 是否隐私: 否
        /// </summary>
        public String alternateAddress { get; set; }

        /// <summary>
        /// 承运商	
        /// 是否隐私: 否
        /// </summary>
        public String carrier { get; set; }

        /// <summary>
        /// 城市	
        /// 是否隐私: 否
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// 城市编号	
        /// 是否隐私: 否
        /// </summary>
        public String cityCode { get; set; }

        /// <summary>
        /// 联系人姓名	
        /// 是否隐私: 否
        /// </summary>
        public String contactPerson { get; set; }

        /// <summary>
        /// 国家	
        /// 是否隐私: 否
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// 国家编号	
        /// 是否隐私: 否
        /// </summary>
        public String countryCode { get; set; }

        /// <summary>
        /// 传真	
        /// 是否隐私: 否
        /// </summary>
        public String fax { get; set; }

        /// <summary>
        /// 传真地区区号	
        /// 是否隐私: 否
        /// </summary>
        public String faxArea { get; set; }

        /// <summary>
        /// 传真国家编号	
        /// 是否隐私: 否
        /// </summary>
        public String faxCountry { get; set; }

        /// <summary>
        /// 物流保险费	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? insuranceFee { get; set; }

        /// <summary>
        /// 委托单号	
        /// 是否隐私: 否
        /// </summary>
        public String logisticsCode { get; set; }

        /// <summary>
        /// 物流费用	
        /// 是否隐私: 否
        /// </summary>
        public Decimal? logisticsFee { get; set; }

        /// <summary>
        /// 手机	
        /// 是否隐私: 否
        /// </summary>
        public String mobile { get; set; }

        /// <summary>
        /// 移动电话地区区号	
        /// 是否隐私: 否
        /// </summary>
        public String mobileArea { get; set; }

        /// <summary>
        /// 移动电话国家编号	
        /// 是否隐私: 否
        /// </summary>
        public String mobileCountry { get; set; }

        /// <summary>
        /// 港口	
        /// 是否隐私: 否
        /// </summary>
        public String port { get; set; }

        /// <summary>
        /// 港口编号	
        /// 是否隐私: 否
        /// </summary>
        public String portCode { get; set; }

        /// <summary>
        /// 省份	
        /// 是否隐私: 否
        /// </summary>
        public String province { get; set; }

        /// <summary>
        /// 省份编号	
        /// 是否隐私: 否
        /// </summary>
        public String provinceCode { get; set; }

        /// <summary>
        /// 绝对时间	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentAbsoluteDate { get; set; }

        /// <summary>
        /// 绝对时间
        /// 
        /// </summary>
        public DateTime? ShipmentAbsoluteDate
        {
            get
            {
                if (!string.IsNullOrEmpty(shipmentAbsoluteDate))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(shipmentAbsoluteDate);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 买家时区	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentAbsoluteZone { get; set; }

        /// <summary>
        /// 倒计时类型。absolute(绝对),relative(相对)	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentDateType { get; set; }

        /// <summary>
        /// 发货方式。AIR(空运),SEA(海运),EXPRESS(快递),LAND(陆运),UNKNOWN(未知)	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentMethod { get; set; }

        /// <summary>
        /// 发货方式。AIR(空运),SEA(海运),EXPRESS(快递),LAND(陆运),UNKNOWN(未知)	
        /// 是否隐私: 否
        /// </summary>
        public Com.Alibaba.Trade.ShipmentMethod? ShipmentMethod
        {
            get
            {
                if (!string.IsNullOrEmpty(shipmentMethod))
                {
                    var shipmentMethodEnum = EnumHelper.ConvertToEnumItem<Com.Alibaba.Trade.ShipmentMethod>(shipmentMethod);
                    return shipmentMethodEnum;
                }
                return null;
            }
        }

        /// <summary>
        /// 发货方式描述。AIR(空运),SEA(海运),EXPRESS(快递),LAND(陆运),UNKNOWN(未知)	
        /// 是否隐私: 否
        /// </summary>
        public String ShipmentMethodDesc
        {
            get
            {
                var shipmentMethodDesc = string.Empty;

                if (ShipmentMethod.HasValue)
                {
                    shipmentMethodDesc = ShipmentMethod.GetDescription();
                }
                return shipmentMethodDesc;

            }
        }

        /// <summary>
        /// 相对时间长度	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentRelativeDuration { get; set; }

        /// <summary>
        /// 相对时间单位。day(天),hour(时),second(秒)	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentRelativeField { get; set; }

        /// <summary>
        /// 相对时间的开始点。pre_amount(预付款到帐),final_amount(尾款到帐)	
        /// 是否隐私: 否
        /// </summary>
        public String shipmentRelativeStart { get; set; }

        /// <summary>
        /// 电话	
        /// 是否隐私: 否
        /// </summary>
        public String telephone { get; set; }

        /// <summary>
        /// 电话地区区号	
        /// 是否隐私: 否
        /// </summary>
        public String telephoneArea { get; set; }

        /// <summary>
        /// 电话国家编号	
        /// 是否隐私: 否
        /// </summary>
        public String telephoneCountryv { get; set; }

        /// <summary>
        /// 贸易条款说明
        /// 是否隐私: 否
        /// </summary>
        public String tradeTerm { get; set; }



    }
}
