// Decompiled with JetBrains decompiler
// Type: Bugu00523Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu00523Menu : Bugu005SelectItemListMenuBase
{
  private const float BOTTOM_ICON_SCALE = 0.6617647f;
  [SerializeField]
  private Transform[] materialTargetIcon;
  [SerializeField]
  private UILabel txtSlectedcountNum;
  [SerializeField]
  private UILabel txtSpendzenieNum;
  [SerializeField]
  private UIButton ibtnYes;
  private bool firstInit = true;
  private GameCore.ItemInfo BaseItem;
  private List<GameCore.ItemInfo> FirstSelectItemList = new List<GameCore.ItemInfo>();
  private ItemIcon[] icons;

  public void SetFirstSelectItem(List<GameCore.ItemInfo> items, GameCore.ItemInfo target)
  {
    this.BaseItem = target;
    this.FirstSelectItemList = items;
  }

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052BuildupMaterialSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    List<Bugu0058Menu.PlayerItemSort> playerItemSortList = new List<Bugu0058Menu.PlayerItemSort>();
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.agility_add, GearKindEnum.sword, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.strength_add, GearKindEnum.axe, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.vitality_add, GearKindEnum.spear, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.dexterity_add, GearKindEnum.bow, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.intelligence_add, GearKindEnum.gun, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.mind_add, GearKindEnum.staff, false);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.BaseItem.gearBuildupParam.hp_add, GearKindEnum.shield, false);
    return playerItemSortList.Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => x.item.id != this.BaseItem.itemID)).Select<Bugu0058Menu.PlayerItemSort, PlayerItem>((Func<Bugu0058Menu.PlayerItemSort, PlayerItem>) (x => x.item)).ToList<PlayerItem>();
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00523Menu.\u003CInitExtension\u003Ec__Iterator3F8()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void BottomInfoUpdate()
  {
    Player player = SMManager.Get<Player>();
    int count = this.SelectItemList == null ? 0 : this.SelectItemList.Count;
    for (int index = 0; index < this.SelectMax; ++index)
    {
      if (index < count)
      {
        this.icons[index].SetEmpty(false);
        if (ItemIcon.IsCache(this.SelectItemList[index].Item))
          this.icons[index].InitByItemInfoCache(this.SelectItemList[index].Item);
        else
          this.StartCoroutine(this.icons[index].InitByItemInfo(this.SelectItemList[index].Item));
        this.icons[index].onClick = (Action<ItemIcon>) (playeritem => { });
        this.icons[index].Gray = false;
        this.icons[index].Deselect();
      }
      else
      {
        this.icons[index].SetEmpty(true);
        this.icons[index].onClick = (Action<ItemIcon>) (playeritem => { });
      }
    }
    this.txtSlectedcountNum.SetTextLocalize(count);
    this.txtSlectedcountNum.color = count >= this.SelectMax ? Color.red : Color.white;
    int buildupCost = CalcItemCost.GetBuildupCost(this.SelectItemList.Select<InventoryItem, GameCore.ItemInfo>((Func<InventoryItem, GameCore.ItemInfo>) (x => x.Item)).ToList<GameCore.ItemInfo>());
    this.txtSpendzenieNum.SetTextLocalize(buildupCost);
    this.txtSpendzenieNum.color = player.money < buildupCost ? Color.red : Color.white;
    this.ibtnYes.isEnabled = count > 0 && player.money >= buildupCost;
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    InventoryItem byItem = this.InventoryItems.FindByItem(item);
    if (byItem != null)
    {
      if (byItem.select)
        this.RemoveSelectItem(byItem);
      else if (this.SelectItemList.Count < this.SelectMax)
        this.AddSelectItem(byItem);
    }
    this.UpdateSelectItemIndexWithInfo();
  }

  public override void IbtnBack()
  {
    if (this.IsPush)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Bugu0058Scene.changeScene(false, this.FirstSelectItemList.Where<GameCore.ItemInfo>((Func<GameCore.ItemInfo, bool>) (x =>
    {
      InventoryItem inventoryItem = this.InventoryItems.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (i => i.Item.itemID == x.itemID));
      return inventoryItem != null && !inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle;
    })).ToList<GameCore.ItemInfo>());
  }

  public void IbtnDecision()
  {
    if (this.IsPush)
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Bugu0058Scene.changeScene(false, this.SelectItemList.Select<InventoryItem, GameCore.ItemInfo>((Func<InventoryItem, GameCore.ItemInfo>) (x => x.Item)).ToList<GameCore.ItemInfo>());
  }

  public void onIbtnIcon1()
  {
    this.RemoveSelectItem(1);
    this.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon2()
  {
    this.RemoveSelectItem(2);
    this.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon3()
  {
    this.RemoveSelectItem(3);
    this.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon4()
  {
    this.RemoveSelectItem(4);
    this.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon5()
  {
    this.RemoveSelectItem(5);
    this.UpdateSelectItemIndexWithInfo();
  }
}
