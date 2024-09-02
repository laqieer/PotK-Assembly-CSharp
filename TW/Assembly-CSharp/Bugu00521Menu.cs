// Decompiled with JetBrains decompiler
// Type: Bugu00521Menu
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
public class Bugu00521Menu : Bugu005SelectItemListMenuBase
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
  private List<GameCore.ItemInfo> FirstSelectItemList = new List<GameCore.ItemInfo>();
  private ItemIcon[] icons;
  private bool firstInit = true;

  public void SetFirstSelectItem(List<GameCore.ItemInfo> items) => this.FirstSelectItemList = items;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052CompositeSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.isWeapon() && x.gear.kind.Enum != GearKindEnum.accessories)).ToList<PlayerItem>();
  }

  protected override List<PlayerMaterialGear> GetMaterialList()
  {
    List<PlayerMaterialGear> list = new List<PlayerMaterialGear>();
    ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => !x.isDilling() && !x.isSpecialDilling() && x.isCompse())).ForEach<PlayerMaterialGear>((Action<PlayerMaterialGear>) (x =>
    {
      int num = x.quantity >= this.SelectMax ? this.SelectMax : x.quantity;
      for (int index = 0; index < num; ++index)
        list.Add(x);
    }));
    return list;
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00521Menu.\u003CInitExtension\u003Ec__Iterator3FB()
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
        this.icons[index].EnableQuantity(0);
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
    int compositeCost = CalcItemCost.GetCompositeCost(this.SelectItemList);
    this.txtSpendzenieNum.SetTextLocalize(compositeCost);
    this.txtSpendzenieNum.color = player.money < compositeCost ? Color.red : Color.white;
    this.ibtnYes.isEnabled = count > 0 && player.money >= compositeCost;
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

  public override void IbtnBack()
  {
    if (this.IsPush)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    if (Singleton<NGGameDataManager>.GetInstance().IsColosseum)
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    List<GameCore.ItemInfo> list = this.FirstSelectItemList.Where<GameCore.ItemInfo>((Func<GameCore.ItemInfo, bool>) (x =>
    {
      InventoryItem inventoryItem = this.InventoryItems.FirstOrDefault<InventoryItem>((Func<InventoryItem, bool>) (i => i.Item.itemID == x.itemID));
      return inventoryItem != null && !inventoryItem.Item.favorite && !inventoryItem.Item.ForBattle;
    })).ToList<GameCore.ItemInfo>();
    List<InventoryItem> invList = new List<InventoryItem>();
    list.ForEach((Action<GameCore.ItemInfo>) (x => invList.Add(new InventoryItem(x))));
    Bugu0053Scene.changeScene(false, invList);
  }

  public void IbtnDecision()
  {
    if (this.IsPush)
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Bugu0053Scene.changeScene(false, this.SelectItemList);
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
