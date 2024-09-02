// Decompiled with JetBrains decompiler
// Type: Shop0074ConfirmPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Shop0074ConfirmPopup : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtDescription04;
  [SerializeField]
  protected UILabel TxtDescription06;
  private Modified<Player> player;
  private int number;

  public void Set(PlayerShopArticle playerShopArticle)
  {
    this.player = SMManager.Observe<Player>();
    this.TxtDescription01.SetText(playerShopArticle.article.description);
    this.TxtDescription02.SetTextLocalize(this.number);
    this.TxtDescription04.SetTextLocalize(playerShopArticle.article.price.ToString() + Consts.Lookup("SHOP_0074_CONFIRM_POPUP_SET"));
  }

  public void onClose() => Singleton<PopupManager>.GetInstance().dismiss();

  private void Update()
  {
    if (this.player == null || !this.player.IsChangedOnce())
      return;
    this.TxtDescription06.SetTextLocalize(Consts.Lookup("SHOP_0074_CONFIRM_POPUP_UPDATE") + (object) this.player.Value.money);
  }
}
