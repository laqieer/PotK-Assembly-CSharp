// Decompiled with JetBrains decompiler
// Type: RepairSoundEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RepairSoundEffect : MonoBehaviour
{
  public bool mLost = true;
  public EffectController ef;
  public bool result;

  public void OnAnimationEnd() => this.ef.OnAnimationEnd();

  public void OnSE0018()
  {
    Debug.Log((object) "OnSE0018()");
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0018");
  }

  public void OnSE0019()
  {
    Debug.Log((object) "OnSE0019()");
    if (!this.mLost)
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0019");
  }

  public void OnSE0020()
  {
    this.result = true;
    Debug.Log((object) "OnSE0020()");
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0020");
  }

  public void SetLost(bool lost) => this.mLost = lost;
}
