// Decompiled with JetBrains decompiler
// Type: Startup00014ClipEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Startup00014ClipEffect : MonoBehaviour
{
  public Startup00014MakeupMonthly Parent;

  public void PlaySe(string seName)
  {
    if (!((Object) this.Parent != (Object) null) || !this.Parent.isStartupScene)
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (!((Object) instance != (Object) null))
      return;
    instance.PlaySe(seName);
  }

  public void EndScene() => this.Parent.EndScene();

  public void StepLock(int isLock)
  {
    if (!((Object) this.Parent != (Object) null) || !this.Parent.isStartupScene)
      return;
    this.Parent.StepLock = isLock == 1;
  }

  public void Stamp()
  {
    if (!((Object) this.Parent != (Object) null) || !this.Parent.isStartupScene)
      return;
    this.Parent.Stamp();
  }
}
