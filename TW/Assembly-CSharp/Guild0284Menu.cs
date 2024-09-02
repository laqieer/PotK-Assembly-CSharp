// Decompiled with JetBrains decompiler
// Type: Guild0284Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0284Menu : BackButtonMenuBase
{
  private const int UNKNOWN_ID = 99999;
  private GuildDisplayEmblem[] emblems;
  private int curEmblemID;
  [SerializeField]
  private NGxScroll scroll;
  private GameObject scrollObj;
  private GameObject guild02841Popup;
  private GameObject guildTitleSortPopup;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollview;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UI2DSprite currentTitle;
  [SerializeField]
  private GameObject[] DisplayOrderSprites;

  public GameObject Guild02841Popup => this.guild02841Popup;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CInitializeAsync\u003Ec__Iterator799()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
    this.txtTitle.SetTextLocalize(Consts.GetInstance().GUILD_28_4_MENU_TITLE);
  }

  [DebuggerHidden]
  public IEnumerator EndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Guild0284Menu.\u003CEndSceneAsync\u003Ec__Iterator79A asyncCIterator79A = new Guild0284Menu.\u003CEndSceneAsync\u003Ec__Iterator79A();
    return (IEnumerator) asyncCIterator79A;
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CResourceLoad\u003Ec__Iterator79B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollInit(GuildDisplayEmblem emblem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CScrollInit\u003Ec__Iterator79C()
    {
      emblem = emblem,
      \u003C\u0024\u003Eemblem = emblem,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SortPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CSortPopup\u003Ec__Iterator79D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemsUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CEmblemsUpdate\u003Ec__Iterator79E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ListSort() => this.StartCoroutine(this.ListSorting());

  private void DisplayOrderSpriteSetting(int type)
  {
    ((IEnumerable<GameObject>) this.DisplayOrderSprites).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    this.DisplayOrderSprites[type].SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator ListSorting()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CListSorting\u003Ec__Iterator79F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CCreateSprite\u003Ec__Iterator7A0()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void EmblemsScrollUpdate() => this.StartCoroutine(this.InitializeAsync());

  public void onSortButton() => this.StartCoroutine(this.SortPopup());

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
