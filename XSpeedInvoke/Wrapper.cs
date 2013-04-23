using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection;
using System.IO;

namespace CalmBeltFund.Trading.XSpeed
{

  public class Wrapper
  {
    [DllImport("XSpeedWrapper.dll")]
    public unsafe static extern int Process(IntPtr hTrader, int type, IntPtr pReqData, int requestID, int p1, StringBuilder p2);

    //[DllImport("XSpeedWrapper.dll")]
    //internal static extern int Process(IntPtr handle, int type, int p1, StringBuilder p2);

    /// <summary>
    /// 订阅行情
    /// </summary>
    /// <param name="hMarketData"></param>
    [DllImport("XSpeedWrapper.dll")]
    internal static extern void SubscribeMarketData(IntPtr hMarketDatachar, IntPtr[] ppInstrumentID, int nCount);

    /// <summary>
    /// 退订行情
    /// </summary>
    /// <param name="hMarketData"></param>
    [DllImport("XSpeedWrapper.dll")]
    internal static extern void UnSubscribeMarketData(IntPtr hMarketData, IntPtr[] ppInstrumentID, int nCount);


    internal delegate void OutputCallback(string msg);
    
    [DllImport("XSpeedWrapper.dll")]
    internal static extern void SetOutputCallback(OutputCallback cb);

    internal static OutputCallback outputCallback = null;

    public static void OutputString(string msg)
    {
      Trace.WriteLine(msg);
      Trace.Flush();
    }

    static Wrapper()
    {
      outputCallback = new OutputCallback(OutputString);
      SetOutputCallback(outputCallback);
    }
  }

}
