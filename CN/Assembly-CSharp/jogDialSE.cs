// Decompiled with JetBrains decompiler
// Type: jogDialSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class jogDialSE : MonoBehaviour
{
  private NGSoundManager sm;

  private void Start() => this.sm = Singleton<NGSoundManager>.GetInstance();

  private void Update()
  {
  }

  public void playSE() => this.sm.playSE("SE_1029");
}
