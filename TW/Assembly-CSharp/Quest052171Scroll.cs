// Decompiled with JetBrains decompiler
// Type: Quest052171Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest052171Scroll : BannerBase
{
  private const int KeyNumMax = 999;
  [SerializeField]
  private UISprite Clear;
  [SerializeField]
  private UISprite New;
  [SerializeField]
  private UISprite[] possessionDigit100;
  [SerializeField]
  private UISprite[] possessionDigit10;
  [SerializeField]
  private UISprite[] possessionDigit1;
  [SerializeField]
  private GameObject possessionObj;
  [SerializeField]
  private GameObject timeText;
  private bool canPlay;
  private Quest052171Menu menu;

  public bool CanPlay => this.canPlay;

  [DebuggerHidden]
  public IEnumerator InitScroll(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    bool isPlay,
    Quest052171Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Scroll.\u003CInitScroll\u003Ec__Iterator809()
    {
      menu = menu,
      questKey = questKey,
      isPlay = isPlay,
      quest = quest,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EquestKey = questKey,
      \u003C\u0024\u003EisPlay = isPlay,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  private string GetSpritePath(int id, bool canplay)
  {
    return BannerBase.GetSpriteIdlePath(id, BannerBase.Type.quest_lock, canplay: canplay, isEarth: true);
  }

  [DebuggerHidden]
  private IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator80A()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj
    };
  }

  private void SetScrollButtonCondition(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    bool canPlay)
  {
    if (canPlay)
      EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.changeScene(quest)));
    else
      EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.StartQuestReleasePopup(quest, questKey)));
  }

  private void changeScene(EarthExtraQuest quest) => Quest0528Scene.changeScene(true, quest);

  public void StartQuestReleasePopup(EarthExtraQuest quest, EarthQuestKey questKey)
  {
    this.StartCoroutine(this.OpenQuestReleasePopup(quest, questKey, this.menu, this));
  }

  [DebuggerHidden]
  private IEnumerator OpenQuestReleasePopup(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    Quest052171Menu menu,
    Quest052171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Scroll.\u003COpenQuestReleasePopup\u003Ec__Iterator80B()
    {
      quest = quest,
      questKey = questKey,
      menu = menu,
      scroll = scroll,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003EquestKey = questKey,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Escroll = scroll
    };
  }

  private void SetPossession(int keyNum)
  {
    this.possessionObj.SetActive(true);
    int num = keyNum <= 999 ? keyNum : 999;
    int index1 = num / 100;
    int index2 = num % 100 / 10;
    int index3 = num % 10;
    ((IEnumerable<UISprite>) this.possessionDigit100).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((IEnumerable<UISprite>) this.possessionDigit10).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((IEnumerable<UISprite>) this.possessionDigit1).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((Component) this.possessionDigit100[index1]).gameObject.SetActive(true);
    ((Component) this.possessionDigit10[index2]).gameObject.SetActive(true);
    ((Component) this.possessionDigit1[index3]).gameObject.SetActive(true);
  }
}
