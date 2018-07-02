/*======================================================================
    Daniel.Zhang
    
    文件名：ReqModelOrderListForSeller.cs
    文件功能描述：订单列表查看(卖家视角) 请求参数模型

======================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Com.Alibaba.Trade.Entities.Request
{
    /// <summary>
    /// 订单列表查看(卖家视角) 请求参数模型
    /// </summary>
    [Serializable]
    public class ReqModelOrderListForSeller : Com.Alibaba.Entities.Request.Paging
    {
        #region ctor

        /// <summary>
        /// 
        /// </summary>
        public ReqModelOrderListForSeller() : base()
        {
            isHis = false;
            needBuyerAddressAndPhone = false;
            needMemoInfo = false;
        }

        #endregion

        #region 下单结束时间

        private String _createEndTime = string.Empty;

        /// <summary>
        /// 下单结束时间		
        /// 是否必须: 否
        /// </summary>
        public String createEndTime
        {
            get
            {
                return _createEndTime;
            }
            set
            {
                _createEndTime = Com.Alibaba.Helpers.StringValidate.StringValidateForDatetimeOcean(value, true, true);
            }
        }

        #endregion

        #region 下单开始时间

        private String _createStartTime = string.Empty;

        /// <summary>
        /// 下单开始时间		
        /// 是否必须: 否
        /// </summary>
        public String createStartTime
        {
            get
            {
                return _createStartTime;
            }
            set
            {
                _createStartTime = Com.Alibaba.Helpers.StringValidate.StringValidateForDatetimeOcean(value, true);
            }
        }

        #endregion

        /// <summary>
        /// 是否查询历史订单表,默认查询当前表	默认false	
        /// 是否必须: 否
        /// </summary>
        public bool? isHis { get; set; }

        #region 查询修改时间结束

        private String _modifyEndTime = string.Empty;

        /// <summary>
        /// 查询修改时间结束		
        /// 是否必须: 否
        /// </summary>
        public String modifyEndTime
        {
            get
            {
                return _modifyEndTime;
            }
            set
            {
                _modifyEndTime = Com.Alibaba.Helpers.StringValidate.StringValidateForDatetimeOcean(value, true, true);
            }
        }

        #endregion

        #region 查询修改时间开始

        private String _modifyStartTime = string.Empty;

        /// <summary>
        /// 查询修改时间开始		
        /// 是否必须: 否
        /// </summary>
        public String modifyStartTime
        {
            get
            {
                return _modifyStartTime;
            }
            set
            {
                _modifyStartTime = Com.Alibaba.Helpers.StringValidate.StringValidateForDatetimeOcean(value, true);
            }
        }

        #endregion

        #region 订单状态

        private String _orderStatus = string.Empty;

        /// <summary>
        /// Com.Alibaba.Trade.OrderStatus
        /// 
        /// 订单状态，值有 success, 
        /// cancel(交易取消，违约金等交割完毕), 
        /// waitbuyerpay(等待卖家付款)， 
        /// waitsellersend(等待卖家发货), 
        /// waitbuyerreceive(等待买家收货 )	
        /// waitbuyerpay	
        /// 是否必须: 否
        /// </summary>
        public String orderStatus
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                if (Enum.GetNames(typeof(Com.Alibaba.Trade.OrderStatus)).Contains(value))
                {
                    _orderStatus = value;
                }
                else
                {
                    _orderStatus = string.Empty;
                }
            }
        }

        #endregion

        #region 退款状态

        private String _refundStatus = string.Empty;

        /// <summary>
        /// Com.Alibaba.Trade.RefundStatus
        /// 退款状态，支持： 
        /// "waitselleragree"(等待卖家同意), 
        /// "refundsuccess"(退款成功), 
        /// "refundclose"(退款关闭), 
        /// "waitbuyermodify"(待买家修改), 
        /// "waitbuyersend"(等待买家退货), 
        /// "waitsellerreceive"(等待卖家确认收货)		
        /// 是否必须: 否
        /// </summary>
        public String refundStatus
        {
            get
            {
                return _refundStatus;
            }
            set
            {
                if (Enum.GetNames(typeof(Com.Alibaba.Trade.RefundStatus)).Contains(value))
                {
                    _refundStatus = value;
                }
                else
                {
                    _refundStatus = string.Empty;
                }
            }
        }


        #endregion

        /// <summary>
        /// 买家memberId		
        /// 是否必须: 否
        /// </summary>
        public String buyerMemberId { get; set; }

        #region 买家评价状态

        /// <summary>
        /// Com.Alibaba.Trade.RateStatus
        /// 买家评价状态 (4:已评价,5:未评价,6;不需要评价)	4	
        /// 是否必须: 否
        /// </summary>
        public int? buyerRateStatus { get; set; }

        #endregion

        #region 交易类型

        private String _tradeType = string.Empty;

        /// <summary>
        /// Com.Alibaba.Trade.TradeType
        /// 交易类型: 
        /// 担保交易(1), 
        /// 预存款交易(2), 
        /// ETC境外收单交易(3), 
        /// 即时到帐交易(4), 
        /// 保障金安全交易(5), 
        /// 统一交易流程(6), 
        /// 分阶段交易(7), 
        /// 货到付款交易(8), 
        /// 信用凭证支付交易(9), 
        /// 账期支付交易(10), 
        /// 1688交易4.0，
        /// 新分阶段交易(50060), 
        /// 当面付的交易流程(50070), 
        /// 服务类的交易流程(50080)		
        /// 是否必须: 否
        /// </summary>
        public String tradeType
        {
            get
            {
                return _tradeType;
            }
            set
            {
                try
                {
                    if (Regex.IsMatch(value, @"\d+"))
                    {
                        var tradeTypeValues = Enum.GetValues(typeof(Com.Alibaba.Trade.TradeType)).Cast<int>();
                        var tradeTypeValue = 0;
                        _tradeType = int.TryParse(value, out tradeTypeValue) ? value : String.Empty;
                    }
                    else
                    {
                        _tradeType = string.Empty;
                    }
                }
                catch
                {
                    _tradeType = string.Empty;
                }

            }
        }

        #endregion

        #region 业务类型

        private List<String> _bizTypes;

        /// <summary>
        /// Com.Alibaba.Trade.BizType
        /// 业务类型，支持： 
        /// "cn"(普通订单类型), 
        /// "ws"(大额批发订单类型), 
        /// "yp"(普通拿样订单类型), 
        /// "yf"(一分钱拿样订单类型), 
        /// "fs"(倒批(限时折扣)订单类型), 
        /// "cz"(加工定制订单类型), 
        /// "ag"(协议采购订单类型), 
        /// "hp"(伙拼订单类型), 
        /// "gc"(国采订单类型), 
        /// "supply"(供销订单类型), 
        /// "nyg"(nyg订单类型), 
        /// "factory"(淘工厂订单类型), 
        /// "quick"(快订下单), 
        /// "xiangpin"(享拼订单), 
        /// "nest"(采购商城-鸟巢), 
        /// "f2f"(当面付), 
        /// "cyfw"(存样服务), 
        /// "sp"(代销订单标记), 
        /// "wg"(微供订单), 
        /// "factorysamp"(淘工厂打样订单), 
        /// "factorybig"(淘工厂大货订单)	
        /// ["cn","ws"]	
        /// 是否必须: 否
        /// </summary>
        public List<String> bizTypes
        {
            get
            {
                return _bizTypes;
            }
            set
            {
                List<String> tempBizTypes = value;
                List<String> retBizType = new List<String>();
                var bizTypes = Enum.GetNames(typeof(Com.Alibaba.Trade.BizType));
                foreach (var bizType in tempBizTypes)
                {
                    if (bizTypes.Contains(bizType))
                    {
                        retBizType.Add(bizType);
                    }
                }
                _bizTypes = retBizType;
            }
        }

        #endregion

        /// <summary>
        /// 商品名称		
        /// 是否必须: 否
        /// </summary>
        public String productName { get; set; }

        /// <summary>
        /// 是否需要查询买家的详细地址信息和电话		false
        /// 是否必须: 否
        /// </summary>
        public Boolean needBuyerAddressAndPhone { get; set; }

        /// <summary>
        /// 是否需要查询备注信息		false
        /// 是否必须: 否
        /// </summary>
        public Boolean needMemoInfo { get; set; }

        /// <summary>
        /// 卖家评价状态 (4:已评价,5:未评价,6;不需要评价)	4	
        /// 是否必须: 否
        /// </summary>
        public int? sellerRateStatus { get; set; }

        /// <summary>
        /// 是否查找投诉中的地拟改单	true,false
        /// 是否必须: 否
        /// </summary>
        public Boolean? tousuStatus { get; set; }
    }
}
