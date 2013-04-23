using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CalmBeltFund.Trading.XSpeed
{

  /// <summary>
  /// DFITCExchangeIDType:交易所编码数据类型
  /// </summary>
  public class XSpeedExchangeIDType
  {
    /// <summary>
    /// 大商所
    /// </summary>
    [Description("大商所")]
    public const string DCE = "DCE";
    /// <summary>
    /// 郑商所
    /// </summary>
    [Description("郑商所")]
    public const string CZCE = "CZCE";
    /// <summary>
    /// 上期所
    /// </summary>
    [Description("上期所")]
    public const string SHFE = "SHFE";
    /// <summary>
    /// 中金所
    /// </summary>
    [Description("中金所")]
    public const string CFFEX = "CFFEX";
  }


  /// <summary>
  /// DFITCAbiPolicyCodeType: 套利策略代码数据类型
  /// </summary>
  public class XSpeedAbiPolicyCodeType
  {
    /// <summary>
    /// 跨期套利
    /// </summary>
    [Description("跨期套利")]
    public const string SP = "SP";
    /// <summary>
    /// 两腿跨品种套利
    /// </summary>
    [Description("两腿跨品种套利")]
    public const string SPC = "SPC";
    /// <summary>
    /// 压榨套利
    /// </summary>
    [Description("压榨套利")]
    public const string SPX = "SPX";
    /// <summary>
    /// Call Spread
    /// </summary>
    [Description("Call Spread")]
    public const string Call = "CSPR";
    /// <summary>
    /// Put Spread
    /// </summary>
    [Description("Put Spread")]
    public const string Put = "PSPR";
    /// <summary>
    /// Combo
    /// </summary>
    [Description("Combo")]
    public const string Combo = "COMBO";
    /// <summary>
    /// Straddle
    /// </summary>
    [Description("Straddle")]
    public const string Straddle = "STD";
    /// <summary>
    /// Strangle
    /// </summary>
    [Description("Strangle")]
    public const string Strangle = "STG";
    /// <summary>
    /// Guts
    /// </summary>
    [Description("Guts")]
    public const string Guts = "GUTS";
    /// <summary>
    /// Synthetic Underlying
    /// </summary>
    [Description("Synthetic Underlying")]
    public const string Synund = "SYN";
  }


  /// <summary>
  /// DFITCBuySellTypeType:买卖数据类型
  /// </summary>
  public enum XSpeedBuySellType : short
  {
    /// <summary>
    /// 买
    /// </summary>
    [Description("买")]
    Buy = 1,
    /// <summary>
    /// 卖
    /// </summary>
    [Description("卖")]
    Sell = 2
  }

  /// <summary>
  /// DFITCOpenCloseTypeType：开平标志数据类型
  /// </summary>
  public enum XSpeedOpenCloseType : int
  {
    /// <summary>
    /// 开仓
    /// </summary>
    [Description("开仓")]
    Open = 1,
    /// <summary>
    /// 平仓
    /// </summary>
    [Description("平仓")]
    Close = 2,
    /// <summary>
    /// 平今
    /// </summary>
    [Description("平今")]
    Closetoday = 4
  }

  /// <summary>
  /// DFITCSpeculatorType:投保类型
  /// </summary>
  public enum XSpeedSpeculatorType : int
  {
    /// <summary>
    /// 投机
    /// </summary>
    [Description("投机")]
    Speculator = 0,
    /// <summary>
    /// 套保
    /// </summary>
    [Description("套保")]
    Hedge = 1,
    /// <summary>
    /// 套利
    /// </summary>
    [Description("套利")]
    Arbitrage = 2
  }

  /// <summary>
  /// DFITCOrderType:订单类型
  /// </summary>
  public enum XSpeedOrderType : int
  {
    /// <summary>
    /// 限价委托
    /// </summary>
    [Description("限价委托")]
    Limitorder = 1,
    /// <summary>
    /// 市价委托
    /// </summary>
    [Description("市价委托")]
    Mkorder = 2
  }

  /// <summary>
  /// DFITCOrderAnswerStatusType:委托回报类型
  /// </summary>
  public enum XSpeedOrderAnswerStatusType : short
  {
    /// <summary>
    /// 已撤单
    /// </summary>
    [Description("已撤单")]
    Canceled = 1,
    /// <summary>
    /// 全部成交
    /// </summary>
    [Description("全部成交")]
    Filled = 2,
    /// <summary>
    /// 未成交还在队列中
    /// </summary>
    [Description("未成交还在队列中")]
    InQueue = 3,
    /// <summary>
    /// 部分成交还在队列中
    /// </summary>
    [Description("部分成交还在队列中")]
    Partial = 4,
    /// <summary>
    /// 部成部撤
    /// </summary>
    [Description("部成部撤")]
    PaprialCanceled = 5,
    /// <summary>
    /// 撤单中
    /// </summary>
    [Description("撤单中")]
    InCanceling = 6,
    /// <summary>
    /// 错误
    /// </summary>
    [Description("错误")]
    Error = 7,
    /// <summary>
    /// 交易所已接受，但尚未成交
    /// </summary>
    [Description("交易所已接受，但尚未成交")]
    Placed = 8,
    /// <summary>
    /// 报单的初始状态，表示单子刚刚开始，尚未报到柜台。
    /// </summary>
    [Description("报单的初始状态，表示单子刚刚开始，尚未报到柜台。")]
    Started = 9,
    /// <summary>
    /// 柜台已接收，但尚未到交易所
    /// </summary>
    [Description("柜台已接收，但尚未到交易所")]
    Triggered = 10
  }

  /// <summary>
  /// DFITCQuotationType:接收行情类型
  /// </summary>
  public enum XSpeedQuotationType : short
  {
    /// <summary>
    /// TCP行情
    /// </summary>
    [Description("TCP行情")]
    QuoteTcp = 1,
    /// <summary>
    /// UDP行情
    /// </summary>
    [Description("UDP行情")]
    QuoteUpd = 2
  }

  /// <summary>
  /// DFITCOrderPropertyType:订单属性
  /// </summary>
  public enum XSpeedOrderPropertyType : byte
  {
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    NON = (byte)'0',
    /// <summary>
    /// 
    /// </summary>
    [Description("FAK")]
    FAK = (byte)'1',
    /// <summary>
    /// 
    /// </summary>
    [Description("FOK")]
    FOK = (byte)'2'
  }

  /// <summary>
  /// DFITCLossProfitTypeType:止盈止损标志
  /// </summary>
  public enum XSpeedLossProfitType : int
  {
    /// <summary>
    /// 止损标志
    /// </summary>
    [Description("止损标志")]
    LossUse = 1,
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    LossUnuse = 0,
    /// <summary>
    /// 止盈标志
    /// </summary>
    [Description("止盈标志")]
    ProfitUse = 1,
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    ProfitUnuse = 0
  }

  /// <summary>
  /// DFITCOrderSortType:定单类别
  /// </summary>
  public enum XSpeedOrderSortType : int
  {
    /// <summary>
    /// 普通委托单
    /// </summary>
    [Description("普通委托单")]
    BasicOrder = 0,
    /// <summary>
    /// 自动强平单
    /// </summary>
    [Description("自动强平单")]
    AutoCloseOrder = 1,
    /// <summary>
    /// 止损止盈单
    /// </summary>
    [Description("止损止盈单")]
    LossprofitOrder = 3,
    /// <summary>
    /// 套利委托单
    /// </summary>
    [Description("套利委托单")]
    AbiOrder = 7
  }

  /// <summary>
  /// DFITCIsAutoOrderType:自动单
  /// </summary>
  public enum XSpeedIsAutoOrderType : int
  {
    /// <summary>
    /// 自动单
    /// </summary>
    [Description("自动单")]
    AutoOrder = 2,
    /// <summary>
    /// 非自动单
    /// </summary>
    [Description("非自动单")]
    NonAutoOrder = 1
  }

  /// <summary>
  /// DFITCOptionTypeType:期权类别数据类型
  /// </summary>
  public enum XSpeedOptionType : int
  {
    /// <summary>
    /// 看涨
    /// </summary>
    [Description("看涨")]
    OptLookUp = 1,
    /// <summary>
    /// 看跌
    /// </summary>
    [Description("看跌")]
    OptLookDown = 2
  }

  /// <summary>
  /// DFITCInstrumentTypeType:合约类型数据类型
  /// </summary>
  public enum XSpeedInstrumentType : int
  {
    /// <summary>
    /// 期货
    /// </summary>
    [Description("期货")]
    OptType = 0,
    /// <summary>
    /// 期货
    /// </summary>
    [Description("期货")]
    CommType = 1
  }


  /// <summary>
  /// DFITCCancelTypeType:撤销标志数据类型
  /// </summary>
  public enum XSpeedCancelType : byte
  {
    /// <summary>
    /// 代表定单
    /// </summary>
    [Description("代表定单")]
    OrderBook = (byte)'O',
    /// <summary>
    /// 代表撤销
    /// </summary>
    [Description("代表撤销")]
    OrderCancel = (byte)'W'
  }
}
