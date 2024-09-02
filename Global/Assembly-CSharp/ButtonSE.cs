// Decompiled with JetBrains decompiler
// Type: ButtonSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ButtonSE : MonoBehaviour
{
  private NGSoundManager sm;
  private int channel;
  public string SE_name = "SE_1002";

  private void Start() => this.sm = Singleton<NGSoundManager>.GetInstance();

  public void playSound() => this.sm.playSE(this.SE_name);
}
