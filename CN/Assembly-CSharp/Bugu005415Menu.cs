// Decompiled with JetBrains decompiler
// Type: Bugu005415Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005415Menu : BackButtonMenuBase
{
  public Bugu005415Scene scene;
  public EffectControllerArmorRepair effect;
  [SerializeField]
  private GameObject back_button_;
  [SerializeField]
  private bool m_bIsBeginAnimation;
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator3A8()
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

  public virtual void IbtnBack()
  {
    if (this.effect.isAnimation)
    {
      this.StartCoroutine(this.SkipCurrentAnimation());
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().stopSE();
      this.backScene();
    }
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartcomposite()
  {
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerItem> thum_list,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Menu.\u003CSetEffectData\u003Ec__Iterator3A9()
    {
      thum_list = thum_list,
      result_list = result_list,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetEffectData(
    List<PlayerItem> thum_list,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Menu.\u003CSetEffectData\u003Ec__Iterator3AA()
    {
      thum_list = thum_list,
      result_list = result_list,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u003Ef__this = this
    };
  }
}
