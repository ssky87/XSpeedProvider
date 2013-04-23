#include "..\header\stdafx.h"


XSpeedTraderSpi::XSpeedTraderSpi()
{
  this->callback = (XSpeedResponseCallback)NULL;
  this->connected = false;
  this->login = false;
}

/* 网络连接正常响应:当客户端与交易后台需建立起通信连接时（还未登录前），客户端API会自动检测与前置机之间的连接，
* 当网络可用，将自动建立连接，并调用该方法通知客户端， 客户端可以在实现该方法时，重新使用资金账号进行登录。（该方法是在Api和前置机建立连接后被调用，该调用仅仅是说明tcp连接已经建立成功。用户需要自行登录才能进行后续的业务操作。登录失败则此方法不会被调用。）
*/	     
void XSpeedTraderSpi::OnFrontConnected()
{
  //OutputLog("XSpeedTraderSpi::OnFrontConnected");

  this->connected = true;
  this->OnResponse(OnFrontConnectedResponse);
}

/**
* 网络连接不正常响应：当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
* @param  nReason:错误原因。
*        0x1001 网络读失败
*        0x1002 网络写失败
*        0x2001 接收心跳超时
*        0x2002 发送心跳失败 
*        0x2003 收到错误报文  
*/
void XSpeedTraderSpi::OnFrontDisconnected( int nReason )
{

  this->OnResponse(OnFrontDisconnectedResponse,(void*)nReason);
}

/**
* 登陆请求响应:当用户发出登录请求后，前置机返回响应时此方法会被调用，通知用户登录是否成功。
* @param pUserLoginInfoRtn:用户登录信息结构地址。
* @param pErrorInfo:若请求失败，返回错误信息地址，该结构含有错误信息。
*/
void XSpeedTraderSpi::OnRspUserLogin( struct DFITCUserLoginInfoRtnField *pUserLoginInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo )
{
  OutputLog("XSpeedTraderSpi::OnRspUserLogin");

  this->login = true;

  this->OnResponse(OnRspUserLoginResponse,pUserLoginInfoRtn,pErrorInfo,pUserLoginInfoRtn->lRequestID);
}

/**
* 登出请求响应:当用户发出退出请求后，前置机返回响应此方法会被调用，通知用户退出状态。
* @param pUserLogoutInfoRtn:返回用户退出信息结构地址。
* @param pErrorInfo:若请求失败，返回错误信息地址。
*/
void XSpeedTraderSpi::OnRspUserLogout( struct DFITCUserLogoutInfoRtnField *pUserLogoutInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo )
{
  this->OnResponse(OnRspUserLogoutResponse,pUserLogoutInfoRtn,pErrorInfo,pUserLogoutInfoRtn->lRequestID);
}

/**
* 期货委托报单响应:当用户录入报单后，前置返回响应时该方法会被调用。
* @param pOrderRtn:返回用户下单信息结构地址。
* @param pErrorInfo:若请求失败，返回错误信息地址。
*/
void XSpeedTraderSpi::OnRspInsertOrder( struct DFITCOrderRspDataRtnField *pOrderRtn,struct DFITCErrorRtnFiled *pErrorInfo )
{
  this->OnResponse(OnRspInsertOrderResponse,pOrderRtn,pErrorInfo);
}

/**
* 期货委托撤单响应:当用户撤单后，前置返回响应是该方法会被调用。
* @param pOrderCanceledRtn:返回撤单响应信息结构地址。
* @param pErrorInfo:若请求失败，返回错误信息地址。
*/
void XSpeedTraderSpi::OnRspCancelOrder( struct DFITCOrderRspDataRtnField *pOrderCanceledRtn,struct DFITCErrorRtnFiled *pErrorInfo )
{
  this->OnResponse(OnRspCancelOrderResponse,pOrderCanceledRtn,pErrorInfo);
}

/* 期权委托报单响应:暂时不支持。*/    
//void XSpeedTraderSpi::OnRspInsertOptOrder( DFITCRspInsertOptOrderRtnField *pOptOrder )
//{
//  this->OnResponse(OnRspInsertOptOrderResponse,pOptOrder);
//}
//
//
///* 期权委托撤单响应:暂时不支持。*/   
//void XSpeedTraderSpi::OnRspCancelOptOrder( DFITCRspCancelOptOrderRtnField *pOptOrder )
//{
//  this->OnResponse(OnRspCancelOptOrderResponse,pOptOrder);
//}

/**
* 错误回报
* @param pErrorInfo:错误信息的结构地址。
*/
void XSpeedTraderSpi::OnRtnErrorMsg( struct DFITCErrorRtnFiled *pErrorInfo )
{
  this->OnResponse(OnRtnErrorMsgResponse,pErrorInfo,pErrorInfo);
}

/**
* 成交回报:当委托成功交易后次方法会被调用。
* @param pRtnMatchData:指向成交回报的结构的指针。
*/
void XSpeedTraderSpi::OnRtnMatchedInfo( struct DFITCMatchRtnField *pRtnMatchData )
{
  this->OnResponse(OnRtnMatchedInfoResponse,pRtnMatchData);
}

