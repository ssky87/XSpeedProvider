/**
 * 版权所有(C)2012-2016, 大连飞创信息技术有限公司
 * 文件名称：DFITCApiStruct.h
 * 文件说明：定义接口所需的数据接口
 * 当前版本：1.0.0
 * 作者：XSpeed项目组
 * 发布日期：2012年8月28日
 */

#ifndef DFITCAPISTRUCT_H_
#define DFITCAPISTRUCT_H_

#ifndef DFITCAPIDATATYPE_H
#include "DFITCAPIDATATYPE.h"
#endif


//心跳包
struct DFITCTimeOutField
{
    long lRequestID;                                //请求ID
};

//请求报单数据类型(基本报单)
struct DFITCInsertOrderField
{
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCPriceType insertPrice;                     //报单价格
    DFITCAmountType orderAmount;                    //报单数量
    DFITCBuySellTypeType  buySellType;              //买卖标志
    DFITCOpenCloseTypeType openCloseType;           //开平标志
    DFITCSpeculatorType speculator;                 //投保类型
    DFITCIsAutoOrderType isAutoOrder;               //是否为自动单
    DFITCOrderTypeType orderType;                   //报单类型 限价 、市价
    DFITCOrderPropertyType orderProperty;           //报单属性 FAK、FOK
};

///////////////////////////////////////////////
///请求报单数据类型(扩展报单) 暂不支持
///扩展报单主要包括：
///1.FAK，2.FOK，3.止盈止损，4.市价单
///////////////////////////////////////////////
struct DFITCLossProfitOrderField
{
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCPriceType insertPrice;                     //报单价格
    DFITCAmountType orderAmount;                    //报单数量
    DFITCBuySellTypeType  buySellType;              //买卖标志
    DFITCOpenCloseTypeType openCloseType;           //开平标志
    DFITCSpeculatorType speculator;                 //投保类型
    DFITCOrderTypeType orderType;                   //报单类型
    DFITCOrderPropertyType orderProperty;           //报单属性
    DFITCPriceType downTriggerPrice;                //下跌触发价差
    DFITCPriceType riseTriggerPrice;                //上涨触发价差
    DFITCLossProfitTypeType lossID;                 //止损标志
    DFITCPriceType downCommPrice;                   //下跌委托价差
    DFITCLossProfitTypeType profitID;               //止盈标志
    DFITCPriceType riseCommPrice;                   //上涨委托价差
    DFITCIsAutoOrderType isAutoOrder;               //是否为自动单 
};

///////////////////////////////////////////////
///请求报单数据类型(套利报单)
///////////////////////////////////////////////
struct DFITCAbiOrderField
{
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCPriceType insertPrice;                     //报单价格
    DFITCAmountType orderAmount;                    //报单数量
    DFITCBuySellTypeType  buySellType;              //买卖标志
    DFITCOpenCloseTypeType openCloseType;           //开平标志
    DFITCInstrumentIDType instrumentID1;            //合约代码1
    DFITCPriceType insertPrice1;                    //报单价格1
    DFITCAmountType orderAmount1;                   //报单数量1
    DFITCBuySellTypeType  buySellType1;             //买卖标志1
    DFITCPriceType   predictInsterest;              //预计利息
    DFITCPriceType   triggerPrice;                  //触发价格
    DFITCPriceType   upDownPrice;                   //涨停板
    DFITCDateType    availableDate;                 //有效日期
    DFITCAmountType  lowestMatchAmount;             //最小成交量
    DFITCIsAutoOrderType isAutoOrder;               //是否为自动单
    DFITCOrderPropertyType orderProperty;           //报单属性
};

/////////////////////////////////////////////////////////
///期权数据结构
/////////////////////////////////////////////////////////

///期权报单数据类型
struct DFITCOptionOrderField
{
    DFITCAccountIDType accountID;                    //客户号
    DFITCInstrumentIDType instrumentID;              //合约代码
    DFITCPriceType insertPrice;                      //委托价格
    DFITCAmountType orderAmount;                     //委托数量
    DFITCBuySellTypeType  buySellType;               //买卖标志
    DFITCSpeculatorType speculator;                  //投保类型
    DFITCOpenCloseTypeType openCloseType;            //开平标志
    DFITCOrderTypeType orderType;                    //报单类型
    DFITCIsAutoOrderType isAutoOrder;                //是否为自动单 
    DFITCOptionTypeType  optionType;                 //期权类别:  1:看涨; 2:看跌
    DFITCInstrumentTypeType instrumentType;          //合约类型
};

