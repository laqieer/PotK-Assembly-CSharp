// Decompiled with JetBrains decompiler
// Type: Invite0135Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
