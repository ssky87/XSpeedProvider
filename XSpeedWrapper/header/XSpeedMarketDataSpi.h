#pragma once

#include "StdAfx.h"
using namespace DFITCXSPEEDAPI;
using namespace DFITCXSPEEDMDAPI;

class CTPMarketDataSpi : public DFITCMdSpi
{
public:

	CTPMarketDataSpi(XSpeedResponseCallback callback)
  {
    this->callback = callback;
  }
  
    //网络连接正常响应
    virtual void OnFrontConnected()
  {
    this->OnResponse(OnFrontConnectedResponse);
  }
		
    //网络连接不正常响应
    virtual void OnFrontDisconnected( int nReason )
  {
    this->OnResponse(OnFrontDisconnectedResponse,(void*)nReason);
  }
	
    /**
     * 登陆请求响应:当用户发出登录请求后，前置机返回响应时此方法会被调用，通知用户登录是否成功。
     * @param pRspUserLogin:用户登录信息结构地址。
     * @param pRspInfo:若请求失败，返回错误信息地址，该结构含有错误信息。
     */
    virtual void OnRspUserLogin(struct DFITCUserLoginInfoRtnField *pRspUserLogin, struct DFITCErrorRtnFiled *pRspInfo) 
  {
   this->OnResponse(OnRspUserLoginResponse,pRspUserLogin,pRspInfo);
  }
		
    /**
     * 登出请求响应:当用户发出退出请求后，前置机返回响应此方法会被调用，通知用户退出状态。
     * @param pRspUsrLogout:返回用户退出信息结构地址。
     * @param pRspInfo:若请求失败，返回错误信息地址。
     */
    virtual void OnRspUserLogout(struct DFITCUserLogoutInfoRtnField *pRspUsrLogout,struct DFITCErrorRtnFiled *pRspInfo) 
  {
    this->OnResponse(OnRspUserLogoutResponse,pRspUsrLogout,pRspInfo);
  }
		
    /*错误应答*/
    virtual void OnRspError(struct DFITCErrorRtnFiled *pRspInfo) 
  {
    this->OnResponse(OnRspErrorResponse,pRspInfo);
  }
	
    /**
     * 行情订阅应答:当用户发出行情订阅该方法会被调用。
     * @param pSpecificInstrument:指向合约响应结构，该结构包含合约的相关信息。
     * @param pRspInfo:错误信息，如果发生错误，该结构含有错误信息。
     */
    virtual void OnRspSubMarketData(struct DFITCSpecificInstrumentField *pSpecificInstrument, struct DFITCErrorRtnFiled *pRspInfo) 
  {
    this->OnResponse(OnRspSubMarketDataResponse,pSpecificInstrument,pRspInfo);
  }
	
    /**
     * 取消订阅行情应答:当用户发出退订请求后该方法会被调用。
     * @param pSpecificInstrument:指向合约响应结构，该结构包含合约的相关信息。
     * @param pRspInfo:错误信息，如果发生错误，该结构含有错误信息。
     */
    virtual void OnRspUnSubMarketData(struct DFITCSpecificInstrumentField *pSpecificInstrument, struct DFITCErrorRtnFiled *pRspInfo) 
  {
    this->OnResponse(OnRspUnSubMarketDataResponse,pSpecificInstrument,pRspInfo);
  }
	
    /**
     * 行情消息应答:如果订阅行情成功且有行情返回时，该方法会被调用。
     * @param pMarketDataField:指向行情信息结构的指针，结构体中包含具体的行情信息。
     */
    virtual void OnMarketData(struct DFITCDepthMarketDataField *pMarketDataField) 
  {
    this->OnResponse(OnMarketDataResponse,pMarketDataField);
  }
	
private:
	

	/*    回调函数指针    */
  XSpeedResponseCallback callback;

  
  void OnResponse(XSPEED_RESPONSE_TYPE type, void *pRspData, DFITCErrorRtnFiled *pRspInfo, int nRequestID, bool bIsLast)
  {
    if(this->callback)
    {
      //this->callback(type,pRspData,pRspInfo,nRequestID,bIsLast);
    }
  }

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


