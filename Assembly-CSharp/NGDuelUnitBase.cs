// Decompiled with JetBrains decompiler
// Type: NGDuelUnitBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public abstract class NGDuelUnitBase : MonoBehaviour
{
  public BL.Unit mMyUnitData;
  protected GameObject mRoot3D;
  protected GameObject mVehicleObject;
  protected GameObject[] mWeaponObject = new GameObject[2];
  protected GameObject mShieldObject;
  protected DuelCutin mDuelCI;
  protected DuelCutin mDuelCINew;
  protected GameObject mEffectShadow;
  protected Animator mCharacterAnimator;
  protected Animator mVehicleAnimator;
  protected DuelDuelConfig mConfig;
  public DuelTime mDuelTime;
  protected bool mIsMonster;
  protected static System.Action<MaterialPropertyBlock, UnityEngine.Material, string> SetColorFunc = (System.Action<MaterialPropertyBlock, UnityEngine.Material, string>) ((block, material, key) =>
  {
    if (!material.HasProperty(key))
      return;
    Color color = material.GetColor(key);
    if ((double) color.r == 0.0 && (double) color.g == 0.0 && ((double) color.b == 0.0 && (double) color.a == 0.0))
      return;
    block.SetColor(key, color);
  });
  protected static System.Action<MaterialPropertyBlock, UnityEngine.Material, string> SetFloatFunc = (System.Action<MaterialPropertyBlock, UnityEngine.Material, string>) ((block, material, key) =>
  {
    if (!material.HasProperty(key))
      return;
    float num = material.GetFloat(key);
    if ((double) num == 0.0)
      return;
    block.SetFloat(key, num);
  });
  protected static System.Action<MaterialPropertyBlock, UnityEngine.Material, string> SetVectorFunc = (System.Action<MaterialPropertyBlock, UnityEngine.Material, string>) ((block, material, key) =>
  {
    if (!material.HasProperty(key))
      return;
    Vector4 vector = material.GetVector(key);
    if ((double) vector.x == 0.0 && (double) vector.y == 0.0 && ((double) vector.z == 0.0 && (double) vector.w == 0.0))
      return;
    block.SetVector(key, vector);
  });
  protected static Func<string, System.Action<MaterialPropertyBlock, UnityEngine.Material, string>, System.Action<MaterialPropertyBlock, UnityEngine.Material>> CreateFunc = (Func<string, System.Action<MaterialPropertyBlock, UnityEngine.Material, string>, System.Action<MaterialPropertyBlock, UnityEngine.Material>>) ((key, func) => (System.Action<MaterialPropertyBlock, UnityEngine.Material>) ((block, material) => func(block, material, key)));
  protected static readonly System.Action<MaterialPropertyBlock, UnityEngine.Material>[] SetMaterialDefaultVariableFuncs = new System.Action<MaterialPropertyBlock, UnityEngine.Material>[10]
  {
    NGDuelUnitBase.CreateFunc("_Color", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_body_color", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_RimColor", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_Rim_Color", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_Rim_Exp", NGDuelUnitBase.SetFloatFunc),
    NGDuelUnitBase.CreateFunc("_alpha", NGDuelUnitBase.SetFloatFunc),
    NGDuelUnitBase.CreateFunc("_Alpha", NGDuelUnitBase.SetFloatFunc),
    NGDuelUnitBase.CreateFunc("_EyeLight_MainColor", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_EyeLight_EyeColor", NGDuelUnitBase.SetColorFunc),
    NGDuelUnitBase.CreateFunc("_Tile", NGDuelUnitBase.SetVectorFunc)
  };

  public Transform mBipTransform { get; protected set; }

  public GameObject baseGameObject => !((UnityEngine.Object) this.mVehicleObject != (UnityEngine.Object) null) ? this.gameObject : this.mVehicleObject;

  protected void loadDuelConfig()
  {
    SkillMetamorphosis metamorphosis = this.mMyUnitData.metamorphosis;
    string duelAnimatorControllerName = this.mMyUnitData.playerUnit.getDuelAnimatorControllerName(metamorphosis != null ? metamorphosis.metamorphosis_id : 0);
    this.mConfig = Array.Find<DuelDuelConfig>(MasterData.DuelDuelConfigList, (Predicate<DuelDuelConfig>) (x => x.controller_name == duelAnimatorControllerName));
    if (this.mConfig == null)
      this.mConfig = Array.Find<DuelDuelConfig>(MasterData.DuelDuelConfigList, (Predicate<DuelDuelConfig>) (x => x.controller_name == "Anim_dummy"));
    this.mDuelTime = new DuelTime(this.mConfig);
  }

  protected IEnumerator createVehicle()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    if (!string.IsNullOrEmpty(ngDuelUnitBase.mMyUnitData.unit.vehicle_model_name))
    {
      Future<GameObject> fs = ngDuelUnitBase.mMyUnitData.unit.LoadModelDuelVehicle();
      IEnumerator e = fs.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject result = fs.Result;
      if ((UnityEngine.Object) result == (UnityEngine.Object) null)
      {
        Debug.LogError((object) string.Format("Do not load vehicle_model_name={0}", (object) ngDuelUnitBase.mMyUnitData.unit.vehicle_model_name));
      }
      else
      {
        ngDuelUnitBase.mVehicleObject = result.Clone(ngDuelUnitBase.mRoot3D.transform);
        ngDuelUnitBase.mVehicleObject.transform.position = ngDuelUnitBase.transform.position;
        ngDuelUnitBase.mVehicleObject.transform.rotation = ngDuelUnitBase.transform.rotation;
        Transform childInFind = ngDuelUnitBase.mVehicleObject.transform.GetChildInFind("ridePoint");
        ngDuelUnitBase.transform.parent = childInFind;
        ngDuelUnitBase.transform.localScale = Vector3.one;
        ngDuelUnitBase.transform.localPosition = new Vector3(0.0f, -0.8f, 0.0f);
        ngDuelUnitBase.transform.localRotation = Quaternion.identity;
        ngDuelUnitBase.mVehicleAnimator = ngDuelUnitBase.mVehicleObject.GetComponent<Animator>();
        ngDuelUnitBase.mVehicleAnimator.gameObject.GetOrAddComponent<clipEffectPlayer>();
        Future<RuntimeAnimatorController> vac = ngDuelUnitBase.mMyUnitData.unit.LoadAnimatorControllerDuelVehicle(ngDuelUnitBase.mMyUnitData.playerUnit.equippedWeaponGearOrInitial.model_kind);
        e = vac.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if (!((UnityEngine.Object) vac.Result == (UnityEngine.Object) null))
        {
          ngDuelUnitBase.mVehicleAnimator.runtimeAnimatorController = vac.Result;
          fs = (Future<GameObject>) null;
          vac = (Future<RuntimeAnimatorController>) null;
        }
      }
    }
  }

  protected virtual IEnumerator createWeapon()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    if (ngDuelUnitBase.mMyUnitData.unit.non_disp_weapon <= 0)
    {
      Future<GameObject> pg = ngDuelUnitBase.mMyUnitData.playerUnit.equippedWeaponGearOrInitial.LoadModel();
      IEnumerator e = pg.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject result = pg.Result;
      Transform[] transformArray = new Transform[2];
      if (ngDuelUnitBase.mMyUnitData.playerUnit.isDualWieldWeapon)
      {
        transformArray[0] = ngDuelUnitBase.transform.GetChildInFind("weaponl");
        transformArray[1] = ngDuelUnitBase.transform.GetChildInFind("weaponr");
      }
      else if (ngDuelUnitBase.mMyUnitData.playerUnit.isLeftHandWeapon)
        transformArray[0] = ngDuelUnitBase.transform.GetChildInFind("weaponl");
      else
        transformArray[1] = ngDuelUnitBase.transform.GetChildInFind("weaponr");
      for (int index = 0; index < transformArray.Length; ++index)
      {
        if (!((UnityEngine.Object) transformArray[index] == (UnityEngine.Object) null))
        {
          GameObject gameObject = result.Clone(transformArray[index]);
          if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
          {
            Quaternion quaternion;
            switch ((GearKindEnum) ngDuelUnitBase.mMyUnitData.playerUnit.unit.kind_GearKind)
            {
              case GearKindEnum.bow:
                quaternion = Quaternion.Euler(0.0f, -90f, -90f);
                break;
              case GearKindEnum.gun:
                quaternion = Quaternion.Euler(0.0f, 90f, -90f);
                break;
              default:
                quaternion = ngDuelUnitBase.mIsMonster ? Quaternion.Euler(0.0f, 0.0f, 180f) : Quaternion.Euler(0.0f, -180f, 0.0f);
                break;
            }
            gameObject.transform.localRotation = quaternion;
            ngDuelUnitBase.mWeaponObject[index] = gameObject;
          }
        }
      }
    }
  }

  protected IEnumerator createShield()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    if (ngDuelUnitBase.mMyUnitData.unit.non_disp_weapon <= 0)
    {
      GearGear shieldGearOrNull = ngDuelUnitBase.mMyUnitData.playerUnit.equippedShieldGearOrNull;
      if (shieldGearOrNull != null)
      {
        Future<GameObject> pg = shieldGearOrNull.LoadModel();
        IEnumerator e = pg.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        GameObject result = pg.Result;
        ngDuelUnitBase.mShieldObject = result.Clone(ngDuelUnitBase.transform.GetChildInFind("weaponl"));
        ngDuelUnitBase.mShieldObject.SetActive(false);
      }
    }
  }

  protected IEnumerator createArmor()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    if (!string.IsNullOrEmpty(ngDuelUnitBase.mMyUnitData.unit.equip_model_name))
    {
      Future<GameObject> fs = ngDuelUnitBase.mMyUnitData.unit.LoadModelDuelEquip();
      IEnumerator e = fs.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject result = fs.Result;
      if ((UnityEngine.Object) result != (UnityEngine.Object) null)
      {
        result.transform.position = Vector3.zero;
        Transform childInFind = ngDuelUnitBase.transform.GetChildInFind("equippoint_a");
        result.Clone(childInFind);
      }
      fs = (Future<GameObject>) null;
    }
  }

  protected IEnumerator createHelm()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    if (!string.IsNullOrEmpty(ngDuelUnitBase.mMyUnitData.unit.equip_model_b_name))
    {
      Future<GameObject> fs = ngDuelUnitBase.mMyUnitData.unit.LoadModelDuelEquipB();
      IEnumerator e = fs.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject result = fs.Result;
      if ((UnityEngine.Object) result != (UnityEngine.Object) null)
      {
        result.transform.position = Vector3.zero;
        Transform childInFind = ngDuelUnitBase.transform.GetChildInFind("equippoint_b");
        result.Clone(childInFind);
      }
      fs = (Future<GameObject>) null;
    }
  }

  protected IEnumerator loadDefaultAnimatorController()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    Animator myAnimator = ngDuelUnitBase.GetComponentInChildren<Animator>();
    if (!((UnityEngine.Object) myAnimator == (UnityEngine.Object) null))
    {
      SkillMetamorphosis metamorphosis = ngDuelUnitBase.mMyUnitData.metamorphosis;
      int metamorId = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
      Future<RuntimeAnimatorController> frac = ngDuelUnitBase.mMyUnitData.playerUnit.LoadDuelAnimator(metamorId);
      IEnumerator e = frac.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      myAnimator.runtimeAnimatorController = frac.Result;
      int num1 = (UnityEngine.Object) myAnimator.avatar == (UnityEngine.Object) null ? 1 : 0;
      int num2 = myAnimator.avatar.isValid ? 1 : 0;
    }
  }

  protected void setupBodyMeshEffect()
  {
    if (this.mMyUnitData.unit.character.category != UnitCategory.player)
      return;
    SkinnedMeshRenderer componentInChildren = this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
    materialPropertyBlock.SetFloat("_rainbow_On", this.mMyUnitData.unit.rainbow_on ? 1f : 0.0f);
    NGDuelUnitBase.SetPropertyBlockMaterialDefault(materialPropertyBlock, componentInChildren.materials);
    componentInChildren.SetPropertyBlock(materialPropertyBlock);
  }

  protected IEnumerator createDuelShadow()
  {
    NGDuelUnitBase ngDuelUnitBase = this;
    Future<GameObject> ft = Singleton<ResourceManager>.GetInstance().Load<GameObject>("BattleEffects/duel/unit_shadow_duel");
    IEnumerator e = ft.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) ft.Result == (UnityEngine.Object) null))
    {
      Transform parent = (UnityEngine.Object) ngDuelUnitBase.mBipTransform != (UnityEngine.Object) null ? ngDuelUnitBase.mBipTransform : ngDuelUnitBase.transform;
      ngDuelUnitBase.mEffectShadow = ft.Result.Clone(parent);
      ngDuelUnitBase.mEffectShadow.transform.localScale = new Vector3(ngDuelUnitBase.mMyUnitData.unit.duel_shadow_scale_x, ngDuelUnitBase.mMyUnitData.unit.duel_shadow_scale_z, 1f);
    }
  }

  protected void adjustShadowObj()
  {
    if (!((UnityEngine.Object) this.mEffectShadow != (UnityEngine.Object) null))
      return;
    Vector3 position = this.mBipTransform.position;
    position.y = 0.0f;
    this.mEffectShadow.transform.position = position;
    this.mEffectShadow.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0.0f, 0.0f));
    this.mEffectShadow.transform.position = new Vector3(this.mEffectShadow.transform.position.x, 0.05f, this.mEffectShadow.transform.position.z);
  }

  public virtual void SetActiveEquipeWeapon(bool active)
  {
    foreach (GameObject gameObject in this.mWeaponObject)
    {
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        gameObject.SetActive(active);
    }
  }

  public virtual void SetActiveShadow(bool active)
  {
    if (!((UnityEngine.Object) this.mEffectShadow != (UnityEngine.Object) null))
      return;
    this.mEffectShadow.SetActive(active);
  }

  protected virtual IEnumerator CreateCutinObject()
  {
    NGDuelUnitBase ngDuelUnitBase1 = this;
    if ((double) ngDuelUnitBase1.mDuelTime.criticalCutinWaitTime > 0.0)
    {
      NGDuelUnitBase ngDuelUnitBase = ngDuelUnitBase1;
      Future<GameObject> fs = (Future<GameObject>) null;
      SkillMetamorphosis metamorphosis = ngDuelUnitBase1.mMyUnitData.metamorphosis;
      int metamor_id = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
      UnitCutinInfo unitCutinInfo = (metamor_id != 0 ? Array.Find<UnitModel>(MasterData.UnitModelList, (Predicate<UnitModel>) (x => x.unit_id_UnitUnit == ngDuelUnitBase.mMyUnitData.unitId && x.job_metamor_id == metamor_id)) : (UnitModel) null)?.cutin_frame ?? ngDuelUnitBase1.mMyUnitData.playerUnit.CutinInfo;
      IEnumerator e;
      if (!string.IsNullOrEmpty(unitCutinInfo.prefab_name))
      {
        fs = new ResourceObject("Animations/battle_cutin/" + unitCutinInfo.prefab_name).Load<GameObject>();
        e = fs.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if ((UnityEngine.Object) fs.Result != (UnityEngine.Object) null)
        {
          GameObject gameObject = fs.Result.Clone(ngDuelUnitBase1.mRoot3D.transform);
          gameObject.transform.localPosition = Vector3.zero;
          gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 180f, 0.0f));
          gameObject.SetActive(false);
          ngDuelUnitBase1.mDuelCINew = gameObject.GetComponent<DuelCutin>();
          e = ngDuelUnitBase1.mDuelCINew.Initialize<BL.Unit>(ngDuelUnitBase1.mMyUnitData);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
      }
      fs = ngDuelUnitBase1.mMyUnitData.unit.character.gender != UnitGender.male ? Res.Animations.battle_cutin.battle_cutin_prefab.Load<GameObject>() : Res.Animations.battle_cutin.battle_cutin_male_prefab.Load<GameObject>();
      e = fs.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      if ((UnityEngine.Object) fs.Result != (UnityEngine.Object) null)
      {
        GameObject gameObject = fs.Result.Clone(ngDuelUnitBase1.mRoot3D.transform);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 180f, 0.0f));
        gameObject.SetActive(false);
        ngDuelUnitBase1.mDuelCI = gameObject.GetComponent<DuelCutin>();
        e = ngDuelUnitBase1.mDuelCI.Initialize<BL.Unit>(ngDuelUnitBase1.mMyUnitData);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      fs = (Future<GameObject>) null;
    }
  }

  public bool PlayCriticalCutin()
  {
    DuelCutin duelCutin = (UnityEngine.Object) this.mDuelCINew != (UnityEngine.Object) null ? this.mDuelCINew : ((UnityEngine.Object) this.mDuelCI != (UnityEngine.Object) null ? this.mDuelCI : (DuelCutin) null);
    if (!((UnityEngine.Object) duelCutin != (UnityEngine.Object) null) || !duelCutin.isTexExist)
      return false;
    duelCutin.gameObject.SetActive(true);
    duelCutin.PlayCriticalCutin();
    return true;
  }

  public bool PlaySkillCutin()
  {
    DuelCutin duelCutin = (UnityEngine.Object) this.mDuelCINew != (UnityEngine.Object) null ? this.mDuelCINew : ((UnityEngine.Object) this.mDuelCI != (UnityEngine.Object) null ? this.mDuelCI : (DuelCutin) null);
    if (!((UnityEngine.Object) duelCutin != (UnityEngine.Object) null) || !duelCutin.isTexExist)
      return false;
    duelCutin.gameObject.SetActive(true);
    duelCutin.PlaySkillCutin();
    return true;
  }

  public bool PlayMultiSkillCutin(int topUnitId, int centerUnitId)
  {
    DuelCutin cutin = (UnityEngine.Object) this.mDuelCI != (UnityEngine.Object) null ? this.mDuelCI : (DuelCutin) null;
    if (!((UnityEngine.Object) cutin != (UnityEngine.Object) null))
      return false;
    this.SetCutinTexture(cutin, topUnitId, DuelCutin.CUTINPOS.TOP);
    this.SetCutinTexture(cutin, centerUnitId, DuelCutin.CUTINPOS.CENTER);
    cutin.gameObject.SetActive(true);
    cutin.PlaySkillCutin(DuelCutin.PlayMode.SECOND_PERSON);
    return true;
  }

  public bool PlayMultiSkillCutin(int topUnitId, int centerUnitId, int bottomUnitId)
  {
    DuelCutin cutin = (UnityEngine.Object) this.mDuelCI != (UnityEngine.Object) null ? this.mDuelCI : (DuelCutin) null;
    if (!((UnityEngine.Object) cutin != (UnityEngine.Object) null))
      return false;
    this.SetCutinTexture(cutin, topUnitId, DuelCutin.CUTINPOS.TOP);
    this.SetCutinTexture(cutin, centerUnitId, DuelCutin.CUTINPOS.CENTER);
    this.SetCutinTexture(cutin, bottomUnitId, DuelCutin.CUTINPOS.BOTTOM);
    cutin.gameObject.SetActive(true);
    cutin.PlaySkillCutin(DuelCutin.PlayMode.THIRD_PERSON);
    return true;
  }

  protected virtual void SetCutinTexture(DuelCutin cutin, int unitId, DuelCutin.CUTINPOS pos) => this.StartCoroutine(cutin.LoadAndSetTexture(unitId, pos));

  protected static void SetPropertyBlockMaterialDefault(
    MaterialPropertyBlock block,
    UnityEngine.Material[] materials)
  {
    foreach (UnityEngine.Material material in materials)
    {
      foreach (System.Action<MaterialPropertyBlock, UnityEngine.Material> defaultVariableFunc in NGDuelUnitBase.SetMaterialDefaultVariableFuncs)
        defaultVariableFunc(block, material);
    }
  }

  [Conditional("UNITY_EDITOR")]
  [Conditional("DEVELOP_BUILD")]
  protected void DuelUnitLog(string log)
  {
  }
}
