// Decompiled with JetBrains decompiler
// Type: LCMObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using PLitJson;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class LCMObj : MonoBehaviour
{
  private const int csMsgNeedInit = 0;
  private const int csMsgFree = 1;
  private const int csMsgNeedWait = 2;
  private const int csMsgNeedFinish = 3;
  private const int csMsgPayOver = 4;
  private const int csSDKInit = -1;
  private const int csGetSerAddRess = 0;
  private const int csCheckLogin = 1;
  private const int csLoginFinish = 2;
  private const int csIsRealName = 3;
  private const int csCreatePayOrder = 4;
  private const int csPaySpend = 5;
  private const float csLogoTime = 1f;
  private bool isSDKLogin;
  private string accessToken = string.Empty;
  private string userinfo = string.Empty;
  private string userid = string.Empty;
  private string deAccessToken = string.Empty;
  private string token = string.Empty;
  private string account_id = string.Empty;
  private string play_id = string.Empty;
  private bool isChanel;
  private string play_crTime = string.Empty;
  private bool isLoginFinish;
  private bool isMsgReSend;
  private int msgFlag;
  private int msgType;
  private string dev;
  private string serorder_id = string.Empty;
  private int payOrder;
  private string sdkorder;
  private int lmoney;
  private bool needShowMoney;
  private int nowCoin;
  private bool needPurchase;
  private bool isInPay;
  private bool isStartEvent = true;
  private int nowLevel = -1;
  private Action<int, int, int> onPayFinish;
  private bool hasLink;
  private bool isSDKLogout;

  public void initParam()
  {
    this.accessToken = string.Empty;
    this.userinfo = string.Empty;
    this.deAccessToken = string.Empty;
    this.userid = string.Empty;
    this.lmoney = 0;
    this.needShowMoney = false;
    this.nowCoin = 0;
    this.account_id = string.Empty;
    this.play_id = string.Empty;
    this.play_crTime = string.Empty;
    this.isChanel = false;
    if (GameConfig.IsChanelPackage)
      this.isChanel = true;
    this.isMsgReSend = false;
    this.isSDKLogin = false;
    this.isLoginFinish = false;
    this.needPurchase = false;
    this.isInPay = false;
    this.hasLink = false;
    this.isStartEvent = true;
    this.nowLevel = -1;
    this.isSDKLogout = false;
    this.msgFlag = 0;
    this.msgType = 0;
  }

  private void Update()
  {
    if (this.msgFlag != 1)
      return;
    this.msgFlag = 2;
    if (this.msgType == 0)
    {
      this.getAllAddress();
      if (this.isMsgReSend)
        return;
      this.loginMain();
    }
    else if (this.msgType == 1)
      this.startLogin();
    else if (this.msgType == 2)
      this.StartCoroutine(WebQueue.RunWorkerMobage());
    else if (this.msgType == 4)
    {
      this.createItemOrder(LCMPayItemLst.getInstance.getPayItemData(this.payOrder), false);
    }
    else
    {
      if (this.msgType != 5)
        return;
      this.StartCoroutine(this.IEnItemSpend(this.sdkorder));
    }
  }

  public void delayinit() => this.StartCoroutine(this.sdkstartinit());

  [DebuggerHidden]
  private IEnumerator sdkstartinit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003Csdkstartinit\u003Ec__Iterator151()
    {
      \u003C\u003Ef__this = this
    };
  }

  public string getAccountid() => this.account_id;

  public string getPlay_id() => this.play_id;

  public string getToken() => this.token;

  public bool isLogin() => this.isLoginFinish;

  public string getSerOrder() => this.serorder_id;

  private void getUserString(string pSour, string[] pValType, ref string[] pVal)
  {
    int length = pValType.Length;
    int startIndex = 0;
    for (int index = 0; index < length; ++index)
    {
      string str1 = pValType[index];
      int num = index + 1 == length ? pSour.Length : pSour.IndexOf(str1);
      string str2 = string.Empty;
      if (num > startIndex)
        str2 = pSour.Substring(startIndex, num - startIndex);
      pVal[index] = str2;
      startIndex = num + str1.Length;
    }
  }

  public void clearLoginInfo() => this.initParam();

  public void onLoginComplete(string pVal)
  {
    this.isSDKLogin = true;
    string[] pValType = new string[3];
    string[] pVal1 = new string[3];
    pValType[0] = "#user#";
    pValType[1] = "#decodedAccessToken#";
    pValType[2] = string.Empty;
    this.getUserString(pVal, pValType, ref pVal1);
    this.accessToken = pVal1[0];
    this.userinfo = pVal1[1];
    this.deAccessToken = pVal1[2];
    if (this.isLoginFinish || this.msgType != 0 || this.msgFlag == 2)
      return;
    this.msgFlag = 1;
  }

  public void onSDKLoginComplete(string pJson)
  {
    this.isSDKLogin = true;
    JsonData jsonData = JsonMapper.ToObject(new JsonReader(pJson));
    this.accessToken = jsonData["accessToken"].ToString();
    this.userinfo = jsonData["userinfo"].ToString();
    this.deAccessToken = jsonData["deAccessToken"].ToString();
    if (jsonData["isChanel"].ToString().ToLower() == "true")
      GameConfig.setChanelPackage(true);
    else
      GameConfig.setChanelPackage(false);
    GameConfig.setClientVer(jsonData["clientVer"].ToString());
    if (this.isLoginFinish || this.msgType != 0 || this.msgFlag == 2)
      return;
    this.msgFlag = 1;
  }

  public void start()
  {
    if (!this.isLoginFinish)
      return;
    if (Persist.auth.Exists)
      Application.LoadLevel("startup000_6");
    else
      Application.LoadLevel("startup000_6");
  }

  public void startLogin()
  {
    this.StartCoroutine(this.IEnaccessToken(this.accessToken, this.userinfo, this.deAccessToken));
  }

  public void getAllAddress() => this.StartCoroutine(this.IEnGetServerAddress());

  public void loginMain() => this.StartCoroutine(this.IEnlogo());

  [DebuggerHidden]
  private IEnumerator IEnlogo()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LCMObj.\u003CIEnlogo\u003Ec__Iterator152 ienlogoCIterator152 = new LCMObj.\u003CIEnlogo\u003Ec__Iterator152();
    return (IEnumerator) ienlogoCIterator152;
  }

  private void isGetAllSer(HTTP.Response response)
  {
    try
    {
      string json_text = response.Text.Trim();
      DDebug.Log("response:" + json_text);
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(json_text));
      DDebug.Log("GetAllServerAddress:");
      string pAccountSer = jsonData["game_center"].ToString();
      DDebug.Log("AccountServer:" + pAccountSer);
      string pGameSer = jsonData["game_server"].ToString();
      DDebug.Log("GameServer:" + pGameSer);
      string pDLCSer = jsonData["dlc"].ToString();
      DDebug.Log("DLCServer:" + pDLCSer);
      string pLuaSer = jsonData["script"].ToString();
      DDebug.Log("LuaServer:" + pLuaSer);
      GameConfig.setServerAddress(pAccountSer, pGameSer, pDLCSer, pLuaSer);
      this.msgFlag = 1;
      this.isMsgReSend = true;
      this.msgType = 1;
    }
    catch
    {
      string message = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        message = response.Text.Trim();
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().pay_dataerror + "Status=" + empty, message, (System.Action) (() =>
      {
        this.msgFlag = 1;
        this.isMsgReSend = true;
        this.msgType = 0;
      }));
    }
  }

  [DebuggerHidden]
  private IEnumerator IEnGetServerAddress()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnGetServerAddress\u003Ec__Iterator153()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setSDKLogin(bool val) => this.isSDKLogin = val;

  public bool getSDKLogin() => this.isSDKLogin;

  public void setAccessToken(string val) => this.accessToken = val;

  public string getAccessToken() => this.accessToken;

  private string getUserId(string pSour)
  {
    string empty = string.Empty;
    try
    {
      empty = JsonMapper.ToObject(new JsonReader(pSour))["userId"].ToString();
    }
    catch
    {
    }
    return empty;
  }

  private bool canGetPayItemLst(HTTP.Response response)
  {
    bool payItemLst = false;
    try
    {
      string json_text = response.Text.Trim();
      DDebug.Log("response:" + json_text);
      JsonReader reader = new JsonReader(json_text);
      DDebug.Log("JsonReader");
      JsonData jsonData = JsonMapper.ToObject(reader);
      DDebug.Log("JsonData");
      string str = jsonData["success"].ToString();
      DDebug.Log("isSuccess:" + str);
      if (str.ToLower() == "true")
      {
        this.account_id = jsonData["data"]["account_id"].ToString();
        DDebug.Log("account_id:" + this.account_id);
        this.play_id = jsonData["data"]["player_id"].ToString();
        DDebug.Log("play_id:" + this.play_id);
        this.token = jsonData["data"]["token"].ToString();
        DDebug.Log("token:" + this.token);
        this.play_crTime = jsonData["data"]["create_time"].ToString();
        DDebug.Log("play createTime:" + this.play_crTime);
        this.isLoginFinish = true;
        this.msgFlag = 1;
        this.msgType = 2;
        payItemLst = true;
      }
      else
      {
        string message = jsonData["error"].ToString();
        ModalWindow.Show(Consts.GetInstance().account_information_error_2, message, (System.Action) (() =>
        {
          this.msgFlag = 1;
          this.msgType = 1;
          this.isMsgReSend = true;
        }));
      }
    }
    catch
    {
      string message = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        message = response.Text.Trim();
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().account_information_error + "Status=" + empty, message, (System.Action) (() =>
      {
        this.msgFlag = 1;
        this.msgType = 1;
        this.isMsgReSend = true;
      }));
    }
    return payItemLst;
  }

  [DebuggerHidden]
  private IEnumerator IEnaccessToken(string accessToken, string pUserInfo, string deAccessToken)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnaccessToken\u003Ec__Iterator154()
    {
      pUserInfo = pUserInfo,
      accessToken = accessToken,
      deAccessToken = deAccessToken,
      \u003C\u0024\u003EpUserInfo = pUserInfo,
      \u003C\u0024\u003EaccessToken = accessToken,
      \u003C\u0024\u003EdeAccessToken = deAccessToken,
      \u003C\u003Ef__this = this
    };
  }

  public void Awake()
  {
  }

  public void createItemOrder(LCMPayData tempData, bool isQuick)
  {
    this.StartCoroutine(this.IEnItemPay(tempData, isQuick));
  }

  public bool isCreateOrdSucc(HTTP.Response response)
  {
    bool ordSucc = false;
    try
    {
      string str = response.Text.Trim();
      DDebug.Log("response:" + str);
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(str));
      if (jsonData["success"].ToString().ToLower() == "true")
      {
        this.serorder_id = jsonData["data"]["transactionid"].ToString();
        DDebug.Log("serorder_id:" + this.serorder_id);
        ordSucc = true;
      }
      else
      {
        string errorStr = LCMPayData.getErrorStr(jsonData["error"].ToString(), str);
        ModalWindow.Show(Consts.GetInstance().pay_order, errorStr, (System.Action) (() => { }));
        this.ItemPayStop(string.Empty);
      }
    }
    catch
    {
      string str = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        str = response.Text.Trim();
        empty = response.status.ToString();
      }
      DDebug.LogError(" pay createOrder error:" + str);
      ModalWindow.Show(Consts.GetInstance().pay_order + " Status=" + empty, Consts.GetInstance().pay_dataerror, (System.Action) (() => { }));
      this.ItemPayStop(string.Empty);
    }
    return ordSucc;
  }

  [DebuggerHidden]
  private IEnumerator IEnItemPay(LCMPayData payObj, bool isQuick)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnItemPay\u003Ec__Iterator155()
    {
      payObj = payObj,
      isQuick = isQuick,
      \u003C\u0024\u003EpayObj = payObj,
      \u003C\u0024\u003EisQuick = isQuick,
      \u003C\u003Ef__this = this
    };
  }

  public void itemSpend(string pSdkorder)
  {
    this.sdkorder = pSdkorder;
    this.msgType = 5;
    this.msgFlag = 1;
  }

  public void ItemPayStop(string msg)
  {
    this.isInPay = false;
    PurchaseLoadingLayer.Disable();
  }

  public void SDKExitEvent()
  {
  }

  public void createRoleEvent(string player_name, string coin)
  {
    SDKExtraObj sdkExtraObj = new SDKExtraObj();
    sdkExtraObj.roleId = SDK.instance.GetPlayID();
    sdkExtraObj.roleName = player_name;
    DDebug.Log(nameof (createRoleEvent));
    string balance = coin;
    LCMNative_Android.createRole(sdkExtraObj.roleId, sdkExtraObj.roleName, "Android", this.play_crTime, balance);
  }

  public void SDKroleEvent(string rolename, int roleLevel, int coin)
  {
    if (this.isStartEvent)
    {
      this.isStartEvent = false;
      this.nowLevel = roleLevel;
      string playId = this.play_id;
      DDebug.LogError("will SDKStartGameEvent");
      string zoneid = "Android";
      string roleLevel1 = roleLevel.ToString();
      string balance = coin.ToString();
      LCMNative_Android.roleEvent("StartPlay", playId, rolename, zoneid, roleLevel1, this.play_crTime, balance);
    }
    else if (this.nowLevel < 0)
    {
      this.nowLevel = roleLevel;
    }
    else
    {
      if (this.nowLevel >= roleLevel)
        return;
      string playId = this.play_id;
      this.nowLevel = roleLevel;
      string roleLevel2 = this.nowLevel.ToString();
      DDebug.LogError("will SDKlevelup");
      string zoneid = "Android";
      string balance = coin.ToString();
      LCMNative_Android.roleEvent("LevelUp", playId, rolename, zoneid, roleLevel2, this.play_crTime, balance);
    }
  }

  public void createRoleExtra(
    string roleid,
    string rolename,
    string zoneid,
    string createTime,
    string balance)
  {
    LCMNative_Android.createRole(this.play_id, rolename, zoneid, this.play_crTime, balance);
  }

  public void remoteMessage(string json)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    try
    {
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(json));
      empty1 = jsonData["msg"].ToString();
      empty2 = jsonData["extra"].ToString();
    }
    catch
    {
      DDebug.LogError("remoteMessagec error");
    }
    if (!(empty1 != string.Empty))
      return;
    ModalWindow.Show(empty2, empty1, (System.Action) (() => { }));
  }

  public void SDKLogoutFinish()
  {
    if (!this.isSDKLogout)
      ModalWindow.Show(string.Empty, Consts.GetInstance().logoutFinish, (System.Action) (() =>
      {
        DDebug.Log("LCMObj SDKLogoutFinish");
        this.SDKExit();
      }));
    else
      this.SDKExit();
  }

  public void SDKExit() => LCMNative_Android.exitSDK();

  public void SDKQuit() => LCMNative_Android.quitSDK();

  public void logout(bool isSDK)
  {
    this.isSDKLogout = isSDK;
    LCMNative_Android.logout();
  }

  public void ItemPayStart()
  {
    this.isInPay = true;
    PaymentListener.RequestPurchase("dummy");
  }

  public bool isShowPaySuccess(HTTP.Response response, ref int coin, ref int is_discount)
  {
    bool flag = false;
    try
    {
      string str1 = response.Text.Trim();
      JsonReader reader = new JsonReader(str1);
      DDebug.Log("JsonReader");
      JsonData jsonData = JsonMapper.ToObject(reader);
      DDebug.Log("jsonData2");
      string str2 = jsonData["success"].ToString();
      string empty = string.Empty;
      if (str2.ToLower() != "true")
        empty = jsonData["error"].ToString();
      if (str2.ToLower() == "true")
      {
        DDebug.Log("isPayFinish");
        is_discount = int.Parse(jsonData["data"]["history"]["exists_reward"].ToString());
        int num1 = int.Parse(jsonData["data"]["free_coin"].ToString());
        int num2 = int.Parse(jsonData["data"]["paid_coin"].ToString());
        coin = num1 + num2;
        DDebug.Log("data is right");
        flag = true;
      }
      else
      {
        switch (empty)
        {
          case "3010":
            DDebug.Log("isPayFinish 3010");
            is_discount = -1;
            coin = -1;
            DDebug.Log("data is right");
            flag = true;
            break;
          case "3014":
            ModalWindow.Show(Consts.GetInstance().pay_success, Consts.GetInstance().pay_error3014, (System.Action) (() => { }));
            DDebug.LogError("pay error:3014");
            this.ItemPayStop(string.Empty);
            break;
          case "3008":
            this.needPurchase = true;
            this.msgType = 4;
            this.msgFlag = 1;
            break;
          default:
            string errorStr = LCMPayData.getErrorStr(empty, str1);
            ModalWindow.Show(Consts.GetInstance().pay_error, errorStr, (System.Action) (() => { }));
            DDebug.LogError("pay error:" + errorStr);
            this.ItemPayStop(string.Empty);
            break;
        }
      }
    }
    catch
    {
      string message = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        message = response.Text.Trim();
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().pay_dataerror + " status=" + empty, message, (System.Action) (() => { }));
      DDebug.LogError("payError:" + message);
      this.ItemPayStop(string.Empty);
    }
    return flag;
  }

  [DebuggerHidden]
  private IEnumerator IEnItemSpend(string sdkorder)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnItemSpend\u003Ec__Iterator156()
    {
      sdkorder = sdkorder,
      \u003C\u0024\u003Esdkorder = sdkorder,
      \u003C\u003Ef__this = this
    };
  }

  public void buyItem(int index)
  {
    if (this.isInPay)
      return;
    this.ItemPayStart();
    this.payOrder = index;
    this.msgType = 3;
    LCMNative_Android.checkRealName();
  }

  public void canCreatePayOrder(bool val)
  {
    if (val)
    {
      this.msgType = 4;
      this.msgFlag = 1;
    }
    else
    {
      this.payOrder = -1;
      ModalWindow.Show(Consts.GetInstance().pay, Consts.GetInstance().pay_realname, (System.Action) (() => { }));
      this.ItemPayStop(string.Empty);
    }
  }

  [DebuggerHidden]
  private IEnumerator pcbuyitem(int gold)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003Cpcbuyitem\u003Ec__Iterator157()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setLMoney(string val)
  {
    DDebug.Log("setLMoney:" + val);
    int num = int.Parse(val);
    if (this.lmoney == num)
      return;
    this.lmoney = num;
    LCMPayItemLst.getInstance.setRefresh(true);
  }

  public void setIsShowMoney(string val)
  {
    if (val == "1")
    {
      DDebug.Log("setIsShowMoney:" + val);
      this.needShowMoney = true;
    }
    else
    {
      DDebug.Log("setIsShowMoney:" + val);
      this.needShowMoney = true;
    }
  }

  public int getLMoney() => this.lmoney;

  public bool getIsShowMoney() => this.needShowMoney;

  public void setPayFinishAct(Action<int, int, int> payEvent) => this.onPayFinish = payEvent;

  public bool getHasLink() => this.hasLink;

  public void setHasLink() => this.hasLink = true;
}
