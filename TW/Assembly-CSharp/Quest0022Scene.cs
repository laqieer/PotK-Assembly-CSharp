// Decompiled with JetBrains decompiler
// Type: Quest0022Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest0022Scene : NGSceneBase
{
  private static bool isInit;
  public Quest0022Menu menu;
  public BGChange bgchange;
  private static QuestStoryClearMessage clearmessage;
  private static BattleEndPlayer_review reviewSet;

  public static void ChangeScene0022(bool stack, int L, int M)
  {
    Quest0022Scene.isInit = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_2", (stack ? 1 : 0) != 0, (object) L, (object) M);
  }

  public static void ChangeScene0022(bool stack, int L, int M, int S)
  {
    Quest0022Scene.isInit = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_2", (stack ? 1 : 0) != 0, (object) L, (object) M, (object) S);
  }

  public static void ChangeScene0022(
    bool stack,
    int L,
    int M,
    int recent_s_id,
    int clearCount,
    BattleEndPlayer_review review)
  {
    Quest0022Scene.clearmessage = ((IEnumerable<QuestStoryClearMessage>) MasterData.QuestStoryClearMessageList).Where<QuestStoryClearMessage>((Func<QuestStoryClearMessage, bool>) (x => x.quest_s_id == recent_s_id)).Where<QuestStoryClearMessage>((Func<QuestStoryClearMessage, bool>) (x => !x.is_firsttime && clearCount > 0 || clearCount == 1)).FirstOrDefault<QuestStoryClearMessage>();
    Quest0022Scene.reviewSet = (BattleEndPlayer_review) null;
    Quest0022Scene.reviewSet = review;
    Quest0022Scene.ChangeScene0022(stack, L, M);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Scene.\u003ConStartSceneAsync\u003Ec__Iterator263()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int L, int M)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Scene.\u003ConStartSceneAsync\u003Ec__Iterator264()
    {
      L = L,
      M = M,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int L, int M, int S)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Scene.\u003ConStartSceneAsync\u003Ec__Iterator265()
    {
      L = L,
      M = M,
      S = S,
      \u003C\u0024\u003EL = L,
      \u003C\u0024\u003EM = M,
      \u003C\u0024\u003ES = S,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    this.menu.SceneStart = true;
    foreach (TweenPosition tweenPosition in this.menu.startAllpostween)
      tweenPosition.tweenGroup = Math.Abs(tweenPosition.tweenGroup);
    foreach (TweenAlpha tweenAlpha in this.menu.startAllalphatween)
      tweenAlpha.tweenGroup = Math.Abs(tweenAlpha.tweenGroup);
  }

  public void onStartScene(int L, int M)
  {
    if (Quest0022Scene.clearmessage != null)
      this.StartCoroutine(this.ClearPopup());
    else if (Quest0022Scene.reviewSet != null && Quest0022Scene.reviewSet.id != string.Empty)
      Quest0022Scene.reviewSet = (BattleEndPlayer_review) null;
    this.menu.SceneStart = true;
    foreach (TweenPosition tweenPosition in this.menu.startAllpostween)
      tweenPosition.tweenGroup = Math.Abs(tweenPosition.tweenGroup);
    foreach (TweenAlpha tweenAlpha in this.menu.startAllalphatween)
      tweenAlpha.tweenGroup = Math.Abs(tweenAlpha.tweenGroup);
    this.menu.HscrollButtonsAction();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  public void onStartScene(int L, int M, int S) => this.onStartScene(L, M);

  [DebuggerHidden]
  private IEnumerator ClearPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0022Scene.\u003CClearPopup\u003Ec__Iterator266 popupCIterator266 = new Quest0022Scene.\u003CClearPopup\u003Ec__Iterator266();
    return (IEnumerator) popupCIterator266;
  }

  [DebuggerHidden]
  private IEnumerator ReviewPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0022Scene.\u003CReviewPopup\u003Ec__Iterator267 popupCIterator267 = new Quest0022Scene.\u003CReviewPopup\u003Ec__Iterator267();
    return (IEnumerator) popupCIterator267;
  }

  public override void onEndScene()
  {
    foreach (GameObject hscrollButton in this.menu.hscrollButtons)
      hscrollButton.GetComponent<Quest0022Hscroll>().centerAnimation(false);
    this.menu.indicator.SeEnable = false;
    this.menu.nowCenterObj = (GameObject) null;
    this.menu.SceneStart = false;
    this.menu.ButtonMove = false;
    this.menu.onEndScene();
  }
}
