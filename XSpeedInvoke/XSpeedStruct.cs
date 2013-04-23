using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CalmBeltFund.Trading.XSpeed
{
  /// <summary>
  /// 心跳包
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCTimeOutField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;

  };

  /// <summary>
  /// 请求报单数据类型(基本报单)
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCInsertOrderField
  {
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 报单价格
    /// </summary>
    [Description("报单价格")]
    public double InsertPrice;
    /// <summary>
    /// 报单数量
    /// </summary>
    [Description("报单数量")]
    public int OrderAmount;
    /// <summary>
    /// 买卖标志
    /// </summary>
    [Description("买卖标志")]
    [MarshalAs(UnmanagedType.I2)]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 投保类型
    /// </summary>
    [Description("投保类型")]
    public int Speculator;
    /// <summary>
    /// 是否为自动单
    /// </summary>
    [Description("是否为自动单")]
    public XSpeedIsAutoOrderType IsAutoOrder;
    /// <summary>
    /// 报单类型 限价 、市价
    /// </summary>
    [Description("报单类型 限价 、市价")]
    public XSpeedOrderType OrderType;
    /// <summary>
    /// 报单属性 FAK、FOK
    /// </summary>
    [Description("报单属性 FAK、FOK")]
    public XSpeedOrderPropertyType OrderProperty;

  };

  /// <summary>
  /// ////////////////////////////////////////////
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCLossProfitOrderField
  {
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 报单价格
    /// </summary>
    [Description("报单价格")]
    public double InsertPrice;
    /// <summary>
    /// 报单数量
    /// </summary>
    [Description("报单数量")]
    public int OrderAmount;
    /// <summary>
    /// 买卖标志
    /// </summary>
    [Description("买卖标志")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 投保类型
    /// </summary>
    [Description("投保类型")]
    public int Speculator;
    /// <summary>
    /// 报单类型
    /// </summary>
    [Description("报单类型")]
    public XSpeedOrderType OrderType;
    /// <summary>
    /// 报单属性
    /// </summary>
    [Description("报单属性")]
    public XSpeedOrderPropertyType OrderProperty;
    /// <summary>
    /// 下跌触发价差
    /// </summary>
    [Description("下跌触发价差")]
    public double DownTriggerPrice;
    /// <summary>
    /// 上涨触发价差
    /// </summary>
    [Description("上涨触发价差")]
    public double RiseTriggerPrice;
    /// <summary>
    /// 止损标志
    /// </summary>
    [Description("止损标志")]
    public XSpeedLossProfitType LossID;
    /// <summary>
    /// 下跌委托价差
    /// </summary>
    [Description("下跌委托价差")]
    public double DownCommPrice;
    /// <summary>
    /// 止盈标志
    /// </summary>
    [Description("止盈标志")]
    public XSpeedLossProfitType ProfitID;
    /// <summary>
    /// 上涨委托价差
    /// </summary>
    [Description("上涨委托价差")]
    public double RiseCommPrice;
    /// <summary>
    /// 是否为自动单
    /// </summary>
    [Description("是否为自动单")]
    public XSpeedIsAutoOrderType IsAutoOrder;

  };

  /// <summary>
  /// ////////////////////////////////////////////
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCAbiOrderField
  {
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 报单价格
    /// </summary>
    [Description("报单价格")]
    public double InsertPrice;
    /// <summary>
    /// 报单数量
    /// </summary>
    [Description("报单数量")]
    public int OrderAmount;
    /// <summary>
    /// 买卖标志
    /// </summary>
    [Description("买卖标志")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 合约代码1
    /// </summary>
    [Description("合约代码1")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID1;
    /// <summary>
    /// 报单价格1
    /// </summary>
    [Description("报单价格1")]
    public double InsertPrice1;
    /// <summary>
    /// 报单数量1
    /// </summary>
    [Description("报单数量1")]
    public int OrderAmount1;
    /// <summary>
    /// 买卖标志1
    /// </summary>
    [Description("买卖标志1")]
    public XSpeedBuySellType BuySellType1;
    /// <summary>
    /// 预计利息
    /// </summary>
    [Description("预计利息")]
    public double PredictInsterest;
    /// <summary>
    /// 触发价格
    /// </summary>
    [Description("触发价格")]
    public double TriggerPrice;
    /// <summary>
    /// 涨停板
    /// </summary>
    [Description("涨停板")]
    public double UpDownPrice;
    /// <summary>
    /// 有效日期
    /// </summary>
    [Description("有效日期")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AvailableDate;
    /// <summary>
    /// 最小成交量
    /// </summary>
    [Description("最小成交量")]
    public int LowestMatchAmount;
    /// <summary>
    /// 是否为自动单
    /// </summary>
    [Description("是否为自动单")]
    public XSpeedIsAutoOrderType IsAutoOrder;
    /// <summary>
    /// 报单属性
    /// </summary>
    [Description("报单属性")]
    public XSpeedOrderPropertyType OrderProperty;

  };

  /// <summary>
  /// 期权报单数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOptionOrderField
  {
    /// <summary>
    /// 客户号
    /// </summary>
    [Description("客户号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 委托价格
    /// </summary>
    [Description("委托价格")]
    public double InsertPrice;
    /// <summary>
    /// 委托数量
    /// </summary>
    [Description("委托数量")]
    public int OrderAmount;
    /// <summary>
    /// 买卖标志
    /// </summary>
    [Description("买卖标志")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 投保类型
    /// </summary>
    [Description("投保类型")]
    public int Speculator;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 报单类型
    /// </summary>
    [Description("报单类型")]
    public XSpeedOrderType OrderType;
    /// <summary>
    /// 是否为自动单
    /// </summary>
    [Description("是否为自动单")]
    public XSpeedIsAutoOrderType IsAutoOrder;
    /// <summary>
    /// 期权类别:  1:看涨; 2:看跌
    /// </summary>
    [Description("期权类别:  1:看涨; 2:看跌")]
    public XSpeedOptionType OptionType;
    /// <summary>
    /// 合约类型
    /// </summary>
    [Description("合约类型")]
    public XSpeedInstrumentType InstrumentType;

  };

  ///期权报单响应数据类型
  public struct DFITCRspInsertOptOrderRtnField
  {
  }

  public struct DFITCRspCancelOptOrderRtnField
  {
  }


  /// <summary>
  /// 期权撤单数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOptionOrderCancelField
  {
    /// <summary>
    /// 客户号
    /// </summary>
    [Description("客户号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 交易所编码
    /// </summary>
    [Description("交易所编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 交易编码
    /// </summary>
    [Description("交易编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String MatchCode;
    /// <summary>
    /// 撤销标志
    /// </summary>
    [Description("撤销标志")]
    public XSpeedCancelType CancelID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 是否为自动单（申报标识）
    /// </summary>
    [Description("是否为自动单（申报标识）")]
    public XSpeedIsAutoOrderType IsAutoOrder;
    /// <summary>
    /// 期权类别:  1:看涨;  2:看跌
    /// </summary>
    [Description("期权类别:  1:看涨;  2:看跌")]
    public XSpeedOptionType OptionType;

  };

  /// <summary>
  /// 撤单数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCCancelOrderField
  {
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;

  };

  /// <summary>
  /// 委托响应类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOrderRspDataRtnField
  {
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 委托状态
    /// </summary>
    [Description("委托状态")]
    public XSpeedOrderAnswerStatusType OrderStatus;

  };

  /// <summary>
  /// 查询资金数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCCapitalField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;

  };

  /// <summary>
  /// 查询持仓数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCPositionField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;

  };

  /// <summary>
  /// 交易所合约
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCExchangeInstrumentField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 交易所编码
    /// </summary>
    [Description("交易所编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;

  };

  /// <summary>
  /// 用户登录数据类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCUserLoginField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 密码
    /// </summary>
    [Description("密码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
    public String Passwd;

  };

  /// <summary>
  /// 用户退出类型
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCUserLogoutField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金帐号ID
    /// </summary>
    [Description("资金帐号ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 会话ID
    /// </summary>
    [Description("会话ID")]
    public int SessionID;

  };

  /// <summary>
  /// 委托回报
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOrderRtnField
  {
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 委托状态
    /// </summary>
    [Description("委托状态")]
    public XSpeedOrderAnswerStatusType OrderStatus;
    /// <summary>
    /// 会话ID
    /// </summary>
    [Description("会话ID")]
    public int SessionID;

  };

  /// <summary>
  /// 成交回报
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCMatchRtnField
  {
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 成交编号
    /// </summary>
    [Description("成交编号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
    public String MatchID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 买卖
    /// </summary>
    [Description("买卖")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 成交价格
    /// </summary>
    [Description("成交价格")]
    public double MatchedPrice;
    /// <summary>
    /// 委托数量
    /// </summary>
    [Description("委托数量")]
    public int CommAmount;
    /// <summary>
    /// 成交数量
    /// </summary>
    [Description("成交数量")]
    public int MatchedAmount;
    /// <summary>
    /// 成交时间
    /// </summary>
    [Description("成交时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String MatchedTime;
    /// <summary>
    /// 报价
    /// </summary>
    [Description("报价")]
    public double InsertPrice;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 成交类型
    /// </summary>
    [Description("成交类型")]
    public int MatchType;
    /// <summary>
    /// 投保
    /// </summary>
    [Description("投保")]
    public int Speculator;
    /// <summary>
    /// 交易所ID
    /// </summary>
    [Description("交易所ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 手续费
    /// </summary>
    [Description("手续费")]
    public double Fee;
    /// <summary>
    /// 会话标识
    /// </summary>
    [Description("会话标识")]
    public int SessionID;

  };

  /// <summary>
  /// 撤单回报
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOrderCanceledRtnField
  {
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 报单价格
    /// </summary>
    [Description("报单价格")]
    public double InsertPrice;
    /// <summary>
    /// 买卖类型
    /// </summary>
    [Description("买卖类型")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenCloseType;
    /// <summary>
    /// 撤单数量
    /// </summary>
    [Description("撤单数量")]
    public int CancelAmount;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 投保
    /// </summary>
    [Description("投保")]
    public int Speculator;
    /// <summary>
    /// 交易所ID
    /// </summary>
    [Description("交易所ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 撤单时间
    /// </summary>
    [Description("撤单时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String CanceledTime;
    /// <summary>
    /// 会话标识
    /// </summary>
    [Description("会话标识")]
    public int SessionID;

  };

  /// <summary>
  /// 错误信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCErrorRtnFiled
  {
    /// <summary>
    /// 错误ID
    /// </summary>
    [Description("错误ID")]
    public int ErrorID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 错误信息
    /// </summary>
    [Description("错误信息")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public String ErrorMsg;

  };

  /// <summary>
  /// 返回资金信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCCapitalInfoRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金帐号
    /// </summary>
    [Description("资金帐号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 上日权益
    /// </summary>
    [Description("上日权益")]
    public double PreEquity;
    /// <summary>
    /// 当日客户权益
    /// </summary>
    [Description("当日客户权益")]
    public double TodayEquity;
    /// <summary>
    /// 平仓盈亏
    /// </summary>
    [Description("平仓盈亏")]
    public double CloseProfitLoss;
    /// <summary>
    /// 持仓盈亏
    /// </summary>
    [Description("持仓盈亏")]
    public double PositionProfitLoss;
    /// <summary>
    /// 委托冻结保证金
    /// </summary>
    [Description("委托冻结保证金")]
    public double FrozenMargin;
    /// <summary>
    /// 持仓保证金
    /// </summary>
    [Description("持仓保证金")]
    public double Margin;
    /// <summary>
    /// 当日手续费
    /// </summary>
    [Description("当日手续费")]
    public double Fee;
    /// <summary>
    /// 可用资金
    /// </summary>
    [Description("可用资金")]
    public double Available;
    /// <summary>
    /// 可取资金
    /// </summary>
    [Description("可取资金")]
    public double Withdraw;
    /// <summary>
    /// 风险度
    /// </summary>
    [Description("风险度")]
    public double RiskDegree;

  };

  /// <summary>
  /// 返回持仓信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCPositionInfoRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金帐号ID
    /// </summary>
    [Description("资金帐号ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 交易所代码
    /// </summary>
    [Description("交易所代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 合约号
    /// </summary>
    [Description("合约号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 买卖
    /// </summary>
    [Description("买卖")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开仓均价
    /// </summary>
    [Description("开仓均价")]
    public double OpenAvgPrice;
    /// <summary>
    /// 持仓均价
    /// </summary>
    [Description("持仓均价")]
    public double PositionAvgPrice;
    /// <summary>
    /// 持仓量
    /// </summary>
    [Description("持仓量")]
    public int PositionAmount;
    /// <summary>
    /// 总可用
    /// </summary>
    [Description("总可用")]
    public int TotalAvaiAmount;
    /// <summary>
    /// 今可用
    /// </summary>
    [Description("今可用")]
    public int TodayAvaiAmount;
    /// <summary>
    /// 昨可用
    /// </summary>
    [Description("昨可用")]
    public int LastAvaiAmount;
    /// <summary>
    /// 今仓
    /// </summary>
    [Description("今仓")]
    public int TodayAmount;
    /// <summary>
    /// 昨仓
    /// </summary>
    [Description("昨仓")]
    public int LastAmount;
    /// <summary>
    /// 挂单量
    /// </summary>
    [Description("挂单量")]
    public int TradingAmount;
    /// <summary>
    /// 盯市持仓盈亏
    /// </summary>
    [Description("盯市持仓盈亏")]
    public double DatePositionProfitLoss;
    /// <summary>
    /// 盯市平仓盈亏
    /// </summary>
    [Description("盯市平仓盈亏")]
    public double DateCloseProfitLoss;
    /// <summary>
    /// 浮动盈亏
    /// </summary>
    [Description("浮动盈亏")]
    public double FloatProfitLoss;
    /// <summary>
    /// 占用保证金
    /// </summary>
    [Description("占用保证金")]
    public double DMargin;
    /// <summary>
    /// 投保类别
    /// </summary>
    [Description("投保类别")]
    public int Speculator;
    /// <summary>
    /// 交易编码
    /// </summary>
    [Description("交易编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String ClientID;
    /// <summary>
    /// 昨结算价
    /// </summary>
    [Description("昨结算价")]
    public double LastPrice;

  };

  /// <summary>
  /// 用户登录返回信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCUserLoginInfoRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金帐号ID
    /// </summary>
    [Description("资金帐号ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 登录结果
    /// </summary>
    [Description("登录结果")]
    public int LoginResult;
    /// <summary>
    /// 初始本地委托号
    /// </summary>
    [Description("初始本地委托号")]
    public int InitLocalOrderID;
    /// <summary>
    /// sessionID
    /// </summary>
    [Description("sessionID")]
    public int SessionID;
    /// <summary>
    /// 错误ID
    /// </summary>
    [Description("错误ID")]
    public int ErrorID;
    /// <summary>
    /// 错误信息
    /// </summary>
    [Description("错误信息")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public String ErrorMsg;

  };

  /// <summary>
  /// 用户退出返回信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCUserLogoutInfoRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 退出结果
    /// </summary>
    [Description("退出结果")]
    public int LogoutResult;
    /// <summary>
    /// 错误ID
    /// </summary>
    [Description("错误ID")]
    public int NErrorID;
    /// <summary>
    /// 错误信息
    /// </summary>
    [Description("错误信息")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public String ErrorMsg;

  };

  /// <summary>
  /// 套利合约查询
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCAbiInstrumentField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 交易所代码
    /// </summary>
    [Description("交易所代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;

  };

  /// <summary>
  /// 套利合约返回信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCAbiInstrumentRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 交易所编码
    /// </summary>
    [Description("交易所编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 品种名称
    /// </summary>
    [Description("品种名称")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String VarietyName;

  };

  /// <summary>
  /// 指定的合约
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCSpecificInstrumentField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 交易所ID
    /// </summary>
    [Description("交易所ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;

  };

  /// <summary>
  /// 交易所合约返回信息
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCExchangeInstrumentRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 交易所编码
    /// </summary>
    [Description("交易所编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 品种名称
    /// </summary>
    [Description("品种名称")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String VarietyName;

  };

  /// <summary>
  /// 委托查询数据结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOrderField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;

  };

  /// <summary>
  /// 成交查询数据结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCMatchField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 资金账户ID
    /// </summary>
    [Description("资金账户ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;

  };

  /// <summary>
  /// 委托查询响应数据结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCOrderCommRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 委托状态
    /// </summary>
    [Description("委托状态")]
    public XSpeedOrderAnswerStatusType OrderStatus;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 买卖
    /// </summary>
    [Description("买卖")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平标志
    /// </summary>
    [Description("开平标志")]
    public XSpeedOpenCloseType OpenClose;
    /// <summary>
    /// 委托价
    /// </summary>
    [Description("委托价")]
    public double InsertPrice;
    /// <summary>
    /// 委托数量
    /// </summary>
    [Description("委托数量")]
    public int OrderAmount;
    /// <summary>
    /// 成交价格
    /// </summary>
    [Description("成交价格")]
    public double MatchedPrice;
    /// <summary>
    /// 成交数量
    /// </summary>
    [Description("成交数量")]
    public int MatchedAmount;
    /// <summary>
    /// 撤单数量
    /// </summary>
    [Description("撤单数量")]
    public int CancelAmount;
    /// <summary>
    /// 委托单类别
    /// </summary>
    [Description("委托单类别")]
    public int OrderType;
    /// <summary>
    /// 投保
    /// </summary>
    [Description("投保")]
    public int Speculator;
    /// <summary>
    /// 委托时间
    /// </summary>
    [Description("委托时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String CommTime;
    /// <summary>
    /// 申报时间
    /// </summary>
    [Description("申报时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String SubmitTime;
    /// <summary>
    /// 交易编码
    /// </summary>
    [Description("交易编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String ClientID;
    /// <summary>
    /// 交易所ID
    /// </summary>
    [Description("交易所ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 委托地址
    /// </summary>
    [Description("委托地址")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public String OperStation;
    /// <summary>
    /// 客户号
    /// </summary>
    [Description("客户号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String AccountID;

  };

  /// <summary>
  /// 成交查询数据响应
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCMatchedRtnField
  {
    /// <summary>
    /// 请求ID
    /// </summary>
    [Description("请求ID")]
    public int RequestID;
    /// <summary>
    /// 柜台委托号
    /// </summary>
    [Description("柜台委托号")]
    public int SpdOrderID;
    /// <summary>
    /// 交易所ID
    /// </summary>
    [Description("交易所ID")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 买卖
    /// </summary>
    [Description("买卖")]
    public XSpeedBuySellType BuySellType;
    /// <summary>
    /// 开平
    /// </summary>
    [Description("开平")]
    public XSpeedOpenCloseType OpenClose;
    /// <summary>
    /// 成交价格
    /// </summary>
    [Description("成交价格")]
    public double MatchedPrice;
    /// <summary>
    /// 成交数量
    /// </summary>
    [Description("成交数量")]
    public int MatchedAmount;
    /// <summary>
    /// 成交金额
    /// </summary>
    [Description("成交金额")]
    public double MatchedMort;
    /// <summary>
    /// 投保类别
    /// </summary>
    [Description("投保类别")]
    public int Speculator;
    /// <summary>
    /// 成交时间
    /// </summary>
    [Description("成交时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String MatchedTime;
    /// <summary>
    /// 成交编号
    /// </summary>
    [Description("成交编号")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
    public String MatchedID;
    /// <summary>
    /// 本地委托号
    /// </summary>
    [Description("本地委托号")]
    public int LocalOrderID;
    /// <summary>
    /// 交易编码
    /// </summary>
    [Description("交易编码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String ClientID;
    /// <summary>
    /// 报单类别
    /// </summary>
    [Description("报单类别")]
    public short CommOrderType;

  };

  /// <summary>
  /// 返回合约信息数据结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCInstrumentRtnField
  {
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public int RequestID;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 多头保证金率
    /// </summary>
    [Description("多头保证金率")]
    public double LongMarginRatio;
    /// <summary>
    /// 空头保证金率
    /// </summary>
    [Description("空头保证金率")]
    public double ShortMarginRatio;
    /// <summary>
    /// 开仓手续费 按手数计算
    /// </summary>
    [Description("开仓手续费 按手数计算")]
    public double OpenFeeVolRatio;
    /// <summary>
    /// 平仓手续费 按手数计算
    /// </summary>
    [Description("平仓手续费 按手数计算")]
    public double CloseFeeVolRatio;
    /// <summary>
    /// 平今手续费 按手数计算
    /// </summary>
    [Description("平今手续费 按手数计算")]
    public double CloseTodayFeeVolRatio;
    /// <summary>
    /// 开仓手续费率 按金额计算
    /// </summary>
    [Description("开仓手续费率 按金额计算")]
    public double OpenFeeAmtRatio;
    /// <summary>
    /// 平仓手续费率 按金额计算
    /// </summary>
    [Description("平仓手续费率 按金额计算")]
    public double CloseFeeAmtRatio;
    /// <summary>
    /// 平今手续费率 按金额计算
    /// </summary>
    [Description("平今手续费率 按金额计算")]
    public double CloseTodayFeeAmtRatio;

  };

  /// <summary>
  /// 深度行情
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DFITCDepthMarketDataField
  {
    /// <summary>
    /// 交易日
    /// </summary>
    [Description("交易日")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String TradingDay;
    /// <summary>
    /// 合约代码
    /// </summary>
    [Description("合约代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String InstrumentID;
    /// <summary>
    /// 交易所代码
    /// </summary>
    [Description("交易所代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public String ExchangeID;
    /// <summary>
    /// 合约在交易所的代码
    /// </summary>
    [Description("合约在交易所的代码")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
    public String ExchangeInstID;
    /// <summary>
    /// 最新价
    /// </summary>
    [Description("最新价")]
    public double LastPrice;
    /// <summary>
    /// 上次结算价
    /// </summary>
    [Description("上次结算价")]
    public double PreSettlementPrice;
    /// <summary>
    /// 昨收盘
    /// </summary>
    [Description("昨收盘")]
    public double PreClosePrice;
    /// <summary>
    /// 昨持仓量
    /// </summary>
    [Description("昨持仓量")]
    public int PreOpenInterest;
    /// <summary>
    /// 今开盘
    /// </summary>
    [Description("今开盘")]
    public double OpenPrice;
    /// <summary>
    /// 最高价
    /// </summary>
    [Description("最高价")]
    public double HighestPrice;
    /// <summary>
    /// 最低价
    /// </summary>
    [Description("最低价")]
    public double LowestPrice;
    /// <summary>
    /// 数量
    /// </summary>
    [Description("数量")]
    public int Volume;
    /// <summary>
    /// 成交金额
    /// </summary>
    [Description("成交金额")]
    public double Turnover;
    /// <summary>
    /// 持仓量
    /// </summary>
    [Description("持仓量")]
    public int OpenInterest;
    /// <summary>
    /// 今收盘
    /// </summary>
    [Description("今收盘")]
    public double ClosePrice;
    /// <summary>
    /// 本次结算价
    /// </summary>
    [Description("本次结算价")]
    public double SettlementPrice;
    /// <summary>
    /// 涨停板价
    /// </summary>
    [Description("涨停板价")]
    public double UpperLimitPrice;
    /// <summary>
    /// 跌停板价
    /// </summary>
    [Description("跌停板价")]
    public double LowerLimitPrice;
    /// <summary>
    /// 昨虚实度
    /// </summary>
    [Description("昨虚实度")]
    public double PreDelta;
    /// <summary>
    /// 今虚实度
    /// </summary>
    [Description("今虚实度")]
    public double CurrDelta;
    /// <summary>
    /// 最后修改时间
    /// </summary>
    [Description("最后修改时间")]
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
    public String UpdateTime;
    /// <summary>
    /// 最后修改毫秒
    /// </summary>
    [Description("最后修改毫秒")]
    public int UpdateMillisec;
    /// <summary>
    /// 申买价一
    /// </summary>
    [Description("申买价一")]
    public double BidPrice1;
    /// <summary>
    /// 申买量一
    /// </summary>
    [Description("申买量一")]
    public int BidVolume1;
    /// <summary>
    /// 申卖价一
    /// </summary>
    [Description("申卖价一")]
    public double AskPrice1;
    /// <summary>
    /// 申卖量一
    /// </summary>
    [Description("申卖量一")]
    public int AskVolume1;
    /// <summary>
    /// 申买价二
    /// </summary>
    [Description("申买价二")]
    public double BidPrice2;
    /// <summary>
    /// 申买量二
    /// </summary>
    [Description("申买量二")]
    public int BidVolume2;
    /// <summary>
    /// 申卖价二
    /// </summary>
    [Description("申卖价二")]
    public double AskPrice2;
    /// <summary>
    /// 申卖量二
    /// </summary>
    [Description("申卖量二")]
    public int AskVolume2;
    /// <summary>
    /// 申买价三
    /// </summary>
    [Description("申买价三")]
    public double BidPrice3;
    /// <summary>
    /// 申买量三
    /// </summary>
    [Description("申买量三")]
    public int BidVolume3;
    /// <summary>
    /// 申卖价三
    /// </summary>
    [Description("申卖价三")]
    public double AskPrice3;
    /// <summary>
    /// 申卖量三
    /// </summary>
    [Description("申卖量三")]
    public int AskVolume3;
    /// <summary>
    /// 申买价四
    /// </summary>
    [Description("申买价四")]
    public double BidPrice4;
    /// <summary>
    /// 申买量四
    /// </summary>
    [Description("申买量四")]
    public int BidVolume4;
    /// <summary>
    /// 申卖价四
    /// </summary>
    [Description("申卖价四")]
    public double AskPrice4;
    /// <summary>
    /// 申卖量四
    /// </summary>
    [Description("申卖量四")]
    public int AskVolume4;
    /// <summary>
    /// 申买价五
    /// </summary>
    [Description("申买价五")]
    public double BidPrice5;
    /// <summary>
    /// 申买量五
    /// </summary>
    [Description("申买量五")]
    public int BidVolume5;
    /// <summary>
    /// 申卖价五
    /// </summary>
    [Description("申卖价五")]
    public double AskPrice5;
    /// <summary>
    /// 申卖量五
    /// </summary>
    [Description("申卖量五")]
    public int AskVolume5;
    /// <summary>
    /// 当日均价
    /// </summary>
    [Description("当日均价")]
    public double AveragePrice;

  };

}
