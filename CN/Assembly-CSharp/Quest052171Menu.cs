// Decompiled with JetBrains decompiler
// Type: Quest052171Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest052171Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UIScrollView scrollview;
  [SerializeField]
  private UIGrid grid;
  private DateTime serverTime;
  private GameObject ScrollPrefab;

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Menu.\u003CInit\u003Ec__Iterator73C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ScrollInit(
    EarthExtraQuest quest,
    EarthQuestKey questKey,
    bool isPlay,
    GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Menu.\u003CScrollInit\u003Ec__Iterator73D()
    {
      prefab = prefab,
      quest = quest,
      questKey = questKey,
      isPlay = isPlay,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Equest = quest,
      \u003C\u0024\u003EquestKey = questKey,
      \u003C\u0024\u003EisPlay = isPlay,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Mypage051Scene.ChangeScene(false, false);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent() => Debug.Log((object) "click default event IbtnEvent");

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  private string GetTitle() => Consts.GetInstance().QUEST_00217_KEY_TITLE;

  public void StartAPI_QuestRelease(EarthExtraQuest quest, EarthQuestKey questKey, bool canPlay)
  {
    this.StartCoroutine(this.QuestRelease(quest, questKey, canPlay));
  }

  [DebuggerHidden]
  private IEnumerator QuestRelease(EarthExtraQuest quest, EarthQuestKey questKey, bool canPlay)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest052171Menu.\u003CQuestRelease\u003Ec__Iterator73E()
    {
      canPlay = canPlay,
      questKey = questKey,
      quest = quest,
      \u003C\u0024\u003EcanPlay = canPlay,
      \u003C\u0024\u003EquestKey = questKey,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }
}
