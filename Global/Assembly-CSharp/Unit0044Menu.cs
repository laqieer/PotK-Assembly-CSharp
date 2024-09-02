// Decompiled with JetBrains decompiler
// Type: Unit0044Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
public class Unit0044Menu : BackButtonMenuBase
{
  protected int totalMoney;
  protected int totalRarity;
  protected int totalLevel;
  protected int rarityAvarage;
  protected int totalRepairMoney;
  protected int totalSellMoney;
  protected bool moneyOverFlag;
  [SerializeField]
  protected GameObject[] SortSprite;
  [SerializeField]
  protected UILabel TxtNumberpossession;
  protected ItemIcon.Sort sortLabel;
  protected List<ItemIcon> allItemIcons = new List<ItemIcon>();
  private GameObject StatusChangePopupPrefab;
  private GameObject EquipAlertPopupPrefab;
  public NGxScroll2 scroll;
  private UIButton removeBtn;
  private int changeGearIndex;
  private PlayerUnit basePlayerUnit;
  private int iconWidth = ItemIcon.Width;
  private int iconHeight = ItemIcon.Height;
  private int iconColumnValue = ItemIcon.ColumnValue;
  private int iconRowValue = ItemIcon.RowValue;
  private int iconScreenValue = ItemIcon.ScreenValue;
  private int iconMaxValue = ItemIcon.MaxValue;
  private bool isInitialize;
  protected bool isEarthMode;
  private List<ItemIcon> allItemIcon = new List<ItemIcon>();
  private List<InventoryItem> playerGears = new List<InventoryItem>();
  private bool isUpdateIcon;
  private float scrool_start_y;

  private bool enableGear(PlayerUnit basePlayerUnit, PlayerItem gear)
  {
    bool flag = false;
    if (gear.gear.kind.Enum == GearKindEnum.shield || gear.gear.kind.Enum == GearKindEnum.accessories)
      flag = true;
    else if (gear.gear.kind_GearKind == basePlayerUnit.unit.kind_GearKind)
      flag = true;
    return flag;
  }

  [DebuggerHidden]
  public virtual IEnumerator UpdateIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CUpdateIcon\u003Ec__Iterator261()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator InitPlayerGears(
    Player player,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] playerUnits,
    List<InventoryItem> playerGears,
    int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CInitPlayerGears\u003Ec__Iterator262()
    {
      index = index,
      playerGears = playerGears,
      basePlayerUnit = basePlayerUnit,
      player = player,
      \u003C\u0024\u003Eindex = index,
      \u003C\u0024\u003EplayerGears = playerGears,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void SetPosessionText(int value, int max)
  {
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}/{1}", (object) value, (object) max));
  }

  private bool CheckProficiencie(PlayerUnit unit, PlayerItem gear)
  {
    bool res = false;
    if (gear.gear.kind.Enum == GearKindEnum.accessories)
      return true;
    ((IEnumerable<PlayerUnitGearProficiency>) unit.gear_proficiencies).ForEach<PlayerUnitGearProficiency>((Action<PlayerUnitGearProficiency>) (x =>
    {
      if (x.gear_kind_id != gear.gear.kind_GearKind || x.level < gear.gear.rarity.index)
        return;
      res = true;
    }));
    return res;
  }

