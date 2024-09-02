// Decompiled with JetBrains decompiler
// Type: Popup0702Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Popup0702Menu : BackButtonMonoBehaiviour
{
  private Action<bool> mCloseCallback;
  private bool pushEnable = true;

  public void Init(Action<bool> closeCallBack)
  {
    this.mCloseCallback = closeCallBack;
    this.pushEnable = false;
  }

  [DebuggerHidden]
  public IEnumerator pushOnWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0702Menu.\u003CpushOnWait\u003Ec__Iterator9BE()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnEnable() => this.StartCoroutine(this.pushOnWait());

  public void onYes()
  {
    if (!this.pushEnable)
      return;
    this.pushEnable = false;
    Singleton<EarthDataManager>.GetInstance().EarthDataRevert();
    this.mCloseCallback(true);
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public void onNo()
  {
    if (!this.pushEnable)
      return;
    this.pushEnable = false;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.onNo();
}
