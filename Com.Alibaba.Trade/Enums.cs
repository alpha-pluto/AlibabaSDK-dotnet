/*======================================================================
    Daniel.Zhang
    
    文件名：Enums.cs
    文件功能描述：类型 预设

======================================================================*/
using System;
using System.ComponentModel;

namespace Com.Alibaba.Trade
{
    #region order view

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Unknow,

        /// <summary>
        /// 交易取消，违约金等交割完毕
        /// </summary>
        [Description("交易取消，违约金等交割完毕")]
        cancel,

        /// <summary>
        /// 交易终止
        /// </summary>
        [Description("交易终止")]
        terminated,

        /// <summary>
        /// 等待卖家付款
        /// </summary>
        [Description("等待买家付款")]
        waitbuyerpay,

        /// <summary>
        /// 等待卖家发货
        /// </summary>
        [Description("等待卖家发货")]
        waitsellersend,

        /// <summary>
        /// 等待物流公司揽件
        /// </summary>
        [Description("等待物流公司揽件")]
        waitlogisticstakein,

        /// <summary>
        /// 等待买家收货
        /// </summary>
        [Description("等待买家收货")]
        waitbuyerreceive,

        /// <summary>
        /// 等待买家签收
        /// </summary>
        [Description("等待买家签收")]
        waitbuyersign,

        /// <summary>
        /// 买家已签收
        /// </summary>
        [Description("买家已签收")]
        signinsuccess,

        /// <summary>
        /// 已收货
        /// </summary>
        [Description("已收货")]
        confirm_goods,

