// Decompiled with JetBrains decompiler
// Type: Quest00210Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00210Menu : BackButtonMenuBase
{
  protected const float LINK_WIDTH = 95f;
  protected const float LINK_HEIGHT = 114f;
  protected const float LINK_DEFWIDTH = 114f;
  protected const float LINK_DEFHEIGHT = 136f;
  private ItemIcon[] icons = new ItemIcon[5];
  [SerializeField]
  private GameObject[] linkItem;
  [SerializeField]
  private List<SupplyItem> SupplyItems = new List<SupplyItem>();
  [SerializeField]
  private List<SupplyItem> SaveDeck = new List<SupplyItem>();
  [SerializeField]
  protected UILabel TxtItemFormation;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected GameObject[] selectButton;
  [SerializeField]
  protected GameObject[] changeButton;
  private bool fromEarth;

  [DebuggerHidden]
  public IEnumerator InitSupplyEdit(List<SupplyItem> SupplyItems, bool fromEarth)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00210Menu.\u003CInitSupplyEdit\u003Ec__Iterator173()
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
    return (IEnumerator) new Quest00210Menu.\u003CupdateSupplyDeckAsync\u003Ec__Iterator174()
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

  public void IbtnChange(int n)
  {
    if (this.IsPushAndSet())
      return;
    this.InitSaveSpace();
    bool flag = this.SupplyItems.RemoveDeck(n);
    Quest00210aScene.changeScene(false, new Quest00210Menu.Param()
    {
      SupplyItems = this.SupplyItems,
      SaveDeck = this.SaveDeck,
      select = n,
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
    for (int index = 0; index < 5; ++index)
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
    return (IEnumerator) new Quest00210Menu.\u003CRenderIcons\u003Ec__Iterator175()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateSelectButton()
  {
    for (int index = 0; index < 5; ++index)
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
