// Decompiled with JetBrains decompiler
// Type: ArmorSythesis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ArmorSythesis : MonoBehaviour
{
  public int mRarity;
  public bool result;

  public void OnSE0012()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0012");
    Debug.Log((object) "manager exist");
    Debug.Log((object) "se 0012");
  }

  public void OnRarity()
  {
    this.result = true;
    string empty = string.Empty;
    string clip;
    switch (this.mRarity)
    {
      case 0:
      case 1:
        clip = "SE_0013";
        break;
      case 2:
        clip = "SE_0014";
        break;
      case 3:
        clip = "SE_0015";
        break;
      case 4:
        clip = "SE_0016";
        break;
      default:
        clip = "SE_0017";
        break;
    }
    if (Debug.isDebugBuild)
      Debug.Log((object) ("Play SE: " + clip + " for rarity: " + (object) this.mRarity + ". " + ((Object) ((Component) this).gameObject).name));
    Singleton<NGSoundManager>.GetInstance().playSE(clip);
  }

  public void SetRarity(int rarity) => this.mRarity = rarity;
}
