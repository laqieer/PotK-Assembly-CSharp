// Decompiled with JetBrains decompiler
// Type: ButtonCloseSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ButtonCloseSE : MonoBehaviour
{
  public void playSound()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1004");
    Debug.Log((object) "ButtonCloseSE playSound");
  }
}
