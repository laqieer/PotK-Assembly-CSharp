// Decompiled with JetBrains decompiler
// Type: NGBattle3DObjectManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGBattle3DObjectManager : BattleManagerBase
{
  public string hpBarPrefab_blue_path = "Prefabs/filed_3d_icon/3dicon_bar_blue";
  public string hpBarPrefab_red_path = "Prefabs/filed_3d_icon/3dicon_bar_red";
  public string buttonPrefab_attack_path = "Prefabs/filed_3d_icon/3dicon_button_attack";
  public string buttonPrefab_heal_path = "Prefabs/filed_3d_icon/3dicon_button_heal";
  public string hpNumber_path = "BattleEffects/field/ef667_hp_number";
  public string damageEffect_path = "BattleEffects/field/ef039_damage";
  public string criticalDamageEffect_path = "BattleEffects/field/ef040_damage_critical";
  public string missEffect_path = "BattleEffects/field/ef042_fe_miss";
  public string criticalEffect_path = "BattleEffects/field/ef041_fe_critical";
  public string skillIconEffect_path = "BattleEffects/field/ef671_fe_skill_icon";
  public string pvp_effect_player_path = "BattleEffects/field/ef653_fe_Multi_Unit";
  public string pvp_effect_enemy_path = "BattleEffects/field/ef654_fe_Multi_Enemy";
  public string pvp_effect_leader_player_path = "BattleEffects/field/ef655_fe_Multi_UnitRida";
  public string pvp_effect_leader_enemy_path = "BattleEffects/field/ef656_fe_Multi_EnemyRida";
  public string shadow_path = "Prefabs/BattleCommon/unit_shadow";
  private GameObject unitBasePrefabObject;
  private GameObject unitShadowPrefabObject;
  public GameObject objectRoot;
  private GameObject hpBarPrefab_blue;
  private GameObject hpBarPrefab_red;
  private GameObject buttonPrefab_attack;
  private GameObject buttonPrefab_heal;
  private GameObject hpNumber;
  private GameObject damageEffect;
  private GameObject criticalDamageEffect;
  private GameObject missEffect;
  private GameObject criticalEffect;
  private GameObject skillIconEffect;
  private GameObject pvp_effect_player;
  private GameObject pvp_effect_enemy;
  private GameObject pvp_effect_leader_player;
  private GameObject pvp_effect_leader_enemy;
  private int loadMapID = -1;
  private GameObject panelPrefab;
  private Transform spawnRoot;

  [DebuggerHidden]
  public IEnumerator loadStage(BE env, bool setOthers = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadStage\u003Ec__Iterator9C1()
    {
      env = env,
      setOthers = setOthers,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003EsetOthers = setOthers,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator loadUnitResources(BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadUnitResources\u003Ec__Iterator9C2()
    {
      env = env,
      \u003C\u0024\u003Eenv = env,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003Cinitialize\u003Ec__Iterator9C3()
    {
      env_ = env_,
      \u003C\u0024\u003Eenv_ = env_,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003Ccleanup\u003Ec__Iterator9C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void destroy3DObjects()
  {
    if (Object.op_Inequality((Object) this.objectRoot, (Object) null))
    {
      Object.Destroy((Object) this.objectRoot);
      this.objectRoot = (GameObject) null;
    }
    if (Object.op_Inequality((Object) this.spawnRoot, (Object) null))
    {
      Object.Destroy((Object) this.spawnRoot);
      this.spawnRoot = (Transform) null;
    }
    BE environment = Singleton<NGBattleManager>.GetInstance().environment;
    environment.stageResource[environment.core.stage].prefab = (GameObject) null;
    foreach (BL.UnitPosition unitPosition in environment.core.unitPositions.value)
      this.releaseUnitResource(unitPosition.unit, environment);
    environment.unitResource.cleanup();
    environment.skillResource.cleanup();
    environment.ailmentSkillResource.cleanup();
    environment.weaponResource.cleanup();
    environment.panelResource.cleanup();
    environment.itemResource.cleanup();
    environment.dropDataResource.cleanup();
    environment.stageResource.cleanup();
    this.unitBasePrefabObject = (GameObject) null;
    this.unitShadowPrefabObject = (GameObject) null;
    this.objectRoot = (GameObject) null;
    this.hpBarPrefab_blue = (GameObject) null;
    this.hpBarPrefab_red = (GameObject) null;
    this.buttonPrefab_attack = (GameObject) null;
    this.buttonPrefab_heal = (GameObject) null;
    this.hpNumber = (GameObject) null;
    this.damageEffect = (GameObject) null;
    this.criticalDamageEffect = (GameObject) null;
    this.missEffect = (GameObject) null;
    this.criticalEffect = (GameObject) null;
    this.skillIconEffect = (GameObject) null;
    this.pvp_effect_player = (GameObject) null;
    this.pvp_effect_enemy = (GameObject) null;
    this.pvp_effect_leader_player = (GameObject) null;
    this.pvp_effect_leader_enemy = (GameObject) null;
  }

  public void setRootActive(bool active)
  {
    if (!Object.op_Inequality((Object) this.objectRoot, (Object) null))
      return;
    this.objectRoot.GetComponent<Battle3DRoot>().objectsAcitve(active);
  }

  public static Vector3 create3DPosition(int row, int column, float height = 0.0f)
  {
    float panelSize = Singleton<NGBattleManager>.GetInstance().panelSize;
    float num1 = panelSize / 2f;
    float num2 = panelSize / 2f;
    return new Vector3((float) column * panelSize + num1, height, (float) row * panelSize + num2);
  }

  private GameObject spawnObject(
    int row,
    int column,
    float direction,
    GameObject unitPrefab,
    GameObject bikePrefab,
    GameObject equipPrefab_a,
    GameObject equipPrefab_b,
    GameObject gearPrefab,
    bool leftHand,
    bool isDualWield,
    GameObject hpBarPrefab,
    GameObject pvpPrefab = null)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    BE environment = instance.environment;
    GameObject gameObject1 = Object.Instantiate<GameObject>(this.unitBasePrefabObject);
    Transform transform = new GameObject("nonTransform").transform;
    transform.parent = gameObject1.transform;
    transform.localPosition = Vector3.zero;
    if (Object.op_Inequality((Object) hpBarPrefab, (Object) null))
      hpBarPrefab.Clone(transform);
    if (Object.op_Inequality((Object) this.hpNumber, (Object) null))
      this.hpNumber.Clone(transform);
    GameObject gameObject2 = new GameObject("rot");
    gameObject2.transform.parent = gameObject1.transform;
    gameObject2.transform.localPosition = instance.unitPositionOffsetValue;
    gameObject2.transform.localScale = Vector3.one;
    gameObject2.transform.localRotation = Quaternion.Euler(0.0f, direction, 0.0f);
    GameObject gameObject3 = new GameObject("angle");
    gameObject3.transform.parent = gameObject2.transform;
    gameObject3.transform.localScale = Vector3.one;
    gameObject3.transform.localPosition = Vector3.zero;
    gameObject3.transform.localRotation = Quaternion.identity;
    gameObject3.AddComponent<UnitAngle>();
    gameObject1.transform.parent = this.spawnRoot;
    GameObject self = !Object.op_Inequality((Object) bikePrefab, (Object) null) ? unitPrefab : bikePrefab;
    if (Object.op_Inequality((Object) self, (Object) null))
    {
      GameObject gameObject4 = self.Clone(gameObject3.transform);
      if (Object.op_Equality((Object) gameObject4.GetComponent<clipEffectPlayer>(), (Object) null))
        gameObject4.AddComponent<clipEffectPlayer>();
      if (Object.op_Inequality((Object) bikePrefab, (Object) null))
      {
        Transform childInFind = gameObject4.transform.GetChildInFind("ridePoint");
        if (Object.op_Inequality((Object) childInFind, (Object) null))
        {
          GameObject gameObject5 = unitPrefab.Clone(childInFind);
          if (Object.op_Equality((Object) gameObject5.GetComponent<clipEffectPlayer>(), (Object) null))
            gameObject5.AddComponent<clipEffectPlayer>();
        }
      }
      if (Object.op_Inequality((Object) equipPrefab_a, (Object) null))
      {
        Transform childInFind = gameObject4.transform.GetChildInFind("equippoint_a");
        if (Object.op_Inequality((Object) childInFind, (Object) null))
          equipPrefab_a.Clone(childInFind);
      }
      if (Object.op_Inequality((Object) equipPrefab_b, (Object) null))
      {
        Transform childInFind = gameObject4.transform.GetChildInFind("equippoint_b");
        if (Object.op_Inequality((Object) childInFind, (Object) null))
          equipPrefab_b.Clone(childInFind);
      }
      if (Object.op_Inequality((Object) gearPrefab, (Object) null))
      {
        if (isDualWield)
        {
          Transform childInFind1 = gameObject4.transform.GetChildInFind("weaponl");
          if (Object.op_Implicit((Object) childInFind1))
            gearPrefab.Clone(childInFind1);
          Transform childInFind2 = gameObject4.transform.GetChildInFind("weaponr");
          if (Object.op_Implicit((Object) childInFind2))
            gearPrefab.Clone(childInFind2);
        }
        else
        {
          Transform childInFind = gameObject4.transform.GetChildInFind(!leftHand ? "weaponr" : "weaponl");
          if (Object.op_Implicit((Object) childInFind))
            gearPrefab.Clone(childInFind);
        }
      }
      if (Object.op_Inequality((Object) pvpPrefab, (Object) null))
        pvpPrefab.Clone(transform);
    }
    else
      Debug.LogError((object) (" === spawnObject prefab NULL : (" + (object) row + ", " + (object) column + ")"));
    BL.Panel fieldPanel = environment.core.getFieldPanel(row, column);
    BE.PanelResource panelResource = environment.panelResource[fieldPanel];
    gameObject1.transform.position = new Vector3(panelResource.gameObject.transform.position.x, panelResource.gameObject.GetComponent<BattlePanelParts>().getHeight(), panelResource.gameObject.transform.position.z);
    return gameObject1;
  }

  public GameObject spawnUnit(BL.UnitPosition up)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    BE environment = instance.environment;
    BE.UnitResource unitResource = environment.unitResource[up.unit];
    bool flag = environment.core.getForceID(up.unit) == BL.ForceID.player;
    GameObject gameObject = this.spawnObject(up.row, up.column, up.direction, unitResource.prefab, unitResource.bikePrefab, unitResource.equipPrefab_a, unitResource.equipPrefab_b, environment.weaponResource[up.unit.weapon].prefab, up.unit.gearLeftHand, up.unit.gearDualWield, !flag ? this.hpBarPrefab_red : this.hpBarPrefab_blue, !instance.isOvo ? (GameObject) null : (!flag ? (!up.unit.is_leader ? this.pvp_effect_enemy : this.pvp_effect_leader_enemy) : (!up.unit.is_leader ? this.pvp_effect_player : this.pvp_effect_leader_player)));
    BattleUnitParts component = gameObject.GetComponent<BattleUnitParts>();
    clipEffectPlayer componentInChildren = gameObject.GetComponentInChildren<clipEffectPlayer>();
    up.unit.isEnable = up.unit.isSpawned;
    component.setUnitPosition(up, ((Component) componentInChildren).gameObject, this.unitShadowPrefabObject, this.damageEffect, this.criticalDamageEffect, this.missEffect, this.criticalEffect, this.skillIconEffect);
    return gameObject;
  }

  public static GameObject hitObject(Camera cam, Vector2 pos, string layer)
  {
    RaycastHit raycastHit = new RaycastHit();
    Ray ray = cam.ScreenPointToRay(Vector2.op_Implicit(pos));
    int num = 1 << LayerMask.NameToLayer(layer);
    return Physics.Raycast(ray, ref raycastHit, 100f, num) ? ((Component) ((RaycastHit) ref raycastHit).collider).gameObject : (GameObject) null;
  }

  public static BL.Panel hitPanel(Vector2 pos)
  {
    Camera[] componentsInChildren = Singleton<NGBattleManager>.GetInstance().battleCamera.GetComponentsInChildren<Camera>(true);
    if (componentsInChildren != null && componentsInChildren.Length > 0)
    {
      GameObject gameObject = NGBattle3DObjectManager.hitObject(componentsInChildren[0], pos, "Panel");
      if (Object.op_Inequality((Object) gameObject, (Object) null))
        return gameObject.GetComponent<BattlePanelParts>().getPanel();
    }
    return (BL.Panel) null;
  }

  public void setButton(BL.Panel panel, bool isHeal)
  {
    BE.PanelResource panelResource = Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel];
    if (isHeal)
      panelResource.gameObject.GetComponent<BattlePanelParts>().setHealButton(this.buttonPrefab_heal);
    else
      panelResource.gameObject.GetComponent<BattlePanelParts>().setAttackButton(this.buttonPrefab_attack);
  }

  public void hideButton(BL.Panel panel)
  {
    Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel].gameObject.GetComponent<BattlePanelParts>().hideButton();
  }

  private void initializeMap(GameObject mapPrefab, Battle3DRoot root, BE env)
  {
    NGBattle3DObjectManager.ApplyLightmapUV(mapPrefab.Clone(root.mapPoint), 1);
  }

  private void initializeCamera(BE env)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    instance.getController<BattleCameraController>().sightDistance = instance.sightDistances[env.core.sight.value];
  }

  [DebuggerHidden]
  public IEnumerator initializePanels(
    GameObject panelPrefab,
    Battle3DRoot root,
    BE env,
    bool setOthers = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CinitializePanels\u003Ec__Iterator9C5()
    {
      env = env,
      root = root,
      panelPrefab = panelPrefab,
      setOthers = setOthers,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003Eroot = root,
      \u003C\u0024\u003EpanelPrefab = panelPrefab,
      \u003C\u0024\u003EsetOthers = setOthers,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator createPanels(GameObject prefab, Battle3DRoot root, BE env, bool setOthers)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CcreatePanels\u003Ec__Iterator9C6()
    {
      env = env,
      setOthers = setOthers,
      root = root,
      prefab = prefab,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003EsetOthers = setOthers,
      \u003C\u0024\u003Eroot = root,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator spawns(List<BL.UnitPosition> units, BE env, bool wait = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003Cspawns\u003Ec__Iterator9C7()
    {
      units = units,
      wait = wait,
      \u003C\u0024\u003Eunits = units,
      \u003C\u0024\u003Ewait = wait,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadSkillResource(BattleskillFieldEffect effectData, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadSkillResource\u003Ec__Iterator9C8()
    {
      env = env,
      effectData = effectData,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003EeffectData = effectData
    };
  }

  [DebuggerHidden]
  private IEnumerator loadSkillResource(BattleskillSkill skill, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadSkillResource\u003Ec__Iterator9C9()
    {
      skill = skill,
      env = env,
      \u003C\u0024\u003Eskill = skill,
      \u003C\u0024\u003Eenv = env,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadAilmentSkillResource(BattleskillAilmentEffect ailmentEffect, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadAilmentSkillResource\u003Ec__Iterator9CA()
    {
      env = env,
      ailmentEffect = ailmentEffect,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003EailmentEffect = ailmentEffect
    };
  }

  [DebuggerHidden]
  private IEnumerator loadItemResource(BL.Item item, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadItemResource\u003Ec__Iterator9CB()
    {
      env = env,
      item = item,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003Eitem = item
    };
  }

  [DebuggerHidden]
  private IEnumerator loadMagicBulletResource(BL.MagicBullet mb, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadMagicBulletResource\u003Ec__Iterator9CC()
    {
      mb = mb,
      env = env,
      \u003C\u0024\u003Emb = mb,
      \u003C\u0024\u003Eenv = env,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator loadUnitResource(BL.Unit unit, BE env)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattle3DObjectManager.\u003CloadUnitResource\u003Ec__Iterator9CD()
    {
      env = env,
      unit = unit,
      \u003C\u0024\u003Eenv = env,
      \u003C\u0024\u003Eunit = unit
    };
  }

  private void releaseUnitResource(BL.Unit unit, BE env) => env.unitResource[unit].cleanup();

  public static void ApplyLightmapUV(GameObject obj, int index)
  {
    LightmapInfo component = obj.GetComponent<LightmapInfo>();
    if (Object.op_Equality((Object) component, (Object) null))
      return;
    Dictionary<string, LightmapInfo.Info> dictionary = ((IEnumerable<LightmapInfo.Info>) component.infos).ToDictionary<LightmapInfo.Info, string, LightmapInfo.Info>((Func<LightmapInfo.Info, string>) (k => k.name), (Func<LightmapInfo.Info, LightmapInfo.Info>) (v => v));
    foreach (Renderer componentsInChild in obj.GetComponentsInChildren<Renderer>(true))
    {
      if (dictionary.ContainsKey(((Object) componentsInChild).name))
      {
        LightmapInfo.Info info = dictionary[((Object) componentsInChild).name];
        componentsInChild.lightmapIndex = index;
        componentsInChild.lightmapScaleOffset = info.lightmapScaleOffset;
      }
    }
  }
}
