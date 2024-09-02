// Decompiled with JetBrains decompiler
// Type: RepairSoundEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RepairSoundEffect : MonoBehaviour
{
  public bool mLost = true;
  public EffectController ef;
  public bool result;

  public void OnAnimationEnd() => this.ef.OnAnimationEnd();

  public void OnSE0018() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0018");

  public void OnSE0019()
  {
    if (!this.mLost)
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0019");
  }

  public void OnSE0020()
  {
    this.result = true;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0020");
  }

  public void SetLost(bool lost) => this.mLost = lost;
}
