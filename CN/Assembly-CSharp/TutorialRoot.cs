// Decompiled with JetBrains decompiler
// Type: TutorialRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialRoot : Singleton<TutorialRoot>
{
  private const string tutorial_finish_scene = "unit004_6_0822";
  [SerializeField]
  private Transform prefabRoot;
  [SerializeField]
  private TutorialProgress progress;
  [SerializeField]
  private TutorialAdvice advice;
  [SerializeField]
  private UIPanel mainPanel;
  [SerializeField]
  private UICamera uiCamera;
  [SerializeField]
  private UIRoot uiRoot;
  [SerializeField]
  private GameObject tutorialPagesGameObject;
  private bool isInitilizing;
  private bool isNowFinish;

  private GameObject wrap => ((Component) this.mainPanel).gameObject;

  public bool IsAdviced => this.advice.IsShow;

  public void StartTutorial()
  {
    Persist.battleEnvironment.Data = (BE) null;
    Persist.battleEnvironment.Delete();
    if (!Persist.tutorial.Exists)
      Persist.tutorial.Flush();
    if (Persist.tutorial.Data.PlayID != null && Persist.tutorial.Data.PlayID.Equals(SDK.instance.GetPlayID()))
    {
      this.progress.CurrentPageIndex = Persist.tutorial.Data.CurrentPage;
    }
    else
    {
      this.progress.CurrentPageIndex = 0;
      Persist.tutorial.Data.SetPageIndex(0);
    }
    if (this.progress.IsFinish())
    {
      Debug.LogError((object) "call Renbder() but tutorial is finished. so restart tutorial");
      this.progress.CurrentPageIndex = 0;
      Persist.tutorial.Data.SetPageIndex(0);
    }
    this.StartCoroutine(this.startTutorial());
  }

  public int GetCurrentPage() => this.progress.CurrentPageIndex;

  public bool IsFirstBattle() => this.GetCurrentPage() == 2;

  public bool IsSceondBattle() => this.GetCurrentPage() == 7;

  [DebuggerHidden]
  private IEnumerator startTutorial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003CstartTutorial\u003Ec__Iterator7AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003Cinit\u003Ec__Iterator7AD()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void finish()
  {
    if (this.isNowFinish)
      return;
    this.isNowFinish = true;
    Persist.battleEnvironment.Data = (BE) null;
    Persist.battleEnvironment.Delete();
    this.wrap.SetActive(false);
    this.StartCoroutine(this.signUpLoop((System.Action) (() =>
    {
      this.endTutorial();
      Singleton<CommonRoot>.GetInstance().isTouchBlock = false;
      Debug.Log((object) "tutorial end, go to next page");
      Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
      Singleton<NGGameDataManager>.GetInstance().StartSceneAsyncProxy((Action<NGGameDataManager.StartSceneProxyResult>) (_ =>
      {
        Unit0046Scene.changeScene(false);
        Singleton<NGSceneManager>.GetInstance().waitSceneAction((System.Action) (() =>
        {
          this.showAdvice(Consts.GetInstance().tutorial_finish, "unit004_6_0822");
          Singleton<NGSceneManager>.GetInstance().clearStack();
        }));
      }));
      this.isNowFinish = false;
    })));
    EventTracker.SendEvent(EventTracker.EventType.FINISH_TUTORIAL);
  }

  public void EndTutorial()
  {
    Debug.LogWarning((object) "call EndTutorial() without tutorial");
    this.endTutorial(false, false);
  }

  private void endTutorial(bool logFiveRocks = true, bool logfacebook = true)
  {
    this.progress.CurrentPageIndex = Persist.tutorial.Data.LastPageIndex;
    Persist.tutorial.Data.SetTutorialFinish();
    Persist.tutorial.Flush();
    if (!logFiveRocks)
      return;
    EventTracker.BeaconTutorial("Finish", Persist.tutorial.Data.DuringSeconds());
  }

  [DebuggerHidden]
  private IEnumerator signUpLoop(System.Action callback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003CsignUpLoop\u003Ec__Iterator7AE()
    {
      callback = callback,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  public bool IsTutorialFinish() => Persist.tutorial.Data.IsFinishTutorial();

  public void OnGachaFinish()
  {
    if (this.IsTutorialFinish())
      return;
    TutorialGachaPage tutorialGachaPage = this.progress.GachaPage();
    if (Object.op_Equality((Object) tutorialGachaPage, (Object) null))
      Debug.LogError((object) ("call OnBattleStateChange but not CurrentPageIndex=" + (object) this.progress.CurrentPageIndex));
    else
      tutorialGachaPage.OnGachaFinish();
  }

  public void OnChangeSceneFinish(string sceneName)
  {
    string tipsMessage = this.getTipsMessage(sceneName);
    if (string.IsNullOrEmpty(tipsMessage))
      return;
    this.showAdvice(tipsMessage, sceneName);
  }

  public void OnBattleStateChange(BL env)
  {
    if (this.IsTutorialFinish())
    {
      this.FirstAnnihilated(env);
    }
    else
    {
      if (env.phaseState.state == BL.Phase.finalize)
      {
        Singleton<NGBattleManager>.GetInstance().isBattleEnable = false;
        Singleton<NGBattleManager>.GetInstance().popupOpen((GameObject) null);
      }
      this.StartCoroutine(this.onBattleStateChange(env.phaseState.state, env.phaseState.turnCount));
    }
  }

  public bool FirstAnnihilated(BL env)
  {
    if (env.phaseState.state == BL.Phase.finalize && !env.battleInfo.pvp && !env.battleInfo.isEarthMode && env.battleInfo.isFirstAllDead && env.allDeadUnitsp(BL.ForceID.player))
    {
      Singleton<NGBattleManager>.GetInstance().isBattleEnable = false;
      System.Action action = (System.Action) (() => Singleton<NGBattleManager>.GetInstance().isBattleEnable = true);
      // ISSUE: reference to a compiler-generated field
      if (!this.ShowAdvice("firstgameover", finishCallback: TutorialRoot.\u003C\u003Ef__am\u0024cache9))
      {
        Singleton<NGBattleManager>.GetInstance().isBattleEnable = true;
        Debug.LogError((object) "ERROR FirstAnnihilated ShowAdvice");
      }
    }
    return false;
  }

  public void ReleaseResources() => this.progress.ReleaseResources();

  [DebuggerHidden]
  public IEnumerator onBattleStateChange(BL.Phase state, int turn)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003ConBattleStateChange\u003Ec__Iterator7AF()
    {
      state = state,
      turn = turn,
      \u003C\u0024\u003Estate = state,
      \u003C\u0024\u003Eturn = turn,
      \u003C\u003Ef__this = this
    };
  }

  public int[] GachaEffectUnitIds()
  {
    return new int[6]
    {
      100113,
      100223,
      200413,
      300113,
      400133,
      500213
    };
  }

  protected override void Initialize()
  {
    this.isNowFinish = false;
    this.isInitilizing = true;
    this.StartCoroutine(this.init());
  }

  private string getTipsMessage(string tipsName, int id = 0)
  {
    string str;
    return Consts.GetInstance().tutorial.TryGetValue(tipsName, out str) && !Persist.tutorial.Data.Hints.ContainsKey(tipsName) ? str : string.Empty;
  }

  private string getTipsMessageForce(string tipsName, int id = 0)
  {
    string str;
    return Consts.GetInstance().tutorial.TryGetValue(tipsName, out str) ? str : string.Empty;
  }

  public bool isReadHint(string sceneName, int id)
  {
    return string.IsNullOrEmpty(this.getTipsMessage(sceneName, id));
  }

  private void doneReadHint(string sceneName)
  {
    if (!Consts.GetInstance().tutorial.ContainsKey(sceneName))
      return;
    Persist.tutorial.Data.Hints[sceneName] = true;
    Persist.tutorial.Flush();
  }

  public bool ShowAdvice(string sceneName = null, int id = 0, System.Action finishCallback = null)
  {
    string tipsMessage = this.getTipsMessage(sceneName, id);
    if (string.IsNullOrEmpty(tipsMessage))
      return false;
    this.showAdvice(tipsMessage, sceneName, finishCallback: finishCallback);
    return true;
  }

  public bool ForceShowAdvice(string sceneName = null, System.Action finishCallback = null)
  {
    return this.ForceShowAdviceInNextButton(sceneName, finishCallback: finishCallback);
  }

  public bool ForceShowAdviceInNextButton(
    string sceneName = null,
    Dictionary<string, Func<Transform, UIButton>> next_button_info = null,
    System.Action finishCallback = null)
  {
    string tipsMessageForce = this.getTipsMessageForce(sceneName);
    if (string.IsNullOrEmpty(tipsMessageForce))
      return false;
    this.showAdvice(tipsMessageForce, sceneName, next_button_info, finishCallback);
    return true;
  }

  private void showAdvice(
    string message,
    string sceneName = null,
    Dictionary<string, Func<Transform, UIButton>> next_button_info = null,
    System.Action finishCallback = null)
  {
    this.wrap.SetActive(true);
    this.advice.SetMessage(sceneName, message, next_button_info);
    this.advice.FinishCallback = (System.Action) (() =>
    {
      if (sceneName != null)
        this.doneReadHint(sceneName);
      this.wrap.SetActive(false);
      if (finishCallback == null)
        return;
      finishCallback();
    });
  }

  private void doneEventQuestExplanation(int sceneID)
  {
    Persist.explanation.Data.Explanation[sceneID] = true;
    Persist.explanation.Flush();
  }

  public void showEventQuestExplanation(string message, int sceneID = -1)
  {
    this.wrap.SetActive(true);
    this.advice.SetMessage((string) null, message);
    this.advice.FinishCallback = (System.Action) (() =>
    {
      if (sceneID != -1)
        this.doneEventQuestExplanation(sceneID);
      this.wrap.SetActive(false);
    });
  }

  public void DebugTutorialStart()
  {
    Persist.tutorial.Data.SetPageIndex(0);
    Persist.tutorial.Delete();
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    Singleton<NGGameDataManager>.GetInstance().StartSceneAsyncProxy((Action<NGGameDataManager.StartSceneProxyResult>) (_ => this.StartTutorial()));
  }

  public void DebugTutorialFinish()
  {
    this.wrap.SetActive(false);
    this.finish();
  }

  public void DebugTutorialAdvice(string message) => this.showAdvice(message);

  [DebuggerHidden]
  private IEnumerator bulkDownLoadCheck()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003CbulkDownLoadCheck\u003Ec__Iterator7B0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doBulkDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TutorialRoot.\u003CdoBulkDownload\u003Ec__Iterator7B1 downloadCIterator7B1 = new TutorialRoot.\u003CdoBulkDownload\u003Ec__Iterator7B1();
    return (IEnumerator) downloadCIterator7B1;
  }

  public enum TutorialStep
  {
    FIRST_BATTLE = 2,
    SCEOND_BATTLE = 7,
  }
}
