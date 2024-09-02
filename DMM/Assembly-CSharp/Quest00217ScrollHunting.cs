// Decompiled with JetBrains decompiler
// Type: Quest00217ScrollHunting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

public class Quest00217ScrollHunting : Quest00217Scroll
{
  public override IEnumerator InitScroll(
    Quest00217Scroll.Parameter param,
    DateTime serverTime)
  {
    this.Setup(param, serverTime);
    IEnumerator e = this.SetAndCreate_BannerSprite(param);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public new void Setup(Quest00217Scroll.Parameter param, DateTime serverTime)
  {
    this.initialized = false;
    this.initData = param;
    this.inside_ = this.gameObject.activeSelf;
    this.rankingEventTerm = CampaignQuest.RankingEventTerm.normal;
    this.SetEndTime(param.eventInfo.end_at);
    this.resetLocalTime(serverTime);
    this.Button.enabled = true;
    bool flag1 = param.isNew;
    bool flag2 = param.isClear;
    bool flag3 = param.isHighlighting;
    if (param.isNotice && param.startTime.HasValue && param.startTime.Value > serverTime)
    {
      flag2 = false;
      flag1 = false;
      flag3 = false;
      this.Button.enabled = false;
      this.SetEndTimeAsStart(param.startTime.Value);
      this.startCountdown(param.startTime.Value - serverTime);
    }
    this.loadEnabledHighlighting = flag3;
    EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => Quest00230Scene.ChangeScene(true, param.eventInfo)));
    this.New.gameObject.SetActive(flag1);
    this.Clear.gameObject.SetActive(flag2);
    if ((UnityEngine.Object) this.Highlighting != (UnityEngine.Object) null)
      this.Highlighting.SetActive(false);
    if (serverTime < param.eventInfo.end_at)
    {
      this.EndTime = param.eventInfo.end_at;
      this.rankingEventTerm = CampaignQuest.RankingEventTerm.normal;
    }
    else if (serverTime < param.eventInfo.final_at)
    {
      this.EndTime = param.eventInfo.final_at;
      this.rankingEventTerm = CampaignQuest.RankingEventTerm.receive;
    }
    this.SetTime(serverTime, this.rankingEventTerm);
    this.initialized = true;
  }

  public new IEnumerator SetAndCreate_BannerSprite()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Quest00217ScrollHunting quest00217ScrollHunting = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E2__current = (object) quest00217ScrollHunting.SetAndCreate_BannerSprite(quest00217ScrollHunting.initData);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator SetAndCreate_BannerSprite(Quest00217Scroll.Parameter param)
  {
    Quest00217ScrollHunting quest00217ScrollHunting = this;
    IEnumerator e = Singleton<NGGameDataManager>.GetInstance().GetWebImage(param.eventInfo.banner_image_url, quest00217ScrollHunting.IdleSprite);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) quest00217ScrollHunting.Highlighting != (UnityEngine.Object) null)
    {
      quest00217ScrollHunting.EffectRenderer.SetTexture("_MaskTex", quest00217ScrollHunting.IdleSprite.mainTexture);
      quest00217ScrollHunting.Highlighting.SetActive(false);
    }
  }

  protected override void updateCountdown(bool immediate)
  {
    if (!this.enabledCountdown)
      return;
    TimeSpan tspan = this.timeGoal - DateTime.Now;
    if (tspan.Ticks <= 0L)
    {
      this.enabledCountdown = false;
      if (!immediate)
        this.duplicateEffectFadeOut(this.gameObject, this.gameObject, 0.5f);
      this.Clear.gameObject.SetActive(this.initData.isClear);
      this.New.gameObject.SetActive(this.initData.isNew);
      if ((UnityEngine.Object) this.Highlighting != (UnityEngine.Object) null)
        this.Highlighting.SetActive(this.initData.isHighlighting);
      this.SetEndTime(this.initData.extra.today_day_end_at);
      this.SetTime(this.nowLocalTime, this.rankingEventTerm);
      if (immediate)
        this.Button.enabled = true;
      else
        this.fadeIn(0.5f);
    }
    else
    {
      if (!(this.lastSeconds != tspan.Seconds | immediate))
        return;
      this.lastSeconds = tspan.Seconds;
      this.updateTime(tspan, immediate ? 0.0f : 0.5f);
    }
  }

  protected override GameObject duplicateEffectFadeOut(
    GameObject parentObj,
    GameObject originalObj,
    float duration)
  {
    GameObject gameObject = NGUITools.AddChild(parentObj, originalObj);
    this.objEffect_ = gameObject;
    gameObject.SetActive(true);
    UnityEngine.Object.Destroy((UnityEngine.Object) gameObject.GetComponent<Quest002171Scroll>());
    gameObject.AddComponent<Quest00217ScrollFadeOut>().init(duration, 100, new EventDelegate((EventDelegate.Callback) (() =>
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.objEffect_);
      this.objEffect_ = (GameObject) null;
    })));
    return gameObject;
  }

  protected override void fadeIn(float duration)
  {
    UIWidget uiWidget = Quest00217ScrollFadeOut.setWidget(this.gameObject, 0);
    if (!((UnityEngine.Object) uiWidget != (UnityEngine.Object) null))
      return;
    uiWidget.alpha = 0.0f;
    this.effect_ = true;
    TweenAlpha ta = TweenAlpha.Begin(this.gameObject, duration, 1f);
    ta.SetOnFinished((EventDelegate.Callback) (() =>
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) ta);
      UnityEngine.Object.Destroy((UnityEngine.Object) uiWidget);
      this.Button.enabled = true;
      this.effect_ = false;
    }));
  }
}
