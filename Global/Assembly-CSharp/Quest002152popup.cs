// Decompiled with JetBrains decompiler
// Type: Quest002152popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Quest002152popup : BackButtonMenuBase
{
  [SerializeField]
  private UI2DSprite LeftChara;
  [SerializeField]
  private UI2DSprite RightChara;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtLiberation;
  public int lvv;

  public void PopupSetiing()
  {
    this.TxtDescription.SetTextLocalize("ディランダル\nと\nエクスカリバー\nの[ffff00]" + "親密Lv" + this.lvv.ToString() + "[-]以上");
    this.TxtLiberation.SetTextLocalize("エピソード解放条件");
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
