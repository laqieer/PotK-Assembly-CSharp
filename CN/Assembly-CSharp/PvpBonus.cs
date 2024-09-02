﻿// Decompiled with JetBrains decompiler
// Type: PvpBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PvpBonus
{
  private Bonus[] bonus;
  private int index;
  private bool isBirthDay;
  private UILabel titleLabel;
  private UILabel limitLabel;

  public void Set(Bonus[] bonus, UILabel title, UILabel limit, bool isBirthDay = true)
  {
    this.index = 0;
    this.bonus = bonus;
    this.titleLabel = title;
    this.limitLabel = limit;
    this.isBirthDay = isBirthDay;
    if (Object.op_Inequality((Object) this.titleLabel, (Object) null))
    {
      ((Component) this.titleLabel).gameObject.AddComponent<TweenAlpha>();
      ((Component) this.titleLabel).gameObject.AddComponent<TweenAlpha>();
      this.SetTween(((Component) this.titleLabel).gameObject);
    }
    if (Object.op_Inequality((Object) this.limitLabel, (Object) null))
    {
      ((Component) this.limitLabel).gameObject.AddComponent<TweenAlpha>();
      ((Component) this.limitLabel).gameObject.AddComponent<TweenAlpha>();
      this.SetTween(((Component) this.limitLabel).gameObject);
    }
    this.SetInfo();
    this.Start();
  }

  private void SetInfo()
  {
    if (this.bonus.Length == 0 || this.bonus == null)
      return;
    if (Object.op_Inequality((Object) this.titleLabel, (Object) null))
      this.titleLabel.text = this.bonus[this.index].DisplayName(true);
    if (!Object.op_Inequality((Object) this.limitLabel, (Object) null))
      return;
    this.limitLabel.text = this.bonus[this.index].RemainingTime();
  }

  private void SetTween(GameObject go)
  {
    TweenAlpha[] components = go.GetComponents<TweenAlpha>();
    this.SetStartTween(components[0]);
    this.SetEndTween(components[1]);
  }

  private void SetStartTween(TweenAlpha tween)
  {
    tween.from = 0.0f;
    tween.to = 1f;
    tween.duration = 1f;
    tween.tweenGroup = 0;
    tween.SetOnFinished((EventDelegate.Callback) (() => this.End()));
  }

  private void SetEndTween(TweenAlpha tween)
  {
    tween.from = 1f;
    tween.to = 0.0f;
    tween.delay = 7f;
    tween.duration = 1f;
    tween.tweenGroup = 1;
    tween.SetOnFinished((EventDelegate.Callback) (() => this.Change()));
  }

  private void Start()
  {
    if (Object.op_Inequality((Object) this.titleLabel, (Object) null))
      ((IEnumerable<TweenAlpha>) ((Component) this.titleLabel).gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((Action<TweenAlpha>) (x =>
      {
        if (x.tweenGroup != 0)
          return;
        x.ResetToBeginning();
        x.PlayForward();
      }));
    if (!Object.op_Inequality((Object) this.limitLabel, (Object) null))
      return;
    ((IEnumerable<TweenAlpha>) ((Component) this.limitLabel).gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((Action<TweenAlpha>) (x =>
    {
      if (x.tweenGroup != 0)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  private void End()
  {
    if (Object.op_Inequality((Object) this.titleLabel, (Object) null))
      ((IEnumerable<TweenAlpha>) ((Component) this.titleLabel).gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((Action<TweenAlpha>) (x =>
      {
        if (x.tweenGroup != 1)
          return;
        x.ResetToBeginning();
        x.PlayForward();
      }));
    if (!Object.op_Inequality((Object) this.limitLabel, (Object) null))
      return;
    ((IEnumerable<TweenAlpha>) ((Component) this.limitLabel).gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((Action<TweenAlpha>) (x =>
    {
      if (x.tweenGroup != 1)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  private void Change()
  {
    this.index = this.index + 1 < this.bonus.Length ? this.index + 1 : 0;
    if (!this.isBirthDay && this.bonus[this.index].category == 12)
      this.index = this.index + 1 < this.bonus.Length ? this.index + 1 : 0;
    this.SetInfo();
    this.Start();
  }
}
