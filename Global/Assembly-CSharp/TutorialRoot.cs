// Decompiled with JetBrains decompiler
// Type: TutorialRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class TutorialRoot : Singleton<TutorialRoot>
{
  private const string tutorial_finish_scene = "dailymission027_1";
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
    this.progress.CurrentPageIndex = Persist.tutorial.Data.CurrentPage;
    if (this.progress.IsFinish())
    {
      Debug.LogWarning((object) "call Render() but tutorial is finished. so restart tutorial");
      this.progress.CurrentPageIndex = 0;
      Persist.tutorial.Data.SetPageIndex(0);
    }
    this.StartCoroutine(this.startTutorial());
  }

  [DebuggerHidden]
  private IEnumerator startTutorial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003CstartTutorial\u003Ec__Iterator666()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003Cinit\u003Ec__Iterator667()
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
      Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
      Singleton<NGGameDataManager>.GetInstance().StartSceneAsyncProxy((Action<NGGameDataManager.StartSceneProxyResult>) (_ => Singleton<NGSceneManager>.GetInstance().changeScene("mypage")));
      this.isNowFinish = false;
    })));
    EventTracker.SendEvent(EventTracker.EventType.FINISH_TUTORIAL);
  }

  public void EndTutorial()
  {
    Debug.LogWarning((object) "call EndTutorial() without tutorial");
    this.endTutorial(false);
  }

  private void endTutorial(bool logfacebook = true)
  {
    this.progress.CurrentPageIndex = Persist.tutorial.Data.LastPageIndex;
    Persist.tutorial.Data.SetTutorialFinish();
    Persist.tutorial.Flush();
    if (!logfacebook)
      return;
    FaceBookWrapper.TutorialComplete();
  }

  [DebuggerHidden]
  private IEnumerator signUpLoop(System.Action callback)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new TutorialRoot.\u003CsignUpLoop\u003Ec__Iterator668()
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
      Debug.LogError((object) "OnGachaFinish gacha page was not found");
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
    return (IEnumerator) new TutorialRoot.\u003ConBattleStateChange\u003Ec__Iterator669()
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
      100111,
      100221,
      200411,
      300111,
      400131,
      500211
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
    string termTranslation;
    if (!Consts.GetInstance().tutorial.TryGetValue(tipsName, out termTranslation) || Persist.tutorial.Data.Hints.ContainsKey(tipsName))
      return string.Empty;
    if (termTranslation == string.Empty)
      termTranslation = LocalizationManager.GetTermTranslation("consts_ConstsConsts_description_" + (object) id);
    return termTranslation;
  }

  private string getTipsMessageForce(string tipsName, int id = 0)
  {
    string termTranslation;
    if (!Consts.GetInstance().tutorial.TryGetValue(tipsName, out termTranslation))
      return string.Empty;
    if (termTranslation == string.Empty && LocalizationPreset.Instance.EnableLocalization)
      termTranslation = LocalizationManager.GetTermTranslation("consts_ConstsConsts_description_" + (object) id);
    return termTranslation;
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
    int id = 0,
    Dictionary<string, Func<Transform, UIButton>> next_button_info = null,
    System.Action finishCallback = null)
  {
    string tipsMessageForce = this.getTipsMessageForce(sceneName, id);
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
    this.advice.SetMessage(message, next_button_info);
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
    this.advice.SetMessage(message);
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
    return (IEnumerator) new TutorialRoot.\u003CbulkDownLoadCheck\u003Ec__Iterator66A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doBulkDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TutorialRoot.\u003CdoBulkDownload\u003Ec__Iterator66B downloadCIterator66B = new TutorialRoot.\u003CdoBulkDownload\u003Ec__Iterator66B();
    return (IEnumerator) downloadCIterator66B;
  }
}
