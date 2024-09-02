// Decompiled with JetBrains decompiler
// Type: Popup0701Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup0701Menu : BackButtonMonoBehaiviour
{
  private Action<bool> mCloseCallback;
  private GameObject popup2;
  private bool pushEnable;

  public void Init(Action<bool> closeCallBack, GameObject popup0702)
  {
    this.popup2 = popup0702;
    this.mCloseCallback = closeCallBack;
    this.pushEnable = false;
  }

  [DebuggerHidden]
  public IEnumerator pushOnWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup0701Menu.\u003CpushOnWait\u003Ec__Iterator9BD()
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
    this.Save();
  }

  private void Save()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.mCloseCallback(false);
  }

  public void onNo()
  {
    if (!this.pushEnable)
      return;
    this.pushEnable = false;
    Singleton<PopupManager>.GetInstance().open(this.popup2).GetComponent<Popup0702Menu>().Init(this.mCloseCallback);
  }

  public override void onBackButton() => this.onNo();
}
