// Decompiled with JetBrains decompiler
// Type: ArmorRepair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ArmorRepair : MonoBehaviour
{
  public bool mLost = true;

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

  public void SetLost(bool lost) => this.mLost = lost;
}
