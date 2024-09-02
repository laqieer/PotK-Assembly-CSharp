// Decompiled with JetBrains decompiler
// Type: MypageCloudAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MypageCloudAnim : MonoBehaviour
{
  public static readonly string HeavenOut = nameof (HeavenOut);
  public static readonly string HeavenIn = nameof (HeavenIn);
  public static readonly string EarthOut = nameof (EarthOut);
  public static readonly string EarthIn = nameof (EarthIn);
  [SerializeField]
  private Animator animator;
  private string StartEffectName = string.Empty;
  private string EndEffectName = string.Empty;
  private System.Action WaitAction;
  private System.Action ReelAction;

  public void Init(string startName, string endName, System.Action waitAction)
  {
    this.StartEffectName = startName;
    this.EndEffectName = endName;
    this.WaitAction = waitAction;
  }

  public void Start()
  {
    this.animator.SetInteger(this.StartEffectName, 1);
    this.animator.SetInteger(this.EndEffectName, 0);
    Animator animator = this.animator;
    AnimatorStateInfo animatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
    int fullPathHash = ((AnimatorStateInfo) ref animatorStateInfo).fullPathHash;
    animator.Play(fullPathHash, 0, 0.0f);
  }

  public void End(System.Action reelAnmAction)
  {
    this.ReelAction = reelAnmAction;
    this.animator.SetInteger(this.StartEffectName, 0);
    this.animator.SetInteger(this.EndEffectName, 1);
  }

  private void WaitStart()
  {
    if (this.WaitAction == null)
      return;
    this.WaitAction();
  }

  private void EndAnimation() => Singleton<CommonRoot>.GetInstance().DisableCloudAnim();

  private void StartReelTweenAnim()
  {
    if (this.ReelAction == null)
      return;
    this.ReelAction();
  }
}
