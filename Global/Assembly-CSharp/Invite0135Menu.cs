// Decompiled with JetBrains decompiler
// Type: Invite0135Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
