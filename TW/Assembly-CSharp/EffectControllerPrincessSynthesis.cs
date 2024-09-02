﻿// Decompiled with JetBrains decompiler
// Type: EffectControllerPrincessSynthesis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerPrincessSynthesis : EffectController
{
  [SerializeField]
  private List<GameObject> thumList_;
  [SerializeField]
  private List<MeshRenderer> meshList_;
  [SerializeField]
  private List<MeshRenderer> meshMaleList_;
  [SerializeField]
  private GameObject animation_root_;
  [SerializeField]
  private List<MeshRenderer> synthesis_list_;
  [SerializeField]
  private List<GameObject> success_list_;
  public PrincessSynthesisSoundEffect sound_manager_;

  public void EndSE() => this.sound_manager_.OnPlayResult();

  [DebuggerHidden]
  private IEnumerator initialize(
    List<PlayerUnit> unit_list,
    List<PlayerUnit> result_unit,
    List<int> other_list)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerPrincessSynthesis.\u003Cinitialize\u003Ec__Iterator9D1()
    {
      unit_list = unit_list,
      result_unit = result_unit,
      other_list = other_list,
      \u003C\u0024\u003Eunit_list = unit_list,
      \u003C\u0024\u003Eresult_unit = result_unit,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Set(
    List<PlayerUnit> unit_list,
    List<PlayerUnit> result_unit,
    List<int> other_list,
    GameObject back_button)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerPrincessSynthesis.\u003CSet\u003Ec__Iterator9D2()
    {
      unit_list = unit_list,
      result_unit = result_unit,
      other_list = other_list,
      back_button = back_button,
      \u003C\u0024\u003Eunit_list = unit_list,
      \u003C\u0024\u003Eresult_unit = result_unit,
      \u003C\u0024\u003Eother_list = other_list,
      \u003C\u0024\u003Eback_button = back_button,
      \u003C\u003Ef__this = this
    };
  }

  public enum ResultUnitID
  {
    OLD,
    EVOLUTION,
  }
}
