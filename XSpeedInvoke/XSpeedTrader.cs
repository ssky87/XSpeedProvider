using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Collections;

namespace CalmBeltFund.Trading.XSpeed
{
  public partial class XSpeedTrader : XSpeedFutureClient
  {
    private string userProductInfo = "CalmBelt";

    //报单引用为NUMBER(12)，需为单调递增的数字
    //内部扩展其格式为：nnnnn.MMM.TT.ii
    //    nnnnn ： Seq，递增序列（按每秒钟一单计算：4H × 60min × 60sec = 14400，5位数字已够用）
    //    MMM   ： ModelID，交易模块识别序号
    //    TT    ： OrderType，区分订单类型
    //    ii    ： Index，组合报单中单腿合约的序号
    const int BaseOrderRef = 1000000;
    int orderRef = 0;

    bool isSettlementConfim = false;
    bool isInitialized = false;
    bool isSimulationServer = false;


    string loginTime = "";

    DateTime tradingDate = DateTime.MinValue;

    TimeSpan loginTimeDCE = TimeSpan.Zero;
    TimeSpan loginTimeCZCE = TimeSpan.Zero;
    TimeSpan loginTimeSHFE = TimeSpan.Zero;
    TimeSpan currentTimeDCE = TimeSpan.Zero;
    TimeSpan currentTimeCZCE = TimeSpan.Zero;
    TimeSpan currentTimeSHFE = TimeSpan.Zero;
    TimeSpan second = new TimeSpan(TimeSpan.TicksPerSecond);
    Stopwatch wallTimeStopwatch = new Stopwatch();
    Timer timer = null;


    DFITCCapitalInfoRtnField tradingAccount;

    //成交列表
    List<DFITCMatchedRtnField> tradeList = new List<DFITCMatchedRtnField>();
    //委托单列表
    List<DFITCOrderCommRtnField> orderList = new List<DFITCOrderCommRtnField>();
    //持仓列表
    List<DFITCPositionInfoRtnField> positionList = new List<DFITCPositionInfoRtnField>();


    /// <summary>
    /// 查询队列中是否存在任务
    /// </summary>
    public bool HasQueryTask
    {
      get { return this.queryTasks.Count > 0; }
    }

    /// <summary>
    /// 是否是模拟服务器
    /// </summary>
    public bool IsSimulationServer
    {
      get { return isSimulationServer; }
    }

