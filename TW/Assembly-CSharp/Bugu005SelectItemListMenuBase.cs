// Decompiled with JetBrains decompiler
// Type: Bugu005SelectItemListMenuBase
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
public class Bugu005SelectItemListMenuBase : Bugu005ItemListMenuBase
{
  [SerializeField]
  protected Bugu005SelectItemListMenuBase.SelectModeEnum SelectMode;
  [SerializeField]
  protected bool EnableFavorite;
  [SerializeField]
  protected bool EnableForBattle;
  [SerializeField]
  protected bool EnableBroken;
  [SerializeField]
  private int selectMax;
  protected List<InventoryItem> SelectItemList = new List<InventoryItem>();

  public int SelectMax
  {
    get => this.selectMax;
    set => this.selectMax = value;
  }

  protected virtual void SelectItemProc(GameCore.ItemInfo item)
  {
  }

  protected virtual bool IsGrayIcon(InventoryItem item)
  {
    if (this.DisableTouchIcon(item))
      return true;
    return this.SelectItemList.Count >= this.selectMax ? !item.Gray : item.Gray;
  }

  protected virtual bool DisableTouchIcon(InventoryItem item)
  {
    if (item.Item == null)
      return !this.EnableForBattle || !this.EnableFavorite || !this.EnableBroken;
    if (!this.EnableForBattle && item.Item.ForBattle || !this.EnableFavorite && item.Item.favorite)
      return true;
    return !this.EnableBroken && item.Item.broken;
  }

  protected override void UpdateInvetoryItem(InventoryItem invItem, PlayerItem item)
  {
    invItem.Item.Set(item);
    invItem.select = false;
    invItem.Gray = false;
    if (!this.DisableTouchIcon(invItem))
      return;
    this.RemoveSelectItem(invItem);
  }

  protected override void UpdateInvetoryItem(InventoryItem invItem, PlayerMaterialGear item)
  {
    invItem.Item.Set(item);
    invItem.select = false;
    invItem.Gray = false;
    if (!this.DisableTouchIcon(invItem))
      return;
    this.RemoveSelectItem(invItem);
  }

