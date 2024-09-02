// Decompiled with JetBrains decompiler
// Type: Title0241Menu
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
using UnityEngine;

#nullable disable
public class Title0241Menu : BackButtonMenuBase
{
  private const int UNKNOWN_ID = 99999;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollview;
  [SerializeField]
  private UI2DSprite CurrentTitle;
  [SerializeField]
  private GameObject[] DisplayOrderSprites;
  private GameObject ScrollPrefab;
  private PlayerEmblem[] emblems;
  private int curEmblemID;
  private int[] displayEmblemIds;

  public override void onBackButton() => this.IbtnBack();

  public virtual void Foreground()
  {
  }

  public virtual void IbtnTitleList()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CInit\u003Ec__Iterator63B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollInit(bool hasEmblem, EmblemEmblem emblem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CScrollInit\u003Ec__Iterator63C()
    {
      hasEmblem = hasEmblem,
      emblem = emblem,
      \u003C\u0024\u003EhasEmblem = hasEmblem,
      \u003C\u0024\u003Eemblem = emblem,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnSort() => this.StartCoroutine(this.SortPopup());

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  private void DisplayOrderSpriteSetting(int type)
  {
    ((IEnumerable<GameObject>) this.DisplayOrderSprites).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    this.DisplayOrderSprites[type].SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator SortPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CSortPopup\u003Ec__Iterator63D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemsUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CEmblemsUpdate\u003Ec__Iterator63E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ListSort() => this.StartCoroutine(this.ListSorting());

  [DebuggerHidden]
  private IEnumerator ListSorting()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CListSorting\u003Ec__Iterator63F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Title0241Menu.\u003CCreateSprite\u003Ec__Iterator640()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void EmblemsScrollUpdate() => this.StartCoroutine(this.Init());

  private class DisplayEmblems
  {
    public bool hasTitle;

    public EmblemEmblem emblem { get; set; }
  }
}
