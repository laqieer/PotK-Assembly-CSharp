// Decompiled with JetBrains decompiler
// Type: TopLogoAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TopLogoAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator backGroundAnim;
  [SerializeField]
  private Animator btnAnim;
  private System.Action finishCallback;

  public void Init()
  {
  }

  public void Finish(System.Action finishCallback_) => this.finishCallback = finishCallback_;

  public void Fade()
  {
  }

  public void SceneChange()
  {
  }
}
