// Decompiled with JetBrains decompiler
// Type: EffectController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EffectController : MonoBehaviour
{
  public UI3DModelCreate model_creater;
  public bool isAnimation;
  public GameObject back_button_;

  protected virtual void Action()
  {
  }

  public void OnAnimationEnd()
  {
    this.back_button_.SetActive(true);
    this.isAnimation = false;
  }

  protected virtual void OnEnable() => UICamera.fallThrough = ((Component) this).gameObject;

  protected virtual void OnDisable()
  {
    UICamera.fallThrough = (GameObject) null;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureGearBasic(int gear_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureGearBasic\u003Ec__Iterator425()
    {
      gear_id = gear_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Egear_id = gear_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureGearThum(int gear_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureGearThum\u003Ec__Iterator426()
    {
      gear_id = gear_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Egear_id = gear_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureSupplyThum(int supply_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureSupplyThum\u003Ec__Iterator427()
    {
      supply_id = supply_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Esupply_id = supply_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTexture(Future<Sprite> sprite, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTexture\u003Ec__Iterator428()
    {
      sprite = sprite,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Esprite = sprite,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureUnit(int unit_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureUnit\u003Ec__Iterator429()
    {
      unit_id = unit_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureUnitThum(int unit_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureUnitThum\u003Ec__Iterator42A()
    {
      unit_id = unit_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetTextureUnitCutin(int unit_id, MeshRenderer mesh_renderer)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetTextureUnitCutin\u003Ec__Iterator42B()
    {
      unit_id = unit_id,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Eunit_id = unit_id,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  protected void SetModelCreate()
  {
    if (!Object.op_Equality((Object) this.model_creater, (Object) null))
      return;
    if (Object.op_Equality((Object) ((Component) this).GetComponent<UI3DModelCreate>(), (Object) null))
      this.model_creater = ((Component) this).gameObject.AddComponent<UI3DModelCreate>();
    else
      this.model_creater = ((Component) this).GetComponent<UI3DModelCreate>();
  }

  [DebuggerHidden]
  protected IEnumerator CreateModel(Transform model_trans, PlayerUnit player_unit, bool flag_happy)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CCreateModel\u003Ec__Iterator42C()
    {
      player_unit = player_unit,
      model_trans = model_trans,
      flag_happy = flag_happy,
      \u003C\u0024\u003Eplayer_unit = player_unit,
      \u003C\u0024\u003Emodel_trans = model_trans,
      \u003C\u0024\u003Eflag_happy = flag_happy,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetAnimator(Future<RuntimeAnimatorController> animator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EffectController.\u003CSetAnimator\u003Ec__Iterator42D()
    {
      animator = animator,
      \u003C\u0024\u003Eanimator = animator,
      \u003C\u003Ef__this = this
    };
  }

  protected void SetLayer(Transform trans, int layer)
  {
    ((Component) trans).gameObject.layer = layer;
    foreach (Transform tran in trans)
      this.SetLayer(tran, layer);
  }

  protected virtual AnimationItemIcon SetCloneItemIcon(
    AnimationItemIcon icon,
    Transform trans,
    GameObject obj,
    PlayerItem item,
    bool new_flag = false)
  {
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationItemIcon>();
    ((Component) icon).transform.localPosition = new Vector3(0.0f, 0.0f, -0.05f);
    ((Object) ((Component) icon).gameObject).name = "AnimationItemIcon";
    icon.Set(item, new_flag);
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  protected virtual AnimationUnitIcon SetCloneUnitIcon(
    AnimationUnitIcon icon,
    Transform trans,
    GameObject obj,
    PlayerUnit unit,
    bool new_flag = false)
  {
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationUnitIcon>();
    ((Component) icon).transform.position = new Vector3(((Component) trans).transform.position.x, ((Component) trans).transform.position.y, ((Component) trans).transform.position.z - 0.05f);
    ((Object) ((Component) icon).gameObject).name = "AnimationUnitIcon";
    icon.Set(unit, new_flag);
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  protected virtual AnimationUnitIcon SetCloneUnitIcon(
    AnimationUnitIcon icon,
    Transform trans,
    GameObject obj,
    UnitUnit unit,
    bool new_flag = false)
  {
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationUnitIcon>();
    ((Component) icon).transform.position = new Vector3(((Component) trans).transform.position.x, ((Component) trans).transform.position.y, ((Component) trans).transform.position.z - 0.05f);
    ((Object) ((Component) icon).gameObject).name = "AnimationUnitIcon";
    icon.Set(unit, new_flag);
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  protected void SetAoriEffect(List<GameObject> obj_list, string[] anim_pattern)
  {
    foreach (string key in anim_pattern)
    {
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (EffectController.\u003C\u003Ef__switch\u0024map13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          EffectController.\u003C\u003Ef__switch\u0024map13 = new Dictionary<string, int>(3)
          {
            {
              "blue",
              0
            },
            {
              "yellow",
              1
            },
            {
              "red",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (EffectController.\u003C\u003Ef__switch\u0024map13.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              obj_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((u, n) => u.SetActive(n == 0)));
              continue;
            case 1:
              obj_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((u, n) => u.SetActive(n == 1)));
              continue;
            case 2:
              obj_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((u, n) => u.SetActive(n == 2)));
              continue;
            default:
              continue;
          }
        }
      }
    }
  }

  protected void SetCommonRarity(List<GameObject> obj_list, int rare_index)
  {
    obj_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((u, n) => u.SetActive(n == rare_index)));
  }

  protected void SetActiveList(List<GameObject> obj_list, int rare_index)
  {
    obj_list.ForEachIndex<GameObject>((System.Action<GameObject, int>) ((u, n) => u.SetActive(n == rare_index)));
  }
}
