// Decompiled with JetBrains decompiler
// Type: TweenRotation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Tween/Tween Rotation")]
public class TweenRotation : UITweener
{
  public Vector3 from;
  public Vector3 to;
  private Transform mTrans;

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
  public Quaternion rotation
  {
    get => this.value;
    set => this.value = value;
  }

  public Quaternion value
  {
    get => this.cachedTransform.localRotation;
    set => this.cachedTransform.localRotation = value;
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = Quaternion.Euler(new Vector3(Mathf.Lerp(this.from.x, this.to.x, factor), Mathf.Lerp(this.from.y, this.to.y, factor), Mathf.Lerp(this.from.z, this.to.z, factor)));
  }

  public static TweenRotation Begin(GameObject go, float duration, Quaternion rot)
  {
    TweenRotation tweenRotation1 = UITweener.Begin<TweenRotation>(go, duration);
    TweenRotation tweenRotation2 = tweenRotation1;
    Quaternion quaternion = tweenRotation1.value;
    Vector3 eulerAngles = ((Quaternion) ref quaternion).eulerAngles;
    tweenRotation2.from = eulerAngles;
    tweenRotation1.to = ((Quaternion) ref rot).eulerAngles;
    if ((double) duration <= 0.0)
    {
      tweenRotation1.Sample(1f, true);
      ((Behaviour) tweenRotation1).enabled = false;
    }
    return tweenRotation1;
  }

  [ContextMenu("Set 'From' to current value")]
  public override void SetStartToCurrentValue()
  {
    Quaternion quaternion = this.value;
    this.from = ((Quaternion) ref quaternion).eulerAngles;
  }

  [ContextMenu("Set 'To' to current value")]
  public override void SetEndToCurrentValue()
  {
    Quaternion quaternion = this.value;
    this.to = ((Quaternion) ref quaternion).eulerAngles;
  }

  [ContextMenu("Assume value of 'From'")]
  private void SetCurrentValueToStart() => this.value = Quaternion.Euler(this.from);

  [ContextMenu("Assume value of 'To'")]
  private void SetCurrentValueToEnd() => this.value = Quaternion.Euler(this.to);
}
