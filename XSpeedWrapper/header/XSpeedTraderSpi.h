#pragma once
#include "StdAfx.h"
using namespace DFITCXSPEEDAPI;
using namespace DFITCXSPEEDMDAPI;

class XSpeedTraderSpi : public DFITCTraderSpi
{
public:

  bool connected;
  bool login;
    /*    回调函数指针    */
  XSpeedResponseCallback callback;

  XSpeedTraderSpi();

  virtual void OnFrontConnected();
  virtual void OnFrontDisconnected( int nReason );

  //客户请求登录响应
  virtual void OnRspUserLogin( struct DFITCUserLoginInfoRtnField *pUserLoginInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo );
  //客户退出请求响应
  virtual void OnRspUserLogout( struct DFITCUserLogoutInfoRtnField *pUserLogoutInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo );
  //委托下单响应
  virtual void OnRspInsertOrder( struct DFITCOrderRspDataRtnField *pOrderRtn,struct DFITCErrorRtnFiled *pErrorInfo );
  //委托撤单响应
  virtual void OnRspCancelOrder( struct DFITCOrderRspDataRtnField *pOrderCanceledRtn,struct DFITCErrorRtnFiled *pErrorInfo );
  //持仓查询响应
  virtual void OnRspQryPosition( struct DFITCPositionInfoRtnField *pPositionInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo , bool bIsLast);
  //客户资金查询响应
  virtual void OnRspCustomerCapital( struct DFITCCapitalInfoRtnField *pCapitalInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo );
  //交易所合约查询响应
  virtual void OnRspQryExchangeInstrument( struct DFITCExchangeInstrumentRtnField *pInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo , bool bIsLast );
  //套利合约查询响应
  virtual void OnRspArbitrageInstrument( struct DFITCAbiInstrumentRtnField *pAbiInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo , bool bIsLast );
  //查询指定合约信息
  virtual void OnRspQrySpecifyInstrument( struct DFITCInstrumentRtnField *pInstrument );
  //错误回报
  virtual void OnRtnErrorMsg( struct DFITCErrorRtnFiled *pErrorInfo );
  //成交回报
  virtual void OnRtnMatchedInfo( struct DFITCMatchRtnField *pRtnMatchData );
  //委托回报
  virtual void OnRtnOrder( struct DFITCOrderRtnField *pRtnMatchData);
  //撤单回报
  virtual void OnRtnCancelOrder( struct DFITCOrderCanceledRtnField *pCanncelOrderData );

  virtual void OnRspQryOrderInfo( struct DFITCOrderCommRtnField *pRtnOrderData , bool bIsLast );
  virtual void OnRspQryMatchInfo( struct DFITCMatchedRtnField *pRtnMatchData , bool bIsLast );


private:





void XSpeedTraderSpi::OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, DFITCErrorRtnFiled *pRspInfo, int nRequestID, bool bIsLast);

  void OnResponse(XSPEED_RESPONSE_TYPE type, DFITCErrorRtnFiled *pRspInfo, int nRequestID, bool bIsLast)
  {
    OnResponse(type,NULL,pRspInfo,nRequestID,bIsLast);
  }

  void OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, DFITCErrorRtnFiled *pRspInfo, bool bIsLast)
  {
    OnResponse(type,pRspData,pRspInfo,0,bIsLast);
  }


  void OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, DFITCErrorRtnFiled *pRspInfo)
  {
    OnResponse(type,pRspData,pRspInfo,0,TRUE);
  }

  void OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, bool bIsLast)
  {
    OnResponse(type,pRspData,NULL,0,TRUE);
  }

  void OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData)
  {
    OnResponse(type,pRspData,NULL,0,TRUE);
  }

  void OnResponse(XSPEED_RESPONSE_TYPE type)
  {
    OnResponse(type,NULL,NULL,0,TRUE);
  }

};
