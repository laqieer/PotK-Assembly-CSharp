// Decompiled with JetBrains decompiler
// Type: ButtonSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
