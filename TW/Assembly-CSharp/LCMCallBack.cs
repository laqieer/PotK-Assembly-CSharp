// Decompiled with JetBrains decompiler
// Type: LCMCallBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    ModalWindow.Show(Consts.GetInstance().pay, Consts.GetInstance().pay_fail, (System.Action) (() => { }));
  }

  private void LCMSDKLogoutComplete()
  {
  }

  private void remoteMessage(string json) => this.LCMData.remoteMessage(json);

  private void setJavaPackageName(string value) => LCMNative_Android.setPackageName(value);

  private void LCMLink(string val)
  {
    if (val == "true")
      ModalWindow.Show(Consts.GetInstance().link_OK, Consts.GetInstance().link_success, (System.Action) (() => { }));
    else
      ModalWindow.Show(Consts.GetInstance().link_fail, val, (System.Action) (() => { }));
  }

  private void LCMLoad(string val)
  {
    if (val == "true")
      ModalWindow.Show(Consts.GetInstance().link_OK, Consts.GetInstance().linkload_success, (System.Action) (() => { }));
    else
      ModalWindow.Show(Consts.GetInstance().linkload_fail, val, (System.Action) (() => { }));
  }

  private void HasLink(string val)
  {
    if (!(val == "true"))
      return;
    this.LCMData.setHasLink();
  }

  private void LCMUnlink(string val)
  {
    if (val == "true")
      ModalWindow.Show(Consts.GetInstance().link_OK, Consts.GetInstance().unlink_success, (System.Action) (() => { }));
    else
      ModalWindow.Show(Consts.GetInstance().unlink_fail, val, (System.Action) (() => { }));
  }
}