  protected override void UpdateInventoryItemList()
  {
    List<InventoryItem> list1 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x =>
    {
      if (x.Item == null || x.removeButton)
        return false;
      return x.Item.isWeapon || x.Item.isSupply;
    })).ToList<InventoryItem>();
    if (list1 != null && list1.Count<InventoryItem>() > 0)
    {
      PlayerItem[] source = SMManager.Get<PlayerItem[]>();
      foreach (InventoryItem inventoryItem in list1)
      {
        InventoryItem invItem = inventoryItem;
        PlayerItem playerItem = ((IEnumerable<PlayerItem>) source).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == invItem.Item.itemID));
        if (playerItem != (PlayerItem) null)
          this.UpdateInvetoryItem(invItem, playerItem);
      }
    }
    List<InventoryItem> list2 = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x =>
    {
      if (x.Item == null || x.removeButton)
        return false;
      return x.Item.isCompse || x.Item.isExchangable;
    })).ToList<InventoryItem>();
    if (list2 != null && list2.Count<InventoryItem>() > 0)
    {
      PlayerMaterialGear[] source = SMManager.Get<PlayerMaterialGear[]>();
      foreach (InventoryItem inventoryItem in list2)
      {
        InventoryItem invItem = inventoryItem;
        PlayerMaterialGear playerMaterialGear = ((IEnumerable<PlayerMaterialGear>) source).FirstOrDefault<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => x.id == invItem.Item.itemID));
        if (playerMaterialGear != (PlayerMaterialGear) null)
          this.UpdateInvetoryItem(invItem, playerMaterialGear);
      }
    }
    this.SelectItemList.ForEachIndex<InventoryItem>((Action<InventoryItem, int>) ((x, idx) =>
    {
      x.select = true;
      x.Gray = true;
      if (this.SelectMode != Bugu005SelectItemListMenuBase.SelectModeEnum.Num)
        return;
      x.index = idx + 1;
    }));
    this.DisplayIconAndBottomInfoUpdate();
    this.isUpdateIcon = true;
  }

  protected override void CreateItemIconAdvencedSetting(int inventoryItemIdx, int allItemIdx)
  {
    ItemIcon itemIcon = this.AllItemIcon[allItemIdx];
    InventoryItem displayItem = this.DisplayItems[inventoryItemIdx];
    itemIcon.onClick = (Action<ItemIcon>) (playeritem => this.SelectItemProc(playeritem.ItemInfo));
    if (displayItem.Item.isSupply || displayItem.Item.isExchangable || displayItem.Item.isCompse)
    {
      itemIcon.QuantitySupply = true;
      itemIcon.EnableQuantity(displayItem.Item.quantity);
    }
    else
      itemIcon.QuantitySupply = false;
    itemIcon.ForBattle = displayItem.Item.ForBattle;
    itemIcon.Favorite = displayItem.Item.favorite;
    itemIcon.Gray = this.IsGrayIcon(displayItem);
    if (this.DisableTouchIcon(displayItem))
    {
      itemIcon.onClick = (Action<ItemIcon>) (_ => { });
      displayItem.Gray = true;
    }
    if (displayItem.select)
    {
      if (this.SelectMode == Bugu005SelectItemListMenuBase.SelectModeEnum.Check)
      {
        itemIcon.SelectByCheckIcon();
        itemIcon.SelectedQuantity(displayItem.selectCount);
      }
      else
        itemIcon.Select(displayItem.index - 1);
    }
    else
    {
      itemIcon.SelectedQuantity(0);
      if (this.SelectMode == Bugu005SelectItemListMenuBase.SelectModeEnum.Check)
        itemIcon.DeselectByCheckIcon();
      else
        itemIcon.Deselect();
    }
    itemIcon.EnableLongPressEvent(new Action<GameCore.ItemInfo>(((Bugu005ItemListMenuBase) this).ChangeDetailScene));
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005SelectItemListMenuBase.\u003CInitExtension\u003Ec__Iterator30A()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void AllItemIconUpdate()
  {
    foreach (ItemIcon itemIcon in this.AllItemIcon)
    {
      ItemIcon icon = itemIcon;
      InventoryItem inventoryItem = this.InventoryItems.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item == icon.ItemInfo));
      if (inventoryItem != null)
      {
        if (inventoryItem.select)
        {
          if (this.SelectMode == Bugu005SelectItemListMenuBase.SelectModeEnum.Check)
          {
            icon.SelectedQuantity(inventoryItem.selectCount);
            icon.SelectByCheckIcon();
          }
          else
            icon.Select(inventoryItem.index - 1);
          icon.Gray = this.IsGrayIcon(inventoryItem);
        }
        else
        {
          if (this.SelectMode == Bugu005SelectItemListMenuBase.SelectModeEnum.Check)
          {
            icon.SelectQuantity = false;
            icon.DeselectByCheckIcon();
          }
          else
            icon.Deselect();
          icon.Gray = this.IsGrayIcon(inventoryItem);
        }
      }
    }
  }

  [DebuggerHidden]
  public override IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005SelectItemListMenuBase.\u003CInit\u003Ec__Iterator30B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void UpdateSelectItemIndex()
  {
    if (this.SelectMode != Bugu005SelectItemListMenuBase.SelectModeEnum.Num)
      return;
    int count = this.SelectItemList.Count;
    for (int index = 0; index < count; ++index)
      this.SelectItemList[index].index = index + 1;
  }

  protected void AddSelectItem(InventoryItem invItem)
  {
    if (invItem == null || this.SelectItemList.Any<InventoryItem>((Func<InventoryItem, bool>) (x => x == invItem)))
      return;
    invItem.select = true;
    invItem.Gray = true;
    invItem.index = 0;
    if (this.SelectMode == Bugu005SelectItemListMenuBase.SelectModeEnum.Num)
      invItem.index = this.SelectItemList.Count<InventoryItem>() + 1;
    this.SelectItemList.Add(invItem);
  }

  public void RemoveSelectItem(InventoryItem invItem)
  {
    if (invItem == null || !this.SelectItemList.Any<InventoryItem>((Func<InventoryItem, bool>) (x => x == invItem)))
      return;
    invItem.select = false;
    invItem.Gray = false;
    invItem.index = 0;
    this.SelectItemList.Remove(invItem);
  }

  public void RemoveSelectItem(int idx)
  {
    this.RemoveSelectItem(this.InventoryItems.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (x => x.index == idx)));
  }

  public void ClearSelectItem()
  {
    foreach (InventoryItem selectItem in this.SelectItemList)
    {
      selectItem.select = false;
      selectItem.Gray = false;
      selectItem.index = 0;
    }
    this.SelectItemList.Clear();
    this.DisplayIconAndBottomInfoUpdate();
  }

  public virtual void IbtnClear()
  {
    if (this.IsPush)
      return;
    this.ClearSelectItem();
  }

  public void UpdateSelectItemIndexWithInfo()
  {
    this.UpdateSelectItemIndex();
    this.DisplayIconAndBottomInfoUpdate();
  }

  protected enum SelectModeEnum
  {
    Num,
    Check,
  }
}
