// Decompiled with JetBrains decompiler
// Type: TweenPosition
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
  public Vector3 from;
  public Vector3 to;
  [HideInInspector]
  public bool worldSpace;
  private Transform mTrans;
  private UIRect mRect;

  public Transform cachedTransform
  {
    get
    {
      if (Object.op_Equality((Object) this.mTrans, (Object) null))
        this.mTrans = ((Component) this).transform;
      return this.mTrans;
    }
  }

  [Obsolete("Use 'value' instead")]
  public Vector3 position
  {
    get => this.value;
    set => this.value = value;
  }

  public Vector3 value
  {
    get => this.worldSpace ? this.cachedTransform.position : this.cachedTransform.localPosition;
    set
    {
      if (Object.op_Equality((Object) this.mRect, (Object) null) || !this.mRect.isAnchored || this.worldSpace)
      {
        if (this.worldSpace)
          this.cachedTransform.position = value;
        else
          this.cachedTransform.localPosition = value;
      }
      else
      {
        value = Vector3.op_Subtraction(value, this.cachedTransform.localPosition);
        NGUIMath.MoveRect(this.mRect, value.x, value.y);
      }
    }
  }

  private void Awake() => this.mRect = ((Component) this).GetComponent<UIRect>();

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = Vector3.op_Addition(Vector3.op_Multiply(this.from, 1f - factor), Vector3.op_Multiply(this.to, factor));
  }

  public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
  {
    TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
    tweenPosition.from = tweenPosition.value;
    tweenPosition.to = pos;
    if ((double) duration <= 0.0)
    {
      tweenPosition.Sample(1f, true);
      ((Behaviour) tweenPosition).enabled = false;
    }
    return tweenPosition;
  }

  [ContextMenu("Set 'From' to current value")]
  public override void SetStartToCurrentValue() => this.from = this.value;

  [ContextMenu("Set 'To' to current value")]
  public override void SetEndToCurrentValue() => this.to = this.value;

  [ContextMenu("Assume value of 'From'")]
  private void SetCurrentValueToStart() => this.value = this.from;

  [ContextMenu("Assume value of 'To'")]
  private void SetCurrentValueToEnd() => this.value = this.to;
}
