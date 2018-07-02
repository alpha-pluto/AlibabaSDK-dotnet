/*======================================================================
    Daniel.Zhang
    
    文件名：ReqModelOrderDetailForSeller.cs
    文件功能描述：订单详情查看(卖家视角) 请求参数模型

======================================================================*/
using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace Com.Alibaba.Trade.Entities.Request
{
    /// <summary>
    /// 订单详情查看(卖家视角) 请求参数模型
    /// </summary>
    [Serializable]
    public class ReqModelOrderDetailForSeller
    {
        /// <summary>
        /// 
        /// </summary>
        public ReqModelOrderDetailForSeller()
        {
            webSite = "1688";
            orderId = 0;
            includeFields = "GuaranteesTerms,NativeLogistics,RateDetail,OrderInvoice";
        }

        /// <summary>
        /// 站点信息，指定调用的API是属于国际站（alibaba）还是1688网站（1688）		
        /// 是否隐私: 是
        /// </summary>
        public String webSite { get; set; }

        /// <summary>
        /// 交易的订单id	123456	
        /// 是否隐私: 是
        /// </summary>
        public long orderId { get; set; }

        /// <summary>
        /// 查询结果中包含的域，GuaranteesTerms：保障条款，NativeLogistics：物流信息，RateDetail：评价详情，OrderInvoice：发票信息。默认返回GuaranteesTerms、NativeLogistics、OrderInvoice。	GuaranteesTerms,NativeLogistics,RateDetail,OrderInvoice	GuaranteesTerms,NativeLogistics,OrderInvoice
        /// 是否隐私: 否
        /// </summary>
        public String includeFields { get; set; }

    }
}
