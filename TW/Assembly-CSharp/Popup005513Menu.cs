// Decompiled with JetBrains decompiler
// Type: Popup005513Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Popup005513Menu : BackButtonMonoBehaiviour
{
  [SerializeField]
  private GameObject txtDescriptionLimit;
  private System.Action action;

  public void Init(System.Action action, bool isMoneyOverAlert)
  {
    this.action = action;
    this.txtDescriptionLimit.SetActive(isMoneyOverAlert);
  }

  public void IbtnYes()
  {
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.action == null)
      return;
    this.action();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
