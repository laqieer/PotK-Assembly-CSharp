// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ShopArticle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ShopArticle
  {
    public int ID;
    public string name;
    public string description;
    public int shop_ShopShop;
    public int view_order;
    public int pay_type_CommonPayType;
    public int? pay_id;
    public int price;
    public string unit;
    public int? limit;
    public int? daily_limit;
    public bool _enable;
    public DateTime? start_at;
    public DateTime? end_at;
    public int? month_start_at;
    public int? month_end_at;
    public int? day_start_at;
    public int? day_end_at;
    public bool sunday_enable;
    public bool monday_enable;
    public bool tuesday_enable;
    public bool wednesday_enable;
    public bool thursday_enable;
    public bool friday_enable;
    public bool saturday_enable;

    public static ShopArticle Parse(MasterDataReader reader)
    {
      return new ShopArticle()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        shop_ShopShop = reader.ReadInt(),
        view_order = reader.ReadInt(),
        pay_type_CommonPayType = reader.ReadInt(),
        pay_id = reader.ReadIntOrNull(),
        price = reader.ReadInt(),
        unit = reader.ReadString(true),
        limit = reader.ReadIntOrNull(),
        daily_limit = reader.ReadIntOrNull(),
        _enable = reader.ReadBool(),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull(),
        month_start_at = reader.ReadIntOrNull(),
        month_end_at = reader.ReadIntOrNull(),
        day_start_at = reader.ReadIntOrNull(),
        day_end_at = reader.ReadIntOrNull(),
        sunday_enable = reader.ReadBool(),
        monday_enable = reader.ReadBool(),
        tuesday_enable = reader.ReadBool(),
        wednesday_enable = reader.ReadBool(),
        thursday_enable = reader.ReadBool(),
        friday_enable = reader.ReadBool(),
        saturday_enable = reader.ReadBool()
      };
    }

    public ShopShop shop
    {
      get
      {
        ShopShop shop;
        if (!MasterData.ShopShop.TryGetValue(this.shop_ShopShop, out shop))
          Debug.LogError((object) ("Key not Found: MasterData.ShopShop[" + (object) this.shop_ShopShop + "]"));
        return shop;
      }
    }

    public CommonPayType pay_type => (CommonPayType) this.pay_type_CommonPayType;

    public ShopContent[] ShopContents
    {
      get
      {
        return ((IEnumerable<ShopContent>) MasterData.ShopContentList).Where<ShopContent>((Func<ShopContent, bool>) (x => x.article.ID == this.ID)).ToArray<ShopContent>();
      }
    }

    public bool UpperLimitCheck()
    {
      bool flag = false;
      Player player = SMManager.Get<Player>();
      PlayerUnit[] source1 = SMManager.Get<PlayerUnit[]>();
      PlayerMaterialUnit[] source2 = SMManager.Get<PlayerMaterialUnit[]>();
      PlayerItem[] source3 = SMManager.Get<PlayerItem[]>();
      PlayerSeasonTicket[] source4 = SMManager.Get<PlayerSeasonTicket[]>();
      PlayerQuestKey[] source5 = SMManager.Get<PlayerQuestKey[]>();
      ShopContent[] shopContents = this.ShopContents;
      foreach (ShopContent shopContent in shopContents)
      {
        ShopContent content = shopContent;
        int num = -1;
        if (content.upper_limit_check)
        {
          CommonRewardType entityType = content.entity_type;
          switch (entityType)
          {
            case CommonRewardType.unit:
            case CommonRewardType.material_unit:
              if (MasterData.UnitUnit[content.entity_id].IsNormalUnit)
              {
                num = ((IEnumerable<PlayerUnit>) source1).Count<PlayerUnit>((Func<PlayerUnit, bool>) (x => x.unit.ID == content.entity_id));
                break;
              }
              PlayerMaterialUnit playerMaterialUnit = ((IEnumerable<PlayerMaterialUnit>) source2).FirstOrDefault<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (x => x._unit == content.entity_id));
              num = playerMaterialUnit == null ? 0 : playerMaterialUnit.quantity;
              break;
            case CommonRewardType.supply:
              num = ((IEnumerable<PlayerItem>) source3).Count<PlayerItem>((Func<PlayerItem, bool>) (x => x.supply != null && x.supply.ID == content.entity_id));
              break;
            case CommonRewardType.gear:
              num = ((IEnumerable<PlayerItem>) source3).Count<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null && x.gear.ID == content.entity_id));
              break;
            case CommonRewardType.money:
              num = player.money;
              break;
            case CommonRewardType.peculiar:
            case CommonRewardType.player_exp:
            case CommonRewardType.unit_exp:
            case CommonRewardType.gear_experience_point:
            case CommonRewardType.gear_training_point:
            case CommonRewardType.recover:
            case CommonRewardType.max_unit:
            case CommonRewardType.max_item:
            case CommonRewardType.emblem:
            case CommonRewardType.cp_recover:
            case CommonRewardType.mp_recover:
              break;
            case CommonRewardType.coin:
              num = player.coin;
              break;
            case CommonRewardType.medal:
              num = player.medal;
              break;
            case CommonRewardType.friend_point:
              num = player.friend_point;
              break;
            case CommonRewardType.battle_medal:
              num = player.battle_medal;
              break;
            case CommonRewardType.quest_key:
              PlayerQuestKey playerQuestKey = ((IEnumerable<PlayerQuestKey>) source5).FirstOrDefault<PlayerQuestKey>((Func<PlayerQuestKey, bool>) (x => x.quest_key_id == content.entity_id));
              if (playerQuestKey != null)
              {
                num = playerQuestKey.quantity;
                break;
              }
              break;
            case CommonRewardType.gacha_ticket:
              num = ((IEnumerable<PlayerGachaTicket>) player.gacha_tickets).Count<PlayerGachaTicket>((Func<PlayerGachaTicket, bool>) (x => x.ticket.ID == content.entity_id));
              break;
            case CommonRewardType.season_ticket:
              PlayerSeasonTicket playerSeasonTicket = ((IEnumerable<PlayerSeasonTicket>) source4).FirstOrDefault<PlayerSeasonTicket>((Func<PlayerSeasonTicket, bool>) (x => x.season_ticket_id == content.entity_id));
              if (playerSeasonTicket != null)
              {
                num = playerSeasonTicket.quantity;
                break;
              }
              break;
            default:
              if (entityType == CommonRewardType.deck)
                break;
              break;
          }
        }
        if (num >= content.upper_limit_count)
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    public Future<Sprite> LoadSpriteThumbnail()
    {
      ShopContent shopContent = this.ShopContents[0];
      if (shopContent.entity_type == CommonRewardType.supply)
        return MasterData.SupplySupply[shopContent.entity_id].LoadSpriteThumbnail();
      if (shopContent.entity_type == CommonRewardType.gear)
        return MasterData.GearGear[shopContent.entity_id].LoadSpriteThumbnail();
      if (shopContent.entity_type == CommonRewardType.unit || shopContent.entity_type == CommonRewardType.material_unit)
        return MasterData.UnitUnit[shopContent.entity_id].LoadSpriteThumbnail();
      return shopContent.entity_type == CommonRewardType.quest_key ? MasterData.QuestkeyQuestkey[shopContent.entity_id].LoadSpriteThumbnail() : Singleton<ResourceManager>.GetInstance().Load<Sprite>("Sprites/1x1_pink");
    }
  }
}
