// Decompiled with JetBrains decompiler
// Type: Bugu055SellMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Bugu055SellMenu : Bugu00525Menu
{
  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist() => Persist.bugu055SellSortAndFilter;

  protected override List<PlayerItem> GetItemList()
  {
    PlayerItem[] playerItemArray = SMManager.Get<PlayerItem[]>();
    List<PlayerItem> list1 = ((IEnumerable<PlayerItem>) playerItemArray).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.isExchangable())).Distinct<PlayerItem>((IEqualityComparer<PlayerItem>) new LambdaEqualityComparer<PlayerItem>((Func<PlayerItem, PlayerItem, bool>) ((a, b) => a.gear.ID == b.gear.ID))).ToList<PlayerItem>();
    List<PlayerItem> list2 = ((IEnumerable<PlayerItem>) playerItemArray).ToList<PlayerItem>();
    foreach (PlayerItem playerItem in list1)
    {
      PlayerItem exchangable = playerItem;
      exchangable.quantity = list2.Count<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null && x.gear.ID == exchangable.gear.ID));
      list2.RemoveAll((Predicate<PlayerItem>) (x => x.gear != null && x.gear.ID == exchangable.gear.ID));
      list2.Add(exchangable);
    }
    return list2;
  }

  protected override void UpdateInventoryItemList()
  {
    List<InventoryItem> list = this.InventoryItems.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item != null && !x.removeButton)).ToList<InventoryItem>();
    if (list != null && list.Count<InventoryItem>() > 0)
    {
      PlayerItem[] playerItemArray = SMManager.Get<PlayerItem[]>();
      foreach (InventoryItem inventoryItem in list)
      {
        InventoryItem invItem = inventoryItem;
        PlayerItem playerItem = ((IEnumerable<PlayerItem>) playerItemArray).FirstOrDefault<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == invItem.Item.itemID));
        if (playerItem != (PlayerItem) null)
          this.UpdateInvetoryItem(invItem, playerItem);
      }
    }
    this.SelectItemList.ForEachIndex<InventoryItem>((System.Action<InventoryItem, int>) ((x, idx) =>
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

  protected override List<PlayerMaterialGear> GetMaterialList() => SMManager.Get<PlayerMaterialGear[]>() != null ? ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).ToList<PlayerMaterialGear>() : (List<PlayerMaterialGear>) null;

  protected override void ChangeDetailScene(GameCore.ItemInfo item)
  {
    if (item == null)
      return;
    if (item.isWeapon)
      Unit05443Scene.changeScene(true, item);
    else
      Bugu05561Scene.changeScene(true, item);
  }

  protected override void BottomInfoUpdate()
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    long sellCost = CalcItemCost.GetSellCost(this.SelectItemList);
    this.NumSpendZenie3.SetTextLocalize(sellCost);
    this.NumSpendZenie3.color = sellCost + instanceOrNull.GetProperty(MasterDataTable.CommonRewardType.money) <= Consts.GetInstance().MONEY_MAX ? Color.white : Color.red;
    int selectItemNum = 0;
    selectItemNum = this.SelectItemList.Count<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.isWeapon));
    this.SelectItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => !x.Item.isWeapon)).ForEach<InventoryItem>((System.Action<InventoryItem>) (item => selectItemNum += item.selectCount));
    this.NumSelectedCount3.SetTextLocalize(selectItemNum);
    this.NumSelectedCount3.color = selectItemNum < this.SelectMax ? Color.white : Color.red;
    this.NumProsession3.SetTextLocalize(Consts.Format(Consts.GetInstance().GEAR_0552_POSSESSION_SELL, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) this.InventoryItems.Count<InventoryItem>()
      }
    }));
    this.DecisionButton.isEnabled = selectItemNum > 0;
  }

  public override void IbtnDecision()
  {
    if (this.IsPushAndSet())
      return;
    if (this.SelectItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear != null)).Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear.rarity.index >= 3)).ToList<InventoryItem>().Count > 0)
      this.StartCoroutine(this.SellWarningPopUp(new System.Action(((Bugu00525Menu) this).CallSellAPI)));
    else
      this.StartCoroutine(this.SellCheckPopUp(new System.Action(((Bugu00525Menu) this).CallSellAPI)));
  }

  public override void CallSellAPI() => this.StartCoroutine(this.ExecuteSellAPI());

  private IEnumerator ExecuteSellAPI()
  {
    Bugu055SellMenu bugu055SellMenu = this;
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    long sellCost = CalcItemCost.GetSellCost(bugu055SellMenu.SelectItemList);
    if ((UnityEngine.Object) instanceOrNull != (UnityEngine.Object) null)
      instanceOrNull.ItemSell(bugu055SellMenu.SelectItemList.ToNotSupplyID().ToArray(), bugu055SellMenu.SelectItemList.ToEntityIdBySupply().ToArray(), bugu055SellMenu.SelectItemList.ToSelectQuantityBySupply().ToArray(), sellCost);
    IEnumerator e = bugu055SellMenu.SellResultPopUp(sellCost);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = bugu055SellMenu.Init();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    yield return (object) new WaitForSeconds(0.5f);
  }
}
