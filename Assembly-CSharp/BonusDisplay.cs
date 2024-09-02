// Decompiled with JetBrains decompiler
// Type: BonusDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections.Generic;
using UnityEngine;

public class BonusDisplay
{
  private Bonus[] bonus;
  private int index;
  private bool isBirthDay;
  private bool isPvp;
  private UILabel titleLabel;
  private UILabel limitLabel;

  public void Set(Bonus[] bonus, UILabel title, UILabel limit, bool isBirthDay = true, bool isPvp = false)
  {
    this.index = 0;
    this.bonus = bonus;
    this.titleLabel = title;
    this.limitLabel = limit;
    this.isBirthDay = isBirthDay;
    this.isPvp = isPvp;
    if ((UnityEngine.Object) this.titleLabel != (UnityEngine.Object) null)
    {
      this.titleLabel.gameObject.AddComponent<TweenAlpha>();
      this.titleLabel.gameObject.AddComponent<TweenAlpha>();
      this.SetTween(this.titleLabel.gameObject, true);
    }
    if ((UnityEngine.Object) this.limitLabel != (UnityEngine.Object) null)
    {
      this.limitLabel.gameObject.AddComponent<TweenAlpha>();
      this.limitLabel.gameObject.AddComponent<TweenAlpha>();
      this.SetTween(this.limitLabel.gameObject);
    }
    this.SetInfo();
    this.Start();
  }

  private void SetInfo()
  {
    if (this.bonus.Length == 0 || this.bonus == null)
      return;
    if ((UnityEngine.Object) this.titleLabel != (UnityEngine.Object) null)
      this.titleLabel.SetTextLocalize(this.bonus[this.index].DisplayName(this.isPvp));
    if (!((UnityEngine.Object) this.limitLabel != (UnityEngine.Object) null))
      return;
    this.limitLabel.SetTextLocalize(this.bonus[this.index].RemainingTime());
  }

  private void SetTween(GameObject go, bool setCallback = false)
  {
    TweenAlpha[] components = go.GetComponents<TweenAlpha>();
    this.SetStartTween(components[0], setCallback);
    this.SetEndTween(components[1], setCallback);
  }

  private void SetStartTween(TweenAlpha tween, bool setCallback)
  {
    tween.from = 0.0f;
    tween.to = 1f;
    tween.duration = 1f;
    tween.tweenGroup = 0;
    if (!setCallback)
      return;
    tween.SetOnFinished((EventDelegate.Callback) (() => this.End()));
  }

  private void SetEndTween(TweenAlpha tween, bool setCallback)
  {
    tween.from = 1f;
    tween.to = 0.0f;
    tween.delay = 7f;
    tween.duration = 1f;
    tween.tweenGroup = 1;
    if (!setCallback)
      return;
    tween.SetOnFinished((EventDelegate.Callback) (() => this.Change()));
  }

  private void Start()
  {
    if ((UnityEngine.Object) this.titleLabel != (UnityEngine.Object) null)
      ((IEnumerable<TweenAlpha>) this.titleLabel.gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((System.Action<TweenAlpha>) (x =>
      {
        if (x.tweenGroup != 0)
          return;
        x.ResetToBeginning();
        x.PlayForward();
      }));
    if (!((UnityEngine.Object) this.limitLabel != (UnityEngine.Object) null))
      return;
    ((IEnumerable<TweenAlpha>) this.limitLabel.gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((System.Action<TweenAlpha>) (x =>
    {
      if (x.tweenGroup != 0)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  private void End()
  {
    if ((UnityEngine.Object) this.titleLabel != (UnityEngine.Object) null)
      ((IEnumerable<TweenAlpha>) this.titleLabel.gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((System.Action<TweenAlpha>) (x =>
      {
        if (x.tweenGroup != 1)
          return;
        x.ResetToBeginning();
        x.PlayForward();
      }));
    if (!((UnityEngine.Object) this.limitLabel != (UnityEngine.Object) null))
      return;
    ((IEnumerable<TweenAlpha>) this.limitLabel.gameObject.GetComponents<TweenAlpha>()).ForEach<TweenAlpha>((System.Action<TweenAlpha>) (x =>
    {
      if (x.tweenGroup != 1)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  private void Change()
  {
    this.index = this.index + 1 >= this.bonus.Length ? 0 : this.index + 1;
    if (!this.isBirthDay && this.bonus[this.index].category == 12)
      this.index = this.index + 1 >= this.bonus.Length ? 0 : this.index + 1;
    this.SetInfo();
    this.Start();
  }
}
