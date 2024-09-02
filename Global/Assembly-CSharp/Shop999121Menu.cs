// Decompiled with JetBrains decompiler
// Type: Shop999121Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    string text1 = Consts.Lookup("SHOP_999121_TXT_TITLE");
    string text2 = Consts.Lookup("SHOP_999121_TXT_DESCRIPTION");
    this.TxtTitle.SetText(text1);
    this.TxtDescription.SetText(text2);
  }

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().closeAll();

  public override void onBackButton() => this.IbtnPopupOk();
}
