// Decompiled with JetBrains decompiler
// Type: CommonRewardType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class CommonRewardType
{
  public readonly int type_;
  public readonly int id_;
  public readonly int quantity_;
  public readonly bool is_new_;
  public readonly PlayerUnit unit;
  public readonly PlayerMaterialUnit materialUnit;
  public readonly PlayerItem gear;
  public readonly GearGear gearGear;
  public readonly UnitUnit unitUnit;
  public readonly SupplySupply supplySupply;
  public readonly bool isUnit;
  public readonly bool isMaterialUnit;
  public readonly bool isGear;
  public readonly bool isSupply;
  public GameObject Icon;
  public global::UnitIcon UnitIconScript;
  public global::ItemIcon ItemIconScript;

  public CommonRewardType(int type, int id, int quantity, bool is_new = false)
  {
    this.type_ = type;
    this.id_ = id;
    this.quantity_ = quantity;
    this.is_new_ = is_new;
    this.isUnit = this.type_ == 1;
    this.isMaterialUnit = this.type_ == 24;
    this.isGear = this.type_ == 3;
    this.isSupply = this.type_ == 2;
    if (this.isUnit)
    {
      this.unit = ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (Unit => Unit.id == id)).FirstOrDefault<PlayerUnit>();
      this.unitUnit = ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).FirstOrDefault<UnitUnit>((Func<UnitUnit, bool>) (fd => fd.ID == id));
    }
    else if (this.isMaterialUnit)
    {
      this.materialUnit = ((IEnumerable<PlayerMaterialUnit>) SMManager.Get<PlayerMaterialUnit[]>()).Where<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (Unit => Unit.id == id)).FirstOrDefault<PlayerMaterialUnit>();
      this.unitUnit = ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).FirstOrDefault<UnitUnit>((Func<UnitUnit, bool>) (fd => fd.ID == id));
    }
    else if (this.isGear)
    {
      this.gear = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (Gear => Gear.id == id)).FirstOrDefault<PlayerItem>();
      this.gearGear = ((IEnumerable<GearGear>) MasterData.GearGearList).FirstOrDefault<GearGear>((Func<GearGear, bool>) (fd => fd.ID == id));
    }
    else
    {
      if (!this.isSupply)
        return;
      this.supplySupply = MasterData.SupplySupply[id];
    }
  }

  public void ThenUnit(Action<PlayerUnit> callback)
  {
    if (!this.isUnit)
      return;
    callback(this.unit);
  }

  public void ThenMaterialUnit(Action<PlayerMaterialUnit> callback)
  {
    if (!this.isMaterialUnit)
      return;
    callback(this.materialUnit);
  }

  public void ThenGear(Action<PlayerItem> callback)
  {
    if (!this.isGear)
      return;
    callback(this.gear);
  }

  public void UnitIcon(Action<global::UnitIcon> callback)
  {
    if (!Object.op_Inequality((Object) this.UnitIconScript, (Object) null))
      return;
    callback(this.UnitIconScript);
  }

  public void ItemIcon(Action<global::ItemIcon> callback)
  {
    if (!Object.op_Inequality((Object) this.ItemIconScript, (Object) null))
      return;
    callback(this.ItemIconScript);
  }

  public void ThenSupply(Action<SupplySupply> callback)
  {
    if (!this.isGear)
      return;
    callback(this.supplySupply);
  }

  public GameObject GetIcon() => this.Icon;

  public global::UnitIcon GetUnitIcon() => this.UnitIconScript;

  public global::ItemIcon GetItemIcon() => this.ItemIconScript;

  [DebuggerHidden]
  public IEnumerator CreateIcon(Transform parent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonRewardType.\u003CCreateIcon\u003Ec__IteratorB09()
    {
      parent = parent,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u003Ef__this = this
    };
  }

  public static string GetRewardName(MasterDataTable.CommonRewardType type, int id, int quantity)
  {
    string empty1 = string.Empty;
    string rewardName;
    switch (type)
    {
      case MasterDataTable.CommonRewardType.unit:
      case MasterDataTable.CommonRewardType.material_unit:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_UNIT, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.UnitUnit[id].name
          },
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.supply:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_SUPPLY, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.SupplySupply[id].name
          },
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.gear:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_GEAR, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.GearGear[id].name
          },
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.money:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_ZENY, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.player_exp:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_EXP, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.unit_exp:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_UNITEXP, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.coin:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_STONE, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.recover:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_AP_RECOVER, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.max_unit:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_MAX_UNIT, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.max_item:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_MAX_ITEM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.medal:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.friend_point:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_POINT, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.emblem:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_EMBLEM, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.EmblemEmblem[id].name
          }
        });
        break;
      case MasterDataTable.CommonRewardType.battle_medal:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_BATTLE_MEDAL, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.cp_recover:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_CP_RECOVER, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.quest_key:
        if (!MasterData.QuestkeyQuestkey.ContainsKey(id))
        {
          rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_KEY_DEFAULT, (IDictionary) new Hashtable()
          {
            {
              (object) "Count",
              (object) quantity
            }
          });
          break;
        }
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_KEY, (IDictionary) new Hashtable()
        {
          {
            (object) "Name",
            (object) MasterData.QuestkeyQuestkey[id].name
          },
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.gacha_ticket:
        string empty2 = string.Empty;
        Hashtable args = new Hashtable()
        {
          {
            (object) "Name",
            (object) (!MasterData.GachaTicket.ContainsKey(id) ? Consts.GetInstance().MYPAGE_0017_GACHATICKET_COMMONNAME : MasterData.GachaTicket[id].short_name)
          },
          {
            (object) "Count",
            (object) quantity
          }
        };
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_GACHATICKET_NAME, (IDictionary) args);
        break;
      case MasterDataTable.CommonRewardType.season_ticket:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_SEASONTICKET, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      case MasterDataTable.CommonRewardType.mp_recover:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_MP_RECOVER, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
      default:
        rewardName = Consts.Format(Consts.GetInstance().MYPAGE_0017_OTHER, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
        break;
    }
    return rewardName;
  }

  public static string GetRewardName(MasterDataTable.CommonRewardType type, int id)
  {
    string empty1 = string.Empty;
    switch (type)
    {
      case MasterDataTable.CommonRewardType.unit:
      case MasterDataTable.CommonRewardType.material_unit:
        return MasterData.UnitUnit[id].name;
      case MasterDataTable.CommonRewardType.supply:
        return MasterData.SupplySupply[id].name;
      case MasterDataTable.CommonRewardType.gear:
        return MasterData.GearGear[id].name;
      case MasterDataTable.CommonRewardType.money:
        return Consts.GetInstance().UNIQUE_ICON_ZENY;
      case MasterDataTable.CommonRewardType.player_exp:
        return Consts.GetInstance().UNIQUE_ICON_EXP;
      case MasterDataTable.CommonRewardType.unit_exp:
        return Consts.GetInstance().UNIQUE_ICON_UNITEXT_LONG;
      case MasterDataTable.CommonRewardType.coin:
        return Consts.GetInstance().UNIQUE_ICON_KISEKI;
      case MasterDataTable.CommonRewardType.recover:
        return Consts.GetInstance().UNIQUE_ICON_APRECOVER;
      case MasterDataTable.CommonRewardType.max_unit:
        return Consts.GetInstance().UNIQUE_ICON_MAXUNIT;
      case MasterDataTable.CommonRewardType.max_item:
        return Consts.GetInstance().UNIQUE_ICON_MAXITEM;
      case MasterDataTable.CommonRewardType.medal:
        return Consts.GetInstance().UNIQUE_ICON_MEDAL;
      case MasterDataTable.CommonRewardType.friend_point:
        return Consts.GetInstance().UNIQUE_ICON_POINT;
      case MasterDataTable.CommonRewardType.emblem:
        return MasterData.EmblemEmblem[id].name;
      case MasterDataTable.CommonRewardType.battle_medal:
        return Consts.GetInstance().UNIQUE_ICON_BATTLE_MEDAL;
      case MasterDataTable.CommonRewardType.cp_recover:
        return Consts.GetInstance().UNIQUE_ICON_CPRECOVER;
      case MasterDataTable.CommonRewardType.quest_key:
        return MasterData.QuestkeyQuestkey[id].name;
      case MasterDataTable.CommonRewardType.gacha_ticket:
        string empty2 = string.Empty;
        return !MasterData.GachaTicket.ContainsKey(id) ? Consts.GetInstance().MYPAGE_0017_GACHATICKET_COMMONNAME : MasterData.GachaTicket[id].short_name;
      case MasterDataTable.CommonRewardType.season_ticket:
        return Consts.GetInstance().UNIQUE_ICON_SEASONTICKET;
      case MasterDataTable.CommonRewardType.mp_recover:
        return Consts.GetInstance().UNIQUE_ICON_MPRECOVER;
      default:
        return Consts.GetInstance().UNIQUE_ICON_OTHER;
    }
  }

  public static string GetRewardQuantity(MasterDataTable.CommonRewardType type, int id, int quantity)
  {
    string empty = string.Empty;
    switch (type)
    {
      case MasterDataTable.CommonRewardType.unit:
      case MasterDataTable.CommonRewardType.material_unit:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_UNIT_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.supply:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_SUPPLY_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.gear:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_GEAR_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.money:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_ZENY_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.player_exp:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_EXP_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.coin:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_STONE_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.recover:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_AP_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.max_unit:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_OTHER_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.max_item:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_OTHER_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.medal:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_MEDAL_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.friend_point:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_POINT_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.emblem:
        return Consts.GetInstance().SPECIAL_SHOP_EMBLEM_NUM;
      case MasterDataTable.CommonRewardType.battle_medal:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_BATTLE_MEDAL_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.cp_recover:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_CP_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.quest_key:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_KEY_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.gacha_ticket:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_GACHATICKET_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.season_ticket:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_SEASONTICKETNUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      case MasterDataTable.CommonRewardType.mp_recover:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_MP_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
      default:
        return Consts.Format(Consts.GetInstance().SPECIAL_SHOP_OTHER_NUM, (IDictionary) new Hashtable()
        {
          {
            (object) "Count",
            (object) quantity
          }
        });
    }
  }
}
