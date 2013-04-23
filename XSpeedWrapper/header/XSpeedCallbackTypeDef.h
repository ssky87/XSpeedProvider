#pragma once
#include "stdafx.h"

/*

*/
enum XSPEED_RESPONSE_TYPE
{
    OnFrontConnectedResponse,
    OnFrontDisconnectedResponse,
    OnRspUserLoginResponse,
    OnRspUserLogoutResponse,
    OnRspInsertOrderResponse,
    OnRspCancelOrderResponse,
    OnRspInsertOptOrderResponse,
    OnRspCancelOptOrderResponse,
    OnRtnErrorMsgResponse,
    OnRtnMatchedInfoResponse,
    OnRtnOrderResponse,
    OnRtnCancelOrderResponse,
    OnRspQryOrderInfoResponse,
    OnRspQryMatchInfoResponse,
    OnRspQryPositionResponse,
    OnRspCustomerCapitalResponse,
    OnRspQryExchangeInstrumentResponse,
    OnRspArbitrageInstrumentResponse,
    OnRspQrySpecifyInstrumentResponse,

    OnRspErrorResponse,
    OnRspSubMarketDataResponse,
    OnRspUnSubMarketDataResponse,
    OnMarketDataResponse
};

enum CTP_REQUEST_TYPE
{

  TraderApiCreate = 1,
  
  TraderApiInit,

  ///删除接口对象本身
	///@remark 不再使用本接口对象时,调用该函数删除接口对象
	TraderApiRelease,

  ///用户登录请求
  TraderApiReqUserLogin,

  ///登出请求
  TraderApiReqUserLogout,

  ReqInsertOrder,
  ReqInsertLossProfitOrder,
  ReqInsertAbiOrder,
  ReqInsertOptOrder,
  ReqCancelOptOrder,
  ReqCancelOrder,
  ReqQryPosition,
  ReqQryCustomerCapital,
  ReqQryExchangeInstrument,
  ReqQryArbitrageInstrument,
  ReqQryOrderInfo,
  ReqQryMatchInfo,
  ReqQrySpecifyInstrument,

  ///创建MdApi
  ///@param pszFlowPath 存贮订阅信息文件的目录，默认为当前目录
  ///@return 创建出的UserApi
  ///modify for udp marketdata
  MarketDataCreate,

  ///删除接口对象本身
  ///@remark 不再使用本接口对象时,调用该函数删除接口对象
  MarketDataRelease,

  ///用户登录请求
  MarketDataReqUserLogin,

  ///登出请求
  MarketDataReqUserLogout,

  ///订阅行情。
  ///@param ppInstrumentID 合约ID  
  ///@param nCount 要订阅/退订行情的合约个数
  ///@remark 
  MarketDataSubscribeMarketData,

  ///退订行情。
  ///@param ppInstrumentID 合约ID  
  ///@param nCount 要订阅/退订行情的合约个数
  ///@remark 
  MarketDataUnSubscribeMarketData,




};
