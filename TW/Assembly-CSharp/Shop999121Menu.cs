// Decompiled with JetBrains decompiler
// Type: Shop999121Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Shop999121Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;

  public void SetText()
  {
    string text1 = Consts.Format(Consts.GetInstance().SHOP_999121_TXT_TITLE);
    string text2 = Consts.Format(Consts.GetInstance().SHOP_999121_TXT_DESCRIPTION);
    this.TxtTitle.SetText(text1);
    this.TxtDescription.SetText(text2);
  }

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().closeAll();

  public override void onBackButton() => this.IbtnPopupOk();
}
