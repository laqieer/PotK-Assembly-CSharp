// Decompiled with JetBrains decompiler
// Type: Gacha99961aMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class Gacha99961aMenu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtPopuptitle;

  public Player player_data_ { get; set; }

  public void SetText(int have_bugu, int max_have_bugu, Player player_data)
  {
    this.player_data_ = player_data;
    this.TxtDescription01.SetText(Consts.Lookup("GACHA_99961MENU_DESCRIPTION01"));
    this.TxtDescription02.SetText(Consts.Lookup("GACHA_99961MENU_DESCRIPTION02"));
    this.TxtDescription03.SetText(Consts.Lookup("GACHA_99961MENU_DESCRIPTION03", (IDictionary) new Hashtable()
    {
      {
        (object) "havebugu",
        (object) have_bugu.ToString().ToConverter()
      },
      {
        (object) "maxhavebugu",
        (object) max_have_bugu.ToString().ToConverter()
      }
    }));
    this.TxtPopuptitle.SetText(Consts.Lookup("GACHA_99961MENU_DESCRIPTION04"));
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnPopupExtend()
  {
    this.player_data_ = SMManager.Get<Player>();
    if (this.player_data_.CheckLimitMaxItem())
      this.StartCoroutine(PopupUtility._999_12_1());
    else
      this.StartCoroutine(PopupUtility._007_16(0.0f));
  }

  public void IbtnPopupIntegrate()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Bugu0053Scene.changeScene(true);
  }

  public void IbtnPopupSell()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Bugu0052Scene.changeSceneSell(true);
  }
}
