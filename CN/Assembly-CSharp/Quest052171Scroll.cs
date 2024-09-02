// Decompiled with JetBrains decompiler
// Type: Quest052171Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  [SerializeField]
  private UISprite Clear;
  [SerializeField]
  private UISprite New;
  [SerializeField]
  private UISprite[] possessionNumL;
  [SerializeField]
  private UISprite[] possessionNumR;
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
    return (IEnumerator) new Quest052171Scroll.\u003CInitScroll\u003Ec__Iterator742()
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

  private string GetSpritePath(int id, bool isIdle, bool canplay)
  {
    return !isIdle ? BannerBase.GetSpritePressedPath(id, BannerBase.Type.quest_lock, canplay: canplay, isEarth: true) : BannerBase.GetSpriteIdlePath(id, BannerBase.Type.quest_lock, canplay: canplay, isEarth: true);
  }

  [DebuggerHidden]
  private IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator743()
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
    EventDelegate.Set(this.BtnFormation.onOver, (EventDelegate.Callback) (() => this.onOver(((Component) this).gameObject)));
    EventDelegate.Set(this.BtnFormation.onOut, (EventDelegate.Callback) (() => this.onOut(((Component) this).gameObject)));
  }

  private void changeScene(EarthExtraQuest quest) => Quest0528Scene.changeScene(true, quest);

  public void StartQuestReleasePopup(EarthExtraQuest quest, EarthQuestKey questKey)
  {
    this.StartCoroutine(this.OpenQuestReleasePopup(quest, questKey, this.menu, this));
  }

  private void onOver(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest052171Scroll>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Quest052171Scroll>().PressSprite).gameObject.SetActive(true);
  }

  private void onOut(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest052171Scroll>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Quest052171Scroll>().PressSprite).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator OpenQuestReleasePopup(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    Quest052171Menu menu,
    Quest052171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Scroll.\u003COpenQuestReleasePopup\u003Ec__Iterator744()
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
    int num = keyNum >= 0 ? keyNum : 0;
    int index1 = num / 10;
    int index2 = num % 10;
    ((IEnumerable<UISprite>) this.possessionNumL).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((IEnumerable<UISprite>) this.possessionNumR).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((Component) this.possessionNumL[index1]).gameObject.SetActive(true);
    ((Component) this.possessionNumR[index2]).gameObject.SetActive(true);
  }
}
