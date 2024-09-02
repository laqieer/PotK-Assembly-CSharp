﻿// Decompiled with JetBrains decompiler
// Type: GachaSEAfterUser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GachaSEAfterUser : MonoBehaviour
{
  private int resultRarity;
  private int tundereRank;
  public bool result;

  public void OnUserActionEnd()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    switch (this.tundereRank)
    {
      case 0:
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0501");
        break;
      case 1:
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0513");
        break;
      case 2:
        Singleton<NGSoundManager>.GetInstance().playSE("SE_0514");
        break;
    }
  }

  public void OnUserActionEnd10()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0515");
  }

  public void setTundere(int rank) => this.tundereRank = rank;

  public void setResult(int rarity) => this.resultRarity = rarity;

  public void OnPlayResult()
  {
    this.result = true;
    switch (this.resultRarity)
    {
      case 0:
        this.OnReality1();
        break;
      case 1:
        this.OnReality2();
        break;
      case 2:
        this.OnReality3();
        break;
      case 3:
        this.OnReality4();
        break;
      case 4:
        this.OnReality5();
        break;
      case 6:
        this.On10Ren();
        break;
      default:
        this.OnReality5();
        break;
    }
  }

  private void OnReality1()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0502");
  }

  private void OnReality2()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0503");
  }

  private void OnReality3()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0504");
  }

  private void OnReality4()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0505");
  }

  private void OnReality5()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0506");
  }

  private void On10Ren()
  {
    if (Object.op_Equality((Object) Singleton<NGSoundManager>.GetInstanceOrNull(), (Object) null))
      return;
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0507");
  }
}