        /// <summary>
        /// 交易成功
        /// </summary>
        [Description("交易成功")]
        success
    }

    /// <summary>
    /// 退款状态
    /// </summary>
    public enum RefundStatus
    {
        /// <summary>
        /// 等待卖家同意
        /// </summary>
        [Description("等待卖家同意")]
        waitselleragree,

        /// <summary>
        /// 等待卖家同意
        /// </summary>
        [Description("等待卖家同意")]
        WAIT_SELLER_AGREE,

        /// <summary>
        /// 退款成功
        /// </summary>
        [Description("退款成功")]
        refundsuccess,

        /// <summary>
        /// 退款成功
        /// </summary>
        [Description("退款成功")]
        REFUND_SUCCESS,

        /// <summary>
        /// 退款关闭
        /// </summary>
        [Description("退款关闭")]
        refundclose,

        /// <summary>
        /// 退款关闭
        /// </summary>
        [Description("退款关闭")]
        REFUND_CLOSED,

        /// <summary>
        /// 待买家修改
        /// </summary>
        [Description("待买家修改")]
        waitbuyermodify,

        /// <summary>
        /// 待买家修改
        /// </summary>
        [Description("待买家修改")]
        WAIT_BUYER_MODIFY,

        /// <summary>
        /// 等待买家退货
        /// </summary>
        [Description("等待买家退货")]
        waitbuyersend,

        /// <summary>
        /// 等待买家退货
        /// </summary>
        [Description("等待买家退货")]
        WAIT_BUYER_SEND,

        /// <summary>
        /// 等待卖家确认收货
        /// </summary>
        [Description("等待卖家确认收货")]
        waitsellerreceive,

        /// <summary>
        /// 等待卖家确认收货
        /// </summary>
        [Description("等待卖家确认收货")]
        WAIT_SELLER_RECEIVE
    }

    /// <summary>
    /// 交易类型
    /// </summary>
    public enum TradeType
    {
        /// <summary>
        /// 担保交易
        /// </summary>
        [Description("担保交易")]
        GuaranteeTransaction = 1,

        /// <summary>
        /// 预存款交易
        /// </summary>
        [Description("预存款交易")]
        DepositInAdvanceTransaction = 2,

        /// <summary>
        /// ETC境外收单交易
        /// </summary>
        [Description("ETC境外收单交易")]
        ETC_OverseasMerchantTransaction = 3,

        /// <summary>
        /// 即时到帐交易
        /// </summary>
        [Description("即时到帐交易")]
        InstantTransaction = 4,

        /// <summary>
        /// 保障金安全交易
        /// </summary>
        [Description("保障金安全交易")]
        SecureOverSecurityTransaction = 5,

        /// <summary>
        /// 统一交易流程
        /// </summary>
        [Description("统一交易流程")]
        UnifiedProcess = 6,

        /// <summary>
        /// 分阶段交易
        /// </summary>
        [Description("分阶段交易")]
        StructuredTransaction = 7,

        /// <summary>
        /// 货到付款交易
        /// </summary>
        [Description("货到付款交易")]
        COD = 8,

        /// <summary>
        /// 信用凭证支付交易
        /// </summary>
        [Description("信用凭证支付交易")]
        LC = 9,

        /// <summary>
        /// 账期支付交易
        /// </summary>
        [Description("账期支付交易")]
        PaymentTerms = 10,

        #region 1688交易4.0

        /// <summary>
        /// 新分阶段交易
        /// </summary>
        [Description("新分阶段交易")]
        NewStructuredTransaction = 50060,

        /// <summary>
        /// 当面付的交易流程
        /// </summary>
        [Description("当面付的交易流程")]
        FaceToFace = 50070,

        /// <summary>
        /// 服务类的交易流程
        /// </summary>
        [Description("服务类的交易流程")]
        Service = 50080

        #endregion
    }

    /// <summary>
    /// 业务类型
    /// </summary>
    public enum BizType
    {
        /// <summary>
        /// 普通订单类型
        /// </summary>
        [Description("普通订单类型")]
        cn,

        /// <summary>
        /// 大额批发订单类型
        /// </summary>
        [Description("大额批发订单类型")]
        ws,

        /// <summary>
        /// 普通拿样订单类型
        /// </summary>
        [Description("普通拿样订单类型")]
        yp,

        /// <summary>
        /// 一分钱拿样订单类型
        /// </summary>
        [Description("一分钱拿样订单类型")]
        yf,

        /// <summary>
        /// 倒批(限时折扣)订单类型
        /// </summary>
        [Description("倒批(限时折扣)订单类型")]
        fs,

        /// <summary>
        /// 加工定制订单类型
        /// </summary>
        [Description("加工定制订单类型")]
        cz,

        /// <summary>
        /// 协议采购订单类型
        /// </summary>
        [Description("协议采购订单类型")]
        ag,

        /// <summary>
        /// 伙拼订单类型
        /// </summary>
        [Description("伙拼订单类型")]
        hp,

        /// <summary>
        /// 国采订单类型
        /// </summary>
        [Description("国采订单类型")]
        gc,

        /// <summary>
        /// 供销订单类型
        /// </summary>
        [Description("供销订单类型")]
        supply,

        /// <summary>
        /// nyg订单类型
        /// </summary>
        [Description("nyg订单类型")]
        nyg,

        /// <summary>
        /// 淘工厂订单类型
        /// </summary>
        [Description("淘工厂订单类型")]
        factory,

        /// <summary>
        /// 快订下单
        /// </summary>
        [Description("快订下单")]
        quick,

        /// <summary>
        /// 享拼订单
        /// </summary>
        [Description("享拼订单")]
        xiangpin,

        /// <summary>
        /// 采购商城-鸟巢
        /// </summary>
        [Description("采购商城-鸟巢")]
        nest,

        /// <summary>
        /// 当面付
        /// </summary>
        [Description("当面付")]
        f2f,

        /// <summary>
        /// 存样服务
        /// </summary>
        [Description("存样服务")]
        cyfw,

        /// <summary>
        /// 代销订单标记
        /// </summary>
        [Description("代销订单标记")]
        sp,

        /// <summary>
        /// 微供订单
        /// </summary>
        [Description("微供订单")]
        wg,

        /// <summary>
        /// 零售通
        /// </summary>
        [Description("零售通")]
        lst,

        /// <summary>
        /// 淘工厂打样订单
        /// </summary>
        [Description("淘工厂打样订单")]
        factorysamp,

        /// <summary>
        /// 淘工厂大货订单
        /// </summary>
        [Description("淘工厂大货订单")]
        factorybig,

        /// <summary>
        /// 信保
        /// </summary>
        [Description("信保")]
        ta,

        /// <summary>
        /// 在线批发
        /// </summary>
        [Description("在线批发")]
        wholesale
    }

    /// <summary>
    /// 业务类型 国际站
    /// </summary>
    public enum BizTypeIntl
    {
        /// <summary>
        /// 信保
        /// </summary>
        [Description("信保")]
        ta,

        /// <summary>
        /// 在线批发
        /// </summary>
        [Description("在线批发")]
        wholesale
    }

    /// <summary>
    /// 评价状态
    /// </summary>
    public enum RateStatus
    {
        /// <summary>
        /// 已评价
        /// </summary>
        [Description("已评价")]
        Rated = 4,

        /// <summary>
        /// 未评价
        /// </summary>
        [Description("未评价")]
        NotRated = 5,

        /// <summary>
        /// 不需要评价
        /// </summary>
        [Description("不需要评价")]
        Unnecessory = 6
    }

    #endregion

    #region logistics

    /// <summary>
    /// 物流状态
    /// </summary>
    public enum LogisticsStatus
    {
        /// <summary>
        /// 未发货
        /// </summary>
        [Description("未发货")]
        NotSend = 1,

        /// <summary>
        /// 已发货
        /// </summary>
        [Description("已发货")]
        Sent = 2,

        /// <summary>
        /// 已收货
        /// </summary>
        [Description("已收货")]
        Delivered = 3,

        /// <summary>
        /// 已经退货
        /// </summary>
        [Description("已经退货")]
        Refunded = 4,

        /// <summary>
        /// 部分发货
        /// </summary>
        [Description("部分发货")]
        PartiallySent = 5,

        /// <summary>
        /// 还未创建物流订单
        /// </summary>
        [Description("还未创建物流订单")]
        WayBillNotCreat = 8
    }

    /// <summary>
    /// 发货方式
    /// </summary>
    public enum ShipmentMethod
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UNKNOWN,

        /// <summary>
        /// 空运
        /// </summary>
        [Description("空运")]
        AIR,

        /// <summary>
        /// 海运
        /// </summary>
        [Description("海运")]
        SEA,

        /// <summary>
        /// 快递
        /// </summary>
        [Description("快递")]
        EXPRESS,

        /// <summary>
        /// 陆运
        /// </summary>
        [Description("陆运")]
        LAND
    }

    /// <summary>
    /// 发货方式(国内)
    /// </summary>
    public enum NativeLogisticsType
    {
        /// <summary>
        /// 自行发货
        /// </summary>
        [Description("自行发货")]
        SELF_SEND_GOODS = 0,

        /// <summary>
        /// 在线发货
        /// </summary>
        [Description("在线发货")]
        ONLINE_SEND_GOODS = 1,

        /// <summary>
        /// 不需要物流的发货
        /// </summary>
        [Description("不需要物流的发货")]
        NO_LOGISTICS_SEND_GOODS = 2
    }

    #endregion

    #region paystatus

    /// <summary>
    /// 国际站 支付状态
    /// </summary>
    public enum PayStatusIntl
    {
        /// <summary>
        /// 未支付
        /// </summary>
        [Description("未支付")]
        WAIT_PAY,

        /// <summary>
        /// 已完成支付
        /// </summary>
        [Description("已完成支付")]
        PAYER_PAID,

        /// <summary>
        /// 部分支付成功
        /// </summary>
        [Description("部分支付成功")]
        PART_SUCCESS,

        /// <summary>
        /// 支付成功
        /// </summary>
        [Description("支付成功")]
        PAY_SUCCESS,

        /// <summary>
        /// 风控关闭
        /// </summary>
        [Description("风控关闭")]
        CLOSED,

        /// <summary>
        /// 支付撤销
        /// </summary>
        [Description("支付撤销")]
        CANCELLED,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        FAIL
    }

    /// <summary>
    /// 1688支付状态
    /// </summary>
    public enum PayStatus
    {
        /// <summary>
        /// 未付款
        /// </summary>
        [Description("未付款")]
        WAIT_PAY = 1,

        /// <summary>
        /// 已付款
        /// </summary>
        [Description("已付款")]
        PAID = 2,

        /// <summary>
        /// 全额退款
        /// </summary>
        [Description("全额退款")]
        REFUNDED = 4,

        /// <summary>
        /// 卖家有收到钱，回款完成
        /// </summary>
        [Description("卖家有收到钱，回款完成")]
        PAYMENT_COLLECTION_ACCOMPLISHED = 6,

        /// <summary>
        /// 未创建外部支付单
        /// </summary>
        [Description("未创建外部支付单")]
        OUT_BILL_NOT_CREAT = 7,

        /// <summary>
        /// 付款前取消
        /// </summary>
        [Description("付款前取消")]
        CANCELLED_BEFORE_PAYMENT = 8,

        /// <summary>
        /// 正在支付中
        /// </summary>
        [Description("正在支付中")]
        PAYMENT_ON_PROCESSING = 9,

        /// <summary>
        /// 账期支付, 待到账
        /// </summary>
        [Description("账期支付, 待到账")]
        PAYMENT_TERM_ON_PROVISIONING = 12
    }

    /// <summary>
    /// 支付方式。 
    /// 国际站：ECL(融资支付),CC(信用卡),TT(线下TT),ACH(echecking支付)。
    /// </summary>
    public enum PayWayIntl
    {
        /// <summary>
        /// 融资支付
        /// </summary>
        [Description("融资支付")]
        ECL,

        /// <summary>
        /// 信用卡
        /// </summary>
        [Description("信用卡")]
        CC,

        /// <summary>
        /// 线下TT
        /// </summary>
        [Description("线下TT")]
        TT,

        /// <summary>
        /// echecking支付
        /// </summary>
        [Description("echecking支付")]
        ACH
    }

    /// <summary>
    /// 支付方式。 
    /// 1688:1-支付宝,2-网商银行信任付,3-诚e赊,4-银行转账,5-赊销宝,6-电子承兑票据,7-账期支付,8-合并支付渠道,9-无打款,10-零售通赊购,13-支付平台,12-声明付款
    /// </summary>
    public enum PayWay
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        ALIPAY = 1,

        /// <summary>
        /// 网商银行信任付
        /// </summary>
        [Description("网商银行信任付")]
        MYBANK_CREDIT = 2,

        /// <summary>
        /// 诚e赊
        /// </summary>
        [Description("诚e赊")]
        CHENG_E_CREDIT = 3,

        /// <summary>
        /// 银行转账
        /// </summary>
        [Description("银行转账")]
        BANK_TRANSFER = 4,

        /// <summary>
        /// 赊销宝
        /// </summary>
        [Description("赊销宝")]
        SHE_XIAO_BAO = 5,

        /// <summary>
        /// 电子承兑票据
        /// </summary>
        [Description("电子承兑票据")]
        ELECTRONIC_ACCEPTANCE_BILL = 6,

        /// <summary>
        /// 账期支付
        /// </summary>
        [Description("账期支付")]
        PAYMENT_TERMS = 7,

        /// <summary>
        /// 合并支付渠道
        /// </summary>
        [Description("合并支付渠道")]
        CONSOLIDATED_PAYMENT_CHANNEL = 8,

        /// <summary>
        /// 无打款
        /// </summary>
        [Description("无打款")]
        NO_MONETARY_FLOW = 9,

        /// <summary>
        /// 零售通赊购
        /// </summary>
        [Description("零售通赊购")]
        CREDIT_OVER_RETAIL = 10,

        /// <summary>
        /// 声明付款
        /// </summary>
        [Description("声明付款")]
        PAY_IN_DECLARATION = 12,

        /// <summary>
        /// 支付平台
        /// </summary>
        [Description("支付平台")]
        PAY_VIA_THIRD_PARTY = 13
    }

    #endregion

    #region invoice

    /// <summary>
    /// 发票类型
    /// 发票类型. 0：普通发票，1:增值税发票，9未知类型
    /// </summary>
    public enum InvoiceType
    {
        /// <summary>
        /// 普通发票
        /// </summary>
        [Description("普通发票")]
        PLAIN_INVOICE = 0,

        /// <summary>
        /// 增值税发票
        /// </summary>
        [Description("增值税发票")]
        VAT_INVOICE = 1,

        /// <summary>
        /// 未知类型
        /// </summary>
        [Description("未知类型")]
        UNKNOW = 9
    }
    #endregion
}
