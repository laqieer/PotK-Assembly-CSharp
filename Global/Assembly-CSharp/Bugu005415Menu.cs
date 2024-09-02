// Decompiled with JetBrains decompiler
// Type: Bugu005415Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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

  [DebuggerHidden]
  private IEnumerator SkipCurrentAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005415Menu.\u003CSkipCurrentAnimation\u003Ec__Iterator330()
    {
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
    return (IEnumerator) new Bugu005415Menu.\u003CSetEffectData\u003Ec__Iterator331()
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
    return (IEnumerator) new Bugu005415Menu.\u003CSetEffectData\u003Ec__Iterator332()
    {
      thum_list = thum_list,
      result_list = result_list,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u003Ef__this = this
    };
  }
}
