// Decompiled with JetBrains decompiler
// Type: LCMCallBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class LCMCallBack : MonoBehaviour
{
  public LCMObj LCMData;

  private void LCMAccessToken(string val) => this.LCMData.setAccessToken(val);

  private void SetLCMIsSDKLogin(string val)
  {
    if (val == "true")
      this.LCMData.setSDKLogin(true);
    else
      this.LCMData.setSDKLogin(false);
  }

  private void LCMLoginComplete(string val) => this.LCMData.onLoginComplete(val);

  private void LCMSDKLoginComplete(string val) => this.LCMData.onSDKLoginComplete(val);

  private void LCMLoginError(string val)
  {
  }

  private void LCMClearLoginInfo() => this.LCMData.clearLoginInfo();

  private void LCMLogoutComplete(string val) => Application.Quit();

  private void LCMQuitGame(string val)
  {
  }

  private void payItemList(string json) => LCMPayItemLst.getInstance.createItemList(json);

  private void setLMoney(string val) => this.LCMData.setLMoney(val);

  private void LCMIsShowMoney(string val)
  {
    DDebug.Log("LCMIsShowMoney:" + val);
    this.LCMData.setIsShowMoney(val);
  }

  private void LCMItemSpend(string sdkorder) => this.LCMData.itemSpend(sdkorder);

  private void LCMItemPayStop(string msg)
  {
    this.LCMData.ItemPayStop(msg);
    if (msg != string.Empty && msg != "602")
      DDebug.LogError("pay error:" + msg);
    switch (msg)
    {
      case "602":
        ModalWindow.Show(Consts.GetInstance().pay, Consts.GetInstance().pay_network, (System.Action) (() => { }));
        break;
      case "410":
      case "406":
        ModalWindow.Show(Consts.GetInstance().pay, Consts.GetInstance().pay_close, (System.Action) (() => { }));
        break;
      default:
        if (msg == string.Empty)
        {
          ModalWindow.Show(Consts.GetInstance().pay, Consts.GetInstance().pay_fail, (System.Action) (() => { }));
          break;
        }
        ModalWindow.Show(Consts.GetInstance().pay + "(p=" + msg + ")", Consts.GetInstance().pay_fail, (System.Action) (() => { }));
        break;
    }
  }

  private void remoteMessage(string json) => this.LCMData.remoteMessage(json);

  private void setJavaPackageName(string value) => LCMNative_Android.setPackageName(value);

  private void SDKLogoutFinish(string value)
  {
    DDebug.Log("LCMCallBack SDKLogoutFinish");
    this.LCMData.SDKLogoutFinish();
  }

  private void SDKRealName(string value)
  {
    if (value.Trim().ToLower() == "true")
      this.LCMData.canCreatePayOrder(true);
    else
      this.LCMData.canCreatePayOrder(false);
  }
}
