﻿// Decompiled with JetBrains decompiler
// Type: WeaponSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class WeaponSE : MonoBehaviour
{
  public string SoundEffectName;
  public TrailRenderer Trail;
  public float Delay;
  private bool isPlayed;
  private NGSoundManager sm;

  private void Start()
  {
    if (Object.op_Equality((Object) this.Trail, (Object) null))
      return;
    this.sm = Singleton<NGSoundManager>.GetInstance();
  }

  [DebuggerHidden]
  private IEnumerator PlaySE(float delaytime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WeaponSE.\u003CPlaySE\u003Ec__IteratorA18()
    {
      delaytime = delaytime,
      \u003C\u0024\u003Edelaytime = delaytime,
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.isPlayed && ((Renderer) this.Trail).enabled)
    {
      this.StartCoroutine(this.PlaySE(this.Delay));
      this.isPlayed = true;
    }
    if (((Renderer) this.Trail).enabled)
      return;
    this.isPlayed = false;
  }
}
