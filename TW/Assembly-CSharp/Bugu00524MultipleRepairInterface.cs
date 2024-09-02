// Decompiled with JetBrains decompiler
// Type: Bugu00524MultipleRepairInterface
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Bugu00524MultipleRepairInterface : MonoBehaviour
{
  public const int REPAIR_SELECT_MAX = 5;
  private const float ICON_SCALE = 0.8f;
  [SerializeField]
  private UIButton ibtnChange;
  [SerializeField]
  private Transform[] repairTargetIcon;
  [SerializeField]
  private UILabel[] txtRepairPercent;
  [SerializeField]
  private UILabel txtZeny;
  [SerializeField]
  private UIButton ibtnRepair;
  private Bugu00524Menu menuInstance;
  private ItemIcon[] icons;
  private int repairPrice;

  public void Init(Bugu00524Menu menu)
  {
    this.menuInstance = menu;
    GameObject itemIconPrefab = this.menuInstance.GetItemIconPrefab();
    int length = this.repairTargetIcon.Length;
    this.icons = new ItemIcon[length];
    for (int index = 0; index < length; ++index)
    {
      this.repairTargetIcon[index].Clear();
      GameObject gameObject = itemIconPrefab.Clone(this.repairTargetIcon[index]);
      gameObject.transform.localScale = new Vector3(0.8f, 0.8f);
      ItemIcon component = gameObject.GetComponent<ItemIcon>();
      this.icons[index] = component;
    }
    this.SetSelectItem((List<InventoryItem>) null);
  }

  public void SetSelectItem(List<InventoryItem> items)
  {
    Player player = SMManager.Get<Player>();
    this.repairPrice = 0;
    int count = items == null ? 0 : items.Count;
    for (int index = 0; index < 5; ++index)
    {
      if (index < count)
      {
        this.icons[index].SetEmpty(false);
        if (ItemIcon.IsCache(items[index].Item))
          this.icons[index].InitByItemInfoCache(items[index].Item);
        else
          this.StartCoroutine(this.icons[index].InitByItemInfo(items[index].Item));
        this.icons[index].onClick = (Action<ItemIcon>) (playeritem => { });
        this.icons[index].Gray = false;
        this.icons[index].Deselect();
        this.txtRepairPercent[index].SetTextLocalize(Math.Round((double) items[index].Item.gear.repair_success_ratio * 100.0).ToString() + Consts.GetInstance().PERCENT);
        this.repairPrice += items[index].GetRepairPrice();
      }
      else
      {
        this.icons[index].SetEmpty(true);
        this.icons[index].onClick = (Action<ItemIcon>) (playeritem => { });
        this.txtRepairPercent[index].SetTextLocalize(Consts.GetInstance().GEAR_0052_REPAIR_DEFAULT_PROBABILITY_TEXT);
      }
    }
    this.txtZeny.SetTextLocalize(this.repairPrice);
    this.txtZeny.color = player.money < this.repairPrice ? Color.red : Color.white;
    this.ibtnRepair.isEnabled = count > 0 && player.money >= this.repairPrice;
  }

  public void onIbtnChange() => this.menuInstance.RepairModeChange();

  public void onIbtnClear() => this.menuInstance.ClearSelectItem();

  public void onIbtnRepair() => this.menuInstance.ibtnRepair(this.repairPrice, 0);

  public void onIbtnIcon1()
  {
    this.menuInstance.RemoveSelectItem(1);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon2()
  {
    this.menuInstance.RemoveSelectItem(2);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon3()
  {
    this.menuInstance.RemoveSelectItem(3);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon4()
  {
    this.menuInstance.RemoveSelectItem(4);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }

  public void onIbtnIcon5()
  {
    this.menuInstance.RemoveSelectItem(5);
    this.menuInstance.UpdateSelectItemIndexWithInfo();
  }
}
