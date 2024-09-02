// Decompiled with JetBrains decompiler
// Type: TopLogoAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  public bool IsPlaying()
  {
    AnimatorStateInfo animatorStateInfo = this.backGroundAnim.GetCurrentAnimatorStateInfo(0);
    return (double) ((AnimatorStateInfo) ref animatorStateInfo).normalizedTime < 1.0;
  }

  public void Finish(System.Action finishCallback_) => this.finishCallback = finishCallback_;

  public void Fade()
  {
  }

  public void SceneChange()
  {
    if (this.finishCallback == null)
      return;
    this.finishCallback();
  }
}