/**
* 委托回报:下单委托成功后，此方法会被调用。
* @param pRtnOrderData:指向委托回报地址的指针。
*/
void XSpeedTraderSpi::OnRtnOrder( struct DFITCOrderRtnField *pRtnOrderData )
{
  this->OnResponse(OnRtnOrderResponse,pRtnOrderData);
}

/**
* 撤单回报:当撤单成功后该方法会被调用。
* @param pCancelOrderData:指向撤单回报结构的地址，该结构体包含被撤单合约的相关信息。
*/
void XSpeedTraderSpi::OnRtnCancelOrder( struct DFITCOrderCanceledRtnField *pCancelOrderData )
{
  this->OnResponse(OnRtnCancelOrderResponse,pCancelOrderData);
}

/**
* 查询当日委托响应:当用户发出委托查询后，该方法会被调用。
* @param pRtnOrderData:指向委托回报结构的地址。
* @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
*/
void XSpeedTraderSpi::OnRspQryOrderInfo( struct DFITCOrderCommRtnField *pRtnOrderData, bool bIsLast )
{
  OutputLog("XSpeedTraderSpi::OnRspQryOrderInfo");
  this->OnResponse(OnRspQryOrderInfoResponse,pRtnOrderData,NULL,pRtnOrderData->lRequestID, bIsLast);
}

/**
* 查询当日成交响应:当用户发出成交查询后该方法会被调用。
* @param pRtnMatchData:指向成交回报结构的地址。
* @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
*/
void XSpeedTraderSpi::OnRspQryMatchInfo( struct DFITCMatchedRtnField *pRtnMatchData, bool bIsLast )
{
  this->OnResponse(OnRspQryMatchInfoResponse,pRtnMatchData,NULL,pRtnMatchData->lRequestID, bIsLast);
}

/**
* 持仓查询响应:当用户发出持仓查询指令后，前置返回响应时该方法会被调用。
* @param pPositionInfoRtn:返回持仓信息结构的地址。
* @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
* @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
*/
void XSpeedTraderSpi::OnRspQryPosition( struct DFITCPositionInfoRtnField *pPositionInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast )
{
  this->OnResponse(OnRspQryPositionResponse,pPositionInfoRtn,pErrorInfo,pPositionInfoRtn->lRequestID, bIsLast);
}

/**
* 客户资金查询响应:当用户发出资金查询指令后，前置返回响应时该方法会被调用。
* @param pCapitalInfoRtn:返回资金信息结构的地址。
* @param pErrorInfo:错误信息结构，如果客户资金查询发生错误，则返回错误信息。
*/
void XSpeedTraderSpi::OnRspCustomerCapital( struct DFITCCapitalInfoRtnField *pCapitalInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo )
{
  OutputLog("XSpeedTraderSpi::OnRspCustomerCapital");
  this->OnResponse(OnRspCustomerCapitalResponse,pCapitalInfoRtn,pErrorInfo,pCapitalInfoRtn->requestID,true);
}

/**
* 交易所合约查询响应:当用户发出合约查询指令后，前置返回响应时该方法会被调用。
* @param pInstrumentData:返回合约信息结构的地址。
* @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
* @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
*/
void XSpeedTraderSpi::OnRspQryExchangeInstrument( struct DFITCExchangeInstrumentRtnField *pInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast )
{
  this->OnResponse(OnRspQryExchangeInstrumentResponse,pInstrumentData,pErrorInfo,pInstrumentData->lRequestID, bIsLast);
}

/**
* 套利合约查询响应:当用户发出套利合约查询指令后，前置返回响应时该方法会被调用。
* @param pAbiInstrumentData:返回套利合约信息结构的地址。
* @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
* @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
*/
void XSpeedTraderSpi::OnRspArbitrageInstrument( struct DFITCAbiInstrumentRtnField *pAbiInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast )
{
  this->OnResponse(OnRspArbitrageInstrumentResponse,pErrorInfo, pAbiInstrumentData->lRequestID, bIsLast);
}

/**
* 查询指定合约响应:当用户发出指定合约查询指令后，前置返回响应时该方法会被调用。
* @param pInstrument:返回指定合约信息结构的地址。
*/
void XSpeedTraderSpi::OnRspQrySpecifyInstrument( struct DFITCInstrumentRtnField *pInstrument )
{
  this->OnResponse(OnRspQrySpecifyInstrumentResponse,pInstrument,pInstrument->lRequestID);
}

void XSpeedTraderSpi::OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, DFITCErrorRtnFiled *pRspInfo, int nRequestID, bool bIsLast)
{
  if(this->callback)
  {
    //OutputLog("XSpeedTraderSpi::OnResponse.InvokeCallback");
    this->callback(type,pRspData,pRspInfo,nRequestID,bIsLast);
  }
}