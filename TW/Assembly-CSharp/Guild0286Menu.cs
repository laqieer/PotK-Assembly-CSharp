// Decompiled with JetBrains decompiler
// Type: Guild0286Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guild0286Menu : Guild0286Scroll
{
  private const int iconWidth = 620;
  private const int iconHeight = 175;
  private const int iconColumnValue = 1;
  private const int iconRowValue = 12;
  private const int iconScreenValue = 8;
  private const int iconMaxValue = 12;
  private const int MAX_RECEIVE = 60;
  [SerializeField]
  private UIButton ibtnReceiveAll;
  [SerializeField]
  private UIButton ibtnGreedItem;
  private ModalWindow popup;
  [SerializeField]
  private CreateIconObject itemIcon;
  [SerializeField]
  private GameObject giftItemPos;
  [SerializeField]
  private UILabel haveValueLabel;
  [SerializeField]
  private UILabel itemNameLabel;
  private GameObject itemDetailPopup;
  private GameObject receivePrefab;
  [SerializeField]
  private GameObject noGiftTxt;

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Guild0281Scene.ChangeSceneGuildTop();
  }

  public virtual void onButtonRecieveAll()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ReceiveAll());
  }

  public void onButtonSend()
  {
    if (this.IsPushAndSet())
      return;
    Guild02861Scene.ChangeScene();
  }

  public void onButtonHaveItem()
  {
    if (this.IsPushAndSet())
      return;
    Guild02862Scene.ChangeScene();
  }

  private void SetHaveItemValue()
  {
    Player player = SMManager.Get<Player>();
    PlayerUnit[] self1 = SMManager.Get<PlayerUnit[]>();
    PlayerMaterialUnit[] source = SMManager.Get<PlayerMaterialUnit[]>();
    PlayerItem[] self2 = SMManager.Get<PlayerItem[]>();
    PlayerMaterialGear[] self3 = SMManager.Get<PlayerMaterialGear[]>();
    GuildMemberGift gift = new GuildMemberGift();
    gift.gift_reward_id = PlayerAffiliation.Current.Player.gift_reward_id;
    gift.gift_reward_type_id = PlayerAffiliation.Current.Player.gift_reward_type_id;
    gift.gift_reward_quantity = PlayerAffiliation.Current.Player.gift_reward_quantity;
    int num = 0;
    int giftRewardTypeId = gift.gift_reward_type_id;
    switch (giftRewardTypeId)
    {
      case 14:
        num = player.medal;
        break;
      case 15:
        num = player.friend_point;
        break;
      case 17:
        num = player.battle_medal;
        break;
      case 19:
        PlayerQuestKey[] self4 = SMManager.Get<PlayerQuestKey[]>();
        int? nullable1 = ((IEnumerable<PlayerQuestKey>) self4).FirstIndexOrNull<PlayerQuestKey>((Func<PlayerQuestKey, bool>) (x => x.quest_key_id == gift.gift_reward_id));
        num = !nullable1.HasValue ? 0 : self4[nullable1.Value].quantity;
        break;
      case 20:
        int? nullable2 = ((IEnumerable<PlayerGachaTicket>) player.gacha_tickets).FirstIndexOrNull<PlayerGachaTicket>((Func<PlayerGachaTicket, bool>) (x => x.ticket_id == gift.gift_reward_id));
        num = !nullable2.HasValue ? 0 : player.gacha_tickets[nullable2.Value].quantity;
        break;
      case 24:
        PlayerMaterialUnit playerMaterialUnit = ((IEnumerable<PlayerMaterialUnit>) source).FirstOrDefault<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (x => x._unit == gift.gift_reward_id));
        if (playerMaterialUnit != null)
        {
          num = playerMaterialUnit.quantity;
          break;
        }
        break;
      case 26:
        num = self3.AmountHavingTargetItem(gift.gift_reward_id);
        break;
      default:
        switch (giftRewardTypeId - 1)
        {
          case 0:
            if (MasterData.UnitUnit.ContainsKey(gift.gift_reward_id))
            {
              num = self1.AmountHavingTargetUnit(gift.gift_reward_id, (MasterDataTable.CommonRewardType) gift.gift_reward_type_id);
              break;
            }
            break;
          case 1:
            num = self2.AmountHavingTargetItem(gift.gift_reward_id, (MasterDataTable.CommonRewardType) gift.gift_reward_type_id);
            break;
          case 2:
            num = self2.AmountHavingTargetItem(gift.gift_reward_id, (MasterDataTable.CommonRewardType) gift.gift_reward_type_id);
            break;
          case 3:
            num = player.money;
            break;
          case 9:
            num = player.coin;
            break;
        }
        break;
    }
    this.haveValueLabel.SetTextLocalize(num);
  }

  private void InitEndAction()
  {
    this.SetHaveItemValue();
    this.CheckAllReceive();
  }

  private void CheckAllReceive()
  {
    if (this.memberGifts.Length == 0)
    {
      this.ibtnReceiveAll.duration = 0.0f;
      this.ibtnReceiveAll.isEnabled = false;
      this.noGiftTxt.SetActive(true);
      if (!Persist.guildSetting.Exists || !GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift))
        return;
      GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newGift, false);
      Persist.guildSetting.Flush();
      Singleton<CommonRoot>.GetInstance().SetGuildFooterBadgeBikkuri();
    }
    else
    {
      this.ibtnReceiveAll.isEnabled = true;
      this.noGiftTxt.SetActive(false);
    }
  }

  private void onLongPressIcon()
  {
    if (this.IsPushAndSet())
      return;
    int giftRewardTypeId = PlayerAffiliation.Current.Player.gift_reward_type_id;
    switch (giftRewardTypeId)
    {
      case 19:
      case 21:
      case 24:
      case 26:
label_3:
        this.StartCoroutine(this.ShowDetailPopup());
        break;
      default:
        switch (giftRewardTypeId - 1)
        {
          case 0:
          case 1:
          case 2:
            goto label_3;
        }
        break;
    }
    this.IsPush = false;
  }

  [DebuggerHidden]
  private IEnumerator ShowDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CShowDetailPopup\u003Ec__Iterator7B8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetHaveItemIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CSetHaveItemIcon\u003Ec__Iterator7B9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CResourceLoad\u003Ec__Iterator7BA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(GuildMemberGift[] gifts)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CInit\u003Ec__Iterator7BB()
    {
      gifts = gifts,
      \u003C\u0024\u003Egifts = gifts,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ReceiveConnection(GuildMemberGift gift)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CReceiveConnection\u003Ec__Iterator7BC()
    {
      gift = gift,
      \u003C\u0024\u003Egift = gift,
      \u003C\u003Ef__this = this
    };
  }

  private void IbtnReceive(GuildMemberGift gift)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ReceiveConnection(gift));
  }

  [DebuggerHidden]
  private IEnumerator ReceiveAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Menu.\u003CReceiveAll\u003Ec__Iterator7BD()
    {
      \u003C\u003Ef__this = this
    };
  }
}
