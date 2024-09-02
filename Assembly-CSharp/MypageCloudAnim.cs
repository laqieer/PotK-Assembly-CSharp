// Decompiled with JetBrains decompiler
// Type: MypageCloudAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
  private bool _real_action_enabled;

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
    this.animator.Play(this.animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0.0f);
    this._real_action_enabled = true;
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
    this._real_action_enabled = false;
  }

  public bool getReelTweenActionEnabled() => this._real_action_enabled;
}
