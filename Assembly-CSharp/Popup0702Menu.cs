// Decompiled with JetBrains decompiler
// Type: Popup0702Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using System.Collections;
using UnityEngine;

public class Popup0702Menu : BackButtonMonoBehaiviour
{
  private System.Action<bool> mCloseCallback;
  private bool pushEnable = true;

  public void Init(System.Action<bool> closeCallBack)
  {
    this.mCloseCallback = closeCallBack;
    this.pushEnable = false;
  }

  public IEnumerator pushOnWait()
  {
    yield return (object) new WaitForSeconds(0.2f);
    this.pushEnable = true;
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
