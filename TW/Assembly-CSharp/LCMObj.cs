// Decompiled with JetBrains decompiler
// Type: LCMObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using PLitJson;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

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
  private const int csCreatePayOrder = 3;
  private const int csPaySpend = 4;
  private const float csLogoTime = 1f;
  private bool isSDKLogin;
  private string accessToken = string.Empty;
  private string userinfo = string.Empty;
  private string userid = string.Empty;
  private string deAccessToken = string.Empty;
  private string token = string.Empty;
  private string account_id = string.Empty;
  private string play_id = string.Empty;
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
  private Action<int, int, int> onPayFinish;
  private bool hasLink;

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
    this.isMsgReSend = false;
    this.isSDKLogin = false;
    this.isLoginFinish = false;
    this.needPurchase = false;
    this.isInPay = false;
    this.hasLink = false;
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
    else if (this.msgType == 3)
    {
      this.createItemOrder(LCMPayItemLst.getInstance.getPayItemData(this.payOrder), false);
    }
    else
    {
      if (this.msgType != 4)
        return;
      this.StartCoroutine(this.IEnItemSpend(this.sdkorder));
    }
  }

  public void delayinit() => this.StartCoroutine(this.sdkstartinit());

  [DebuggerHidden]
  private IEnumerator sdkstartinit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003Csdkstartinit\u003Ec__Iterator17C()
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
    if (!this.isLoginFinish)
    {
      if (this.msgType != 0 || this.msgFlag == 2)
        return;
      this.msgFlag = 1;
    }
    else if (this.userid != this.getUserId(this.userinfo))
    {
      this.isLoginFinish = false;
      this.msgType = 1;
      this.msgFlag = 1;
      string loadedLevelName = Application.loadedLevelName;
      this.isMsgReSend = true;
      switch (loadedLevelName)
      {
        case "start":
          break;
        case "startup000_6":
          break;
        default:
          SceneManager.LoadScene("startup000_6");
          break;
      }
    }
    else
    {
      this.msgType = 2;
      this.msgFlag = 2;
    }
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
    LCMObj.\u003CIEnlogo\u003Ec__Iterator17D ienlogoCIterator17D = new LCMObj.\u003CIEnlogo\u003Ec__Iterator17D();
    return (IEnumerator) ienlogoCIterator17D;
  }

  private void isGetAllSer(HTTP.Response response)
  {
    try
    {
      string json_text = response.Text.Trim();
      DDebug.Log("response:" + json_text);
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(json_text));
      string pAccountSer = jsonData["game_center"].ToString();
      string pGameSer = jsonData["game_server"].ToString();
      string pDLCSer = jsonData["dlc"].ToString();
      string pLuaSer = jsonData["script"].ToString();
      DDebug.Log("GetAllServerAddress:");
      DDebug.Log("AccountServer:" + pAccountSer);
      DDebug.Log("GameServer:" + pGameSer);
      DDebug.Log("DLCServer:" + pDLCSer);
      DDebug.Log("LuaServer:" + pLuaSer);
      GameConfig.setServerAddress(pAccountSer, pGameSer, pDLCSer, pLuaSer);
      this.msgFlag = 1;
      this.isMsgReSend = true;
      this.msgType = 1;
    }
    catch (Exception ex)
    {
      string message = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        message = response.Text;
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().pay_dataerror + "Status=" + empty, message, (System.Action) (() =>
      {
        this.msgFlag = 1;
        this.isMsgReSend = true;
        this.msgType = 0;
      }));
      if (ex == null)
        return;
      Debug.LogError((object) ("lcmobjct verserver:" + ex.Message));
    }
  }

  [DebuggerHidden]
  private IEnumerator IEnGetServerAddress()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnGetServerAddress\u003Ec__Iterator17E()
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
      string text = response.Text;
      DDebug.Log("response:" + text);
      JsonReader reader = new JsonReader(text);
      DDebug.Log("JsonReader canGetPayItemLst");
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
        message = response.Text;
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
    return (IEnumerator) new LCMObj.\u003CIEnaccessToken\u003Ec__Iterator17F()
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
    this.ItemPayStart();
    this.StartCoroutine(this.IEnItemPay(tempData, isQuick));
  }

  public bool isCreateOrdSucc(HTTP.Response response)
  {
    bool ordSucc = false;
    try
    {
      string text = response.Text;
      DDebug.Log("response:" + text);
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(text));
      if (jsonData["success"].ToString().ToLower() == "true")
      {
        this.serorder_id = jsonData["data"]["transactionid"].ToString();
        DDebug.Log("serorder_id:" + this.serorder_id);
        ordSucc = true;
      }
      else
      {
        string errorStr = LCMPayData.getErrorStr(jsonData["error"].ToString(), text);
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
        str = response.Text;
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().pay_order + " Status=reStatus", Consts.GetInstance().pay_dataerror, (System.Action) (() => { }));
      this.ItemPayStop(string.Empty);
    }
    return ordSucc;
  }

  [DebuggerHidden]
  private IEnumerator IEnItemPay(LCMPayData payObj, bool isQuick)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnItemPay\u003Ec__Iterator180()
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
    this.msgType = 4;
    this.msgFlag = 1;
  }

  public void ItemPayStop(string msg)
  {
    this.isInPay = false;
    PurchaseLoadingLayer.Disable();
  }

  public void remoteMessage(string json)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    try
    {
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(json.Trim()));
      empty1 = jsonData["msg"].ToString();
      empty2 = jsonData["extra"].ToString();
    }
    catch
    {
      DDebug.LogError("payitem bundleDesc error");
    }
    if (!(empty1 != string.Empty))
      return;
    ModalWindow.Show(empty1, empty2, (System.Action) (() => { }));
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
      DDebug.Log("isShowPaySuccess:" + str1);
      JsonReader reader = new JsonReader(str1);
      DDebug.Log("JsonReader isShowPaySuccess");
      JsonData jsonData = JsonMapper.ToObject(reader);
      DDebug.Log("jsonData2");
      string str2 = jsonData["success"].ToString();
      string empty = string.Empty;
      if (str2.ToLower() != "true")
        empty = jsonData["error"].ToString();
      if (!(str2.ToLower() == "true"))
      {
        switch (empty)
        {
          case "3010":
            break;
          case "3014":
            ModalWindow.Show(Consts.GetInstance().pay_success, Consts.GetInstance().pay_error3014, (System.Action) (() => { }));
            this.ItemPayStop(string.Empty);
            goto label_12;
          case "3008":
            this.needPurchase = true;
            this.msgType = 3;
            this.msgFlag = 1;
            goto label_12;
          default:
            string errorStr = LCMPayData.getErrorStr(empty, str1);
            ModalWindow.Show(Consts.GetInstance().pay_error, errorStr, (System.Action) (() => { }));
            this.ItemPayStop(string.Empty);
            goto label_12;
        }
      }
      DDebug.Log("isPayFinish");
      is_discount = int.Parse(jsonData["data"]["history"]["exists_reward"].ToString());
      int num1 = int.Parse(jsonData["data"]["free_coin"].ToString());
      int num2 = int.Parse(jsonData["data"]["paid_coin"].ToString());
      coin = num1 + num2;
      DDebug.Log("data is right");
      flag = true;
    }
    catch
    {
      string str = "responseText is null";
      string empty = string.Empty;
      if (response != null)
      {
        str = response.Text;
        empty = response.status.ToString();
      }
      ModalWindow.Show(Consts.GetInstance().pay_error + " status=" + empty, Consts.GetInstance().pay_dataerror, (System.Action) (() => { }));
      this.ItemPayStop(string.Empty);
    }
label_12:
    return flag;
  }

  [DebuggerHidden]
  private IEnumerator IEnItemSpend(string sdkorder)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003CIEnItemSpend\u003Ec__Iterator181()
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
    this.payOrder = index;
    this.msgType = 3;
    this.msgFlag = 1;
  }

  [DebuggerHidden]
  private IEnumerator pcbuyitem(int gold)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LCMObj.\u003Cpcbuyitem\u003Ec__Iterator182()
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
