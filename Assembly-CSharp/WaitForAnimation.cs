// Decompiled with JetBrains decompiler
// Type: WaitForAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WaitForAnimation : CustomYieldInstruction
{
  private Animator animator_;
  private int lastStateHash_;
  private int layerNo_;
  private float timeout_;
  private float timeCount_;
  private int waitFrameHashset_ = 1;
  private int lastFrame_;

  public WaitForAnimation(Animator animator, int layerNo = 0, float timeout = 0.0f, int waitframeHashset = 1) => this.Init(animator, layerNo, WaitForAnimation.getCheckHash(animator.GetCurrentAnimatorStateInfo(layerNo)), timeout, waitframeHashset);

  private void Init(
    Animator animator,
    int layerNo,
    int hash,
    float timeout,
    int waitFrameHashset)
  {
    this.layerNo_ = layerNo;
    this.animator_ = animator;
    this.lastStateHash_ = hash;
    this.timeout_ = timeout;
    this.timeCount_ = Time.time + timeout;
    this.waitFrameHashset_ = waitFrameHashset;
    this.lastFrame_ = Time.frameCount;
  }

  private static int getCheckHash(AnimatorStateInfo info) => info.fullPathHash;

  public override bool keepWaiting
  {
    get
    {
      AnimatorStateInfo animatorStateInfo = this.animator_.GetCurrentAnimatorStateInfo(this.layerNo_);
      if (this.waitFrameHashset_ > 0)
      {
        if (this.lastFrame_ == Time.frameCount)
          return true;
        this.lastFrame_ = Time.frameCount;
        if (--this.waitFrameHashset_ > 0)
          return true;
        this.lastStateHash_ = WaitForAnimation.getCheckHash(animatorStateInfo);
      }
      return ((double) this.timeout_ > 0.0 ? ((double) this.timeCount_ > (double) Time.time ? 1 : 0) : 1) != 0 && WaitForAnimation.getCheckHash(animatorStateInfo) == this.lastStateHash_ && (double) animatorStateInfo.normalizedTime < 1.0;
    }
  }
}
