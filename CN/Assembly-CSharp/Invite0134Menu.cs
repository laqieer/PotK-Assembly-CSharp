// Decompiled with JetBrains decompiler
// Type: Invite0134Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Invite0134Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtDescription00;
  [SerializeField]
  protected UILabel TxtDescription01;
  [SerializeField]
  protected UILabel TxtDescription02;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  private UI2DSprite linkItem;

  protected virtual void IbtnPopupBack()
  {
  }

  protected virtual void IbtnPopupOk()
  {
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void updateDescription00(string str) => this.TxtDescription00.SetTextLocalize(str);

  public void updateDescription01(CommonRewardType crt)
  {
    this.TxtDescription01.SetTextLocalize(Consts.Format(Consts.GetInstance().INVITE_0134_MENU_UPDATE_DESCRIPTION, (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) crt.quantity_
      }
    }));
  }

  public void updateDescription02(string str) => this.TxtDescription02.SetTextLocalize(str);

  public void updateLinkItem(Sprite sprite) => this.linkItem.sprite2D = sprite;

  public void updateDescriptions(WebAPI.Response.InvitationAcceptRewards[] iar)
  {
    if (iar[0].reward_type_id != 10)
      return;
    this.TxtDescription01.SetTextLocalize(Consts.Format(Consts.GetInstance().INVITE_0134_MENU_UPDATE_DESCRIPTION, (IDictionary) new Hashtable()
    {
      {
        (object) "num",
        (object) iar[0].reward_quantity
      }
    }));
  }
}
