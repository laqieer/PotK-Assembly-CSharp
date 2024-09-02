// Decompiled with JetBrains decompiler
// Type: PrincessEvolutionSoundEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PrincessEvolutionSoundEffect : MonoBehaviour
{
  private int resultRarity;
  public bool result;

  public void OnStartPrincessEvolution()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0006");
  }

  public void setResult(int rarity) => this.resultRarity = rarity;

  public void OnPlayResult()
  {
    this.result = true;
    switch (this.resultRarity)
    {
      case 1:
        this.OnReality1();
        break;
      case 2:
        this.OnReality2();
        break;
      case 3:
        this.OnReality3();
        break;
      case 4:
        this.OnReality4();
        break;
      case 5:
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

  private void OnReality1() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0007");

  private void OnReality2() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0008");

  private void OnReality3() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0009");

  private void OnReality4() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0010");

  private void OnReality5() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0011");

  private void On10Ren() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0011");
}
