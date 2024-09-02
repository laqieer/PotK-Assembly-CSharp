// Decompiled with JetBrains decompiler
// Type: TweenFOV
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Tween/Tween Field of View")]
[RequireComponent(typeof (Camera))]
public class TweenFOV : UITweener
{
  public float from = 45f;
  public float to = 45f;
  private Camera mCam;

  public Camera cachedCamera
  {
    get
    {
      if (Object.op_Equality((Object) this.mCam, (Object) null))
        this.mCam = ((Component) this).GetComponent<Camera>();
      return this.mCam;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float fov
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get => this.cachedCamera.fieldOfView;
    set => this.cachedCamera.fieldOfView = value;
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = (float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor);
  }

  public static TweenFOV Begin(GameObject go, float duration, float to)
  {
    TweenFOV tweenFov = UITweener.Begin<TweenFOV>(go, duration);
    tweenFov.from = tweenFov.value;
    tweenFov.to = to;
    if ((double) duration <= 0.0)
    {
      tweenFov.Sample(1f, true);
      ((Behaviour) tweenFov).enabled = false;
    }
    return tweenFov;
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