///期权报单响应数据类型
struct DFITCRspInsertOptOrderRtnField
{
};

///期权撤单数据类型
struct DFITCOptionOrderCancelField
{
    DFITCAccountIDType accountID;                    //客户号
    DFITCExchangeIDType exchangeID;                  //交易所编码
    DFITCClientIDType  matchCode;                    //交易编码
    DFITCCancelTypeType cancelID;                    //撤销标志
    DFITCSPDOrderIDType spdOrderID;                  //柜台委托号
    DFITCIsAutoOrderType isAutoOrder;                //是否为自动单（申报标识）
    DFITCOptionTypeType  optionType;                 //期权类别:  1:看涨;  2:看跌
};
///期权撤单响应结构
struct DFITCRspCancelOptOrderRtnField
{
};

///撤单数据类型
struct DFITCCancelOrderField
{
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCInstrumentIDType instrumentID;             //合约代码
};

///委托响应类型
struct DFITCOrderRspDataRtnField
{
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCOrderAnswerStatusType  orderStatus;        //委托状态
};

///查询资金数据类型
struct DFITCCapitalField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
};

///查询持仓数据类型
struct DFITCPositionField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCInstrumentIDType instrumentID;             //合约代码
};

///交易所合约
struct DFITCExchangeInstrumentField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCExchangeIDType exchangeID;                 //交易所编码
};

///用户登录数据类型
struct DFITCUserLoginField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCPasswdType passwd;                         //密码
};

///用户退出类型
struct DFITCUserLogoutField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金帐号ID
    DFITCSessionIDType sessionID;                   //会话ID
};

///委托回报
struct DFITCOrderRtnField
{
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCOrderAnswerStatusType  orderStatus;        //委托状态
    DFITCSessionIDType sessionID;                   //会话ID
};

///成交回报
struct DFITCMatchRtnField
{
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCMatchIDType matchID;                       //成交编号
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCBuySellTypeType buySellType;               //买卖
    DFITCOpenCloseTypeType openCloseType;           //开平标志
    DFITCPriceType matchedPrice;                    //成交价格
    DFITCAmountType commAmount;                     //委托数量
    DFITCAmountType   matchedAmount;                //成交数量
    DFITCDateType matchedTime;                      //成交时间
    DFITCPriceType insertPrice;                     //报价
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCMatchType matchType;                       //成交类型
    DFITCSpeculatorType speculator;                 //投保
    DFITCExchangeIDType exchangeID;                 //交易所ID
    DFITCFeeType fee;                               //手续费	
    DFITCSessionIDType sessionID;                   //会话标识	
};

///撤单回报
struct DFITCOrderCanceledRtnField
{
    DFITCLocalOrderIDType   localOrderID;           //本地委托号
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCPriceType        insertPrice;              //报单价格
    DFITCBuySellTypeType buySellType;               //买卖类型
    DFITCOpenCloseTypeType openCloseType;           //开平标志
    DFITCAmountType    cancelAmount;                //撤单数量
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCSpeculatorType speculator;                 //投保
    DFITCExchangeIDType exchangeID;                 //交易所ID
    DFITCDateType canceledTime;                     //撤单时间
    DFITCSessionIDType sessionID;                   //会话标识	
};

///错误信息
struct DFITCErrorRtnFiled
{
    DFITCErrorIDType  nErrorID;                     //错误ID
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCErrorMsgInfoType errorMsg;                 //错误信息
};

///返回资金信息
struct DFITCCapitalInfoRtnField
{
    long requestID;                                 //请求ID
    DFITCAccountIDType accountID;                   //资金帐号
    DFITCEquityType preEquity;                      //上日权益
    DFITCEquityType todayEquity;                    //当日客户权益
    DFITCProfitLossType closeProfitLoss;            //平仓盈亏
    DFITCProfitLossType positionProfitLoss;         //持仓盈亏
    DFITCProfitLossType frozenMargin;               //委托冻结保证金
    DFITCProfitLossType margin;                     //持仓保证金
    DFITCProfitLossType fee;                        //当日手续费
    DFITCProfitLossType available;                  //可用资金
    DFITCProfitLossType withdraw;                   //可取资金
    DFITCRiskDegreeType  riskDegree;                //风险度
};



