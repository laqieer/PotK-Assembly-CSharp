// Decompiled with JetBrains decompiler
// Type: TopLogoAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
