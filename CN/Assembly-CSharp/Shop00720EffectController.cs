// Decompiled with JetBrains decompiler
// Type: Shop00720EffectController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00720EffectController : EffectController
{
  public string[] textureNameList_1;
  public string[] textureNameList_2;
  public string[] textureNameList_3;
  public int stopTextureId_1;
  public int stopTextureId_2;
  public int stopTextureId_3;
  public int[] transitionPlanList;
  public int rarity;
  public bool loadState;
  [SerializeField]
  private GameObject gb_started;
  private SlotDebug slot_script;
  private bool isMale;
  [SerializeField]
  public DuelCutin duelCutin;
  [SerializeField]
  private GameObject[] bugsCutinInitOff;
  [SerializeField]
  public DuelCutin duelCutinMale;
  [SerializeField]
  private GameObject[] bugsCutinMaleInitOff;
  private GameObject AnimationUnitIconPrefab;
  private GameObject AnimationItemIconPrefab;
  [SerializeField]
  private GameObject new_eft_;
  [SerializeField]
  private List<GetSumContainerList> renpatu_obj_;
  [SerializeField]
  private List<AnimationUnitIcon> renpatu_unit_;
  [SerializeField]
  private List<AnimationItemIcon> renpatu_item_;

  public SlotDebug Slot_script => this.slot_script;

  private void Awake()
  {
    this.slot_script = this.gb_started.GetComponent<SlotDebug>();
    this.StartCoroutine(this.slot_script.Init());
    this.SlotInit();
  }

  public void Bet()
  {
    Debug.Log((object) nameof (Bet));
    if (this.slot_script.isReady)
    {
      this.slot_script.SlotStart();
    }
    else
    {
      if (!this.slot_script.isEnd)
        return;
      this.SlotInit();
    }
  }

  public void SlotInit() => this.slot_script.SlotInit();

  public void Skip()
  {
    Debug.Log((object) nameof (Skip));
    this.slot_script.Skip();
  }

  [DebuggerHidden]
  public IEnumerator Renpatu(
    WebAPI.Response.SlotS001MedalPayResult[] result_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720EffectController.\u003CRenpatu\u003Ec__Iterator44F()
    {
      result_data = result_data,
      \u003C\u0024\u003Eresult_data = result_data,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRealityUnitThumnaile(
    int realityIndex,
    WebAPI.Response.SlotS001MedalPayResult[] result_data,
    int index)
  {
    GetSumContainerList sumContainerList = this.renpatu_obj_[result_data.Length - 1];
    switch (realityIndex)
    {
      case 0:
      case 1:
      case 2:
        ((Renderer) sumContainerList.renpatu_mesh_blur_[index]).enabled = false;
        break;
      case 4:
        ((Component) sumContainerList.renpatu_unit_light_[index]).gameObject.SetActive(true);
        break;
      case 5:
        ((Component) sumContainerList.renpatu_unit_light2_[index]).gameObject.SetActive(true);
        break;
    }
  }

  private void SetRealityItemThumnaile(
    int realityIndex,
    WebAPI.Response.SlotS001MedalPayResult[] result_data,
    int index,
    SupplySupply supply)
  {
    GetSumContainerList sumContainerList = this.renpatu_obj_[result_data.Length - 1];
    switch (realityIndex)
    {
      case 0:
      case 1:
      case 2:
        ((Renderer) sumContainerList.renpatu_mesh_blur_[index]).enabled = false;
        break;
      case 4:
        if (supply != null)
        {
          ((Component) sumContainerList.renpatu_item_light_[index]).gameObject.SetActive(true);
          break;
        }
        ((Component) sumContainerList.renpatu_item_other_light_[index]).gameObject.SetActive(true);
        break;
      case 5:
        if (supply != null)
        {
          ((Component) sumContainerList.renpatu_item_light2_[index]).gameObject.SetActive(true);
          break;
        }
        ((Component) sumContainerList.renpatu_item_other_light2_[index]).gameObject.SetActive(true);
        break;
    }
  }

  private new AnimationUnitIcon SetCloneUnitIcon(
    AnimationUnitIcon icon,
    Transform trans,
    GameObject obj,
    UnitUnit unit,
    bool new_flag = false)
  {
    if (Object.op_Inequality((Object) icon, (Object) null) && Object.op_Inequality((Object) ((Component) icon).gameObject.transform.parent, (Object) ((Component) trans).transform))
    {
      Object.Destroy((Object) ((Component) icon).gameObject);
      icon = (AnimationUnitIcon) null;
    }
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationUnitIcon>();
    else
      ((Component) icon).gameObject.SetActive(true);
    ((Component) icon).transform.position = new Vector3(((Component) trans).transform.position.x, ((Component) trans).transform.position.y, ((Component) trans).transform.position.z);
    ((Component) icon).transform.localRotation = Quaternion.Euler(0.0f, -180f, 0.0f);
    ((Object) ((Component) icon).gameObject).name = "AnimationUnitIcon";
    icon.Set(unit, new_flag);
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  private AnimationItemIcon SetCloneItemIcon(
    AnimationItemIcon icon,
    Transform trans,
    GameObject obj,
    GearGear item,
    bool new_flag = false)
  {
    if (Object.op_Inequality((Object) icon, (Object) null) && Object.op_Inequality((Object) ((Component) icon).gameObject.transform.parent, (Object) ((Component) trans).transform))
    {
      Object.Destroy((Object) ((Component) icon).gameObject);
      icon = (AnimationItemIcon) null;
    }
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationItemIcon>();
    else
      ((Component) icon).gameObject.SetActive(true);
    ((Component) icon).transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    ((Component) icon).transform.localRotation = Quaternion.Euler(0.0f, -180f, 0.0f);
    ((Object) ((Component) icon).gameObject).name = "AnimationItemIcon";
    icon.Set(item, new_flag);
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  private AnimationItemIcon SetCloneSupplyIcon(
    AnimationItemIcon icon,
    Transform trans,
    GameObject obj)
  {
    if (Object.op_Inequality((Object) icon, (Object) null) && Object.op_Inequality((Object) ((Component) icon).gameObject.transform.parent, (Object) ((Component) trans).transform))
    {
      Object.Destroy((Object) ((Component) icon).gameObject);
      icon = (AnimationItemIcon) null;
    }
    if (Object.op_Equality((Object) icon, (Object) null))
      icon = obj.Clone(((Component) trans).transform).GetComponent<AnimationItemIcon>();
    else
      ((Component) icon).gameObject.SetActive(true);
    ((Component) icon).transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    ((Component) icon).transform.localRotation = Quaternion.Euler(0.0f, -180f, 0.0f);
    ((Object) ((Component) icon).gameObject).name = nameof (SetCloneSupplyIcon);
    icon.SetSimpleMode();
    this.SetLayer(((Component) icon).gameObject.transform, ((Component) trans).gameObject.layer);
    return icon;
  }

  [DebuggerHidden]
  private IEnumerator SetTextureItemThum(
    CommonRewardType crt,
    MeshRenderer mesh_renderer,
    GameObject rootObj = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720EffectController.\u003CSetTextureItemThum\u003Ec__Iterator450()
    {
      crt = crt,
      rootObj = rootObj,
      mesh_renderer = mesh_renderer,
      \u003C\u0024\u003Ecrt = crt,
      \u003C\u0024\u003ErootObj = rootObj,
      \u003C\u0024\u003Emesh_renderer = mesh_renderer,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CutInInitialize(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720EffectController.\u003CCutInInitialize\u003Ec__Iterator451()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void PlayCutin()
  {
    if (this.isMale)
    {
      foreach (GameObject gameObject in this.bugsCutinMaleInitOff)
        gameObject.SetActive(false);
      ((Component) this.duelCutinMale).gameObject.SetActive(true);
      this.duelCutinMale.PlaySkillCutin();
    }
    else
    {
      foreach (GameObject gameObject in this.bugsCutinInitOff)
        gameObject.SetActive(false);
      ((Component) this.duelCutin).gameObject.SetActive(true);
      this.duelCutin.PlaySkillCutin();
    }
  }

  public void HideCutin()
  {
    if (this.isMale)
    {
      ((Component) this.duelCutinMale).gameObject.SetActive(false);
      ((Component) this.duelCutinMale).gameObject.GetComponent<Animator>().ResetTrigger("Start");
    }
    else
    {
      ((Component) this.duelCutin).gameObject.SetActive(false);
      ((Component) this.duelCutin).gameObject.GetComponent<Animator>().ResetTrigger("Start");
    }
  }
}
