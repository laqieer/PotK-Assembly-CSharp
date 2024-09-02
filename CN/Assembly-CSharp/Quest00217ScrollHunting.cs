// Decompiled with JetBrains decompiler
// Type: Quest00217ScrollHunting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00217ScrollHunting : Quest00217Scroll
{
  [DebuggerHidden]
  public override IEnumerator InitScroll(Quest00217Scroll.Parameter param, DateTime serverTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217ScrollHunting.\u003CInitScroll\u003Ec__Iterator1EB()
    {
      param = param,
      serverTime = serverTime,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u003Ef__this = this
    };
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

  protected override GameObject duplicateEffectFadeOut(
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

  protected override void fadeIn(float duration)
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
}
