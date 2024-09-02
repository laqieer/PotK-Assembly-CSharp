// Decompiled with JetBrains decompiler
// Type: jogDialSE
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class jogDialSE : MonoBehaviour
{
  private NGSoundManager sm;

  private void Start() => this.sm = Singleton<NGSoundManager>.GetInstance();

  private void Update()
  {
  }

  public void playSE() => this.sm.playSE("SE_1029");
}
