﻿// Decompiled with JetBrains decompiler
// Type: EffectSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectSE : MonoBehaviour
{
  public string SoundEffectName;
  public bool playOnStart = true;
  public bool playOnEnable;
  public float Delay;
  private NGSoundManager sm;

  private void Start()
  {
    this.sm = Singleton<NGSoundManager>.GetInstance();
    if (!this.playOnStart && !this.playOnEnable)
      return;
    this.StartCoroutine(this.PlaySE(this.Delay));
  }

  private void OnEnable()
  {
    if (this.playOnStart || !this.playOnEnable)
      return;
    this.StartCoroutine(this.PlaySE(this.Delay));
  }

  public void playSe()
  {
    this.sm = Singleton<NGSoundManager>.GetInstance();
    if (this.playOnStart)
      return;
    this.StartCoroutine(this.PlaySE(this.Delay));
  }

  [DebuggerHidden]
  public IEnumerator PlaySE(float delayTime = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectSE.\u003CPlaySE\u003Ec__Iterator9FA()
    {
      delayTime = delayTime,
      \u003C\u0024\u003EdelayTime = delayTime,
      \u003C\u003Ef__this = this
    };
  }
}