///返回持仓信息
struct DFITCPositionInfoRtnField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金帐号ID
    DFITCExchangeIDType exchangeID;                 //交易所代码
    DFITCInstrumentIDType instrumentID;             //合约号
    DFITCBuySellTypeType  buySellType;              //买卖
    DFITCPriceType openAvgPrice;                    //开仓均价
    DFITCPriceType positionAvgPrice;                //持仓均价
    DFITCAmountType positionAmount;                 //持仓量
    DFITCAmountType totalAvaiAmount;                //总可用
    DFITCAmountType todayAvaiAmount;                //今可用
    DFITCAmountType lastAvaiAmount;                 //昨可用
    DFITCAmountType todayAmount;                    //今仓
    DFITCAmountType lastAmount;                     //昨仓
    DFITCAmountType tradingAmount;                  //挂单量
    DFITCProfitLossType datePositionProfitLoss;     //盯市持仓盈亏
    DFITCProfitLossType dateCloseProfitLoss;        //盯市平仓盈亏
    DFITCProfitLossType floatProfitLoss;            //浮动盈亏
    DFITCProfitLossType dMargin;                    //占用保证金
    DFITCSpeculatorType speculator;                 //投保类别
    DFITCClientIDType clientID;                     //交易编码
    DFITCPriceType    lastPrice;                    //昨结算价
};

///用户登录返回信息
struct DFITCUserLoginInfoRtnField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金帐号ID
    DFITCAccountLoginResultType loginResult;        //登录结果
    DFITCLocalOrderIDType initLocalOrderID;         //初始本地委托号
    DFITCSessionIDType sessionID;                   //sessionID
    DFITCErrorIDType  nErrorID;                     //错误ID
    DFITCErrorMsgInfoType errorMsg;                 //错误信息
};

///用户退出返回信息
struct DFITCUserLogoutInfoRtnField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCAccountLogoutResultType logoutResult;      //退出结果
    DFITCErrorIDType  nErrorID;                     //错误ID
    DFITCErrorMsgInfoType errorMsg;                 //错误信息
};

///套利合约查询
struct DFITCAbiInstrumentField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCExchangeIDType exchangeID;                 //交易所代码
};

///套利合约返回信息
struct DFITCAbiInstrumentRtnField
{
    long lRequestID;                                //请求ID
    DFITCExchangeIDType exchangeID;                 //交易所编码
    DFITCInstrumentIDType InstrumentID;             //合约代码
    DFITCVarietyNameType VarietyName;               //品种名称
};

///指定的合约
struct DFITCSpecificInstrumentField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
    DFITCInstrumentIDType InstrumentID;             //合约代码
    DFITCExchangeIDType exchangeID;                 //交易所ID
};

///交易所合约返回信息
struct DFITCExchangeInstrumentRtnField
{
    long lRequestID;                                //请求ID
    DFITCExchangeIDType exchangeID;                 //交易所编码
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCVarietyNameType VarietyName;               //品种名称
};

///委托查询数据结构
struct DFITCOrderField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
};

///成交查询数据结构
struct DFITCMatchField
{
    long lRequestID;                                //请求ID
    DFITCAccountIDType accountID;                   //资金账户ID
};

///委托查询响应数据结构
struct DFITCOrderCommRtnField
{
    long lRequestID;                                //请求ID
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号  
    DFITCOrderAnswerStatusType orderStatus;         //委托状态                            
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCBuySellTypeType buySellType;               //买卖
    DFITCOpenCloseTypeType openClose;               //开平标志
    DFITCPriceType insertPrice;                     //委托价
    DFITCAmountType orderAmount;                    //委托数量
    DFITCPriceType matchedPrice;                    //成交价格
    DFITCAmountType matchedAmount;                  //成交数量
    DFITCAmountType cancelAmount;                   //撤单数量
    DFITCMatchType orderType;                       //委托单类别
    DFITCSpeculatorType speculator;                 //投保
    DFITCDateType commTime;                         //委托时间
    DFITCDateType submitTime;                       //申报时间
    DFITCClientIDType clientID;                     //交易编码
    DFITCExchangeIDType exchangeID;                 //交易所ID
    DFITCFrontAddrType operStation;                 //委托地址
    DFITCAccountIDType  accountID;                  //客户号
};

