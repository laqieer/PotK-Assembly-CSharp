﻿// Decompiled with JetBrains decompiler
// Type: TitleSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleSoundEvent : MonoBehaviour
{
  public void playSE(string cue_name)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!((Object) instance != (Object) null))
      return;
    instance.PlaySe(cue_name);
  }
}
