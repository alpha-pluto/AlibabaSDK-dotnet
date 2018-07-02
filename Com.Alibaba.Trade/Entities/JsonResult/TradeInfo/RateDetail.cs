/*======================================================================
    Daniel.Zhang
    
    文件名：RateDetail.cs
    文件功能描述：评价 模型

======================================================================*/
using System;

namespace Com.Alibaba.Trade.Entities.TradeInfo
{
    /// <summary>
    /// 评价
    /// </summary>
    [Serializable]
    public class RateDetail
    {
        /// <summary>
        /// 评价星级	
        /// 是否隐私: 否
        /// </summary>
        public int? starLevel { get; set; }

        /// <summary>
        /// 评价详情	
        /// 是否隐私: 否
        /// </summary>
        public String content { get; set; }

        /// <summary>
        /// 收到评价的用户昵称	
        /// 是否隐私: 否
        /// </summary>
        public String receiverNick { get; set; }

        /// <summary>
        /// 发送评价的用户昵称	
        /// 是否隐私: 否
        /// </summary>
        public String posterNick { get; set; }

        /// <summary>
        /// 评价上线时间
        /// 是否隐私: 否
        /// </summary>
        public String publishTime { get; set; }

        /// <summary>
        /// 评价上线时间
        /// 是否隐私: 否
        /// </summary>
        public DateTime? PublishTime
        {
            get
            {
                if (!string.IsNullOrEmpty(publishTime))
                {
                    try
                    {
                        return Com.Alibaba.Helpers.DateTimeHelper.FormatFromStr(publishTime);
                    }
                    catch (Exception)
                    {

                    }
                }

                return null;
            }
        }
    }
}
