// Decompiled with JetBrains decompiler
// Type: Invite0135Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Invite0135Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtDescription1left;

  public void updateDescription(string str) => this.txtDescription1left.SetTextLocalize(str);

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
