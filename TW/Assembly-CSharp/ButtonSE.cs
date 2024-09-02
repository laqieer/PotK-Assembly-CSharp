// Decompiled with JetBrains decompiler
// Type: ButtonSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ButtonSE : MonoBehaviour
{
  private NGSoundManager sm;
  private int channel;
  public string SE_name = "SE_1002";

  private void Start() => this.sm = Singleton<NGSoundManager>.GetInstance();

  public void playSound()
  {
    this.sm.playSE(this.SE_name);
    Debug.Log((object) "[CRI] ButtonSE playSound");
  }
}
