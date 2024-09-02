// Decompiled with JetBrains decompiler
// Type: Quest002171Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest002171Scroll : BannerBase
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
  private Quest002171Menu menu;

  public bool CanPlay => this.canPlay;

  [DebuggerHidden]
  public IEnumerator InitScroll(
    PlayerQuestGate[] keyQuests,
    DateTime serverTime,
    Quest002171Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CInitScroll\u003Ec__Iterator1FC()
    {
      menu = menu,
      keyQuests = keyQuests,
      serverTime = serverTime,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EkeyQuests = keyQuests,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }

  private string SetSpritePath(int id, bool isIdle, bool canplay)
  {
    return !isIdle ? BannerBase.GetSpritePressedPath(id, BannerBase.Type.quest_lock, canplay: canplay) : BannerBase.GetSpriteIdlePath(id, BannerBase.Type.quest_lock, canplay: canplay);
  }

  [DebuggerHidden]
  private IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator1FD()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj
    };
  }

  private void SetScrollButtonCondition(
    PlayerQuestGate[] keyQuests,
    bool canPlay,
    DateTime serverTime)
  {
    if (canPlay)
    {
      PlayerQuestGate keyQuest = ((IEnumerable<PlayerQuestGate>) keyQuests).First<PlayerQuestGate>((Func<PlayerQuestGate, bool>) (x => x.in_progress));
      EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.changeScene(keyQuest, ((Component) this).gameObject, serverTime)));
    }
    else
      EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.StartQuestReleasePopup(keyQuests, this.menu)));
    EventDelegate.Set(this.BtnFormation.onOver, (EventDelegate.Callback) (() => this.onOver(((Component) this).gameObject)));
    EventDelegate.Set(this.BtnFormation.onOut, (EventDelegate.Callback) (() => this.onOut(((Component) this).gameObject)));
  }

  private void changeScene(PlayerQuestGate keyQuest, GameObject obj, DateTime serverTime)
  {
    this.StartCoroutine(this.QuestTimeCompare(keyQuest));
  }

  public void ChangeScene(PlayerQuestGate playerKey)
  {
    this.StartCoroutine(this.QuestTimeCompare(playerKey));
  }

  public void StartQuestReleasePopup(PlayerQuestGate[] keyQuests, Quest002171Menu menu)
  {
    this.StartCoroutine(this.OpenQuestReleasePopup(keyQuests, menu, this));
  }

  private void onOver(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest002171Scroll>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Quest002171Scroll>().PressSprite).gameObject.SetActive(true);
  }

  private void onOut(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest002171Scroll>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Quest002171Scroll>().PressSprite).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator OpenQuestReleasePopup(
    PlayerQuestGate[] keyQuests,
    Quest002171Menu menu,
    Quest002171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003COpenQuestReleasePopup\u003Ec__Iterator1FE()
    {
      keyQuests = keyQuests,
      menu = menu,
      scroll = scroll,
      \u003C\u0024\u003EkeyQuests = keyQuests,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Escroll = scroll
    };
  }

  [DebuggerHidden]
  private IEnumerator QuestTimeCompare(PlayerQuestGate keyQuest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CQuestTimeCompare\u003Ec__Iterator1FF()
    {
      keyQuest = keyQuest,
      \u003C\u0024\u003EkeyQuest = keyQuest
    };
  }

  private void SetPossession(int keyNum)
  {
    this.possessionObj.SetActive(true);
    int index1 = keyNum / 10;
    int index2 = keyNum % 10;
    ((IEnumerable<UISprite>) this.possessionNumL).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((IEnumerable<UISprite>) this.possessionNumR).ForEach<UISprite>((Action<UISprite>) (x => ((Component) x).gameObject.SetActive(false)));
    ((Component) this.possessionNumL[index1]).gameObject.SetActive(true);
    ((Component) this.possessionNumR[index2]).gameObject.SetActive(true);
  }
}
