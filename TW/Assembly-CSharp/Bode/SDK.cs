// Decompiled with JetBrains decompiler
// Type: Bode.SDK
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Bode
{
  public class SDK
  {
    private static SDK _instance;
    private SDKBase sdkInstance;
    private static GameObject sdkObj;

    private event System.Action OnLoginSuc;

    public static void Init()
    {
      GameObject gameObject = new GameObject();
      ((Object) gameObject).name = "SDKObject_Dnt";
      SDK.sdkObj = gameObject;
      Object.DontDestroyOnLoad((Object) gameObject);
    }

    public static SDK instance
    {
      get
      {
        if (SDK._instance == null)
        {
          SDK._instance = new SDK();
          SDK.Init();
          SDK._instance.sdkInstance = (SDKBase) SDK.sdkObj.AddComponent<LCMSDK>();
        }
        return SDK._instance;
      }
    }

    public void start() => this.sdkInstance.start(SDK.sdkObj);

    public bool IsLogined() => this.sdkInstance.isLoginFinish();

    public void createRoleExtra(string roleid, string rolename, string zoneid)
    {
      this.sdkInstance.createRoleExtra(roleid, rolename, zoneid);
    }

    public void Quit() => this.sdkInstance.Quit();

    public string GetToken()
    {
      string empty = string.Empty;
      return this.sdkInstance.getToken();
    }

    public string GetPlayID()
    {
      string empty = string.Empty;
      return this.sdkInstance.getPlayID();
    }

    public string GetAccountID()
    {
      string empty = string.Empty;
      return this.sdkInstance.getAccountID();
    }

    public void SDKInit() => this.sdkInstance.SDKInit();

    public void Login() => this.sdkInstance.Login();

    public void LogOut(bool pVal) => this.sdkInstance.LogOut();

    public void buyItem(int index) => this.sdkInstance.buyItem(index);

    public void testPay() => this.sdkInstance.testPay();

    public void testPaySpand() => this.sdkInstance.testPaySpand();

    public void testPayQuick(int index) => this.sdkInstance.testPayQuick(index);

    public void setPayFinishAct(Action<int, int, int> payEvent)
    {
      this.sdkInstance.setPayFinishAct(payEvent);
    }

    public int getLMoney() => this.sdkInstance.getLMoney();

    public bool isShowMoney() => this.sdkInstance.getIsShowMoney();

    public void ItemPayStop(string msg) => this.sdkInstance.ItemPayStop(msg);

    public void addOnLoginSuc(System.Action act) => this.OnLoginSuc += act;

    public void removeOnLoginSuc(System.Action act) => this.OnLoginSuc -= act;

    public void link(string linkType) => this.sdkInstance.link(linkType);

    public void unlink() => this.sdkInstance.unlink();

    public void loadaccount(string linkType, string oneKeyStr)
    {
      this.sdkInstance.loadaccount(linkType, oneKeyStr);
    }
  }
}
