/**
 * 版权所有(C)2012-2016, 大连飞创信息技术有限公司
 * 文件名称：DFITCTraderApi.h
 * 文件说明：定义XSpeed交易接口
 * 当前版本：1.0.0
 * 作者：XSpeed项目组
 * 发布日期：2012年8月28日
 */
 
#ifndef DFITCTRADERAPI_H_
#define DFITCTRADERAPI_H_

#include "DFITCAPISTRUCT.h"

namespace DFITCXSPEEDAPI
{
#ifdef DFITCTRADERAPI_EXPORTS
#define DFITCTRADERAPI_API __declspec(dllexport)
#else
#define DFITCTRADERAPI_API __declspec(dllimport)
#endif

class DFITCTraderSpi
{
public:
	   
    /* 网络连接正常响应:当客户端与交易后台需建立起通信连接时（还未登录前），客户端API会自动检测与前置机之间的连接，
     * 当网络可用，将自动建立连接，并调用该方法通知客户端， 客户端可以在实现该方法时，重新使用资金账号进行登录。（该方法是在Api和前置机建立连接后被调用，该调用仅仅是说明tcp连接已经建立成功。用户需要自行登录才能进行后续的业务操作。登录失败则此方法不会被调用。）
     */	     
    virtual void OnFrontConnected(){};
	
    /**
     * 网络连接不正常响应：当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
     * @param  nReason:错误原因。
     *        0x1001 网络读失败
     *        0x1002 网络写失败
     *        0x2001 接收心跳超时
     *        0x2002 发送心跳失败 
     *        0x2003 收到错误报文  
     */
    virtual void OnFrontDisconnected( int nReason ){};
	
    /**
     * 登陆请求响应:当用户发出登录请求后，前置机返回响应时此方法会被调用，通知用户登录是否成功。
     * @param pUserLoginInfoRtn:用户登录信息结构地址。
     * @param pErrorInfo:若请求失败，返回错误信息地址，该结构含有错误信息。
     */
    virtual void OnRspUserLogin( struct DFITCUserLoginInfoRtnField *pUserLoginInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo ){};
	
    /**
     * 登出请求响应:当用户发出退出请求后，前置机返回响应此方法会被调用，通知用户退出状态。
     * @param pUserLogoutInfoRtn:返回用户退出信息结构地址。
     * @param pErrorInfo:若请求失败，返回错误信息地址。
     */
    virtual void OnRspUserLogout( struct DFITCUserLogoutInfoRtnField *pUserLogoutInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo ){};
	
    /**
     * 期货委托报单响应:当用户录入报单后，前置返回响应时该方法会被调用。
     * @param pOrderRtn:返回用户下单信息结构地址。
     * @param pErrorInfo:若请求失败，返回错误信息地址。
     */
    virtual void OnRspInsertOrder( struct DFITCOrderRspDataRtnField *pOrderRtn,struct DFITCErrorRtnFiled *pErrorInfo ){};
	
    /**
     * 期货委托撤单响应:当用户撤单后，前置返回响应是该方法会被调用。
     * @param pOrderCanceledRtn:返回撤单响应信息结构地址。
     * @param pErrorInfo:若请求失败，返回错误信息地址。
     */
    virtual void OnRspCancelOrder( struct DFITCOrderRspDataRtnField *pOrderCanceledRtn,struct DFITCErrorRtnFiled *pErrorInfo ){};

    /* 期权委托报单响应:暂时不支持。*/    
    virtual void OnRspInsertOptOrder( DFITCRspInsertOptOrderRtnField *pOptOrder ){};

    
    /* 期权委托撤单响应:暂时不支持。*/   
    virtual void OnRspCancelOptOrder( DFITCRspCancelOptOrderRtnField *pOptOrder ){};

    /**
     * 错误回报
     * @param pErrorInfo:错误信息的结构地址。
     */
    virtual void OnRtnErrorMsg( struct DFITCErrorRtnFiled *pErrorInfo ){};
	
    /**
     * 成交回报:当委托成功交易后次方法会被调用。
     * @param pRtnMatchData:指向成交回报的结构的指针。
     */
    virtual void OnRtnMatchedInfo( struct DFITCMatchRtnField *pRtnMatchData ){};
	
