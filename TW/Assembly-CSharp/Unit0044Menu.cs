// Decompiled with JetBrains decompiler
// Type: Unit0044Menu
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
public class Unit0044Menu : Bugu005SelectItemListMenuBase
{
  [SerializeField]
  protected UILabel TxtNumberpossession;
  private GameObject StatusChangePopupPrefab;
  private GameObject EquipAlertPopupPrefab;
  private int changeGearIndex;
  private PlayerUnit basePlayerUnit;
  private bool isEarthMode;

  public int ChangeGearIndex
  {
    set => this.changeGearIndex = value;
    get => this.changeGearIndex;
  }

  public PlayerUnit BasePlayerUnit
  {
    set => this.basePlayerUnit = value;
    get => this.basePlayerUnit;
  }

  public bool IsEarthMode
  {
    set => this.isEarthMode = value;
    get => this.isEarthMode;
  }

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.unit0044SortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => !x.broken && x.isWeapon() && (x.gear.kind.Enum == GearKindEnum.shield || x.gear.kind.Enum == GearKindEnum.accessories || x.gear.kind_GearKind == this.basePlayerUnit.unit.kind_GearKind) && x.gear.enableEquipmentUnit(this.basePlayerUnit))).ToList<PlayerItem>();
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CInitExtension\u003Ec__Iterator30C()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void ChangeDetailScene(GameCore.ItemInfo item)
  {
    Unit00443Scene.changeSceneLimited(true, item);
  }

  protected override void BottomInfoUpdate()
  {
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}/{1}", (object) ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Count<PlayerItem>(), (object) SMManager.Get<Player>().max_items));
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    if (this.InventoryItems.FindByItem(item).removeButton)
    {
      this.StartCoroutine(this.RemoveGearAsync());
    }
    else
    {
      this.ChangeGear(this.basePlayerUnit, this.basePlayerUnit.equippedGear, ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == item.itemID)));
      this.UpdateSelectItemIndexWithInfo();
    }
  }

  protected override void CreateItemIconAdvencedSetting(int inventoryItemIdx, int allItemIdx)
  {
    ItemIcon itemIcon = this.AllItemIcon[allItemIdx];
    InventoryItem displayItem = this.DisplayItems[inventoryItemIdx];
    itemIcon.Gray = false;
    itemIcon.QuantitySupply = false;
    if (displayItem.removeButton)
    {
      itemIcon.Favorite = false;
      itemIcon.ForBattle = false;
      itemIcon.onClick = (Action<ItemIcon>) (playeritem => this.StartCoroutine(this.RemoveGearAsync()));
      itemIcon.DisableLongPressEvent();
    }
    else
    {
      itemIcon.ForBattle = displayItem.Item.ForBattle;
      itemIcon.Favorite = displayItem.Item.favorite;
      itemIcon.onClick = (Action<ItemIcon>) (playeritem => this.SelectItemProc(playeritem.ItemInfo));
      if (this.IsGrayIcon(displayItem))
      {
        itemIcon.Gray = true;
        displayItem.Gray = true;
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
      }
      itemIcon.EnableLongPressEvent(new Action<GameCore.ItemInfo>(((Bugu005ItemListMenuBase) this).ChangeDetailScene));
    }
  }

  protected override bool DisableTouchIcon(InventoryItem item)
  {
    if (item.Item == null || !item.Item.gear.isEquipment(this.basePlayerUnit) || this.basePlayerUnit.equippedGear != (PlayerItem) null && this.basePlayerUnit.equippedGear.id == item.Item.itemID)
      return true;
    return !item.Item.gear.isEquipment(this.basePlayerUnit) && base.DisableTouchIcon(item);
  }

  [DebuggerHidden]
  private IEnumerator StatusPopup(PlayerUnit baseUnit, PlayerItem beforeGear, PlayerItem afterGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CStatusPopup\u003Ec__Iterator30D()
    {
      beforeGear = beforeGear,
      afterGear = afterGear,
      baseUnit = baseUnit,
      \u003C\u0024\u003EbeforeGear = beforeGear,
      \u003C\u0024\u003EafterGear = afterGear,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeGear(PlayerUnit baseUnit, PlayerItem beforeGear, PlayerItem afterGear)
  {
    if (afterGear != (PlayerItem) null)
    {
      if (afterGear.ForBattle)
        Singleton<PopupManager>.GetInstance().open(this.EquipAlertPopupPrefab).GetComponent<Unit004431Popup>().Init(((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => !x.unit.IsMaterialUnit)).ToArray<PlayerUnit>(), baseUnit, afterGear, this.changeGearIndex, this.isEarthMode);
      else
        this.StartCoroutine(this.StatusPopup(baseUnit, beforeGear, afterGear));
    }
    else
      this.StartCoroutine(this.StatusPopup(baseUnit, beforeGear, afterGear));
  }

  [DebuggerHidden]
  private IEnumerator RemoveGearAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CRemoveGearAsync\u003Ec__Iterator30E()
    {
      \u003C\u003Ef__this = this
    };
  }
}
