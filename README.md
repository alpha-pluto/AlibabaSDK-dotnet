# AlibabaSDK-dotnet
对接阿里巴巴开放平台，商家管理集成方案...

1.	概述
随着电商的发展，商家已经开始向多个平台发展。多个平台与商家自身管理系统（ERP）的数据对接就显得尤为重要。
AlibabaSDK 提供与阿里开放平台对接的Api，为商家在1688上的数据（商品，订单等）的对接、管理等提供解决方案。

2.	阿里开放平台URL
开放平台的URL分为两种体系
2.1	预授权体系
此体系下的URL构成如下：

${RequestSchema}://auth.1688.com/{apiRoot}/{protocol}/{apiVersion}/{apiNamespace}/{apiName}/{clientId}

取值示例如下(以获取accesstoken为例)，当然具体要依据不同的功用与阿里给出的文档对应。

${RequestSchema}的取值为 “http” 或 “https” ( Com.Alibaba.UriSchema )
{apiRoot}的取值为 “openapi”
{protocol}取值为 “http” (此处可取值为 枚举类型Com.Alibaba.Protocol 的值)
{apiVersion}的取值为1
{apiNamespace}取值为 “system.oauth2”
{apiName}取值为 “getToken”
{clientId}为对应店铺的授权信息 appKey

以post 方法提交 ，并且有 参数 如下：

var data={
grant_type=”authorization_code”,
	need_refresh_token=”true”,
  client_id=${appKey}, //此处为应店铺的授权信息 appKey
  client_secret=${appSecret},//此处为应店铺的授权信息 appSecret
  redirect_uri=${redicectUri},////此处为接收回调的地址 
  code=${pre-auth-code}//此处为已经得到的预授权码
  }








2.2	实际调用体系
此体系下的URL构成如下：

${RequestSchema}://gw.open.1688.com/{requestPolicy.ApiRoot}/{requestPolicy.Protocol}/{requestPolicy.ApiVersion}/{requestPolicy.ApiNamespace}/{requestPolicy.ApiName}/{requestPolicy.ClientId}


取值示例如下(以获取订单(卖家视图) 为例)，当然具体要依据不同的功用与阿里给出的文档对应。

${RequestSchema}的取值为 “http” 或 “https” ( Com.Alibaba.UriSchema )
{requestPolicy.ApiRoot}的取值为 “openapi”
{requestPolicy.Protocol}取值为 “param2” (此处可取值为 枚举类型Com.Alibaba.Protocol 的值)
{requestPolicy.ApiVersion}的取值为1
{requestPolicy.ApiNamespace}取值为 “com.alibaba.trade”
{requestPolicy.ApiName}取值为 “alibaba.trade.get.sellerView”
{requestPolicy.ClientId}为对应店铺的授权信息 appKey

以post 方法提交 ，并且有 参数 如下：

var data={
website=”1688”,
	orderId=${orderId},
  includeFields=” GuaranteesTerms,NativeLogistics,RateDetail,OrderInvoice”,//参看对应的阿里文档 
  access_token=${access_token},
  _aop_signature=${_aop_signature }//此处通过url算出的签名
}



