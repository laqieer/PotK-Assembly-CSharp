// Decompiled with JetBrains decompiler
// Type: Shop999121Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