    /// <summary>
    /// 终端标识
    /// </summary>
    public string UserProductInfo
    {
      get { return userProductInfo; }
      set { userProductInfo = value; }
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserKey
    {
      get { return string.Format("{0}@{1}@XSpeed", AccountID, BrokerID); }
    }
    
    public int CurrentOrderRef
    {
      get { return orderRef; }
    }

    /// <summary>
    /// 交易日
    /// </summary>
    public DateTime TradingDate
    {
      get { return tradingDate; }
    }

    /// <summary>
    /// 当前时间(大商所)
    /// </summary>
    public TimeSpan CurrentTimeDCE
    {
      get { return currentTimeDCE; }
    }

    /// <summary>
    /// 当前时间(郑交所)
    /// </summary>
    public TimeSpan CurrentTimeCZCE
    {
      get { return currentTimeCZCE; }
    }

    /// <summary>
    /// 当前时间(上期所)
    /// </summary>
    public TimeSpan CurrentTimeSHFE
    {
      get { return currentTimeSHFE; }
    }


    public DFITCCapitalInfoRtnField TradingAccount
    {
      get { return tradingAccount; }
      private set { tradingAccount = value; }
    }



    public List<DFITCOrderCommRtnField> OrderList
    {
      get { return orderList; }
    }

    public List<DFITCMatchedRtnField> TradeList
    {
      get { return tradeList; }
    }
    public List<DFITCPositionInfoRtnField> PositionList
    {
      get { return positionList; }
    }


    public XSpeedTrader()
    {
      timer = new Timer(new TimerCallback(this.UpdateTime));
    }

    /// <summary>
    /// 交易所时间
    /// </summary>
    /// <param name="obj"></param>
    void UpdateTime(object obj)
    {
      this.currentTimeDCE = this.loginTimeDCE.Add(wallTimeStopwatch.Elapsed);
      this.currentTimeCZCE = this.loginTimeCZCE.Add(wallTimeStopwatch.Elapsed);
      this.currentTimeSHFE = this.loginTimeSHFE.Add(wallTimeStopwatch.Elapsed);
    }

    public int IncrementOrderRef()
    {
      return Interlocked.Increment(ref this.orderRef);
    }


    /// <summary>
    /// 连接交易服务器
    /// </summary>
    /// <param name="frontAddress"></param>
    /// <param name="brokerID"></param>
    /// <param name="userID"></param>
    /// <param name="password"></param>
    public void Connect(string[] frontAddress, string brokerID, string userID, string password,bool restart = true)
    {

      this.BrokerID = brokerID;
      this.AccountID = userID;
      this.Password = password;

      //创建Trader实例
      try
      {
        //创建
        _instance = (IntPtr)Process(IntPtr.Zero, (int)XSpeedRequestAction.TraderApiCreate, 0, null);

        ResponseCallback callback = new ResponseCallback(ResponseHandler);
        //回调地址
        IntPtr hFunc = Marshal.GetFunctionPointerForDelegate(this.callback);

        //注册前置机地址
        string address = frontAddress[0];

        if (address.StartsWith("tcp://", StringComparison.OrdinalIgnoreCase) == false)
        {
          address = "tcp://" + address;
        }

        this.FrontAddress = address;

        //创建
        Process(_instance, (int)XSpeedRequestAction.TraderApiInit, hFunc, new StringBuilder(this.FrontAddress));

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    void UserLogin()
    {
      DFITCUserLoginField userLogin = new DFITCUserLoginField();

      userLogin.RequestID = this.CreateRequestID();
      userLogin.AccountID = this.AccountID;
      userLogin.Passwd = this.Password;

      int result = InvokeAPI(XSpeedRequestAction.TraderApiUserLoginAction, userLogin, userLogin.RequestID);

      Trace.WriteLine("XSpeedTrader:UserLogin : " + result.ToString());
    }

    void UserLogout()
    {
      DFITCUserLogoutField userLogout = new DFITCUserLogoutField();

      userLogout.RequestID = CreateRequestID();
      userLogout.AccountID = this.AccountID;
      userLogout.SessionID = this.SessionID;

      int result = InvokeAPI(XSpeedRequestAction.TraderApiUserLogoutAction, userLogout, userLogout.RequestID);
    }


    public void ChangePassword(string oldPassword,string newPassword,bool accountAmountPassword = false)
    {
      
    }

    #region 下单类请求

    public DFITCInsertOrderField InsertOrder(string symbolCode, double price, XSpeedBuySellType direct, int volume, XSpeedOpenCloseType flag,string orderRef = "")
    {
      DFITCInsertOrderField order = new DFITCInsertOrderField();

      order.AccountID = this.AccountID;

      //合约
      order.InstrumentID = symbolCode;

      order.LocalOrderID = this.IncrementOrderRef();

      //方向
      order.BuySellType = direct;
      //开平仓
      order.OpenCloseType = flag;
      //投机/套保
      order.Speculator = 0;

      ///价格
      order.InsertPrice = price;
      ///数量: 1
      order.OrderAmount = volume;
      //限价单
      order.OrderType = XSpeedOrderType.Limitorder;
      //自动单
      order.IsAutoOrder = XSpeedIsAutoOrderType.NonAutoOrder;
      //普通单
      order.OrderProperty = XSpeedOrderPropertyType.NON;

      SendInsertOrder(order);

      return order;
    }


    public int SendInsertOrder(DFITCInsertOrderField order)
    {
      return InvokeAPI(XSpeedRequestAction.InsertOrderAction, order, 0);
    }

    public DFITCCancelOrderField CancelOrder(string symbolCode, int spdOrderID,int localOrderID = 0)
    {
      DFITCCancelOrderField orderAction = new DFITCCancelOrderField();

      orderAction.AccountID = this.AccountID;
      orderAction.LocalOrderID = localOrderID;
      orderAction.InstrumentID = symbolCode;
      orderAction.SpdOrderID = spdOrderID;

      InvokeAPI(XSpeedRequestAction.CancelOrderAction, orderAction, 0);

      return orderAction;
    }

    #endregion

    #region 查询类请求


    public void QueryTradingAccount()
    {
      DFITCCapitalField req = new DFITCCapitalField();

      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;

      AddQueryTask(req, XSpeedRequestAction.QueryCustomerCapitalAction);
    }

    /// <summary>
    /// 查询合约
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryInstrument()
    {
      DFITCExchangeInstrumentField req;

      req = new DFITCExchangeInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.DCE;

      AddQueryTask(req, XSpeedRequestAction.QueryExchangeInstrumentAction);

      //上海
      req = new DFITCExchangeInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.SHFE;

      AddQueryTask(req, XSpeedRequestAction.QueryExchangeInstrumentAction);

      //郑州
      req = new DFITCExchangeInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.CZCE;

      AddQueryTask(req, XSpeedRequestAction.QueryExchangeInstrumentAction);

      //中金
      req = new DFITCExchangeInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.CFFEX;

      AddQueryTask(req, XSpeedRequestAction.QueryExchangeInstrumentAction);

    }


    /// <summary>
    /// 查询合约
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QueryArbitrageInstrument()
    {
      DFITCAbiInstrumentField req;

      req = new DFITCAbiInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.DCE;
      AddQueryTask(req, XSpeedRequestAction.QueryArbitrageInstrumentAction);


      req = new DFITCAbiInstrumentField();
      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = XSpeedExchangeIDType.CZCE;
      AddQueryTask(req, XSpeedRequestAction.QueryArbitrageInstrumentAction);
    }

    /// <summary>
    /// 查询合约
    /// </summary>
    /// <param name="instrumentID"></param>
    public void QuerySpecificInstrument(string exchangeID, string instrumentID)
    {
      DFITCSpecificInstrumentField req = new DFITCSpecificInstrumentField();

      req.RequestID = CreateRequestID();
      req.AccountID = this.AccountID;
      req.ExchangeID = exchangeID;
      req.InstrumentID = instrumentID;

      AddQueryTask(req, XSpeedRequestAction.QuerySpecifyInstrument);
    }

    /// <summary>
    /// 查询成交情况
    /// </summary>
    public void QueryTrade()
    {
      DFITCMatchField req = new DFITCMatchField();

      req.RequestID = CreateRequestID();
      //req.BrokerID = BrokerID;
      req.AccountID = AccountID;

      this.tradeList = new List<DFITCMatchedRtnField>();

      this.AddQueryTask(req, XSpeedRequestAction.QueryMatchInfoAction);

    }

    /// <summary>
    /// 持仓情况查询
    /// </summary>
    public void QueryPosition()
    {
      DFITCPositionField req = new DFITCPositionField();

      req.RequestID = CreateRequestID();
      req.AccountID = AccountID;

      this.AddQueryTask(req, XSpeedRequestAction.QueryPositionAction);
    }


    /// <summary>
    /// 报单查询
    /// </summary>
    public void QueryOrder()
    {
      DFITCOrderField req = new DFITCOrderField();

      req.RequestID = CreateRequestID();
      req.AccountID = AccountID;

      this.AddQueryTask(req, XSpeedRequestAction.QueryOrderInfoAction);
    }

    #endregion

    protected override void ProcessBusinessResponse(XSpeedResponseType responseType, IntPtr pData, XSpeedResponseInfo rspInfo, int requestID)
    {

      Trace.WriteLine(string.Format("{0} [{1}]:{2},{3},{4}", this.wallTimeStopwatch.ElapsedMilliseconds, this.UserKey, "ProcessBusinessResponse", responseType, requestID));

      switch (responseType)
      {
        #region 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
        case XSpeedResponseType.FrontConnectedResponse:
          {

            this.isConnect = true;

            this.UserLogin();

            //调用事件
            OnEventHandler(XSpeedResponseType.FrontConnectedResponse, new XSpeedEventArgs());

            break;
          }
        #endregion

        #region 通信中断
        case XSpeedResponseType.FrontDisconnectedResponse:
          ///  当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
          ///@param nReason 错误原因
          ///        0x1001 网络读失败
          ///        0x1002 网络写失败
          ///        0x2001 接收心跳超时
          ///        0x2002 发送心跳失败
          ///        0x2003 收到错误报文
          {
            this.isConnect = false;

            //调用事件
            OnEventHandler(XSpeedResponseType.FrontDisconnectedResponse, new XSpeedEventArgs());
          }
          break;
        #endregion

        #region 用户登录
        case XSpeedResponseType.UserLoginResponse:
          {

            XSpeedEventArgs<DFITCUserLoginInfoRtnField> args = CreateEventArgs<DFITCUserLoginInfoRtnField>(requestID, rspInfo);

            DFITCUserLoginInfoRtnField userLogin = args.Value;


            if (rspInfo.ErrorID == 0)
            {

              //this.BrokerID = userLogin.BrokerID;
              //this.FrontID = userLogin.FrontID;
              this.SessionID = userLogin.SessionID;
              this.isLogin = true;

              //最大报单引用
              this.orderRef = userLogin.InitLocalOrderID;

              //DateTime.TryParseExact(userLogin.TradingDay, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out this.tradingDate);
              //TimeSpan.TryParse(userLogin.DCETime, out this.loginTimeDCE);
              //TimeSpan.TryParse(userLogin.CZCETime, out this.loginTimeCZCE);
              //TimeSpan.TryParse(userLogin.SHFETime, out this.loginTimeSHFE);

              this.wallTimeStopwatch.Start();
              this.timer.Change(0, 1000);

            }

            this.OnEventHandler(XSpeedResponseType.UserLoginResponse, args);
          }
          break;
        #endregion

        #region 登出请求响应
        case XSpeedResponseType.UserLogoutResponse:
          {
            this.isLogin = false;

            //调用事件
            OnEventHandler(XSpeedResponseType.UserLogoutResponse, new XSpeedEventArgs());
            break;
          }
        #endregion

        #region 报单录入请求响应
        case XSpeedResponseType.InsertOrderResponse:
          {

            XSpeedEventArgs<DFITCOrderRspDataRtnField> args = CreateEventArgs<DFITCOrderRspDataRtnField>(pData, rspInfo);


            DFITCOrderCommRtnField order = GetOrder(args.Value.SpdOrderID);

            if (order.SpdOrderID == 0)
            {
              //
            }
            else
            {
              order.OrderStatus = args.Value.OrderStatus;
            }

            //调用事件
            OnEventHandler(XSpeedResponseType.InsertOrderResponse, args);

            break;
          }
        #endregion

        #region 改单响应
        case XSpeedResponseType.CancelOrderResponse:
          {
            XSpeedEventArgs<DFITCCancelOrderField> args = CreateEventArgs<DFITCCancelOrderField>(pData, rspInfo);

            //调用事件
            OnEventHandler(XSpeedResponseType.CancelOrderResponse, args);

            break;
          }
        #endregion

        #region 查询报单响应
        case XSpeedResponseType.QueryOrderInfoResponse:
          {
            XSpeedEventArgs<List<DFITCOrderCommRtnField>> args = CreateListEventArgs<DFITCOrderCommRtnField>(requestID, rspInfo);

            lock (this.OrderList)
            {
              this.OrderList.Clear();
              this.OrderList.AddRange(args.Value);
            }

            //调用事件
            OnEventHandler(XSpeedResponseType.QueryOrderInfoResponse, args);

            break;
          }
        #endregion

        #region 查询成交单响应
        case XSpeedResponseType.QueryMatchInfoResponse:
          {
            XSpeedEventArgs<List<DFITCMatchedRtnField>> args = CreateListEventArgs<DFITCMatchedRtnField>(requestID, rspInfo);

            this.TradeList.Clear();
            this.TradeList.AddRange(args.Value);

            //调用事件
            OnEventHandler(XSpeedResponseType.QueryMatchInfoResponse, args);

            break;
          }
        #endregion

        #region 查询投资者持仓响应
        case XSpeedResponseType.QueryPositionResponse:
          {
            XSpeedEventArgs<List<DFITCPositionInfoRtnField>> args = CreateListEventArgs<DFITCPositionInfoRtnField>(requestID, rspInfo);

            this.PositionList.Clear();
            this.PositionList.AddRange(args.Value);

            //调用事件
            OnEventHandler(XSpeedResponseType.QueryPositionResponse, args);
            break;
          }
        #endregion

        #region 查询资金账户响应
        case XSpeedResponseType.CustomerCapitalResponse:
          {

            /// 查询资金账户响应
            XSpeedEventArgs<DFITCCapitalInfoRtnField> args = CreateEventArgs<DFITCCapitalInfoRtnField>(requestID, rspInfo);

            this.tradingAccount = args.Value;

            this.OnEventHandler(XSpeedResponseType.CustomerCapitalResponse, args);

            break;
          }
        #endregion

        #region 查询标准合约响应
        case XSpeedResponseType.QuerySpecifyInstrumentResponse:
          {
            XSpeedEventArgs<DFITCInstrumentRtnField> args = CreateEventArgs<DFITCInstrumentRtnField>(pData, rspInfo);

            //this.SetInstrumentRate(args.Value);

            //调用事件
            OnEventHandler(XSpeedResponseType.QuerySpecifyInstrumentResponse, args);

            break;
          }
        #endregion

        #region 查询合约响应
        case XSpeedResponseType.QueryExchangeInstrumentResponse:
          {

            XSpeedEventArgs<List<DFITCExchangeInstrumentRtnField>> values = CreateListEventArgs<DFITCExchangeInstrumentRtnField>(requestID, rspInfo);

            foreach (var instrument in values.Value)
            {

              //CTPInstrument ctpInstrument = new CTPInstrument();
              //ctpInstrument.SetNativeValue(instrument);

              ////加入到市场列表
              //if (this.Exchanges.ContainsKey(ctpInstrument.ExchangeID))
              //{
              //  this.Exchanges[instrument.ExchangeID].Instruments.Add(ctpInstrument);
              //}

              //if (this.SymbolProducts.ContainsKey(ctpInstrument.ProductID.ToUpper()) == false)
              //{
              //  this.SymbolProducts.Add(ctpInstrument.ProductID.ToUpper(), new CTPSymbolProduct(instrument));
              //}

              //加入到合约表
              //if (this.InstrumentDictionary.ContainsKey(ctpInstrument.ID) == false)
              //{
              //  this.InstrumentDictionary.Add(ctpInstrument.ID, ctpInstrument);
              //}
            }

            //创建新的事件参数
            //List<CTPInstrument> list = new List<CTPInstrument>(this.InstrumentDictionary.Values);
            //XSpeedEventArgs<List<CTPInstrument>> args = new XSpeedEventArgs<List<CTPInstrument>>(list);

            //调用事件
            OnEventHandler(XSpeedResponseType.QueryExchangeInstrumentResponse, values);

            break;
          }
        #endregion

        #region 查询套利合约响应
        case XSpeedResponseType.ArbitrageInstrumentResponse:
          {
            XSpeedEventArgs<List<DFITCAbiInstrumentRtnField>> values = CreateListEventArgs<DFITCAbiInstrumentRtnField>(requestID, rspInfo);

            //调用事件
            OnEventHandler(XSpeedResponseType.ArbitrageInstrumentResponse, values);

            break;
          }
        #endregion

        #region 错误回报
        case XSpeedResponseType.ReturnErrorMsgResponse:
          {
            this.OnEventHandler(XSpeedResponseType.ReturnErrorMsgResponse, new XSpeedEventArgs(rspInfo));
            break;
          }
        #endregion

        #region 报单回报
        case XSpeedResponseType.ReturnOrderResponse:
          {

            XSpeedEventArgs<DFITCOrderRtnField> args = CreateEventArgs<DFITCOrderRtnField>(pData, rspInfo);

            DFITCOrderCommRtnField order = GetOrder(args.Value.SpdOrderID);

            if (order.SpdOrderID == 0)
            {
              //
            }
            else
            {
              order.OrderStatus = args.Value.OrderStatus;
            }

            //调用事件
            OnEventHandler(XSpeedResponseType.ReturnOrderResponse, args);

            break;
          }
        #endregion

        #region 成交回报
        case XSpeedResponseType.ReturnMatchedInfoResponse:
          {
            XSpeedEventArgs<DFITCMatchedRtnField> args = CreateEventArgs<DFITCMatchedRtnField>(pData, rspInfo);

            //插入到列表中
            AppendOrReplaceOrder(this.tradeList, args.Value);

            //调用事件
            OnEventHandler(XSpeedResponseType.ReturnMatchedInfoResponse, args);

            break;
          }
        #endregion

        default:
          Debug.Assert(true, responseType.ToString());
          break;
      }
    }


    #region IDisposable 成员

    public override void Dispose()
    {

      if (this.isDispose == true)
      {
        return;
      }

      this.isDispose = true;

      try
      {
        if (this._instance != IntPtr.Zero)
        {
          Process(this._instance, (int)XSpeedRequestAction.TraderApiRelease, 0, null);

          this._instance = IntPtr.Zero;
        }

      }
      catch (Exception ex)
      {

      }
      finally
      {

        this.timer.Change(Timeout.Infinite, Timeout.Infinite);
        this.wallTimeStopwatch.Stop();

        this.queryTaskTimer.Change(Timeout.Infinite, Timeout.Infinite);
        this.queryTasks.Clear();

        this.processedTasks.Clear();
        this.orderList.Clear();

        this.orderList.Clear();
        this.tradeList.Clear();
        this.positionList.Clear();

      }

      base.Dispose();
    }

    #endregion


    public override bool Equals(object obj)
    {

      if (obj == null)
      {
        return false;
      }

      if (obj is XSpeedTrader)
      {
        XSpeedTrader trader = obj as XSpeedTrader;

        if (trader == this)
        {
          return true;
        }
        else
        {
          return trader.UserKey == this.UserKey;
        }
      }
      else
      {
        return false;
      }
    }

    public override int GetHashCode()
    {
      return this.UserKey.GetHashCode();
    }

    DFITCOrderCommRtnField GetOrder(int spdOrderID)
    {
      lock (this.orderList)
      {
        DFITCOrderCommRtnField order = (from item in this.orderList
                                        where item.SpdOrderID == spdOrderID
                                        select item).FirstOrDefault();

        return order;
      }
    }

    //DFITCOrderCommRtnField GetOrder(int sessionID)
    //{
    //  lock (this.orderList)
    //  {
    //    DFITCOrderCommRtnField order = (from item in this.orderList
    //                                    where item.SessionID == sessionID && item.
    //                                    select item).FirstOrDefault();

    //    return order;
    //  }
    //}

    static void AppendOrReplaceOrder(IList list, object nativeOrder)
    {

      for (int i = 0; i < list.Count; i++)
      {
        object order = list[i];

        if (GetOrderUniqueKey(order) == GetOrderUniqueKey(nativeOrder))
        {
          list[i] = nativeOrder;
          return;
        }
      }

      list.Add(nativeOrder);

    }

    static string GetOrderUniqueKey(object field)
    {
      //报单
      if (field is DFITCOrderCommRtnField)
      {
        DFITCOrderCommRtnField value = (DFITCOrderCommRtnField)field;
        return string.Format("{0}_{1}", value.AccountID, value.SpdOrderID);
      }

      //报单
      //if (field is DFITCOrderRspDataRtnField)
      //{
      //  DFITCOrderRspDataRtnField value = (DFITCOrderRspDataRtnField)field;
      //  return string.Format("{0}_{1}", this.AccountID, value.SpdOrderID);
      //}

      throw new Exception("Unknow type : " + field.GetType().ToString());

    }

  }
}
