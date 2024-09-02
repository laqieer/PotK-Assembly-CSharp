// Decompiled with JetBrains decompiler
// Type: LCMSDK
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class LCMSDK : SDKBase
{
  public static LCMObj gLCMObj;
  public static bool _IsClone;
  public static LCMCallBack lcmCallBackObj;

  public override void start(GameObject gObj)
  {
    if (!LCMSDK._IsClone)
    {
      ((Object) gObj).name = "LCMCallBack";
      LCMSDK.lcmCallBackObj = gObj.AddComponent<LCMCallBack>();
      LCMSDK.gLCMObj = gObj.AddComponent<LCMObj>();
      LCMSDK.gLCMObj.initParam();
      LCMSDK.lcmCallBackObj.LCMData = LCMSDK.gLCMObj;
      Object.DontDestroyOnLoad((Object) LCMSDK.lcmCallBackObj);
      Object.DontDestroyOnLoad((Object) LCMSDK.gLCMObj);
      LCMSDK._IsClone = true;
      this.getSDKLoginInfo();
    }
    else
      LCMSDK.gLCMObj.start();
  }

  public override void LogOut() => LCMNative_Android.logout();

  public override void Quit() => LCMNative_Android.exitSDK();

  public override string getToken() => LCMSDK.gLCMObj.getToken();

  public override string getPlayID() => LCMSDK.gLCMObj.getPlay_id();

  public override string getAccountID() => LCMSDK.gLCMObj.getAccountid();

  public override bool isLoginFinish() => LCMSDK.gLCMObj.isLogin();

  public override void SDKInit()
  {
  }

  public override void Login() => LCMNative_Android.login();

  public override void createRoleExtra(string roleid, string rolename, string zoneid)
  {
    LCMNative_Android.createRole(roleid, rolename, zoneid);
  }

  public void getSDKLoginInfo() => LCMNative_Android.getSDKLoginInfo();

  public void pcAccessToken()
  {
    string userName = GameConfig.UserName;
    LCMSDK.gLCMObj.onLoginComplete(userName + "#user#{\"userId\":\"4812\"}#decodedAccessToken#{\"p1\":\"aaa\"}");
    LCMPayItemLst.getInstance.pcitemlst();
  }

  public void pcLCMswitchpc()
  {
    string str = "stone";
    LCMSDK.gLCMObj.onLoginComplete(str + "#user#{\"userId\":\"4813\"}#decodedAccessToken#{\"p1\":\"aaa\"}");
  }

  public override void testPay() => LCMNative_Android.getPayItemList();

  public override void testPaySpand() => LCMNative_Android.onlyPurchase();

  public override void testPayQuick(int index)
  {
    LCMPayData payItemData = LCMPayItemLst.getInstance.getPayItemData(index);
    LCMSDK.gLCMObj.createItemOrder(payItemData, true);
  }

  public override void buyItem(int index) => LCMSDK.gLCMObj.buyItem(index);

  public override void setPayFinishAct(Action<int, int, int> payEvent)
  {
    LCMSDK.gLCMObj.setPayFinishAct(payEvent);
  }

  public override int getLMoney() => LCMSDK.gLCMObj.getLMoney();

  public override bool getIsShowMoney() => LCMSDK.gLCMObj.getIsShowMoney();

  public override void ItemPayStop(string msg) => LCMSDK.gLCMObj.ItemPayStop(msg);

  public override void link(string linkType) => LCMNative_Android.link(linkType);

  public override void unlink() => LCMNative_Android.unlink();

  public override void loadaccount(string linkType, string oneKeyStr)
  {
    LCMNative_Android.loadaccount(linkType, oneKeyStr);
  }
}
