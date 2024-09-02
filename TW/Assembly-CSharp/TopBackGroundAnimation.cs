// Decompiled with JetBrains decompiler
// Type: TopBackGroundAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TopBackGroundAnimation : MonoBehaviour
{
  [SerializeField]
  private Animator anim;
  private System.Action finishCallback;

  public void Init() => this.anim.Play("TOP_prohectZERO_Title");

  public void StartFinishAnim(System.Action finishCallback_)
  {
    this.finishCallback = finishCallback_;
    this.anim.StopPlayback();
    this.anim.SetInteger("Start_Fade_anim", 1);
  }

  public void Finish()
  {
    if (this.finishCallback == null)
      return;
    this.finishCallback();
  }
}
