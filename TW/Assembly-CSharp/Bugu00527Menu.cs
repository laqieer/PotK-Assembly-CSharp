// Decompiled with JetBrains decompiler
// Type: Bugu00527Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
public class Bugu00527Menu : Bugu005SelectItemListMenuBase
{
  private const int NORMAL_SELECT_MAX = 5;
  public const int SPECIAL_SELECT_MAX = 1;
  [SerializeField]
  protected UILabel NumSpendZenie3;
  [SerializeField]
  protected UILabel NumSelectedCount3;
  [SerializeField]
  protected UILabel NumProsession3;
  [SerializeField]
  private UIButton ibtnYes;
  private Bugu00527Menu.DrillingType drillingType;
  private GameCore.ItemInfo BaseItem;
  private List<InventoryItem> FirstSelectItemList = new List<InventoryItem>();
  private bool firstInit = true;

  private bool IsActiveDrillingMaterial(GameCore.ItemInfo item)
  {
    if (this.BaseItem == null)
      return false;
    return item.gear.kind.Enum == this.BaseItem.gear.kind.Enum || item.gear.kind.Enum == GearKindEnum.drilling;
  }

  private bool IsActiveSpecialDrillingMaterial(GameCore.ItemInfo item)
  {
    if (this.BaseItem == null)
      return false;
    if (item.gear.group_id == this.BaseItem.gear.group_id)
      return true;
    if (item.gear.kind.Enum != GearKindEnum.special_drilling)
      return false;
    if (item.gear.special_drilling_kind == null)
      return true;
    return item.gear.special_drilling_kind != null && item.gear.special_drilling_kind.Enum == this.BaseItem.gear.kind.Enum;
  }

  public void SetFirstSelectItem(
    Bugu00527Menu.DrillingType dType,
    List<InventoryItem> items,
    GameCore.ItemInfo target)
  {
    this.drillingType = dType;
    this.BaseItem = target;
    this.FirstSelectItemList = items;
    this.SelectMax = this.drillingType != Bugu00527Menu.DrillingType.Normal ? 1 : 5;
  }

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052DrillingMaterialSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return this.drillingType == Bugu00527Menu.DrillingType.Normal ? ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x =>
    {
      if (x.gear == null || x.id == this.BaseItem.itemID || x.gear.disappearance_num.HasValue)
        return false;
      return x.gear.kind.isEquip || x.gear.kind.Enum == GearKindEnum.drilling;
    })).ToList<PlayerItem>() : ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x =>
    {
      if (x.gear == null || x.id == this.BaseItem.itemID || x.gear.disappearance_num.HasValue)
        return false;
      return x.gear.kind.isEquip || x.gear.kind.Enum == GearKindEnum.special_drilling;
    })).ToList<PlayerItem>();
  }

  protected override List<PlayerMaterialGear> GetMaterialList()
  {
    List<PlayerMaterialGear> res = new List<PlayerMaterialGear>();
    if (this.drillingType == Bugu00527Menu.DrillingType.Normal)
      ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x =>
      {
        if (x.gear == null || x.id == this.BaseItem.itemID || x.gear.disappearance_num.HasValue)
          return false;
        return x.gear.kind.isEquip || x.gear.kind.Enum == GearKindEnum.drilling;
      })).ForEach<PlayerMaterialGear>((Action<PlayerMaterialGear>) (x =>
      {
        int num = x.quantity >= this.SelectMax ? this.SelectMax : x.quantity;
        for (int index = 0; index < num; ++index)
          res.Add(x);
      }));
    else
      ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x =>
      {
        if (x.gear == null || x.id == this.BaseItem.itemID || x.gear.disappearance_num.HasValue)
          return false;
        return x.gear.kind.isEquip || x.gear.kind.Enum == GearKindEnum.special_drilling;
      })).ForEach<PlayerMaterialGear>((Action<PlayerMaterialGear>) (x =>
      {
        int num = x.quantity >= this.SelectMax ? this.SelectMax : x.quantity;
        for (int index = 0; index < num; ++index)
          res.Add(x);
      }));
    return res;
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00527Menu.\u003CInitExtension\u003Ec__Iterator400()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void BottomInfoUpdate()
  {
    Player player = SMManager.Get<Player>();
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    int num1 = (int) ((boostInfo != null ? boostInfo.DiscountGearDrilling : 1.0M) * (Decimal) (this.drillingType != Bugu00527Menu.DrillingType.Normal ? (float) CalcItemCost.GetSpecialDrillingCost(this.BaseItem, this.SelectItemList) : CalcItemCost.GetNormalDrillingCost(this.SelectItemList)));
    this.NumSpendZenie3.SetTextLocalize(num1);
    this.NumSpendZenie3.color = num1 >= player.money ? Color.red : Color.white;
    this.NumSelectedCount3.SetTextLocalize("{0}/{1}".F((object) this.SelectItemList.Count<InventoryItem>(), (object) (this.drillingType != Bugu00527Menu.DrillingType.Normal ? 1 : 5)));
    int num2 = (int) ((boostInfo != null ? boostInfo.BootRateGearDrilling : 1.0M) * this.SelectItemList.Sum<InventoryItem>((Func<InventoryItem, Decimal>) (x => Math.Floor((Decimal) GearDrilling.GetGearDrilling(x.Item.gearLevel, x.Item.gear.rarity.index) * (Decimal) x.Item.gear.drilling_rate))));
    if (this.drillingType == Bugu00527Menu.DrillingType.Special)
      num2 = 0;
    this.NumProsession3.SetTextLocalize(num2);
    this.ibtnYes.isEnabled = this.SelectItemList.Count<InventoryItem>() > 0 && player.money >= num1;
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    InventoryItem byItemIndex = this.InventoryItems.FindByItemIndex(item);
    if (byItemIndex != null)
    {
      if (byItemIndex.select)
        this.RemoveSelectItem(byItemIndex);
      else if (this.SelectItemList.Count < this.SelectMax)
        this.AddSelectItem(byItemIndex);
    }
    this.UpdateSelectItemIndexWithInfo();
  }

  protected override bool DisableTouchIcon(InventoryItem item)
  {
    return this.drillingType == Bugu00527Menu.DrillingType.Normal && !this.IsActiveDrillingMaterial(item.Item) || this.drillingType == Bugu00527Menu.DrillingType.Special && !this.IsActiveSpecialDrillingMaterial(item.Item) || base.DisableTouchIcon(item);
  }

  public override void IbtnBack()
  {
    if (this.IsPush)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Bugu0059Scene.changeScene(false, this.BaseItem, this.FirstSelectItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x =>
    {
      InventoryItem inventoryItem = this.InventoryItems.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (i => i.Item.itemID == x.Item.itemID));
      return inventoryItem != null && !inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle;
    })).ToList<InventoryItem>());
  }

  public void IbtnDecision()
  {
    if (this.IsPush)
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Bugu0059Scene.changeScene(false, this.BaseItem, this.SelectItemList);
  }

  public enum DrillingType
  {
    Normal,
    Special,
  }
}