    /**
     * 委托回报:下单委托成功后，此方法会被调用。
     * @param pRtnOrderData:指向委托回报地址的指针。
     */
    virtual void OnRtnOrder( struct DFITCOrderRtnField *pRtnOrderData ){};
	
    /**
     * 撤单回报:当撤单成功后该方法会被调用。
     * @param pCancelOrderData:指向撤单回报结构的地址，该结构体包含被撤单合约的相关信息。
     */
    virtual void OnRtnCancelOrder( struct DFITCOrderCanceledRtnField *pCancelOrderData ){};
	
    /**
     * 查询当日委托响应:当用户发出委托查询后，该方法会被调用。
     * @param pRtnOrderData:指向委托回报结构的地址。
     * @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
     */
    virtual void OnRspQryOrderInfo( struct DFITCOrderCommRtnField *pRtnOrderData, bool bIsLast ){};
	
    /**
     * 查询当日成交响应:当用户发出成交查询后该方法会被调用。
     * @param pRtnMatchData:指向成交回报结构的地址。
     * @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
     */
    virtual void OnRspQryMatchInfo( struct DFITCMatchedRtnField *pRtnMatchData, bool bIsLast ){};
	
    /**
     * 持仓查询响应:当用户发出持仓查询指令后，前置返回响应时该方法会被调用。
     * @param pPositionInfoRtn:返回持仓信息结构的地址。
     * @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
     * @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
     */
    virtual void OnRspQryPosition( struct DFITCPositionInfoRtnField *pPositionInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast ){};
	
    /**
     * 客户资金查询响应:当用户发出资金查询指令后，前置返回响应时该方法会被调用。
     * @param pCapitalInfoRtn:返回资金信息结构的地址。
     * @param pErrorInfo:错误信息结构，如果客户资金查询发生错误，则返回错误信息。
     */
    virtual void OnRspCustomerCapital( struct DFITCCapitalInfoRtnField *pCapitalInfoRtn,struct DFITCErrorRtnFiled *pErrorInfo ){};
	
    /**
     * 交易所合约查询响应:当用户发出合约查询指令后，前置返回响应时该方法会被调用。
     * @param pInstrumentData:返回合约信息结构的地址。
     * @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
     * @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
     */
    virtual void OnRspQryExchangeInstrument( struct DFITCExchangeInstrumentRtnField *pInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast ){};
	
    /**
     * 套利合约查询响应:当用户发出套利合约查询指令后，前置返回响应时该方法会被调用。
     * @param pAbiInstrumentData:返回套利合约信息结构的地址。
     * @param pErrorInfo:错误信息结构，如果持仓查询发生错误，则返回错误信息。
     * @param bIsLast:表明是否是最后一条响应信息（0 -否   1 -是）。
     */
    virtual void OnRspArbitrageInstrument( struct DFITCAbiInstrumentRtnField *pAbiInstrumentData,struct DFITCErrorRtnFiled *pErrorInfo, bool bIsLast ){};
	
    /**
     * 查询指定合约响应:当用户发出指定合约查询指令后，前置返回响应时该方法会被调用。
     * @param pInstrument:返回指定合约信息结构的地址。
     */
    virtual void OnRspQrySpecifyInstrument( struct DFITCInstrumentRtnField *pInstrument ){};

};//end of DFITCTraderSpi

class DFITCTRADERAPI_API DFITCTraderApi
{
public:
    DFITCTraderApi();
    virtual ~DFITCTraderApi();
	
    /**
     * 静态函数，产生一个api实例
     * @return 创建出的UserApi
     */
    static DFITCTraderApi *CreateDFITCTraderApi();
	
    /**
     * 删除接口对象本身，不再使用本接口对象时,调用该函数删除接口对象。
     */
    virtual void Release();
	
    /**
     * 和服务器建立socket连接，并启动一个接收线程， 同时该方法注册一个回调函数集
     * @param pszFrontAddr:交易前置网络地址。
     *                     网络地址的格式为:"protocol://ipaddress:port",如"tcp://172.21.200.103:10910"
     *                     其中protocol的值为tcp格式。
     *                     ipaddress表示交易前置的IP,port表示交易前置的端口     
     * @param *pSpi:类DFITCMdSpi对象实例
     * @return 0 - 初始化成功; -1 - 初始化失败。
     */
    virtual int Init( char *pszFrontAddr,DFITCTraderSpi *pSpi );
	
