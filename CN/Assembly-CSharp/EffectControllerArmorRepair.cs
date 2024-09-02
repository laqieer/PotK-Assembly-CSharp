// Decompiled with JetBrains decompiler
// Type: EffectControllerArmorRepair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerArmorRepair : EffectController
{
  [SerializeField]
  private GameObject animation_root_;
  [SerializeField]
  private List<RepairObjectController> animationObject;
  public RepairSoundEffect sound_effect_;
  private GameObject AnimationItemIconPrefab;
  private int useList;

  public void EndSE() => this.sound_effect_.OnSE0020();

  public void EndEffect()
  {
    for (int index = 0; index < this.animationObject[this.useList].animationObject.Count; ++index)
      this.animationObject[this.useList].animationObject[index].SkipEffect();
  }

  [DebuggerHidden]
  public IEnumerator initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerArmorRepair.\u003Cinitialize\u003Ec__Iterator8F2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Set(
    List<PlayerItem> thum_list,
    GameObject back_button,
    List<WebAPI.Response.ItemGearRepairRepair_results> result_list = null,
    List<WebAPI.Response.ItemGearPoweredRepairRepair_results> result_list_powered = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerArmorRepair.\u003CSet\u003Ec__Iterator8F3()
    {
      thum_list = thum_list,
      result_list = result_list,
      back_button = back_button,
      result_list_powered = result_list_powered,
      \u003C\u0024\u003Ethum_list = thum_list,
      \u003C\u0024\u003Eresult_list = result_list,
      \u003C\u0024\u003Eback_button = back_button,
      \u003C\u0024\u003Eresult_list_powered = result_list_powered,
      \u003C\u003Ef__this = this
    };
  }
}
