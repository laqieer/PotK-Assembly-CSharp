﻿// Decompiled with JetBrains decompiler
// Type: PrincessJobChangeSoundEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PrincessJobChangeSoundEffect : PrincessEvolutionSoundEffect
{
  public string voiceFile { get; set; }

  public string selectorLabel { get; set; }

  public string voiceCompleted { get; set; }

  public void VoiceCompleted()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if ((Object) instance == (Object) null || string.IsNullOrEmpty(this.voiceFile) || string.IsNullOrEmpty(this.voiceCompleted))
      return;
    instance.playVoiceByStringID(this.voiceFile, this.voiceCompleted, selectorLabel: this.selectorLabel);
  }
}
