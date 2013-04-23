using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CalmBeltFund.Trading.XSpeed
{
  public abstract class XSpeedFutureClient : BaseClient<XSpeedRequestAction, XSpeedResponseType>
  {


    #region BaseEvents

    public event EventHandler<XSpeedEventArgs<DFITCUserLoginField>> UserLoginResponse
    {
      add { AddHandler(XSpeedResponseType.UserLoginResponse, value); }
      remove { RemoveHandler(XSpeedResponseType.UserLoginResponse, value); }
    }

    public event EventHandler<XSpeedEventArgs> UserLogoutResponse
    {
      add { AddHandler(XSpeedResponseType.UserLogoutResponse, value); }
      remove { RemoveHandler(XSpeedResponseType.UserLogoutResponse, value); }
    }


    public event EventHandler<XSpeedEventArgs> FrontConnectedResponse
    {
      add { AddHandler(XSpeedResponseType.FrontConnectedResponse, value); }
      remove { RemoveHandler(XSpeedResponseType.FrontConnectedResponse, value); }
    }

    public event EventHandler<XSpeedEventArgs> FrontDisconnectedResponse
    {
      add { AddHandler(XSpeedResponseType.FrontDisconnectedResponse, value); }
      remove { RemoveHandler(XSpeedResponseType.FrontDisconnectedResponse, value); }
    }

    public event EventHandler<XSpeedEventArgs> ReturnErrorResponse
    {
      add { AddHandler(XSpeedResponseType.ReturnErrorMsgResponse, value); }
      remove { RemoveHandler(XSpeedResponseType.ReturnErrorMsgResponse, value); }
    }

    #endregion

    #region API Invoke


    protected override unsafe int ProcessRequest(IntPtr handle, int type, IntPtr pReqData, int requestID)
    {
      return Wrapper.Process(handle, type, pReqData, requestID, 0, null);
    }

    protected override unsafe int Process(IntPtr handle, int type, int p1, StringBuilder p2)
    {
      return Wrapper.Process(handle, type, IntPtr.Zero, 0, p1, p2);
    }


    protected unsafe int Process(IntPtr handle, int type, IntPtr hData, StringBuilder p2)
    {
      return Wrapper.Process(handle, type, hData, 0, 0, p2);
    }

    #endregion

    protected override XSpeedResponseInfo GetResponseInfo(IntPtr pRspInfo)
    {

      XSpeedResponseInfo rsp = new XSpeedResponseInfo();

      DFITCErrorRtnFiled rspInfo = PInvokeUtility.GetObjectFromIntPtr<DFITCErrorRtnFiled>(pRspInfo);

      rsp.ErrorID = rspInfo.ErrorID;
      //rsp.Message = PInvokeUtility.GetUnicodeString(rspInfo.ErrorMsg);
      rsp.Message = rspInfo.ErrorMsg;

      return rsp;
    }

    protected override XSpeedResponseType ConvertToResponseType(int rsp)
    {
      return (XSpeedResponseType)rsp;
    }

    protected override int ConvertActionToInt(XSpeedRequestAction action)
    {
      return (int)action;
    }
  }
}
