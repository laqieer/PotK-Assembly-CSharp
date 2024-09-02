// Decompiled with JetBrains decompiler
// Type: Quest00217Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00217Scroll : BannerBase
{
  protected const string SeekIndexL = "L";
  protected const string SeekIndexM = "M";
  [SerializeField]
  public UISprite Clear;
  [SerializeField]
  public UISprite New;
  [SerializeField]
  protected FloatButton Button;
  [SerializeField]
  protected GameObject Highlighting;
  [SerializeField]
  protected UIUnityMaskRenderer EffectRenderer;
  protected bool initialized;
  protected Quest00217Scroll.Parameter initData;
  protected CampaignQuest.RankingEventTerm rankingEventTerm;
  protected bool inside_ = true;
  protected bool enabledCountdown;
  protected bool effect_;
  protected GameObject objEffect_;
  protected DateTime timeGoal;
  protected int lastSeconds;
  private DateTime lastServerTime;
  private float lastLocalTime;

  public CampaignQuest.RankingEventTerm RankingEventTerm => this.rankingEventTerm;

  [DebuggerHidden]
  public virtual IEnumerator InitScroll(Quest00217Scroll.Parameter param, DateTime serverTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CInitScroll\u003Ec__Iterator1E8()
    {
      param = param,
      serverTime = serverTime,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
  }

  protected string SetSpritePath(int L, int M, bool isIdle, string seek_index)
  {
    bool flag = seek_index == "m" || seek_index == nameof (M);
    int id = !flag ? L : M;
    int tmp = !flag ? 0 : 1;
    BannerBase.Type type = BannerBase.Type.quest;
    return !isIdle ? BannerBase.GetSpritePressedPath(id, type, tmp) : BannerBase.GetSpriteIdlePath(id, type, tmp);
  }

  [DebuggerHidden]
  protected IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator1E9()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj
    };
  }

  protected void SetScrollButtonCondition(
    PlayerExtraQuestS extra,
    DateTime serverTime,
    string seekIndex)
  {
    EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.changeScene(extra, ((Component) this).gameObject, serverTime, seekIndex)));
    EventDelegate.Set(this.BtnFormation.onOver, (EventDelegate.Callback) (() => this.onOver(((Component) this).gameObject)));
    EventDelegate.Set(this.BtnFormation.onOut, (EventDelegate.Callback) (() => this.onOut(((Component) this).gameObject)));
  }

  public void changeScene(
    PlayerExtraQuestS extra,
    GameObject obj,
    DateTime serverTime,
    string seekIndex)
  {
    this.StartCoroutine(this.QuestTimeCompare(extra, obj, serverTime, seekIndex));
  }

  public void onOver(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest00217Scroll>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Quest00217Scroll>().PressSprite).gameObject.SetActive(true);
  }

  public void onOut(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest00217Scroll>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Quest00217Scroll>().PressSprite).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator QuestTimeCompare(
    PlayerExtraQuestS StageData,
    GameObject obj,
    DateTime serverTime,
    string seekIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CQuestTimeCompare\u003Ec__Iterator1EA()
    {
      serverTime = serverTime,
      StageData = StageData,
      seekIndex = seekIndex,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003EseekIndex = seekIndex,
      \u003C\u003Ef__this = this
    };
  }

  protected void startCountdown(TimeSpan tspan)
  {
    this.timeGoal = DateTime.Now.Add(tspan);
    this.lastSeconds = tspan.Seconds - 1;
    this.enabledCountdown = true;
  }

  protected void resetLocalTime(DateTime serverTime)
  {
    this.lastServerTime = serverTime;
    this.lastLocalTime = Time.time;
  }

  protected DateTime nowLocalTime
  {
    get => this.lastServerTime.AddSeconds((double) Time.time - (double) this.lastLocalTime);
  }

  private void Update() => this.updateCountdown(false);

  protected virtual void updateCountdown(bool immediate)
  {
    if (!this.enabledCountdown)
      return;
    TimeSpan tspan = this.timeGoal - DateTime.Now;
    if (tspan.Ticks <= 0L)
    {
      this.enabledCountdown = false;
      if (!immediate)
        this.duplicateEffectFadeOut(((Component) this).gameObject, ((Component) this).gameObject, 0.5f);
      ((Component) this.Clear).gameObject.SetActive(this.initData.isClear);
      ((Component) this.New).gameObject.SetActive(this.initData.isNew);
      if (Object.op_Inequality((Object) this.Highlighting, (Object) null))
        this.Highlighting.SetActive(this.initData.isHighlighting);
      this.SetEndTime(this.initData.extra.today_day_end_at);
      this.SetTime(this.nowLocalTime, this.rankingEventTerm);
      if (immediate)
        ((Behaviour) this.Button).enabled = true;
      else
        this.fadeIn(0.5f);
    }
    else
    {
      if (this.lastSeconds == tspan.Seconds && !immediate)
        return;
      this.lastSeconds = tspan.Seconds;
      this.updateTime(tspan, !immediate ? 0.5f : 0.0f);
    }
  }

  protected virtual GameObject duplicateEffectFadeOut(
    GameObject parentObj,
    GameObject originalObj,
    float duration)
  {
    GameObject gameObject = NGUITools.AddChild(parentObj, originalObj);
    this.objEffect_ = gameObject;
    gameObject.SetActive(true);
    Object.Destroy((Object) gameObject.GetComponent<Quest002171Scroll>());
    gameObject.AddComponent<Quest00217ScrollFadeOut>().init(duration, 100, new EventDelegate((EventDelegate.Callback) (() =>
    {
      Object.Destroy((Object) this.objEffect_);
      this.objEffect_ = (GameObject) null;
    })));
    return gameObject;
  }

  protected virtual void fadeIn(float duration)
  {
    UIWidget uiWidget = Quest00217ScrollFadeOut.setWidget(((Component) this).gameObject, 0);
    if (!Object.op_Inequality((Object) uiWidget, (Object) null))
      return;
    uiWidget.alpha = 0.0f;
    this.effect_ = true;
    TweenAlpha ta = TweenAlpha.Begin(((Component) this).gameObject, duration, 1f);
    ta.SetOnFinished((EventDelegate.Callback) (() =>
    {
      Object.Destroy((Object) ta);
      Object.Destroy((Object) uiWidget);
      ((Behaviour) this.Button).enabled = true;
      this.effect_ = false;
    }));
  }

  private void OnEnable()
  {
    if (!this.initialized)
      return;
    if (this.enabledCountdown)
      this.updateCountdown(true);
    else
      this.SetTime(this.nowLocalTime, this.rankingEventTerm);
  }

  private void OnDisable()
  {
    if (Object.op_Inequality((Object) this.objEffect_, (Object) null))
    {
      Object.Destroy((Object) this.objEffect_);
      this.objEffect_ = (GameObject) null;
    }
    if (this.effect_)
    {
      UIWidget component1 = ((Component) this).gameObject.GetComponent<UIWidget>();
      TweenAlpha component2 = ((Component) this).gameObject.GetComponent<TweenAlpha>();
      component2.value = 1f;
      Object.Destroy((Object) component2);
      Object.Destroy((Object) component1);
      ((Behaviour) this.Button).enabled = true;
      this.effect_ = false;
    }
    this.terminateAnimation();
  }

  public void onInside()
  {
    this.inside_ = true;
    ((Component) this).gameObject.SetActive(true);
  }

  public void onOutside()
  {
    this.inside_ = false;
    ((Component) this).gameObject.SetActive(false);
  }

  public class Parameter
  {
    public PlayerExtraQuestS extra;
    public EventInfo eventInfo;
    public bool isClear;
    public bool isNew;
    public Quest00217Scroll.SeekType seek;
    public bool isNotice;
    public DateTime? startTime;
    public bool isHighlighting;
  }

  public enum SeekType
  {
    NONE,
    M,
    L,
  }
}
