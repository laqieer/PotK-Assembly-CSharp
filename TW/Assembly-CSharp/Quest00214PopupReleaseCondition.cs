// Decompiled with JetBrains decompiler
// Type: Quest00214PopupReleaseCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Quest00214PopupReleaseCondition : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtDescription;

  public void Init(string message) => this.TxtDescription.SetText(message);

  public void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOk();
}
