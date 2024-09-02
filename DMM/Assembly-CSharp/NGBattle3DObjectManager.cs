// Decompiled with JetBrains decompiler
// Type: NGBattle3DObjectManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class NGBattle3DObjectManager : BattleManagerBase
{
  public readonly string hpBarPrefab_blue_path = "Prefabs/filed_3d_icon/3dicon_bar_blue";
  public readonly string hpBarPrefab_red_path = "Prefabs/filed_3d_icon/3dicon_bar_red";
  public readonly string hpBarPrefab_red_facility_path = "Prefabs/filed_3d_icon/3dicon_bar_red_facility";
  public readonly string buttonPrefab_attack_path = "Prefabs/filed_3d_icon/3dicon_button_attack";
  public readonly string buttonPrefab_heal_path = "Prefabs/filed_3d_icon/3dicon_button_heal";
  public readonly string buttonPrefab_loading_path = "Prefabs/filed_3d_icon/3dicon_botan_loading";
  public readonly string buttonPrefab_wait_path = "Prefabs/filed_3d_icon/3dicon_button_wait";
  public readonly string iconPrefab_leader_path = "Prefabs/filed_3d_icon/3dicon_LEADER";
  public readonly string hpNumber_path = "BattleEffects/field/ef667_hp_number";
  public readonly string damageEffect_path = "BattleEffects/field/ef039_damage";
  public readonly string criticalDamageEffect_path = "BattleEffects/field/ef040_damage_critical";
  public readonly string missEffect_path = "BattleEffects/field/ef042_fe_miss";
  public readonly string criticalEffect_path = "BattleEffects/field/ef041_fe_critical";
  public readonly string skillIconEffect_path = "BattleEffects/field/ef671_fe_skill_icon";
  public readonly string terrainSkillEffect_path = "BattleEffects/field/ef049_terrain_00";
  public readonly string jumpLandingEffect_path = "BattleEffects/field/ef056_fe_landing_00";
  public readonly string fieldJumpEffect_path = "BattleEffects/field/ef056_fe_jump_mark";
  public readonly string pledgeEffect_path = "BattleEffects/field/ef065_fe_pledge";
  public readonly string pvp_effect_player_path = "BattleEffects/field/ef653_fe_Multi_Unit";
  public readonly string pvp_effect_enemy_path = "BattleEffects/field/ef654_fe_Multi_Enemy";
  public readonly string pvp_effect_leader_player_path = "BattleEffects/field/ef655_fe_Multi_UnitRida";
  public readonly string pvp_effect_leader_enemy_path = "BattleEffects/field/ef656_fe_Multi_EnemyRida";
  public readonly string shadow_path = "Prefabs/BattleCommon/unit_shadow";
  private GameObject unitBasePrefabObject;
  private GameObject unitShadowPrefabObject;
  public GameObject objectRoot;
  private GameObject hpBarPrefab_blue;
  private GameObject hpBarPrefab_red;
  private GameObject hpBarPrefab_red_facility;
  private GameObject buttonPrefab_attack;
  private GameObject buttonPrefab_heal;
  private GameObject buttonPrefab_loading;
  private GameObject buttonPrefab_wait;
  private GameObject iconPrefab_leader;
  private GameObject hpNumber;
  private GameObject damageEffect;
  private GameObject criticalDamageEffect;
  private GameObject missEffect;
  private GameObject criticalEffect;
  private GameObject skillIconEffect;
  private GameObject terrainSkillEffect;
  private GameObject jumpLandingEffect;
  private GameObject callEntryEffect;
  private GameObject pvp_effect_player;
  private GameObject pvp_effect_enemy;
  private GameObject pvp_effect_leader_player;
  private GameObject pvp_effect_leader_enemy;
  private int loadMapID = -1;
  private GameObject panelPrefab;
  private Transform spawnRoot;

  public IEnumerator loadStage(BE env, bool setOthers = true)
  {
    NGBattle3DObjectManager battle3DobjectManager = this;
    BL.Stage stage = env.core.stage;
    Future<GameObject> panelF;
    IEnumerator e;
    if ((UnityEngine.Object) battle3DobjectManager.panelPrefab == (UnityEngine.Object) null)
    {
      panelF = Res.Prefabs.battle.Panel.Load<GameObject>();
      e = panelF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.panelPrefab = panelF.Result;
      panelF = (Future<GameObject>) null;
    }
    env.panelResource.cleanup();
    env.dropDataResource.cleanup();
    Battle3DRoot root;
    if (battle3DobjectManager.loadMapID != stage.stage.map.ID)
    {
      env.stageResource.cleanup();
      LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
      LightmapData ld0 = new LightmapData();
      LightmapData ld1 = new LightmapData();
      Future<Texture2D> duelFarF = stage.stage.map.LoadDuelFarLightmap();
      Future<Texture2D> fieldFarF = stage.stage.map.LoadFieldFarLightmap();
      e = duelFarF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = fieldFarF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      ld0.lightmapColor = duelFarF.Result;
      ld1.lightmapColor = fieldFarF.Result;
      LightmapSettings.lightmaps = new LightmapData[2]
      {
        ld0,
        ld1
      };
      RenderSettings.ambientLight = new Color(stage.stage.map.field_ambient_color_r, stage.stage.map.field_ambient_color_g, stage.stage.map.field_ambient_color_b);
      if ((UnityEngine.Object) battle3DobjectManager.objectRoot != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) battle3DobjectManager.objectRoot);
        yield return (object) new WaitForEndOfFrame();
      }
      panelF = stage.stage.map.LoadFieldRoot();
      e = panelF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      GameObject result = panelF.Result;
      battle3DobjectManager.objectRoot = UnityEngine.Object.Instantiate<GameObject>(result);
      Future<GameObject> mapPrefabF = stage.stage.map.LoadFieldMap();
      e = mapPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      env.stageResource[stage].prefab = mapPrefabF.Result;
      root = battle3DobjectManager.objectRoot.GetComponent<Battle3DRoot>();
      yield return (object) new WaitForEndOfFrame();
      battle3DobjectManager.initializeMap(env.stageResource[stage].prefab, root, env);
      battle3DobjectManager.loadMapID = stage.stage.map.ID;
      ld0 = (LightmapData) null;
      ld1 = (LightmapData) null;
      duelFarF = (Future<Texture2D>) null;
      fieldFarF = (Future<Texture2D>) null;
      panelF = (Future<GameObject>) null;
      mapPrefabF = (Future<GameObject>) null;
    }
    else
      root = battle3DobjectManager.objectRoot.GetComponent<Battle3DRoot>();
    e = battle3DobjectManager.initializePanels(battle3DobjectManager.panelPrefab, root, env, setOthers);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) battle3DobjectManager.spawnRoot != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) battle3DobjectManager.spawnRoot);
      yield return (object) new WaitForEndOfFrame();
    }
    battle3DobjectManager.spawnRoot = new GameObject("Units").transform;
    battle3DobjectManager.spawnRoot.parent = root.panelPoint;
    battle3DobjectManager.spawnRoot.localPosition = Vector3.zero;
    battle3DobjectManager.spawnRoot.localScale = Vector3.one;
    root.initialize();
    BattleCameraController controller = Singleton<NGBattleManager>.GetInstance().getController<BattleCameraController>();
    yield return (object) battle3DobjectManager.StartCoroutine(BattleCameraFilter.Create(stage.stage, controller.Camera.gameObject, false));
    battle3DobjectManager.initializeCamera(env);
  }

  public IEnumerator loadUnitResources(BE env)
  {
    List<BL.UnitPosition>.Enumerator enumerator = env.core.unitPositions.value.GetEnumerator();
    while (enumerator.MoveNext())
    {
      BL.UnitPosition up = enumerator.Current;
      IEnumerator e = this.loadUnitResource(up.unit, env, false);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      PlayerUnitSkills[] playerUnitSkillsArray = up.unit.playerUnit.skills;
      int index;
      for (index = 0; index < playerUnitSkillsArray.Length; ++index)
      {
        e = this.loadSkillResource(playerUnitSkillsArray[index].skill, env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      playerUnitSkillsArray = (PlayerUnitSkills[]) null;
      GearGearSkill[] gearGearSkillArray = up.unit.playerUnit.equippedGearOrInitial.skills;
      for (index = 0; index < gearGearSkillArray.Length; ++index)
      {
        e = this.loadSkillResource(gearGearSkillArray[index].skill, env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      gearGearSkillArray = (GearGearSkill[]) null;
      if (up.unit.playerUnit.equippedGear2 != (PlayerItem) null)
      {
        gearGearSkillArray = up.unit.playerUnit.equippedGear2.skills;
        for (index = 0; index < gearGearSkillArray.Length; ++index)
        {
          e = this.loadSkillResource(gearGearSkillArray[index].skill, env);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        gearGearSkillArray = (GearGearSkill[]) null;
      }
      if (up.unit.playerUnit.equippedGear3 != (PlayerItem) null)
      {
        gearGearSkillArray = up.unit.playerUnit.equippedGear3.skills;
        for (index = 0; index < gearGearSkillArray.Length; ++index)
        {
          e = this.loadSkillResource(gearGearSkillArray[index].skill, env);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        gearGearSkillArray = (GearGearSkill[]) null;
      }
      GearReisouSkill[] gearReisouSkillArray;
      if (up.unit.playerUnit.equippedGear != (PlayerItem) null && up.unit.playerUnit.equippedReisou != (PlayerItem) null)
      {
        gearReisouSkillArray = up.unit.playerUnit.equippedReisou.getReisouSkills(up.unit.playerUnit.equippedGear.entity_id);
        for (index = 0; index < gearReisouSkillArray.Length; ++index)
        {
          e = this.loadSkillResource(gearReisouSkillArray[index].skill, env);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        gearReisouSkillArray = (GearReisouSkill[]) null;
      }
      if (up.unit.playerUnit.equippedGear2 != (PlayerItem) null && up.unit.playerUnit.equippedReisou2 != (PlayerItem) null)
      {
        gearReisouSkillArray = up.unit.playerUnit.equippedReisou2.getReisouSkills(up.unit.playerUnit.equippedGear2.entity_id);
        for (index = 0; index < gearReisouSkillArray.Length; ++index)
        {
          e = this.loadSkillResource(gearReisouSkillArray[index].skill, env);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        gearReisouSkillArray = (GearReisouSkill[]) null;
      }
      if (up.unit.playerUnit.equippedGear3 != (PlayerItem) null && up.unit.playerUnit.equippedReisou3 != (PlayerItem) null)
      {
        gearReisouSkillArray = up.unit.playerUnit.equippedReisou3.getReisouSkills(up.unit.playerUnit.equippedGear3.entity_id);
        for (index = 0; index < gearReisouSkillArray.Length; ++index)
        {
          e = this.loadSkillResource(gearReisouSkillArray[index].skill, env);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
        gearReisouSkillArray = (GearReisouSkill[]) null;
      }
      BL.MagicBullet[] magicBulletArray = up.unit.magicBullets;
      for (index = 0; index < magicBulletArray.Length; ++index)
      {
        e = this.loadMagicBulletResource(magicBulletArray[index], env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      magicBulletArray = (BL.MagicBullet[]) null;
      if (up.unit.playerUnit.equippedExtraSkill != null)
      {
        e = this.loadSkillResource(up.unit.playerUnit.equippedExtraSkill.masterData, env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      playerUnitSkillsArray = up.unit.playerUnit.retrofitSkills;
      for (index = 0; index < playerUnitSkillsArray.Length; ++index)
      {
        e = this.loadSkillResource(playerUnitSkillsArray[index].skill, env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      playerUnitSkillsArray = (PlayerUnitSkills[]) null;
      BL.Weapon[] weaponArray = up.unit.optionWeapons;
      for (index = 0; index < weaponArray.Length; ++index)
      {
        e = this.loadSkillResource(weaponArray[index].attackMethod.skill, env);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      weaponArray = (BL.Weapon[]) null;
      List<BL.Skill> source = new List<BL.Skill>((IEnumerable<BL.Skill>) up.unit.skills);
      if (up.unit.hasOugi)
        source.Add(up.unit.ougi);
      if (up.unit.hasSEASkill)
        source.Add(up.unit.SEASkill);
      Future<GameObject> tmpF;
      if (source.Any<BL.Skill>((Func<BL.Skill, bool>) (skill => ((IEnumerable<BattleskillEffect>) skill.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.EffectLogic.Enum == BattleskillEffectLogicEnum.jump)))))
      {
        if ((UnityEngine.Object) this.jumpLandingEffect == (UnityEngine.Object) null)
        {
          tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(this.jumpLandingEffect_path);
          e = tmpF.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          this.jumpLandingEffect = tmpF.Result;
          tmpF = (Future<GameObject>) null;
        }
        NGBattleManager bm = Singleton<NGBattleManager>.GetInstance();
        if ((UnityEngine.Object) bm.fieldJumpEffectPrefab == (UnityEngine.Object) null)
        {
          tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(this.fieldJumpEffect_path);
          e = tmpF.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          bm.fieldJumpEffectPrefab = tmpF.Result;
          tmpF = (Future<GameObject>) null;
        }
        bm = (NGBattleManager) null;
      }
      if (up.unit.isCallEntryReserve && (UnityEngine.Object) this.callEntryEffect == (UnityEngine.Object) null)
      {
        tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(this.pledgeEffect_path);
        e = tmpF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        this.callEntryEffect = tmpF.Result;
        tmpF = (Future<GameObject>) null;
      }
      up = (BL.UnitPosition) null;
    }
    enumerator = new List<BL.UnitPosition>.Enumerator();
  }

  public override IEnumerator initialize(BattleInfo battleInfo, BE env_ = null)
  {
    NGBattle3DObjectManager battle3DobjectManager = this;
    NGBattleManager bm = Singleton<NGBattleManager>.GetInstance();
    BE env = env_ ?? bm.environment;
    ResourceManager rm = Singleton<ResourceManager>.GetInstance();
    Future<GameObject> tmpF = rm.Load<GameObject>(battle3DobjectManager.hpBarPrefab_blue_path);
    IEnumerator e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.hpBarPrefab_blue = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.hpBarPrefab_red_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.hpBarPrefab_red = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.hpBarPrefab_red_facility_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.hpBarPrefab_red_facility = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.buttonPrefab_attack_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.buttonPrefab_attack = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.buttonPrefab_heal_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.buttonPrefab_heal = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.buttonPrefab_loading_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.buttonPrefab_loading = tmpF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.buttonPrefab_wait_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.buttonPrefab_wait = tmpF.Result;
    if (bm.isOvo)
    {
      tmpF = rm.Load<GameObject>(battle3DobjectManager.iconPrefab_leader_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.iconPrefab_leader = tmpF.Result;
    }
    tmpF = rm.Load<GameObject>(battle3DobjectManager.hpNumber_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.hpNumber = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.damageEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.damageEffect = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.criticalDamageEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.criticalDamageEffect = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.missEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.missEffect = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.criticalEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.criticalEffect = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.skillIconEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.skillIconEffect = tmpF.Result;
    tmpF = Singleton<ResourceManager>.GetInstance().Load<GameObject>(battle3DobjectManager.terrainSkillEffect_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.terrainSkillEffect = tmpF.Result;
    if (bm.isOvo)
    {
      tmpF = rm.Load<GameObject>(battle3DobjectManager.pvp_effect_player_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.pvp_effect_player = tmpF.Result;
      tmpF = rm.Load<GameObject>(battle3DobjectManager.pvp_effect_enemy_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.pvp_effect_enemy = tmpF.Result;
      tmpF = rm.Load<GameObject>(battle3DobjectManager.pvp_effect_leader_player_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.pvp_effect_leader_player = tmpF.Result;
      tmpF = rm.Load<GameObject>(battle3DobjectManager.pvp_effect_leader_enemy_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      battle3DobjectManager.pvp_effect_leader_enemy = tmpF.Result;
    }
    Future<GameObject> unitBaseF = Res.Prefabs.battle.UnitBase.Load<GameObject>();
    e = unitBaseF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.unitBasePrefabObject = unitBaseF.Result;
    tmpF = rm.Load<GameObject>(battle3DobjectManager.shadow_path);
    e = tmpF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    battle3DobjectManager.unitShadowPrefabObject = tmpF.Result;
    e = battle3DobjectManager.loadStage(env);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = battle3DobjectManager.loadUnitResources(env);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    BattleskillAilmentEffect[] battleskillAilmentEffectArray = MasterData.BattleskillAilmentEffectList;
    for (int index = 0; index < battleskillAilmentEffectArray.Length; ++index)
    {
      BattleskillAilmentEffect ailmentEffect = battleskillAilmentEffectArray[index];
      e = battle3DobjectManager.loadAilmentSkillResource(ailmentEffect, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    battleskillAilmentEffectArray = (BattleskillAilmentEffect[]) null;
    foreach (BL.Item obj in env.core.itemList.value)
    {
      e = battle3DobjectManager.loadItemResource(obj, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    e = battle3DobjectManager.spawns(env.core.unitPositions.value, env, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    BattleskillSkill skill1;
    if (env.core.playerCallSkillState.skillId != 0 && MasterData.BattleskillSkill.TryGetValue(env.core.playerCallSkillState.skillId, out skill1))
    {
      e = battle3DobjectManager.loadSkillResource(skill1, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    BattleskillSkill skill2;
    if (env.core.enemyCallSkillState.skillId != 0 && MasterData.BattleskillSkill.TryGetValue(env.core.enemyCallSkillState.skillId, out skill2))
    {
      e = battle3DobjectManager.loadSkillResource(skill2, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    battle3DobjectManager.gameObject.AddComponent<BattleFieldAttribute>();
  }

  public override IEnumerator cleanup()
  {
    this.destroy3DObjects();
    LightmapSettings.lightmaps = new LightmapData[0];
    BattleCameraFilter.LatestCameraFilterResource = "";
    BattleCameraFilter.LatestCameraFilterResourceDuel = "";
    yield break;
  }

  private void destroy3DObjects()
  {
    if ((UnityEngine.Object) this.objectRoot != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.objectRoot);
      this.objectRoot = (GameObject) null;
    }
    if ((UnityEngine.Object) this.spawnRoot != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.spawnRoot);
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
    this.hpBarPrefab_red_facility = (GameObject) null;
    this.buttonPrefab_attack = (GameObject) null;
    this.buttonPrefab_heal = (GameObject) null;
    this.buttonPrefab_loading = (GameObject) null;
    this.buttonPrefab_wait = (GameObject) null;
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
    if (!((UnityEngine.Object) this.objectRoot != (UnityEngine.Object) null))
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
    GameObject attachPointPrefab,
    GameObject bikePrefab,
    GameObject equipPrefab_a,
    GameObject equipPrefab_b,
    GameObject gearPrefab,
    BE.UnitResource.Attachment unitEffect,
    bool leftHand,
    bool isDualWield,
    GameObject hpBarPrefab,
    GameObject leaderIconPrefab = null,
    GameObject pvpPrefab = null,
    bool isNotAngle = false,
    bool isView = true)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    BE environment = instance.environment;
    GameObject gameObject1 = UnityEngine.Object.Instantiate<GameObject>(this.unitBasePrefabObject);
    Transform transform = new GameObject("nonTransform").transform;
    transform.parent = gameObject1.transform;
    transform.localPosition = Vector3.zero;
    if (isView)
    {
      if ((UnityEngine.Object) hpBarPrefab != (UnityEngine.Object) null)
        hpBarPrefab.Clone(transform);
      if ((UnityEngine.Object) this.hpNumber != (UnityEngine.Object) null)
        this.hpNumber.Clone(transform);
      if ((UnityEngine.Object) leaderIconPrefab != (UnityEngine.Object) null)
        leaderIconPrefab.Clone(transform);
    }
    GameObject gameObject2 = new GameObject("rot");
    gameObject2.transform.parent = gameObject1.transform;
    gameObject2.transform.localPosition = isNotAngle ? Vector3.zero : instance.unitPositionOffsetValue;
    gameObject2.transform.localScale = Vector3.one;
    gameObject2.transform.localRotation = Quaternion.Euler(0.0f, direction, 0.0f);
    GameObject gameObject3 = new GameObject("angle");
    gameObject3.transform.parent = gameObject2.transform;
    gameObject3.transform.localScale = Vector3.one;
    gameObject3.transform.localPosition = Vector3.zero;
    gameObject3.transform.localRotation = Quaternion.identity;
    if (!isNotAngle)
      gameObject3.AddComponent<UnitAngle>();
    gameObject1.transform.parent = this.spawnRoot;
    if (isView)
    {
      GameObject unitObject = this.createUnitObject(gameObject3.transform, unitPrefab, bikePrefab, equipPrefab_a, equipPrefab_b, gearPrefab, unitEffect, leftHand, isDualWield);
      if ((UnityEngine.Object) unitObject != (UnityEngine.Object) null && (UnityEngine.Object) pvpPrefab != (UnityEngine.Object) null)
        pvpPrefab.Clone(transform);
      if ((UnityEngine.Object) unitObject != (UnityEngine.Object) null && (UnityEngine.Object) attachPointPrefab != (UnityEngine.Object) null)
      {
        foreach (Transform componentsInChild in unitObject.GetComponentsInChildren<Transform>())
        {
          if (componentsInChild.name == "attach_point")
          {
            GameObject gameObject4 = attachPointPrefab.Clone(componentsInChild);
            gameObject4.transform.localPosition = Vector3.zero;
            gameObject4.transform.localScale = Vector3.one;
            gameObject4.transform.localRotation = Quaternion.identity;
            break;
          }
        }
      }
    }
    else
      new GameObject("unitObject")
      {
        transform = {
          parent = gameObject3.transform,
          localScale = Vector3.one,
          localPosition = Vector3.zero,
          localRotation = Quaternion.identity
        }
      }.AddComponent<clipEffectPlayer>();
    BL.Panel fieldPanel = environment.core.getFieldPanel(row, column);
    BE.PanelResource panelResource = environment.panelResource[fieldPanel];
    gameObject1.transform.position = new Vector3(panelResource.gameObject.transform.position.x, panelResource.gameObject.GetComponent<BattlePanelParts>().getHeight(), panelResource.gameObject.transform.position.z);
    return gameObject1;
  }

  public GameObject createUnitObject(
    Transform parent,
    GameObject unitPrefab,
    GameObject bikePrefab,
    GameObject equipPrefab_a,
    GameObject equipPrefab_b,
    GameObject gearPrefab,
    BE.UnitResource.Attachment unitEffect,
    bool leftHand,
    bool isDualWield)
  {
    GameObject self = (UnityEngine.Object) bikePrefab != (UnityEngine.Object) null ? bikePrefab : unitPrefab;
    if (!((UnityEngine.Object) self != (UnityEngine.Object) null))
      return (GameObject) null;
    GameObject go1 = self.Clone(parent);
    if ((UnityEngine.Object) go1.GetComponent<clipEffectPlayer>() == (UnityEngine.Object) null)
      go1.AddComponent<clipEffectPlayer>();
    if ((UnityEngine.Object) bikePrefab != (UnityEngine.Object) null)
    {
      Transform childInFind = go1.transform.GetChildInFind("ridePoint");
      if ((UnityEngine.Object) childInFind != (UnityEngine.Object) null)
      {
        GameObject go2 = unitPrefab.Clone(childInFind);
        if ((UnityEngine.Object) go2.GetComponent<clipEffectPlayer>() == (UnityEngine.Object) null)
          go2.AddComponent<clipEffectPlayer>();
        if ((UnityEngine.Object) unitEffect.prefab != (UnityEngine.Object) null)
          unitEffect.prefab.Clone(this.getEffectPoint(go2, unitEffect.node));
      }
    }
    else if ((UnityEngine.Object) unitEffect.prefab != (UnityEngine.Object) null)
      unitEffect.prefab.Clone(this.getEffectPoint(go1, unitEffect.node));
    if ((UnityEngine.Object) equipPrefab_a != (UnityEngine.Object) null)
    {
      Transform childInFind = go1.transform.GetChildInFind("equippoint_a");
      if ((UnityEngine.Object) childInFind != (UnityEngine.Object) null)
        equipPrefab_a.Clone(childInFind);
    }
    if ((UnityEngine.Object) equipPrefab_b != (UnityEngine.Object) null)
    {
      Transform childInFind = go1.transform.GetChildInFind("equippoint_b");
      if ((UnityEngine.Object) childInFind != (UnityEngine.Object) null)
        equipPrefab_b.Clone(childInFind);
    }
    if ((UnityEngine.Object) gearPrefab != (UnityEngine.Object) null)
    {
      if (isDualWield)
      {
        Transform childInFind1 = go1.transform.GetChildInFind("weaponl");
        if ((bool) (UnityEngine.Object) childInFind1)
          gearPrefab.Clone(childInFind1);
        Transform childInFind2 = go1.transform.GetChildInFind("weaponr");
        if ((bool) (UnityEngine.Object) childInFind2)
          gearPrefab.Clone(childInFind2);
      }
      else
      {
        Transform childInFind = go1.transform.GetChildInFind(leftHand ? "weaponl" : "weaponr");
        if ((bool) (UnityEngine.Object) childInFind)
          gearPrefab.Clone(childInFind);
      }
    }
    return go1;
  }

  private Transform getEffectPoint(GameObject go, string effect_node)
  {
    Transform transform = !string.IsNullOrEmpty(effect_node) ? go.transform.GetChildInFind(effect_node) : (Transform) null;
    if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
      transform = go.transform.GetChildInFind("Bip");
    if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
      transform = go.transform.GetChildInFind("bip");
    return transform;
  }

  private bool IsLeaderUnit(BL.Unit unit) => Singleton<NGBattleManager>.GetInstance().isOvo && !unit.isFacility && unit.is_leader;

  public GameObject spawnUnit_(BL.UnitPosition up)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    BE environment = instance.environment;
    BE.UnitResource unitResource = environment.unitResource[up.unit];
    bool flag = environment.core.getForceID(up.unit) == BL.ForceID.player;
    GameObject gameObject = this.spawnObject(up.row, up.column, up.direction, unitResource.prefab, unitResource.attachPointPrefab, unitResource.bikePrefab, unitResource.equipPrefab_a, unitResource.equipPrefab_b, environment.weaponResource[up.unit.weapon].prefab, unitResource.unitEffect, up.unit.gearLeftHand, up.unit.gearDualWield, flag ? this.hpBarPrefab_blue : (up.unit.isFacility ? this.hpBarPrefab_red_facility : this.hpBarPrefab_red), this.IsLeaderUnit(up.unit) ? this.iconPrefab_leader : (GameObject) null, instance.isOvo ? (flag ? (up.unit.is_leader ? this.pvp_effect_leader_player : this.pvp_effect_player) : (up.unit.is_leader ? this.pvp_effect_leader_enemy : this.pvp_effect_enemy)) : (GameObject) null, up.unit.isFacility, up.unit.isView);
    BattleUnitParts component = gameObject.GetComponent<BattleUnitParts>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      clipEffectPlayer componentInChildren = gameObject.GetComponentInChildren<clipEffectPlayer>();
      if (up.unit.isView)
        component.setUnitPosition(up, componentInChildren.gameObject, up.unit.isFacility ? (GameObject) null : this.unitShadowPrefabObject, this.damageEffect, this.criticalDamageEffect, this.missEffect, this.criticalEffect, this.skillIconEffect, this.terrainSkillEffect, this.jumpLandingEffect, this.callEntryEffect);
      else
        component.setUnitPosition(up, componentInChildren.gameObject);
    }
    up.unit.isEnable = up.unit.isSpawned;
    return gameObject;
  }

  public static GameObject hitObject(Camera cam, Vector2 pos, string layer)
  {
    RaycastHit raycastHit = new RaycastHit();
    Ray ray = cam.ScreenPointToRay((Vector3) pos);
    int num = 1 << LayerMask.NameToLayer(layer);
    ref RaycastHit local = ref raycastHit;
    int layerMask = num;
    return Physics.Raycast(ray, out local, 100f, layerMask) ? raycastHit.collider.gameObject : (GameObject) null;
  }

  public static BL.Panel hitPanel(Vector2 pos)
  {
    Camera[] componentsInChildren = Singleton<NGBattleManager>.GetInstance().battleCamera.GetComponentsInChildren<Camera>(true);
    if (componentsInChildren != null && componentsInChildren.Length != 0)
    {
      GameObject gameObject = NGBattle3DObjectManager.hitObject(componentsInChildren[0], pos, "Panel");
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        return gameObject.GetComponent<BattlePanelParts>().getPanel();
    }
    return (BL.Panel) null;
  }

  public void setButton(BL.Panel panel, bool isHeal, bool isLoading)
  {
    BE.PanelResource panelResource = Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel];
    if (isLoading)
      panelResource.gameObject.GetComponent<BattlePanelParts>().setLoadingButton(this.buttonPrefab_loading);
    else if (isHeal)
      panelResource.gameObject.GetComponent<BattlePanelParts>().setHealButton(this.buttonPrefab_heal);
    else
      panelResource.gameObject.GetComponent<BattlePanelParts>().setAttackButton(this.buttonPrefab_attack);
  }

  public void hideButton(BL.Panel panel) => Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel].gameObject.GetComponent<BattlePanelParts>().hideButton();

  public void showWaitButton(BL.Panel panel) => Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel].gameObject.GetComponent<BattlePanelParts>().setWaitButton(this.buttonPrefab_wait);

  public void hideWaitButton(BL.Panel panel) => Singleton<NGBattleManager>.GetInstance().environment.panelResource[panel].gameObject.GetComponent<BattlePanelParts>().hideWaitButton();

  private void initializeMap(GameObject mapPrefab, Battle3DRoot root, BE env) => NGBattle3DObjectManager.ApplyLightmapUV(mapPrefab.Clone(root.mapPoint), 1);

  private void initializeCamera(BE env)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    instance.getController<BattleCameraController>().sightDistance = instance.sightDistances[env.core.sight.value];
  }

  public IEnumerator initializePanels(
    GameObject panelPrefab,
    Battle3DRoot root,
    BE env,
    bool setOthers = true)
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    BL.Stage stage = env.core.stage;
    float panelSize = instance.panelSize;
    root.panelPoint.position = new Vector3(((float) (stage.mapOffsetColumn - 1) - 20f) * panelSize, 0.0f, ((float) (stage.mapOffsetRow - 1) - 20f) * panelSize);
    IEnumerator e = this.createPanels(panelPrefab, root, env, setOthers);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator createPanels(
    GameObject prefab,
    Battle3DRoot root,
    BE env,
    bool setOthers)
  {
    ResourceManager instance = Singleton<ResourceManager>.GetInstance();
    int height = env.core.getFieldHeight();
    int width = env.core.getFieldWidth();
    Future<GameObject> fieldEventPrefabF = (Future<GameObject>) null;
    Future<GameObject> GuardAreaPrefabF = (Future<GameObject>) null;
    Future<GameObject> TargetAreaPrefabF = (Future<GameObject>) null;
    if (setOthers)
    {
      fieldEventPrefabF = instance.Load<GameObject>("BattleEffects/field/ef018_get_item");
      IEnumerator e = fieldEventPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      if (env.core.condition.isExistLoseAreaCondition)
      {
        GuardAreaPrefabF = Res.Animations.battle_effect.GuardArea.Load<GameObject>();
        e = GuardAreaPrefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      if (env.core.condition.isExistWinAreaCondition)
      {
        TargetAreaPrefabF = Res.Animations.battle_effect.TargetArea.Load<GameObject>();
        e = TargetAreaPrefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    NGBattleManager bm = Singleton<NGBattleManager>.GetInstance();
    bool flag = false;
    foreach (Component component in root.panelPoint)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
      flag = true;
    }
    if (flag)
      yield return (object) new WaitForEndOfFrame();
    GameObject gameObject1 = new GameObject("Panels");
    gameObject1.transform.parent = root.panelPoint;
    gameObject1.transform.localPosition = Vector3.zero;
    gameObject1.transform.localScale = Vector3.one;
    for (int row = 0; row < height; ++row)
    {
      for (int column = 0; column < width; ++column)
      {
        BL.Panel fieldPanel = env.core.getFieldPanel(row, column);
        GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(prefab);
        gameObject2.transform.parent = gameObject1.transform;
        gameObject2.transform.localPosition = NGBattle3DObjectManager.create3DPosition(row, column);
        gameObject2.transform.localScale = new Vector3(bm.panelSize, bm.panelSize, bm.panelSize);
        gameObject2.GetComponent<PanelInit>().Init();
        if (setOthers && fieldPanel.fieldEvent != null)
          env.dropDataResource[fieldPanel.fieldEvent].prefab = fieldEventPrefabF.Result;
        BattlePanelParts component = gameObject2.GetComponent<BattlePanelParts>();
        component.setPanel(fieldPanel);
        if (setOthers)
        {
          component.initButtons(this.buttonPrefab_attack, this.buttonPrefab_heal, this.buttonPrefab_loading, this.buttonPrefab_wait);
          if (env.core.condition.isExistLoseAreaCondition && fieldPanel.checkVictoryConditionAtrribute(BL.PanelVictoryConditionAtrribute.lose_enemy_on_panel))
            component.setGuardArea(GuardAreaPrefabF.Result);
          if (env.core.condition.isExistWinAreaCondition && fieldPanel.checkVictoryConditionAtrribute(BL.PanelVictoryConditionAtrribute.win_player_on_panel))
            component.setGuardArea(TargetAreaPrefabF.Result);
        }
      }
    }
  }

  public IEnumerator spawns(List<BL.UnitPosition> units, BE env, bool wait = true)
  {
    foreach (BL.UnitPosition unit in units)
    {
      this.spawnUnit_(unit);
      if (wait)
        yield return (object) null;
    }
  }

  private IEnumerator loadSkillResource(BattleskillFieldEffect effectData, BE env)
  {
    BE.SkillResource skillR = env.skillResource[effectData.ID];
    Future<GameObject> effectPrefabF;
    IEnumerator e;
    if ((UnityEngine.Object) skillR.effectPrefab == (UnityEngine.Object) null)
    {
      effectPrefabF = effectData.LoadFieldEffectPrefab();
      e = effectPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      skillR.effectPrefab = effectPrefabF.Result;
      effectPrefabF = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) skillR.targetEffectPrefab == (UnityEngine.Object) null)
    {
      effectPrefabF = effectData.LoadFieldTargetEffectPrefab();
      e = effectPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      skillR.targetEffectPrefab = effectPrefabF.Result;
      effectPrefabF = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) skillR.invokedEffectPrefab == (UnityEngine.Object) null)
    {
      effectPrefabF = effectData.LoadFieldInvokedEffectPrefab();
      e = effectPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      skillR.invokedEffectPrefab = effectPrefabF.Result;
      effectPrefabF = (Future<GameObject>) null;
    }
  }

  private IEnumerator loadSkillResource(BattleskillSkill skill, BE env)
  {
    IEnumerator e;
    if (skill.field_effect != null)
    {
      e = this.loadSkillResource(skill.field_effect, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    if (skill.passive_effect != null)
    {
      e = this.loadSkillResource(skill.passive_effect, env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  private IEnumerator loadAilmentSkillResource(
    BattleskillAilmentEffect ailmentEffect,
    BE env)
  {
    BE.AilmentSkillResource skillR = env.ailmentSkillResource[ailmentEffect.ID];
    if ((UnityEngine.Object) skillR.targetEffectPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> targetEffectPrefabF = ailmentEffect.LoadFieldAilmentEffectPrefab();
      IEnumerator e = targetEffectPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      skillR.targetEffectPrefab = targetEffectPrefabF.Result;
      targetEffectPrefabF = (Future<GameObject>) null;
    }
  }

  private IEnumerator loadItemResource(BL.Item item, BE env)
  {
    BE.ItemResource itemR = env.itemResource[item.itemId];
    Future<GameObject> targetEffectPrefabF = item.item.skill.LoadFieldTargetEffectPrefab();
    IEnumerator e = targetEffectPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    itemR.targetEffectPrefab = targetEffectPrefabF.Result;
    if ((UnityEngine.Object) itemR.targetEffectPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> prefabF = Singleton<ResourceManager>.GetInstance().Load<GameObject>("BattleEffects/field/ef024_heal_l");
      e = prefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      itemR.targetEffectPrefab = prefabF.Result;
      prefabF = (Future<GameObject>) null;
    }
  }

  private IEnumerator loadMagicBulletResource(BL.MagicBullet mb, BE env)
  {
    IEnumerator e = this.loadSkillResource(mb.skill, env);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator reloadInBattleUnitResource(BL.Unit unit, BE env, bool nonMetamor)
  {
    if (unit.isView)
      yield return (object) this.loadUnitResource(unit, env, nonMetamor);
  }

  private IEnumerator loadUnitResource(BL.Unit unit, BE env, bool nonMetamor)
  {
    if (unit.isView)
    {
      BE.UnitResource unitR = env.unitResource[unit];
      if (!((UnityEngine.Object) unitR.prefab != (UnityEngine.Object) null))
      {
        int num;
        if (!nonMetamor)
        {
          SkillMetamorphosis metamorphosis = unit.metamorphosis;
          num = metamorphosis != null ? metamorphosis.metamorphosis_id : 0;
        }
        else
          num = 0;
        int metamorId = num;
        Future<GameObject> unitF = unit.playerUnit.LoadModelField(metamorId);
        IEnumerator e = unitF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        unitR.prefab = unitF.Result;
        if (unit.isFacility)
        {
          FacilityLevel facilityLevel = ((IEnumerable<FacilityLevel>) MasterData.FacilityLevelList).FirstOrDefault<FacilityLevel>((Func<FacilityLevel, bool>) (x => x.level == unit.playerUnit.level && x.unit_UnitUnit == unit.unitId));
          if (facilityLevel != null)
          {
            foreach (UnityEngine.Object componentsInChild in unitR.prefab.GetComponentsInChildren<Transform>())
            {
              if (componentsInChild.name == "attach_point")
              {
                Future<GameObject> f = Singleton<ResourceManager>.GetInstance().Load<GameObject>(string.Format("Facility/3D/{0}", (object) facilityLevel.attach_point_name));
                e = f.Wait();
                while (e.MoveNext())
                  yield return e.Current;
                e = (IEnumerator) null;
                unitR.attachPointPrefab = f.Result;
                break;
              }
            }
          }
        }
        PlayerUnit playerUnit = unit.playerUnit;
        Future<GameObject> bikeF = playerUnit.unit.LoadModelFieldVehicle();
        Future<GameObject> equipF = playerUnit.unit.LoadModelFieldEquip();
        Future<GameObject> equipbF = playerUnit.unit.LoadModelFieldEquipB();
        Future<GameObject> gearF = playerUnit.LoadEquippedNonShieldGearModel();
        Future<UnityEngine.Material> normalFaceMatF = playerUnit.LoadFieldNormalFaceMaterial(metamorId);
        Future<GameObject> unitEffectF = playerUnit.LoadModelUnitAuraEffect(out unitR.unitEffect.node, metamorId, true);
        e = bikeF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        e = equipF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        e = equipbF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        e = gearF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        e = normalFaceMatF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        e = unitEffectF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        env.weaponResource[unit.weapon].prefab = gearF.Result;
        unitR.bikePrefab = bikeF.Result;
        unitR.equipPrefab_a = equipF.Result;
        unitR.equipPrefab_b = equipbF.Result;
        unitR.unitEffect.prefab = unitEffectF.Result;
        unitR.faceMaterial = normalFaceMatF.Result;
      }
    }
  }

  private void releaseUnitResource(BL.Unit unit, BE env) => env.unitResource[unit].cleanup();

  public static void ApplyLightmapUV(GameObject obj, int index)
  {
    LightmapInfo component = obj.GetComponent<LightmapInfo>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    Dictionary<string, LightmapInfo.Info> dictionary = ((IEnumerable<LightmapInfo.Info>) component.infos).ToDictionary<LightmapInfo.Info, string, LightmapInfo.Info>((Func<LightmapInfo.Info, string>) (k => k.name), (Func<LightmapInfo.Info, LightmapInfo.Info>) (v => v));
    foreach (Renderer componentsInChild in obj.GetComponentsInChildren<Renderer>(true))
    {
      if (dictionary.ContainsKey(componentsInChild.name))
      {
        LightmapInfo.Info info = dictionary[componentsInChild.name];
        componentsInChild.lightmapIndex = index;
        componentsInChild.lightmapScaleOffset = info.lightmapScaleOffset;
      }
    }
  }

  public IEnumerator initializeForEdit(BE env_ = null)
  {
    using (ScopeTimer timer = new ScopeTimer("NGBattle3DObjectManager.initializeForEdit"))
    {
      NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
      BE env = env_ ?? instance.environment;
      timer.Time(1);
      ResourceManager rm = Singleton<ResourceManager>.GetInstance();
      Future<GameObject> tmpF = rm.Load<GameObject>(this.hpBarPrefab_blue_path);
      IEnumerator e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.hpBarPrefab_blue = tmpF.Result;
      tmpF = rm.Load<GameObject>(this.hpBarPrefab_red_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.hpBarPrefab_red = tmpF.Result;
      tmpF = rm.Load<GameObject>(this.buttonPrefab_attack_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.buttonPrefab_attack = tmpF.Result;
      tmpF = rm.Load<GameObject>(this.buttonPrefab_heal_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.buttonPrefab_heal = tmpF.Result;
      tmpF = rm.Load<GameObject>(this.buttonPrefab_loading_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.buttonPrefab_loading = tmpF.Result;
      tmpF = rm.Load<GameObject>(this.hpNumber_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.hpNumber = tmpF.Result;
      Future<GameObject> unitBaseF = Res.Prefabs.battle.UnitBase.Load<GameObject>();
      e = unitBaseF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.unitBasePrefabObject = unitBaseF.Result;
      tmpF = rm.Load<GameObject>(this.shadow_path);
      e = tmpF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.unitShadowPrefabObject = tmpF.Result;
      timer.Time(2);
      e = this.loadStageForEdit(env);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      timer.Time(3);
      env.core.playerUnits = new BL.ClassValue<List<BL.Unit>>(new List<BL.Unit>());
      env.core.unitPositions = new BL.ClassValue<List<BL.UnitPosition>>(new List<BL.UnitPosition>());
      env = (BE) null;
      tmpF = (Future<GameObject>) null;
      rm = (ResourceManager) null;
      unitBaseF = (Future<GameObject>) null;
    }
  }

  public IEnumerator loadStageForEdit(BE env)
  {
    BL.Stage stage = env.core.stage;
    Future<GameObject> panelF;
    IEnumerator e;
    if ((UnityEngine.Object) this.panelPrefab == (UnityEngine.Object) null)
    {
      panelF = new ResourceObject("Prefabs/battle/EditPanel").Load<GameObject>();
      e = panelF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.panelPrefab = panelF.Result;
      panelF = (Future<GameObject>) null;
    }
    env.panelResource.cleanup();
    env.dropDataResource.cleanup();
    Battle3DRoot root;
    if (this.loadMapID != stage.stage.map.ID)
    {
      env.stageResource.cleanup();
      LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
      LightmapData ld0 = new LightmapData();
      LightmapData ld1 = new LightmapData();
      Future<Texture2D> duelFarF = stage.stage.map.LoadDuelFarLightmap();
      Future<Texture2D> fieldFarF = stage.stage.map.LoadFieldFarLightmap();
      e = duelFarF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = fieldFarF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      ld0.lightmapColor = duelFarF.Result;
      ld1.lightmapColor = fieldFarF.Result;
      LightmapSettings.lightmaps = new LightmapData[2]
      {
        ld0,
        ld1
      };
      RenderSettings.ambientLight = new Color(stage.stage.map.field_ambient_color_r, stage.stage.map.field_ambient_color_g, stage.stage.map.field_ambient_color_b);
      if ((UnityEngine.Object) this.objectRoot != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.objectRoot);
        yield return (object) new WaitForEndOfFrame();
      }
      panelF = stage.stage.map.LoadFieldRoot();
      e = panelF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.objectRoot = UnityEngine.Object.Instantiate<GameObject>(panelF.Result);
      List<Camera> list = ((IEnumerable<Camera>) this.objectRoot.GetComponentsInChildren<Camera>()).Where<Camera>((Func<Camera, bool>) (c => c.gameObject.name.StartsWith("3D Camera"))).ToList<Camera>();
      Camera camera1 = list.FirstOrDefault<Camera>((Func<Camera, bool>) (c => c.gameObject.name.EndsWith("Front")));
      if ((UnityEngine.Object) camera1 != (UnityEngine.Object) null)
      {
        float num = -1f - camera1.depth;
        foreach (Camera camera2 in list)
          camera2.depth += num;
        camera1.clearFlags = CameraClearFlags.Depth;
      }
      Future<GameObject> mapPrefabF = stage.stage.map.LoadFieldMap();
      e = mapPrefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      env.stageResource[stage].prefab = mapPrefabF.Result;
      root = this.objectRoot.GetComponent<Battle3DRoot>();
      yield return (object) new WaitForEndOfFrame();
      this.initializeMap(env.stageResource[stage].prefab, root, env);
      this.loadMapID = stage.stage.map.ID;
      ld0 = (LightmapData) null;
      ld1 = (LightmapData) null;
      duelFarF = (Future<Texture2D>) null;
      fieldFarF = (Future<Texture2D>) null;
      panelF = (Future<GameObject>) null;
      mapPrefabF = (Future<GameObject>) null;
    }
    else
      root = this.objectRoot.GetComponent<Battle3DRoot>();
    e = this.initializePanels(this.panelPrefab, root, env, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) this.spawnRoot != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.spawnRoot);
      yield return (object) new WaitForEndOfFrame();
    }
    this.spawnRoot = new GameObject("Units").transform;
    this.spawnRoot.parent = root.panelPoint;
    this.spawnRoot.localPosition = Vector3.zero;
    this.spawnRoot.localScale = Vector3.one;
    root.initialize();
    this.initializeCamera(env);
  }
}
