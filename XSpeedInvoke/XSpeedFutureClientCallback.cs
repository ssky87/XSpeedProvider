using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CalmBeltFund.Trading.XSpeed
{
  /// <summary>
  /// 回调函数指针
  /// </summary>
  /// <param name="type"></param>
  /// <param name="pData"></param>
  /// <param name="pRspInfo"></param>
  /// <param name="requestID"></param>
  /// <param name="isLast"></param>
  public delegate void ResponseCallback(int type, IntPtr pData, IntPtr pRspInfo, int requestID, [MarshalAs(UnmanagedType.U1)]bool isLast);


  public class XSpeedResponseInfo
  {
    public int ErrorID { get; set; }
    public string Message { get; set; }

    internal XSpeedResponseInfo()
    {
      this.ErrorID = 0;
      this.Message = "";
    }

    public static XSpeedResponseInfo Empty
    {
      get
      {
        XSpeedResponseInfo info = new XSpeedResponseInfo();
        return info;
      }
    }
  }

  public class XSpeedEventArgs : EventArgs
  {
    public XSpeedResponseInfo ResponseInfo { get; internal set; }
    public int RequestID { get; internal set; }

    public XSpeedEventArgs(XSpeedResponseInfo rspInfo, int requestID)
    {
      this.ResponseInfo = rspInfo;
      this.RequestID = requestID;
    }

    public XSpeedEventArgs(XSpeedResponseInfo rspInfo)
      : this(rspInfo, 0)
    { }

    public XSpeedEventArgs()
      : this(XSpeedResponseInfo.Empty, 0)
    { }
  }

  public class XSpeedEventArgs<T> : XSpeedEventArgs
  {
    T value;

    public object RequestData { get; internal set; }

    public T Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    public XSpeedEventArgs(T value)
      : base()
    {
      this.value = value;
    }

    internal XSpeedEventArgs(T value, XSpeedResponseInfo rspInfo)
      : this(value, rspInfo, 0)
    {

    }

    internal XSpeedEventArgs(T value, XSpeedResponseInfo rspInfo, int requestID)
      : base(rspInfo, requestID)
    {
      this.value = value;
    }
  }

  /// <summary>
  /// 返回的数据类型
  /// </summary>
  public class ResponseDataTypeAttribute : Attribute
  {
    public Type Type { get; set; }

    public ResponseDataTypeAttribute(Type value)
    {
      this.Type = value;
    }
  }



  public class TaskBase<T>
  {
    T action;
    int requestID;
    object parameter;

    public T Action
    {
      get { return action; }
      set { action = value; }
    }

    public object Parameter
    {
      get { return parameter; }
      set { parameter = value; }
    }

    public int RequestID
    {
      get { return requestID; }
      set { requestID = value; }
    }
  }


  /// <summary>
  /// 请求动作
  /// </summary>
  public enum XSpeedRequestAction : int
  {
    /// <summary>
    /// 创建交易接口
    /// </summary>
    TraderApiCreate = 1,

    /// <summary>
    /// 创建交易接口
    /// </summary>
    TraderApiInit,

    /// <summary>
    /// 删除接口对象本身
    /// </summary>
    TraderApiRelease,

    /// <summary>
    /// 用户登录请求
    /// </summary>
    TraderApiUserLoginAction,

    /// <summary>
    /// 登出请求
    /// </summary>
    TraderApiUserLogoutAction,

    
    InsertOrderAction,
    InsertLossProfitOrderAction,
    InsertAbiOrderAction,
    InsertOptOrderAction,
    CancelOptOrderAction,
    CancelOrderAction,
    QueryPositionAction,
    QueryCustomerCapitalAction,
    QueryExchangeInstrumentAction,
    QueryArbitrageInstrumentAction,
    QueryOrderInfoAction,
    QueryMatchInfoAction,
    QuerySpecifyInstrument,

    ///创建MdApi
    ///@param pszFlowPath 存贮订阅信息文件的目录，默认为当前目录
    ///@return 创建出的UserApi
    ///modify for udp marketdata
    MarketDataCreate,

    ///删除接口对象本身
    ///@remark 不再使用本接口对象时,调用该函数删除接口对象
    MarketDataRelease,

    ///用户登录请求
    MarketDataUserLoginAction,

    ///登出请求
    MarketDataUserLogoutAction,

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

  }

  /// <summary>
  /// 响应类型
  /// </summary>
  public enum XSpeedResponseType : int
  {

    /// <summary>
    ///  网络连接正常响应
    /// </summary>
    [ResponseDataType(null)]
    FrontConnectedResponse,

    /// <summary>
    /// ///
    /// 网络连接不正常响应：当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
    /// @param  nReason:错误原因。
    ///        0x1001 网络读失败
    ///        0x1002 网络写失败
    ///        0x2001 接收心跳超时
    ///        0x2002 发送心跳失败 
    ///        0x2003 收到错误报文  
    /// </summary>
    [ResponseDataType(null)]
    FrontDisconnectedResponse,

    /// <summary>
    /// ///
    /// 登陆请求响应:当用户发出登录请求后，前置机返回响应时此方法会被调用，通知用户登录是否成功。
    /// </summary>
    [ResponseDataType(typeof(DFITCUserLoginInfoRtnField))]
    UserLoginResponse,

    /// <summary>
    /// 登出请求响应:当用户发出退出请求后，前置机返回响应此方法会被调用，通知用户退出状态。
    /// </summary>
    [ResponseDataType(typeof(DFITCUserLogoutInfoRtnField))]
    UserLogoutResponse,

    /// <summary>
    /// 期货委托报单响应:当用户录入报单后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCOrderRspDataRtnField))]
    InsertOrderResponse,

    /// <summary>
    /// 期货委托撤单响应:当用户撤单后，前置返回响应是该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCOrderRspDataRtnField))]
    CancelOrderResponse,

    /// <summary>
    ///  期权委托报单响应:暂时不支持。
    /// </summary>
    [ResponseDataType(typeof(DFITCRspInsertOptOrderRtnField))]
    InsertOptOrderResponse,

    /// <summary>
    ///  期权委托撤单响应:暂时不支持。
    /// </summary>
    [ResponseDataType(typeof(DFITCRspCancelOptOrderRtnField))]
    CancelOptOrderResponse,

    /// <summary>
    /// 错误回报
    /// </summary>
    [ResponseDataType(typeof(DFITCErrorRtnFiled))]
    ReturnErrorMsgResponse,

    /// <summary>
    /// 成交回报:当委托成功交易后次方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCMatchRtnField))]
    ReturnMatchedInfoResponse,

    /// <summary>
    /// 委托回报:下单委托成功后，此方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCOrderRtnField))]
    ReturnOrderResponse,

    /// <summary>
    /// 撤单回报:当撤单成功后该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCOrderCanceledRtnField))]
    ReturnCancelOrderResponse,

    /// <summary>
    /// 查询当日委托响应:当用户发出委托查询后，该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCOrderCommRtnField))]
    QueryOrderInfoResponse,

    /// <summary>
    /// 查询当日成交响应:当用户发出成交查询后该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCMatchedRtnField))]
    QueryMatchInfoResponse,

    /// <summary>
    /// 持仓查询响应:当用户发出持仓查询指令后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCPositionInfoRtnField))]
    QueryPositionResponse,

    /// <summary>
    /// 客户资金查询响应:当用户发出资金查询指令后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCCapitalInfoRtnField))]
    CustomerCapitalResponse,

    /// <summary>
    /// 交易所合约查询响应:当用户发出合约查询指令后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCExchangeInstrumentRtnField))]
    QueryExchangeInstrumentResponse,

    /// <summary>
    /// 套利合约查询响应:当用户发出套利合约查询指令后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCAbiInstrumentRtnField))]
    ArbitrageInstrumentResponse,

    /// <summary>
    /// 查询指定合约响应:当用户发出指定合约查询指令后，前置返回响应时该方法会被调用。
    /// </summary>
    [ResponseDataType(typeof(DFITCInstrumentRtnField))]
    QuerySpecifyInstrumentResponse,

  }
}
