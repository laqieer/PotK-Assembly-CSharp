// Decompiled with JetBrains decompiler
// Type: UI3DModelCreate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UI3DModelCreate : MonoBehaviour
{
  [SerializeField]
  private GameObject base_model_;
  [SerializeField]
  private GameObject unit_model_;
  [SerializeField]
  private GameObject equip_model_;
  [SerializeField]
  private GameObject tiara_model_;
  [SerializeField]
  private GameObject equip_gear_model_;
  [SerializeField]
  private GameObject vehicle_model_;
  [SerializeField]
  private Animator unit_animator_;
  [SerializeField]
  private Animator vehicle_animator_;
  private Future<GameObject> unit_;
  private Future<GameObject> equip_;
  private Future<GameObject> equip_gear_;
  private Future<GameObject> vehicle_;
  private Future<GameObject> tiara_;
  private Future<RuntimeAnimatorController> unit_runtime_;
  private Future<RuntimeAnimatorController> vehicle_runtime_;
  private clipEffectPlayer clip_effect_player;
  private bool is_left_hand;
  private bool is_dual_wield;
  public bool winAnimator_;

  public GameObject BaseModel
  {
    get => this.base_model_;
    set => this.base_model_ = value;
  }

  public GameObject UnitModel
  {
    get => this.unit_model_;
    set => this.unit_model_ = value;
  }

  public GameObject VehicleModel
  {
    get => this.vehicle_model_;
    set => this.vehicle_model_ = value;
  }

  public GameObject EquipGearModel
  {
    get => this.equip_gear_model_;
    set => this.equip_gear_model_ = value;
  }

  public GameObject EquipModel
  {
    get => this.equip_model_;
    set => this.equip_model_ = value;
  }

  public GameObject TiaraModel
  {
    get => this.tiara_model_;
    set => this.tiara_model_ = value;
  }

  public Animator UnitAnimator
  {
    get => this.unit_animator_;
    set => this.unit_animator_ = value;
  }

  public Animator VehicleAnimator
  {
    get => this.vehicle_animator_;
    set => this.vehicle_animator_ = value;
  }

  public void SetNull()
  {
    this.unit_ = (Future<GameObject>) null;
    this.equip_ = (Future<GameObject>) null;
    this.equip_gear_ = (Future<GameObject>) null;
    this.vehicle_ = (Future<GameObject>) null;
    this.unit_animator_ = (Animator) null;
    this.vehicle_animator_ = (Animator) null;
    this.unit_model_ = (GameObject) null;
    this.equip_model_ = (GameObject) null;
    this.equip_gear_model_ = (GameObject) null;
    this.vehicle_model_ = (GameObject) null;
    this.unit_runtime_ = (Future<RuntimeAnimatorController>) null;
    this.vehicle_runtime_ = (Future<RuntimeAnimatorController>) null;
  }

  [DebuggerHidden]
  private IEnumerator InitUnitUnitAnimator(UnitUnit unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CInitUnitUnitAnimator\u003Ec__Iterator466()
    {
      unit_data = unit_data,
      \u003C\u0024\u003Eunit_data = unit_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitPlayerUnitAnimator(PlayerUnit player_unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CInitPlayerUnitAnimator\u003Ec__Iterator467()
    {
      player_unit_data = player_unit_data,
      \u003C\u0024\u003Eplayer_unit_data = player_unit_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitUnitUnitModel(UnitUnit unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CInitUnitUnitModel\u003Ec__Iterator468()
    {
      unit_data = unit_data,
      \u003C\u0024\u003Eunit_data = unit_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitGear(UnitUnit unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CInitGear\u003Ec__Iterator469()
    {
      unit_data = unit_data,
      \u003C\u0024\u003Eunit_data = unit_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadGear(GearGear gear_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CLoadGear\u003Ec__Iterator46A()
    {
      gear_data = gear_data,
      \u003C\u0024\u003Egear_data = gear_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateModel(UnitUnit unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CCreateModel\u003Ec__Iterator46B()
    {
      unit_data = unit_data,
      \u003C\u0024\u003Eunit_data = unit_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateModel(PlayerUnit player_unit_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UI3DModelCreate.\u003CCreateModel\u003Ec__Iterator46C()
    {
      player_unit_data = player_unit_data,
      \u003C\u0024\u003Eplayer_unit_data = player_unit_data,
      \u003C\u003Ef__this = this
    };
  }

  private void Create()
  {
    this.base_model_ = (!Object.op_Implicit((Object) this.vehicle_.Result) ? this.unit_.Result : this.vehicle_.Result).Clone(((Component) this).transform);
    this.unit_model_ = this.base_model_;
    this.unit_animator_ = this.unit_model_.GetComponentInChildren<Animator>();
    this.unit_animator_.runtimeAnimatorController = this.unit_runtime_.Result;
    this.clip_effect_player = ((Component) this.unit_animator_).gameObject.GetComponent<clipEffectPlayer>();
    if (Object.op_Equality((Object) this.clip_effect_player, (Object) null))
      this.clip_effect_player = ((Component) this.unit_animator_).gameObject.AddComponent<clipEffectPlayer>();
    if (Object.op_Inequality((Object) this.vehicle_.Result, (Object) null))
    {
      Transform childInFind = this.unit_model_.transform.GetChildInFind("ridePoint");
      if (Object.op_Inequality((Object) childInFind, (Object) null))
      {
        this.vehicle_model_ = this.unit_model_;
        this.vehicle_animator_ = this.vehicle_model_.GetComponentInChildren<Animator>();
        this.vehicle_animator_.runtimeAnimatorController = this.vehicle_runtime_.Result;
        this.unit_model_ = this.unit_.Result.Clone(childInFind);
        this.unit_animator_ = this.unit_model_.GetComponentInChildren<Animator>();
        this.unit_animator_.runtimeAnimatorController = this.unit_runtime_.Result;
        this.unit_model_.transform.localPosition = new Vector3(0.0f, -0.8f, 0.0f);
        this.clip_effect_player = ((Component) this.unit_animator_).gameObject.GetComponent<clipEffectPlayer>();
        if (Object.op_Equality((Object) this.clip_effect_player, (Object) null))
          this.clip_effect_player = ((Component) this.unit_animator_).gameObject.AddComponent<clipEffectPlayer>();
      }
      else
        Debug.LogWarning((object) "raidePoint が　みつからない。");
    }
    Transform childInFind1 = this.unit_model_.transform.GetChildInFind("equippoint_a");
    if (Object.op_Inequality((Object) childInFind1, (Object) null))
      this.equip_model_ = this.equip_.Result.Clone(childInFind1);
    Transform childInFind2 = this.unit_model_.transform.GetChildInFind("equippoint_b");
    if (!Object.op_Inequality((Object) childInFind2, (Object) null))
      return;
    this.tiara_model_ = this.tiara_.Result.Clone(childInFind2);
  }

  public void SetGear(GearKind gear_data, UnitCategory category)
  {
    Object.Destroy((Object) this.equip_gear_model_);
    this.equip_gear_model_ = (GameObject) null;
    if (this.equip_gear_ == null)
      return;
    if (this.is_dual_wield)
    {
      Transform childInFind1 = this.unit_model_.transform.GetChildInFind("weaponl");
      Transform childInFind2 = this.unit_model_.transform.GetChildInFind("weaponr");
      this.SetGearPoint(childInFind1, gear_data, category);
      this.SetGearPoint(childInFind2, gear_data, category);
    }
    else
      this.SetGearPoint(this.unit_model_.transform.GetChildInFind(!this.is_left_hand ? "weaponr" : "weaponl"), gear_data, category);
  }

  private void SetGearPoint(Transform gearPoint, GearKind gear_data, UnitCategory category)
  {
    if (Object.op_Equality((Object) gearPoint, (Object) null))
      return;
    if (this.equip_gear_.HasResult)
      this.equip_gear_model_ = this.equip_gear_.Result.Clone(gearPoint);
    if (Object.op_Equality((Object) this.equip_gear_model_, (Object) null))
      return;
    switch (gear_data.Enum)
    {
      case GearKindEnum.sword:
      case GearKindEnum.axe:
      case GearKindEnum.spear:
      case GearKindEnum.staff:
      case GearKindEnum.shield:
      case GearKindEnum.unique_wepon:
      case GearKindEnum.smith:
        if (category == UnitCategory.player)
        {
          this.equip_gear_model_.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
          break;
        }
        this.equip_gear_model_.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180f);
        break;
      case GearKindEnum.bow:
        this.equip_gear_model_.transform.localRotation = Quaternion.Euler(0.0f, -90f, -90f);
        break;
      case GearKindEnum.gun:
        this.equip_gear_model_.transform.localRotation = Quaternion.Euler(0.0f, 90f, -90f);
        break;
    }
  }

  private void OnEnable()
  {
    RenderSettings.ambientLight = Consts.GetInstance().UI3DMODEL_AMBIENT_COLOR;
  }

  private void OnDisable()
  {
    if (Object.op_Implicit((Object) Object.FindObjectOfType<UI3DModel>()))
      return;
    RenderSettings.ambientLight = Consts.GetInstance().UI3DMODEL_DEFAULT_AMBIENT_COLOR;
  }
}
