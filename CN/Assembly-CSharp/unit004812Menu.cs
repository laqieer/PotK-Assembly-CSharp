// Decompiled with JetBrains decompiler
// Type: unit004812Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class unit004812Menu : BackButtonMenuBase
{
  public unit004812Scene scene;
  public EffectControllerPrincessSynthesis effect;
  private PlayerUnit basePlayerUnit_;
  private PlayerUnit resultPlayerUnit_;
  private List<int> otherData;
  public Dictionary<string, object> showPopupData;
  [SerializeField]
  private GameObject backButton_;
  private bool m_bIsBeginAnimation;
  public Touch2NextAuto touchScript;

  public Unit00468Scene.Mode mode { get; set; }

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator328()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    if (!this.m_bIsBeginAnimation || !Object.op_Implicit((Object) this.effect) || this.effect.isAnimation || this.touchScript.touch2Next.activeSelf)
      return;
    this.touchScript.touch2Next.SetActive(true);
    this.m_bIsBeginAnimation = false;
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerUnit> num_list,
    List<PlayerUnit> result_list,
    List<int> other_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new unit004812Menu.\u003CSetEffectData\u003Ec__Iterator329()
    {
      result_list = result_list,
      other_list = other_list,
      num_list = num_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u0024\u003Enum_list = num_list,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.effect.isAnimation)
    {
      this.StartCoroutine(this.SkipCurrentAnimation());
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().stopSE();
      Unit004813Scene.changeScene(false, this.basePlayerUnit_, this.resultPlayerUnit_, this.otherData, this.showPopupData, this.mode);
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
  }
}
