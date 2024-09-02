// Decompiled with JetBrains decompiler
// Type: Gacha99941Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Gacha99941Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtPopupTitle;

  public virtual void IbtnPopupBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void SetText()
  {
    this.TxtDescription01.SetText(Consts.Format(Consts.GetInstance().GACHA_99941MENU_DESCRIPTION01));
    this.TxtPopupTitle.SetText(Consts.Format(Consts.GetInstance().GACHA_99941MENU_DESCRIPTION02));
  }

  public override void onBackButton() => this.IbtnPopupBack();
}
