// Decompiled with JetBrains decompiler
// Type: Gacha99941Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
