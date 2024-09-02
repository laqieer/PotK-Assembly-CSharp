// Decompiled with JetBrains decompiler
// Type: TweenAlpha
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
  [Range(0.0f, 1f)]
  public float from = 1f;
  [Range(0.0f, 1f)]
  public float to = 1f;
  private UIRect mRect;

  public UIRect cachedRect
  {
    get
    {
      if (Object.op_Equality((Object) this.mRect, (Object) null))
      {
        this.mRect = ((Component) this).GetComponent<UIRect>();
        if (Object.op_Equality((Object) this.mRect, (Object) null))
          this.mRect = ((Component) this).GetComponentInChildren<UIRect>();
      }
      return this.mRect;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float alpha
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get => this.cachedRect.alpha;
    set => this.cachedRect.alpha = value;
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = Mathf.Lerp(this.from, this.to, factor);
  }

  public static TweenAlpha Begin(GameObject go, float duration, float alpha)
  {
    TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration);
    tweenAlpha.from = tweenAlpha.value;
    tweenAlpha.to = alpha;
    if ((double) duration <= 0.0)
    {
      tweenAlpha.Sample(1f, true);
      ((Behaviour) tweenAlpha).enabled = false;
    }
    return tweenAlpha;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
