// Decompiled with JetBrains decompiler
// Type: Guild0284Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Guild0284Menu.\u003CInitializeAsync\u003Ec__Iterator6E2()
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
    Guild0284Menu.\u003CEndSceneAsync\u003Ec__Iterator6E3 asyncCIterator6E3 = new Guild0284Menu.\u003CEndSceneAsync\u003Ec__Iterator6E3();
    return (IEnumerator) asyncCIterator6E3;
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CResourceLoad\u003Ec__Iterator6E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollInit(GuildDisplayEmblem emblem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CScrollInit\u003Ec__Iterator6E5()
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
    return (IEnumerator) new Guild0284Menu.\u003CSortPopup\u003Ec__Iterator6E6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemsUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CEmblemsUpdate\u003Ec__Iterator6E7()
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
    return (IEnumerator) new Guild0284Menu.\u003CListSorting\u003Ec__Iterator6E8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0284Menu.\u003CCreateSprite\u003Ec__Iterator6E9()
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
