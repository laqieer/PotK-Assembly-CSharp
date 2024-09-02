// Decompiled with JetBrains decompiler
// Type: TopBackGroundAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
