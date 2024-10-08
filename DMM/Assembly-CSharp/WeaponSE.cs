﻿// Decompiled with JetBrains decompiler
// Type: WeaponSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class WeaponSE : MonoBehaviour
{
  public string SoundEffectName;
  public TrailRenderer Trail;
  public float Delay;
  private bool isPlayed;
  private NGSoundManager sm;

  private void Start()
  {
    if ((Object) this.Trail == (Object) null)
      return;
    this.sm = Singleton<NGSoundManager>.GetInstance();
  }

  private IEnumerator PlaySE(float delaytime)
  {
    if (!((Object) null == (Object) this.sm) && this.SoundEffectName != null && !("" == this.SoundEffectName))
    {
      yield return (object) new WaitForSeconds(delaytime);
      this.sm.playSE(this.SoundEffectName);
    }
  }

  private void Update()
  {
    if (!this.isPlayed && this.Trail.enabled)
    {
      this.StartCoroutine(this.PlaySE(this.Delay));
      this.isPlayed = true;
    }
    if (this.Trail.enabled)
      return;
    this.isPlayed = false;
  }
}
