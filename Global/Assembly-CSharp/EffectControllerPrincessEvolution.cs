// Decompiled with JetBrains decompiler
// Type: EffectControllerPrincessEvolution
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectControllerPrincessEvolution : EffectController
{
  [SerializeField]
  private GameObject odd_;
  [SerializeField]
  private GameObject even_;
  [SerializeField]
  private List<GameObject> thumList_odd_;
  [SerializeField]
  private List<GameObject> thumList_even_;
  [SerializeField]
  private List<MeshRenderer> meshList_odd_;
  [SerializeField]
  private List<MeshRenderer> meshList_even_;
  [SerializeField]
  private List<AnimationUnitIcon> unitIconList_;
  [SerializeField]
  private CommonRarityAnim common_rarity_anim_;
  [SerializeField]
  private GameObject animation_root_;
  [SerializeField]
  private GameObject base_model_;
  [SerializeField]
  private Transform base_trans_;
  [SerializeField]
  private MeshRenderer base_image_;
  [SerializeField]
  private GameObject Rarity;
  [SerializeField]
  private GameObject Reincarnation;
  [SerializeField]
  private GameObject new_model_;
  [SerializeField]
  private Transform new_trans_;
  [SerializeField]
  private MeshRenderer new_image_;
  private Animator new_animator_;
  [SerializeField]
  private GameObject is_new_;
  public PrincessEvolutionSoundEffect soundManager;
  private GameObject animationUnitIconPrefab;
  [SerializeField]
  private GameObject ModelVersion;
  [SerializeField]
  private GameObject ImageVersion;

  public void EndSE() => this.soundManager.OnPlayResult();

  [DebuggerHidden]
  private IEnumerator initialize(
    List<PlayerUnit> unit_list,
    List<PlayerUnit> result_unit,
    Unit00499Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerPrincessEvolution.\u003Cinitialize\u003Ec__Iterator798()
    {
      unit_list = unit_list,
      result_unit = result_unit,
      mode = mode,
      \u003C\u0024\u003Eunit_list = unit_list,
      \u003C\u0024\u003Eresult_unit = result_unit,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  public void Evolution()
  {
    ((Component) this.base_trans_).gameObject.SetActive(false);
    ((Component) this.new_trans_).gameObject.SetActive(true);
    if (Object.op_Equality((Object) this.new_animator_, (Object) null))
      return;
    ((Behaviour) this.new_animator_).enabled = true;
  }

  [DebuggerHidden]
  public IEnumerator Set(
    List<PlayerUnit> unit_list,
    bool is_new,
    List<PlayerUnit> result_unit,
    GameObject back_button,
    Unit00499Scene.Mode mode)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectControllerPrincessEvolution.\u003CSet\u003Ec__Iterator799()
    {
      back_button = back_button,
      is_new = is_new,
      unit_list = unit_list,
      result_unit = result_unit,
      mode = mode,
      \u003C\u0024\u003Eback_button = back_button,
      \u003C\u0024\u003Eis_new = is_new,
      \u003C\u0024\u003Eunit_list = unit_list,
      \u003C\u0024\u003Eresult_unit = result_unit,
      \u003C\u0024\u003Emode = mode,
      \u003C\u003Ef__this = this
    };
  }

  public enum ResultUnitID
  {
    OLD,
    EVOLUTION,
  }
}
