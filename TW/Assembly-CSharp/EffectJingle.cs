// Decompiled with JetBrains decompiler
// Type: EffectJingle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EffectJingle : MonoBehaviour
{
  public string bgm;
  private string oldBgm;

  private void Start()
  {
    this.oldBgm = Singleton<NGSoundManager>.GetInstance().GetBgmName();
    Singleton<NGSoundManager>.GetInstance().PlayBgm(this.bgm, fadeInTime: 1f, fadeOutTime: 0.3f);
  }

  private void Update()
  {
    if (Singleton<NGSoundManager>.GetInstance().IsBgmPlaying(0))
      return;
    Singleton<NGSoundManager>.GetInstance().PlayBgm(this.oldBgm);
  }
}
