// Decompiled with JetBrains decompiler
// Type: Bugu00524SimpleRepairInterface
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
public class Bugu00524SimpleRepairInterface : MonoBehaviour
{
  public const int REPAIR_SELECT_MAX = 1;
  private const int BED_MAX_PERCENT = 90;
  private const int BED_UP_PERCENT = 10;
  private const int MEDAL_PRICE = 10;
  [SerializeField]
  private UIButton ibtnChange;
  [SerializeField]
  private Transform repairTargetIcon;
  [SerializeField]
  private UILabel txtWeaponName;
  [SerializeField]
  private UILabel txtRepairPercent;
  [SerializeField]
  private UILabel txtZeny;
  [SerializeField]
  private UIButton ibtnMinus;
  [SerializeField]
  private UIButton ibtnPlus;
  [SerializeField]
  private UIButton ibtnRepairRareMedal;
  [SerializeField]
  private UIButton ibtnRepair;
  private Bugu00524Menu menuInstance;
  private ItemIcon icon;
  private int repairPrice;
  private int zenyBoostCnt;

  public void Init(Bugu00524Menu menu)
  {
    this.menuInstance = menu;
    GameObject itemIconPrefab = this.menuInstance.GetItemIconPrefab();
    this.repairTargetIcon.Clear();
    this.icon = itemIconPrefab.Clone(this.repairTargetIcon).GetComponent<ItemIcon>();
    this.zenyBoostCnt = 0;
    this.SetSelectItem((List<InventoryItem>) null);
  }

  public void SetSelectItem(List<InventoryItem> items)
  {
    this.zenyBoostCnt = 0;
    if (items != null && items.Count<InventoryItem>() > 0)
    {
      this.icon.SetEmpty(false);
      if (ItemIcon.IsCache(items[0].Item))
        this.icon.InitByItemInfoCache(items[0].Item);
      else
        this.StartCoroutine(this.icon.InitByItemInfo(items[0].Item));
      this.icon.onClick = (Action<ItemIcon>) (playeritem => { });
      this.icon.Gray = false;
      this.icon.Deselect();
    }
    else
      this.icon.SetEmpty(true);
    this.SetInfomation(items);
  }

  private void SetInfomation(List<InventoryItem> items)
  {
    Player player = SMManager.Get<Player>();
    string text = string.Empty;
    string empty = string.Empty;
    int num = 0;
    int count = items == null ? 0 : items.Count;
    this.repairPrice = 0;
    string defaultProbabilityText;
    if (items != null && items.Count<InventoryItem>() > 0)
    {
      text = items[0].Item.Name();
      this.repairPrice += items[0].GetRepairPrice(this.zenyBoostCnt);
      num = (int) Math.Round((double) items[0].Item.gear.repair_success_ratio * 100.0) + 10 * this.zenyBoostCnt;
      defaultProbabilityText = num.ToString();
    }
    else
      defaultProbabilityText = Consts.GetInstance().GEAR_0052_REPAIR_DEFAULT_PROBABILITY_TEXT;
    this.txtWeaponName.SetTextLocalize(text);
    this.txtRepairPercent.SetTextLocalize(defaultProbabilityText);
    this.txtZeny.SetTextLocalize(this.repairPrice);
    this.txtZeny.color = player.money < this.repairPrice ? Color.red : Color.white;
    this.ibtnMinus.isEnabled = count > 0 && this.zenyBoostCnt > 0;
    this.ibtnPlus.isEnabled = count > 0 && num < 90;
    this.ibtnRepairRareMedal.isEnabled = count > 0 && player.medal >= 10;
    this.ibtnRepair.isEnabled = count > 0 && player.money >= this.repairPrice;
  }

  public void onIbtnChange() => this.menuInstance.RepairModeChange();

  public void onIbtnMinus()
  {
    --this.zenyBoostCnt;
    if (this.zenyBoostCnt < 0)
      this.zenyBoostCnt = 0;
    this.SetInfomation(this.menuInstance.GetSelectItem());
  }

  public void onIbtnPlus()
  {
    ++this.zenyBoostCnt;
    if ((int) Math.Round((double) this.menuInstance.GetSelectItem()[0].Item.gear.repair_success_ratio * 100.0) + 10 * this.zenyBoostCnt > 90)
      --this.zenyBoostCnt;
    this.SetInfomation(this.menuInstance.GetSelectItem());
  }

  public void onIbtnRepairRareMedal() => this.menuInstance.ibtnRepairRareMedal(10);

  public void onIbtnRepair() => this.menuInstance.ibtnRepair(this.repairPrice, this.zenyBoostCnt);

  public void onIbtnIcon()
  {
    this.menuInstance.RemoveSelectItem(1);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }
}
