// Decompiled with JetBrains decompiler
// Type: Quest002171Scroll
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
public class Quest002171Scroll : BannerBase
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

  public bool CanPlay => this.canPlay;

  public bool IsBackToKeyQuest { get; set; }

  [DebuggerHidden]
  public IEnumerator InitScroll(
    PlayerQuestGate[] keyQuests,
    DateTime serverTime,
    bool isBackToKeyQuest = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CInitScroll\u003Ec__Iterator22D()
    {
      isBackToKeyQuest = isBackToKeyQuest,
      keyQuests = keyQuests,
      serverTime = serverTime,
      \u003C\u0024\u003EisBackToKeyQuest = isBackToKeyQuest,
      \u003C\u0024\u003EkeyQuests = keyQuests,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }

  private string SetSpritePath(int id, bool canplay)
  {
    return BannerBase.GetSpriteIdlePath(id, BannerBase.Type.quest_lock, canplay: canplay);
  }

  [DebuggerHidden]
  private IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator22E()
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
      EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.StartQuestReleasePopup(keyQuests)));
  }

  private void changeScene(PlayerQuestGate keyQuest, GameObject obj, DateTime serverTime)
  {
    this.StartCoroutine(this.QuestTimeCompare(keyQuest));
  }

  public void ChangeScene(PlayerQuestGate playerKey)
  {
    this.StartCoroutine(this.QuestTimeCompare(playerKey));
  }

  public void StartQuestReleasePopup(PlayerQuestGate[] keyQuests)
  {
    if (this.IsBackToKeyQuest)
      this.StartCoroutine(this.OpenQuestReleasePopup(keyQuests, this));
    else
      this.StartCoroutine(this.OpenCollaboQuestReleasePopup(keyQuests, this));
  }

  [DebuggerHidden]
  private IEnumerator OpenQuestReleasePopup(PlayerQuestGate[] keyQuests, Quest002171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003COpenQuestReleasePopup\u003Ec__Iterator22F()
    {
      keyQuests = keyQuests,
      scroll = scroll,
      \u003C\u0024\u003EkeyQuests = keyQuests,
      \u003C\u0024\u003Escroll = scroll
    };
  }

  [DebuggerHidden]
  private IEnumerator OpenCollaboQuestReleasePopup(
    PlayerQuestGate[] keyQuests,
    Quest002171Scroll scroll)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003COpenCollaboQuestReleasePopup\u003Ec__Iterator230()
    {
      keyQuests = keyQuests,
      scroll = scroll,
      \u003C\u0024\u003EkeyQuests = keyQuests,
      \u003C\u0024\u003Escroll = scroll
    };
  }

  [DebuggerHidden]
  private IEnumerator QuestTimeCompare(PlayerQuestGate keyQuest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171Scroll.\u003CQuestTimeCompare\u003Ec__Iterator231()
    {
      keyQuest = keyQuest,
      \u003C\u0024\u003EkeyQuest = keyQuest,
      \u003C\u003Ef__this = this
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