    /**
     * 等待接口线程结束运行。
     * @return 线程退出代码。
     */
    virtual int Join();
    
    //心跳
    virtual void HeartBeat();
	
    /**
     * 用户发出登陆请求
     * @param pUserLoginData:指向用户登录请求结构的地址。
     * @return 0 - 登录成功; 1 - 登录失败(登录失败为用户名或者登录密码有误)。
     */ 
    virtual int ReqUserLogin( struct DFITCUserLoginField *pUserLoginData );
	
    /**
     * 用户发出登出请求
     * @param pUserLogoutData:指向用户登录请出结构的地址。
     * @return 0 - 登录成功; 1 - 登出失败。
     */ 
    virtual int ReqUserLogout( struct DFITCUserLogoutField *pUserLogoutData );
	
    /**
     * 期货委托报单请求。
     * @param pInsertOrderData:用户请求报单信息结构地址。
     * @return 0 - 下单成功; 1 - 下单失败。
     */
    virtual int ReqInsertOrder( struct DFITCInsertOrderField *pInsertOrderData );

  
    /* 期货止盈止损报单请求:暂不支持。*/
    virtual int ReqInsertLossProfitOrder( struct DFITCLossProfitOrderField *pOrderData );
	 
    /* 期货套利报单请求:暂不支持。*/  
    virtual int ReqInsertAbiOrder( struct DFITCAbiOrderField *pAbiOrder );
    
    /*期权报单请求:暂不支持。*/
    virtual int ReqInsertOptOrder( DFITCOptionOrderField *pOptOrder );
        
    /* 期权撤单请求:暂不支持。*/    
    virtual int ReqCancelOptOrder( DFITCOptionOrderCancelField *pOptOrder );

    /**
     * 期货撤单请求。
     * @param pCancelOrderData:用户请求撤单信息结构地址。
     * @return 0 - 撤单成功; 1 - 撤单失败。(如果同时提供柜台委托号和本地委托号，则柜台维护号优先处理)
     */
    virtual int ReqCancelOrder( struct DFITCCancelOrderField *pCancelOrderData );
	
    /**
     * 持仓查询请求。
     * @param pPositionData:指向请求持仓查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。（如果没有提供合约代码，则查询全部持仓信息。）
     */
    virtual int ReqQryPosition( struct DFITCPositionField *pPositionData );
	
    /**
     * 客户资金查询请求。
     * @param pCapitalData:请求资金查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。(用户需要填充该结构的各个字段。)
     */
    virtual int ReqQryCustomerCapital( struct DFITCCapitalField *pCapitalData );
	
    /**
     * 查询交易所合约列表（非套利）。
     * @param pExchangeInstrumentData:交易所合约查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。
     */
    virtual int ReqQryExchangeInstrument( struct DFITCExchangeInstrumentField *pExchangeInstrumentData );

    /**
     * 查询交易所套利合约列表。
     * @param pAbtriInstrumentData:交易所套利合约查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。
     */
    virtual int ReqQryArbitrageInstrument( struct DFITCAbiInstrumentField *pAbtriInstrumentData );

    /**
     * 当日委托查询请求。
     * @param pOrderData:当日委托查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。
     */
    virtual int ReqQryOrderInfo( struct DFITCOrderField *pOrderData );

    /**
     * 当日成交查询请求。
     * @param pMatchData:当日成交查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。
     */
    virtual int ReqQryMatchInfo( struct DFITCMatchField *pMatchData );

    /**
     * 指定合约信息查询请求。
     * @param pInstrument:指定合约查询结构地址。
     * @return 0 - 查询成功; 1 - 查询失败。
     */
    virtual int ReqQrySpecifyInstrument( struct DFITCSpecificInstrumentField *pInstrument );

protected:
    static void DestoryDFITCTraderApi( DFITCTraderApi *pApi );
    DFITCTraderSpi *m_pSpi;
};//end of DFITCTraderApi
}//end of namespace
#endif