// Decompiled with JetBrains decompiler
// Type: TweenVolume
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Tween/Tween Volume")]
[RequireComponent(typeof (AudioSource))]
public class TweenVolume : UITweener
{
  [Range(0.0f, 1f)]
  public float from = 1f;
  [Range(0.0f, 1f)]
  public float to = 1f;
  private AudioSource mSource;

  public AudioSource audioSource
  {
    get
    {
      if (Object.op_Equality((Object) this.mSource, (Object) null))
      {
        this.mSource = ((Component) this).GetComponent<AudioSource>();
        if (Object.op_Equality((Object) this.mSource, (Object) null))
        {
          this.mSource = ((Component) this).GetComponent<AudioSource>();
          if (Object.op_Equality((Object) this.mSource, (Object) null))
          {
            Debug.LogError((object) "TweenVolume needs an AudioSource to work with", (Object) this);
            ((Behaviour) this).enabled = false;
          }
        }
      }
      return this.mSource;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float volume
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get
    {
      return Object.op_Inequality((Object) this.audioSource, (Object) null) ? this.mSource.volume : 0.0f;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.audioSource, (Object) null))
        return;
      this.mSource.volume = value;
    }
  }

  protected override void OnUpdate(float factor, bool isFinished)
  {
    this.value = (float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor);
    ((Behaviour) this.mSource).enabled = (double) this.mSource.volume > 0.0099999997764825821;
  }

  public static TweenVolume Begin(GameObject go, float duration, float targetVolume)
  {
    TweenVolume tweenVolume = UITweener.Begin<TweenVolume>(go, duration);
    tweenVolume.from = tweenVolume.value;
    tweenVolume.to = targetVolume;
    return tweenVolume;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
