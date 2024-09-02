// Decompiled with JetBrains decompiler
// Type: Bugu00524Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu00524Menu : Bugu005SelectItemListMenuBase
{
  [SerializeField]
  private Bugu00524Menu.REPIAR_MODE repairMode = Bugu00524Menu.REPIAR_MODE.SIMPLE;
  [SerializeField]
  private GameObject[] repairInterfaceGameObject;
  [SerializeField]
  private Bugu00524SimpleRepairInterface simpleRepairInterface;
  [SerializeField]
  private Bugu00524MultipleRepairInterface multipleRepairInterface;
  private GameObject popup0052Prefab;

  public GameObject GetItemIconPrefab() => this.ItemIconPrefab;

  public List<InventoryItem> GetSelectItem() => this.SelectItemList;

  private int GetMaxSelect()
  {
    if (this.repairMode == Bugu00524Menu.REPIAR_MODE.MULITI)
      return 5;
    return this.repairMode == Bugu00524Menu.REPIAR_MODE.SIMPLE ? 1 : 0;
  }

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052RepairSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.isWeapon() && x.broken)).ToList<PlayerItem>();
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00524Menu.\u003CInitExtension\u003Ec__Iterator405()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void BottomInfoUpdate()
  {
    if (this.repairMode == Bugu00524Menu.REPIAR_MODE.MULITI)
    {
      this.multipleRepairInterface.SetSelectItem(this.SelectItemList);
    }
    else
    {
      if (this.repairMode != Bugu00524Menu.REPIAR_MODE.SIMPLE)
        return;
      this.simpleRepairInterface.SetSelectItem(this.SelectItemList);
    }
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

  private void RepairConfirmPopupYesBtnAction(bool isRareMadel, int price, int boostCnt)
  {
    if (this.SelectItemList == null || this.SelectItemList.Count == 0)
      return;
    if (this.repairMode == Bugu00524Menu.REPIAR_MODE.SIMPLE)
    {
      this.StartCoroutine(this.RepairPoweredAPI(isRareMadel, price, boostCnt));
    }
    else
    {
      if (this.repairMode != Bugu00524Menu.REPIAR_MODE.MULITI)
        return;
      this.StartCoroutine(this.RepairAPI());
    }
  }

  [DebuggerHidden]
  private IEnumerator ShowRepairConfirmPopup(
    Bugu0052MedalPopup.CurrencyKind kind,
    int price,
    int bCnt,
    Action<bool, int, int> act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00524Menu.\u003CShowRepairConfirmPopup\u003Ec__Iterator406()
    {
      kind = kind,
      price = price,
      bCnt = bCnt,
      act = act,
      \u003C\u0024\u003Ekind = kind,
      \u003C\u0024\u003Eprice = price,
      \u003C\u0024\u003EbCnt = bCnt,
      \u003C\u0024\u003Eact = act,
      \u003C\u003Ef__this = this
    };
  }

  public void ibtnRepairRareMedal(int rareMedalCnt)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowRepairConfirmPopup(Bugu0052MedalPopup.CurrencyKind.RareMedal, rareMedalCnt, 0, new Action<bool, int, int>(this.RepairConfirmPopupYesBtnAction)));
  }

  public void ibtnRepair(int price, int boostCnt)
  {
    if (this.IsPush)
      return;
    this.StartCoroutine(this.ShowRepairConfirmPopup(Bugu0052MedalPopup.CurrencyKind.Money, price, boostCnt, new Action<bool, int, int>(this.RepairConfirmPopupYesBtnAction)));
  }

  private void CurrentRepairModeInit()
  {
    this.SelectMax = this.GetMaxSelect();
    ((IEnumerable<GameObject>) this.repairInterfaceGameObject).ToggleOnce((int) this.repairMode);
    this.ClearSelectItem();
  }

  public void RepairModeChange()
  {
    if (this.IsPush)
      return;
    if (this.repairMode == Bugu00524Menu.REPIAR_MODE.SIMPLE)
      this.repairMode = Bugu00524Menu.REPIAR_MODE.MULITI;
    else if (this.repairMode == Bugu00524Menu.REPIAR_MODE.MULITI)
      this.repairMode = Bugu00524Menu.REPIAR_MODE.SIMPLE;
    this.CurrentRepairModeInit();
  }

  [DebuggerHidden]
  public IEnumerator RepairAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00524Menu.\u003CRepairAPI\u003Ec__Iterator407()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RepairPoweredAPI(bool isReraMedal, int price, int boostCnt)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00524Menu.\u003CRepairPoweredAPI\u003Ec__Iterator408()
    {
      isReraMedal = isReraMedal,
      price = price,
      boostCnt = boostCnt,
      \u003C\u0024\u003EisReraMedal = isReraMedal,
      \u003C\u0024\u003Eprice = price,
      \u003C\u0024\u003EboostCnt = boostCnt,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RepairUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00524Menu.\u003CRepairUpdate\u003Ec__Iterator409()
    {
      \u003C\u003Ef__this = this
    };
  }

  private enum REPIAR_MODE
  {
    MULITI,
    SIMPLE,
  }
}