  [DebuggerHidden]
  private IEnumerator StatusPopup(PlayerUnit baseUnit, PlayerItem beforeGear, ItemIcon afterGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CStatusPopup\u003Ec__Iterator263()
    {
      afterGear = afterGear,
      beforeGear = beforeGear,
      baseUnit = baseUnit,
      \u003C\u0024\u003EafterGear = afterGear,
      \u003C\u0024\u003EbeforeGear = beforeGear,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeGear(PlayerUnit baseUnit, PlayerItem beforeGear, ItemIcon afterGear)
  {
    if (Object.op_Inequality((Object) afterGear, (Object) null))
    {
      PlayerItem playerItem = afterGear.PlayerItem;
      if (afterGear.ForBattle)
        Singleton<PopupManager>.GetInstance().open(this.EquipAlertPopupPrefab).GetComponent<Unit004431Popup>().Init(((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => !x.unit.IsMaterialUnit)).ToArray<PlayerUnit>(), baseUnit, playerItem, this.changeGearIndex, this.isEarthMode);
      else
        this.StartCoroutine(this.StatusPopup(baseUnit, beforeGear, afterGear));
    }
    else
      this.StartCoroutine(this.StatusPopup(baseUnit, beforeGear, afterGear));
  }

  private void RemoveGear(PlayerUnit baseUnit)
  {
    this.StartCoroutine(this.RemoveGearAsync(baseUnit));
  }

  [DebuggerHidden]
  private IEnumerator RemoveGearAsync(PlayerUnit baseUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CRemoveGearAsync\u003Ec__Iterator264()
    {
      baseUnit = baseUnit,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void Sort()
  {
    ((IEnumerable<GameObject>) this.SortSprite).ForEach<GameObject>((Action<GameObject>) (v => v.SetActive(false)));
    this.SortSprite[(int) this.sortLabel].SetActive(true);
    this.playerGears = this.playerGears.SortBy(this.sortLabel).ToList<InventoryItem>();
    this.scroll.Reset();
    for (int index = 0; index < Mathf.Min(this.iconMaxValue, this.allItemIcon.Count); ++index)
    {
      this.scroll.Add(((Component) this.allItemIcon[index]).gameObject, this.iconWidth, this.iconHeight);
      ((Component) this.allItemIcon[index]).gameObject.SetActive(true);
    }
    this.scroll.CreateScrollPoint(this.iconHeight, this.playerGears.Count);
    this.scroll.ResolvePosition();
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIconRange(int value)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CCreateItemIconRange\u003Ec__Iterator265()
    {
      value = value,
      \u003C\u0024\u003Evalue = value,
      \u003C\u003Ef__this = this
    };
  }

  private void ScrollIconUpdate(int inventoryItemsIndex, int count)
  {
    if (this.playerGears[inventoryItemsIndex].removeButton || ItemIcon.IsCache(this.playerGears[inventoryItemsIndex].Item))
      this.CreateItemIconCache(inventoryItemsIndex, count);
    else
      this.StartCoroutine(this.CreateItemIcon(inventoryItemsIndex, count));
  }

  private void ScrollUpdate()
  {
    if ((!this.isInitialize || this.playerGears.Count <= this.iconScreenValue) && !this.isUpdateIcon)
      return;
    int num1 = this.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.playerGears.Count - this.iconScreenValue - 1) / this.iconColumnValue * this.iconHeight);
    float num4 = (float) (this.iconHeight * this.iconRowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int count = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject item = gameObject;
        float num5 = item.transform.localPosition.y + num2;
        int? nullable = this.playerGears.FirstIndexOrNull<InventoryItem>((Func<InventoryItem, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
        if ((double) num5 > (double) num1)
        {
          item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
          if (nullable.HasValue && nullable.Value + this.iconMaxValue < (this.playerGears.Count + 4) / 5 * 5)
          {
            if (nullable.Value + this.iconMaxValue >= this.playerGears.Count)
              item.SetActive(false);
            else
              this.ScrollIconUpdate(nullable.Value + this.iconMaxValue, count);
            flag = true;
          }
        }
        else if ((double) num5 < -((double) num4 - (double) num1))
        {
          int num6 = this.iconMaxValue;
          if (!item.activeSelf)
          {
            item.SetActive(true);
            num6 = 0;
          }
          if (nullable.HasValue && nullable.Value - num6 >= 0)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + num4, 0.0f);
            this.ScrollIconUpdate(nullable.Value - num6, count);
            flag = true;
          }
        }
        else if (this.isUpdateIcon)
          this.ScrollIconUpdate(nullable.Value, count);
        ++count;
      }
    }
    while (flag);
    if (!this.isUpdateIcon)
      return;
    this.isUpdateIcon = false;
  }

  private void ResetItemIcon(int index)
  {
    ((Component) this.allItemIcon[index]).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator CreateItemIcon(int info_index, int item_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CCreateItemIcon\u003Ec__Iterator266()
    {
      item_index = item_index,
      info_index = info_index,
      \u003C\u0024\u003Eitem_index = item_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateItemIconCache(int info_index, int item_index)
  {
    ItemIcon itemIcon = this.allItemIcon[item_index];
    InventoryItem playerGear = this.playerGears[info_index];
    this.playerGears.Where<InventoryItem>((Func<InventoryItem, bool>) (a => Object.op_Equality((Object) a.icon, (Object) itemIcon))).ForEach<InventoryItem>((Action<InventoryItem>) (b => b.icon = (ItemIcon) null));
    this.playerGears[info_index].icon = itemIcon;
    if (playerGear.removeButton)
      itemIcon.InitByRemoveButton();
    else
      itemIcon.InitByPlayerItemCache(this.playerGears[info_index].Item);
    this.CreateItemIconSharing(info_index, item_index);
  }

  private void CreateItemIconSharing(int info_index, int item_index)
  {
    ItemIcon itemIcon = this.allItemIcon[item_index];
    InventoryItem item = this.playerGears[info_index];
    item.Gray = false;
    if (item.removeButton)
    {
      itemIcon.Gray = false;
      itemIcon.ForBattle = false;
      itemIcon.onClick = (Action<ItemIcon>) (playeritem => this.RemoveGear(this.basePlayerUnit));
    }
    else
    {
      itemIcon.onClick = (Action<ItemIcon>) (playeritem =>
      {
        if (this.IsPushAndSet())
          return;
        this.ChangeGear(this.basePlayerUnit, this.basePlayerUnit.equippedGear, playeritem);
      });
      EventDelegate.Set(itemIcon.gear.button.onLongPress, (EventDelegate.Callback) (() =>
      {
        if (this.IsPushAndSet())
          return;
        this.ChangeDetailScene(item.Item);
      }));
      if (!item.Item.gear.isEquipment(this.basePlayerUnit))
      {
        item.Gray = true;
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
      }
      if (this.basePlayerUnit.equippedGear != (PlayerItem) null && this.basePlayerUnit.equippedGear == item.Item)
      {
        item.Gray = true;
        itemIcon.ForBattle = true;
        itemIcon.onClick = (Action<ItemIcon>) (_ => { });
      }
      itemIcon.ForBattle = item.Item.ForBattle;
      itemIcon.Gray = item.Gray;
    }
  }

  [DebuggerHidden]
  private IEnumerator LoadObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0044Menu.\u003CLoadObject\u003Ec__Iterator267()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void ChangeDetailScene(PlayerItem gear)
  {
    Unit00443Scene.changeSceneLimited(true, gear);
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public void onEndScene()
  {
  }

  protected virtual void Foreground()
  {
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyScene("unit004_4");
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnSort()
  {
    if (this.IsPush)
      return;
    int num;
    this.sortLabel = (ItemIcon.Sort) ((num = (int) (this.sortLabel + 1)) % 4);
    Persist.sortOrder.Data.Weapon = (int) this.sortLabel;
    this.Sort();
    Singleton<CommonRoot>.GetInstance().isTouchBlock = true;
    this.playerGears.ForEach((Action<InventoryItem>) (v => v.icon = (ItemIcon) null));
    this.StartCoroutine(this.CreateItemIconRange(Mathf.Min(this.iconMaxValue, this.playerGears.Count)));
  }

  protected virtual void VScrollBar()
  {
  }
}
