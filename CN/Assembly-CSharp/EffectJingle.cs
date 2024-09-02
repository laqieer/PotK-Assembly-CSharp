// Decompiled with JetBrains decompiler
// Type: EffectJingle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
