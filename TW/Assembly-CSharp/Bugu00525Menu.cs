// Decompiled with JetBrains decompiler
// Type: Bugu00525Menu
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
public class Bugu00525Menu : Bugu005SelectItemListMenuBase
{
  [SerializeField]
  private UIScrollView ScrollView;
  [SerializeField]
  protected UIButton DecisionButton;
  [SerializeField]
  protected UILabel NumProsession3;
  [SerializeField]
  protected UILabel NumSelectedCount3;
  [SerializeField]
  protected UILabel NumSpendZenie3;
  private GameObject popup005711Prefab;
  private GameObject popup005513Prefab;
  private GameObject popup005514Prefab;
  private GameObject popup005512Prefab;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052SellSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return SMManager.Get<PlayerItem[]>() != null ? ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).ToList<PlayerItem>() : (List<PlayerItem>) null;
  }

  protected override List<PlayerMaterialGear> GetMaterialList()
  {
    return SMManager.Get<PlayerMaterialGear[]>() != null ? ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).ToList<PlayerMaterialGear>() : (List<PlayerMaterialGear>) null;
  }

  [DebuggerHidden]
  protected override IEnumerator InitExtension()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CInitExtension\u003Ec__Iterator40C()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void BottomInfoUpdate()
  {
    Player player = SMManager.Get<Player>();
    int saleValue = 0;
    this.SelectItemList.ForEach((Action<InventoryItem>) (item => saleValue += item.GetSellPrice()));
    this.NumSpendZenie3.SetTextLocalize(saleValue);
    this.NumSpendZenie3.color = saleValue + player.money > Consts.GetInstance().MONEY_MAX ? Color.red : Color.white;
    int selectItemNum = 0;
    selectItemNum = this.SelectItemList.Count<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.isWeapon));
    this.SelectItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => !x.Item.isWeapon)).ForEach<InventoryItem>((Action<InventoryItem>) (item => selectItemNum += item.selectCount));
    this.NumSelectedCount3.SetTextLocalize(selectItemNum);
    this.NumSelectedCount3.color = selectItemNum >= this.SelectMax ? Color.red : Color.white;
    this.NumProsession3.SetTextLocalize(Consts.Format(Consts.GetInstance().GEAR_0052_POSSESSION, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) this.InventoryItems.Count<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.isWeapon))
      },
      {
        (object) "max",
        (object) player.max_items
      }
    }));
    this.DecisionButton.isEnabled = selectItemNum > 0 && this.SelectMax >= selectItemNum;
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    InventoryItem byItem = this.InventoryItems.FindByItem(item);
    if (byItem == null)
      return;
    if (byItem.select)
    {
      if (!item.isWeapon)
      {
        this.StartCoroutine(this.CountSelectPopUp(byItem));
      }
      else
      {
        this.RemoveSelectItem(byItem);
        this.UpdateSelectItemIndexWithInfo();
      }
    }
    else
    {
      if (this.SelectItemList.Count >= this.SelectMax)
        return;
      if (!item.isWeapon)
      {
        this.StartCoroutine(this.CountSelectPopUp(byItem));
      }
      else
      {
        this.AddSelectItem(byItem);
        this.UpdateSelectItemIndexWithInfo();
      }
    }
  }

  public virtual void IbtnDecision()
  {
    if (this.IsPushAndSet())
      return;
    if (this.SelectItemList.Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear != null)).Where<InventoryItem>((Func<InventoryItem, bool>) (x => x.Item.gear.rarity.index >= 3)).ToList<InventoryItem>().Count > 0)
      this.StartCoroutine(this.SellWarningPopUp(new System.Action(this.CallSellAPI)));
    else
      this.StartCoroutine(this.SellCheckPopUp(new System.Action(this.CallSellAPI)));
  }

  [DebuggerHidden]
  private IEnumerator CountSelectPopUp(InventoryItem item)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CCountSelectPopUp\u003Ec__Iterator40D()
    {
      item = item,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellCheckPopUp(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CSellCheckPopUp\u003Ec__Iterator40E()
    {
      action = action,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellWarningPopUp(System.Action action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CSellWarningPopUp\u003Ec__Iterator40F()
    {
      action = action,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SellResultPopUp(long resultMoney)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CSellResultPopUp\u003Ec__Iterator410()
    {
      resultMoney = resultMoney,
      \u003C\u0024\u003EresultMoney = resultMoney,
      \u003C\u003Ef__this = this
    };
  }

  public void SetSellCount(InventoryItem item, int count)
  {
    item.selectCount = count;
    if (count != 0)
    {
      if (!this.SelectItemList.Any<InventoryItem>((Func<InventoryItem, bool>) (x => x == item)))
        this.AddSelectItem(item);
    }
    else if (this.SelectItemList.Any<InventoryItem>((Func<InventoryItem, bool>) (x => x == item)))
      this.RemoveSelectItem(item);
    this.UpdateSelectItemIndexWithInfo();
  }

  public virtual void CallSellAPI() => this.StartCoroutine(this.ExecuteSellAPI());

  [DebuggerHidden]
  private IEnumerator ExecuteSellAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00525Menu.\u003CExecuteSellAPI\u003Ec__Iterator411()
    {
      \u003C\u003Ef__this = this
    };
  }
}
