// Decompiled with JetBrains decompiler
// Type: PrincessSynthesisSoundEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PrincessSynthesisSoundEffect : MonoBehaviour
{
  private int resultSuccess;
  public bool result;

  public void OnStartPrincessSynthesis()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0002");
  }

  public void setResult(int rarity) => this.resultSuccess = rarity;

  public void OnPlayResult()
  {
    this.result = true;
    switch (this.resultSuccess)
    {
      case 1:
        this.OnSuccess();
        break;
      case 2:
        this.OnGreatSuccess();
        break;
      case 3:
        this.OnFailuer();
        break;
      default:
        this.OnGreatSuccess();
        break;
    }
  }

  private void OnSuccess() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0003");

  private void OnGreatSuccess() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0004");

  private void OnFailuer() => Singleton<NGSoundManager>.GetInstance().playSE("SE_0005");
}
