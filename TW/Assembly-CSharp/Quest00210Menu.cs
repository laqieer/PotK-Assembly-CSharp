// Decompiled with JetBrains decompiler
// Type: Quest00210Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00210Menu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject[] linkItem;
  [SerializeField]
  private GameObject[] selectButton;
  [SerializeField]
  private GameObject[] changeButton;
  [SerializeField]
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();
  [SerializeField]
  private List<SupplyItem> SaveDeck = new List<SupplyItem>();
  private ItemIcon[] icons = new ItemIcon[Consts.GetInstance().DECK_SUPPLY_MAX];
  private bool fromEarth;
  private GameObject iconPrefab;

  [DebuggerHidden]
  public IEnumerator Init(List<SupplyItem> SupplyItems, bool fromEarth)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Menu.\u003CInit\u003Ec__Iterator1D8()
    {
      fromEarth = fromEarth,
      SupplyItems = SupplyItems,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u0024\u003ESupplyItems = SupplyItems,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator updateSupplyDeckAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Menu.\u003CupdateSupplyDeckAsync\u003Ec__Iterator1D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void updateEarthSupplyDeck()
  {
    Singleton<EarthDataManager>.GetInstance().SetSupplyBox(this.SupplyItems.DeckList().Select<SupplyItem, Tuple<int, int>>((Func<SupplyItem, Tuple<int, int>>) (x => new Tuple<int, int>(x.Supply.ID, x.SelectCount))).ToArray<Tuple<int, int>>());
    Singleton<EarthDataManager>.GetInstance().Save();
    this.backScene();
  }

  public void IbtnDecide()
  {
    if (this.IsPushAndSet())
      return;
    if (!this.fromEarth)
      this.StartCoroutine(this.updateSupplyDeckAsync());
    else
      this.updateEarthSupplyDeck();
  }

  public void IbtnChange(int idx)
  {
    if (this.IsPushAndSet())
      return;
    this.InitSaveSpace();
    bool flag = this.SupplyItems.RemoveDeck(idx);
    Quest00210aScene.ChangeScene(false, new Quest00210Menu.Param()
    {
      SupplyItems = this.SupplyItems,
      SaveDeck = this.SaveDeck,
      select = idx,
      removeButton = flag
    });
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnChange() => this.IbtnChange(1);

  public virtual void IbtnChange2() => this.IbtnChange(2);

  public virtual void IbtnChange3() => this.IbtnChange(3);

  public virtual void IbtnChange4() => this.IbtnChange(4);

  public virtual void IbtnChange5() => this.IbtnChange(5);

  public virtual void IbtnPopupResign()
  {
    if (this.IsPush)
      return;
    this.SupplyItems.RemoveAll();
    for (int index = 0; index < Consts.GetInstance().DECK_SUPPLY_MAX; ++index)
    {
      this.icons[index].SetEmpty(true);
      this.icons[index].QuantitySupply = false;
    }
    this.UpdateSelectButton();
    this.InitSaveSpace();
  }

  public virtual void IbtnPopupRevival()
  {
    if (this.IsPush)
      return;
    this.SupplyItems.Fill();
    this.InitSaveSpace();
    this.StartCoroutine(this.RenderIcons());
  }

  [DebuggerHidden]
  private IEnumerator RenderIcons()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Menu.\u003CRenderIcons\u003Ec__Iterator1DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateSelectButton()
  {
    for (int index = 0; index < Consts.GetInstance().DECK_SUPPLY_MAX; ++index)
      this.changeButton[index].SetActive(false);
    int num = 0;
    for (int index = 0; index < this.SupplyItems.Count; ++index)
    {
      if (this.SupplyItems[index].DeckIndex > 0)
      {
        this.changeButton[this.SupplyItems[index].DeckIndex - 1].SetActive(true);
        ++num;
      }
    }
  }

  private void InitSaveSpace() => this.SaveDeck = this.SupplyItems.Copy();

  public class Param
  {
    public List<SupplyItem> SupplyItems;
    public List<SupplyItem> SaveDeck;
    public int select;
    public bool removeButton;
  }
}