//成交查询数据响应
struct DFITCMatchedRtnField
{
    long lRequestID;                                //请求ID
    DFITCSPDOrderIDType spdOrderID;                 //柜台委托号
    DFITCExchangeIDType exchangeID;                 //交易所ID
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCBuySellTypeType  buySellType;              //买卖
    DFITCOpenCloseTypeType openClose;               //开平
    DFITCPriceType matchedPrice;                    //成交价格
    DFITCAmountType matchedAmount;                  //成交数量
    DFITCPriceType matchedMort;                     //成交金额
    DFITCSpeculatorType speculator;                 //投保类别
    DFITCDateType matchedTime;                      //成交时间
    DFITCMatchIDType matchedID;                     //成交编号
    DFITCLocalOrderIDType localOrderID;             //本地委托号
    DFITCClientIDType clientID;                     //交易编码
    DFITCOrderCommTypeType commOrderType;           //报单类别
};

///返回合约信息数据结构
struct DFITCInstrumentRtnField
{
    long lRequestID;
    DFITCInstrumentIDType instrumentID;             //合约代码
    DFITCRatioType longMarginRatio;                 //多头保证金率
    DFITCRatioType shortMarginRatio;                //空头保证金率
    DFITCRatioType openFeeVolRatio;                 //开仓手续费 按手数计算
    DFITCRatioType closeFeeVolRatio;                //平仓手续费 按手数计算
    DFITCRatioType closeTodayFeeVolRatio;           //平今手续费 按手数计算
    DFITCRatioType openFeeAmtRatio;                 //开仓手续费率 按金额计算
    DFITCRatioType closeFeeAmtRatio;                //平仓手续费率 按金额计算
    DFITCRatioType closeTodayFeeAmtRatio;           //平今手续费率 按金额计算	
};

///深度行情
struct DFITCDepthMarketDataField
{
    DFITCDateType   tradingDay;                     //交易日
    DFITCInstrumentIDType  instrumentID;            //合约代码
    DFITCExchangeIDType exchangeID;                 //交易所代码
    DFITCInstrumentIDType exchangeInstID;           //合约在交易所的代码
    DFITCPriceType  lastPrice;                      //最新价
    DFITCPriceType  preSettlementPrice;             //上次结算价
    DFITCPriceType  preClosePrice;                  //昨收盘
    DFITCAmountType preOpenInterest;                //昨持仓量
    DFITCPriceType  openPrice;                      //今开盘
    DFITCPriceType  highestPrice;                   //最高价
    DFITCPriceType  lowestPrice;                    //最低价
    DFITCAmountType Volume;                         //数量
    DFITCPriceType  turnover;                       //成交金额
    DFITCAmountType openInterest;                   //持仓量
    DFITCPriceType  closePrice;                     //今收盘
    DFITCPriceType  settlementPrice;                //本次结算价
    DFITCPriceType  upperLimitPrice;                //涨停板价
    DFITCPriceType  lowerLimitPrice;                //跌停板价
    DFITCDeltaType  preDelta;                       //昨虚实度
    DFITCDeltaType  currDelta;                      //今虚实度
    DFITCDateType UpdateTime;                       //最后修改时间
    DFITCMilliSecType  UpdateMillisec;              //最后修改毫秒
    DFITCPriceType  BidPrice1;                      //申买价一
    DFITCVolumeType BidVolume1;                     //申买量一
    DFITCPriceType  AskPrice1;                      //申卖价一
    DFITCVolumeType AskVolume1;                     //申卖量一
    DFITCPriceType  BidPrice2;                      //申买价二
    DFITCVolumeType BidVolume2;                     //申买量二
    DFITCPriceType  AskPrice2;                      //申卖价二
    DFITCVolumeType AskVolume2;                     //申卖量二
    DFITCPriceType  BidPrice3;                      //申买价三
    DFITCVolumeType BidVolume3;                     //申买量三
    DFITCPriceType  AskPrice3;                      //申卖价三
    DFITCVolumeType AskVolume3;                     //申卖量三
    DFITCPriceType  BidPrice4;                      //申买价四
    DFITCVolumeType BidVolume4;                     //申买量四
    DFITCPriceType  AskPrice4;                      //申卖价四
    DFITCVolumeType AskVolume4;                     //申卖量四
    DFITCPriceType  BidPrice5;                      //申买价五
    DFITCVolumeType BidVolume5;                     //申买量五
    DFITCPriceType  AskPrice5;                      //申卖价五
    DFITCVolumeType AskVolume5;                     //申卖量五
    DFITCPriceType  AveragePrice;                   //当日均价
};

#endif
