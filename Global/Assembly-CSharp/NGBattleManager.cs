// Decompiled with JetBrains decompiler
// Type: NGBattleManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGBattleManager : Singleton<NGBattleManager>
{
  public string topSceneNormal = "battleUI_01";
  public string topScenePvp = "battleUI_pvp";
  public string topSceneEarth = "battleUI_51";
  public string duelScene;
  public string storyScene;
  public bool noDuelScene;
  private GameObject managers;
  private GameObject effects;
  private System.Type[] managerList;
  private BattleInfo mBattleInfo;
  private string mErrorString;
  public bool initialized;
  private BE environment_;
  private PVPManager _pvpManager;
  public Vector2 mapOffset = new Vector2(-10f, -5f);
  public float unitAngle = -40f;
  public float panelSize = 2f;
  public GameObject battleCamera;
  public Vector3 cameraPositionOffset = new Vector3(0.0f, 0.0f, 5f);
  public float cameraAngle = -40f;
  public float cameraSwipeTime = 0.3f;
  public float cameraSwipeVelocity = 1f;
  public float cameraSwipeMove = 6f;
  public float defaultUnitSpeed = 4f;
  public float[] sightDistances;
  private string effectPrefabPath = "Animations/battle_effect/{0}";
  public BattleEffects battleEffects;
  public bool isSuspend;
  private Battle01SelectNode selectNode;
  private NGBattleManager.OrderValues orderValues;
  public bool mIsBattleEnable;

  public string topScene
  {
    get
    {
      if (this.isPvp)
        return this.topScenePvp;
      return this.isEarth ? this.topSceneEarth : this.topSceneNormal;
    }
  }

  public BattleInfo battleInfo
  {
    get => this.mBattleInfo;
    set => this.mBattleInfo = value;
  }

  public bool isError => this.mErrorString != null;

  public string errorString
  {
    get => this.mErrorString;
    set => this.mErrorString = value;
  }

  public BE environment
  {
    get => this.environment_;
    set => this.environment_ = value;
  }

  public bool isPvp
  {
    get
    {
      if (Object.op_Inequality((Object) this._pvpManager, (Object) null))
        return true;
      return this.mBattleInfo != null && this.mBattleInfo.pvp;
    }
  }

  public PVPManager pvpManager => this._pvpManager;

  public bool isOvo => this.isPvp;

  public IGameEngine gameEngine
  {
    get
    {
      return Object.op_Inequality((Object) this._pvpManager, (Object) null) ? (IGameEngine) this._pvpManager : (IGameEngine) null;
    }
  }

  public bool useGameEngine => this.gameEngine != null;

  public bool isEarth => this.mBattleInfo != null && this.mBattleInfo.isEarthMode;

  public void setUiNode(Battle01SelectNode node) => this.selectNode = node;

  public int order
  {
    set => this.orderValues = new NGBattleManager.OrderValues(value, this);
    get
    {
      if (this.orderValues == null)
        this.orderValues = new NGBattleManager.OrderValues(1, this);
      return this.orderValues.order;
    }
  }

  public float unitAngleValue => this.orderValues.unitAngleValue;

  public float cameraAngleYValue => this.orderValues.cameraAngleYValue;

  public Vector3 cameraPositionOffsetValue => this.orderValues.cameraPositionOffsetValue;

  public Vector3 unitPositionOffsetValue => this.orderValues.unitPositionOffsetValue;

  public Vector3 unitShadowOffsetValue => this.orderValues.unitShadowOffsetValue;

  public Quaternion unitNonTransformRotationValue => this.orderValues.unitNonTransformRotationValue;

  public void setManagers(GameObject o) => this.managers = o;

  protected override void Initialize()
  {
    this.managerList = new List<System.Type>()
    {
      typeof (NGBattleUIManager),
      typeof (NGBattleAIManager),
      typeof (NGBattle3DObjectManager),
      typeof (TreasureBoxManager),
      typeof (BattleTimeManager)
    }.ToArray();
  }

  public void initMasterData(BattleInfo info = null)
  {
    if (info == null)
      info = this.mBattleInfo;
    MasterData.LoadBattleMapLandform(info.stage.map);
    if (this.battleInfo.enemy_ids != null && this.battleInfo.enemy_ids.Length > 0)
      MasterData.LoadBattleStageEnemy(info.stage);
    if (this.battleInfo.user_enemy_ids == null || this.battleInfo.user_enemy_ids.Length <= 0)
      return;
    MasterData.LoadBattleStageUserUnit(info.stage);
  }

  public void resetEnvironment()
  {
    this.environment = new BE();
    this.environment.core = new BL();
    BattleFuncs.environment.Reset(this.environment.core);
  }

  [DebuggerHidden]
  public IEnumerator makeResumeInfo()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CmakeResumeInfo\u003Ec__Iterator857()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator initEnvironment()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CinitEnvironment\u003Ec__Iterator858()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator initBattle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CinitBattle\u003Ec__Iterator859()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator cleanupBattle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CcleanupBattle\u003Ec__Iterator85A()
    {
      \u003C\u003Ef__this = this
    };
  }

  public T getManager<T>() where T : BattleManagerBase
  {
    return Object.op_Equality((Object) this.managers, (Object) null) ? (T) null : this.managers.GetComponent<T>();
  }

  public T getController<T>() where T : BattleMonoBehaviour
  {
    return Object.op_Equality((Object) this.managers, (Object) null) ? (T) null : this.managers.GetComponent<T>();
  }

  private void setError(string s)
  {
    this.errorString = s;
    Debug.LogError((object) s);
  }

  public List<string> createResourceLoadList(BattleInfo info = null)
  {
    if (info == null)
      info = this.mBattleInfo;
    if (info == null)
    {
      this.setError("info is null");
      return new List<string>();
    }
    if (info.deck == null)
    {
      this.setError("info.deck is null");
      return new List<string>();
    }
    if (info.deck.player_units == null)
    {
      this.setError("info.deck.player_units is null");
      return new List<string>();
    }
    ResourceManager instance = Singleton<ResourceManager>.GetInstance();
    if (Object.op_Equality((Object) instance, (Object) null))
    {
      this.setError("ResourceManager.GetInstance() is null");
      return new List<string>();
    }
    List<string> resourceLoadList = new List<string>();
    if (info.pvp)
    {
      foreach (PlayerUnit playerUnit in ((IEnumerable<PlayerUnit>) info.pvp_player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)))
        resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(playerUnit.unit));
      foreach (PlayerUnit playerUnit in ((IEnumerable<PlayerUnit>) info.pvp_enemy_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)))
        resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(playerUnit.unit));
    }
    else
    {
      if (info.Enemies == null)
      {
        this.setError("info.Enemies is null");
        return new List<string>();
      }
      foreach (BattleStageEnemy enemy in info.Enemies)
      {
        if (enemy == null)
        {
          this.setError("enemy is null");
          return new List<string>();
        }
      }
      if (info.UserEnemies == null)
      {
        this.setError("info.UserEnemies is null");
        return new List<string>();
      }
      foreach (BattleStageUserUnit userEnemy in info.UserEnemies)
      {
        if (userEnemy == null)
        {
          this.setError("user_enemy is null");
          return new List<string>();
        }
      }
      if (this.battleInfo.quest_type == CommonQuestType.Earth || this.battleInfo.quest_type == CommonQuestType.EarthExtra)
      {
        if (info.EarthGuests == null)
        {
          this.setError("info.UserEnemies is null");
          return new List<string>();
        }
        foreach (BattleEarthStageGuest earthGuest in info.EarthGuests)
        {
          if (earthGuest == null)
          {
            this.setError("user_enemy is null");
            return new List<string>();
          }
        }
      }
      else
      {
        if (info.Guests == null)
        {
          this.setError("info.UserEnemies is null");
          return new List<string>();
        }
        foreach (BattleStageGuest guest in info.Guests)
        {
          if (guest == null)
          {
            this.setError("user_enemy is null");
            return new List<string>();
          }
        }
      }
      foreach (PlayerUnit playerUnit in ((IEnumerable<PlayerUnit>) info.deck.player_units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => x != (PlayerUnit) null)))
        resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(playerUnit.unit));
      if (info.helper != null && info.helper.leader_unit != (PlayerUnit) null && info.helper.leader_unit.unit != null)
        resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(info.helper.leader_unit.unit));
      if (info.Enemies != null)
      {
        foreach (BattleStageEnemy enemy in info.Enemies)
          resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(enemy.unit));
      }
      if (info.user_units != null)
      {
        foreach (PlayerUnit userUnit in info.user_units)
          resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(userUnit.unit));
      }
      if (this.battleInfo.quest_type == CommonQuestType.Earth || this.battleInfo.quest_type == CommonQuestType.EarthExtra)
      {
        if (info.EarthGuests != null)
        {
          foreach (BattleEarthStageGuest earthGuest in info.EarthGuests)
            resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(earthGuest.unit));
        }
      }
      else if (info.Guests != null)
      {
        foreach (BattleStageGuest guest in info.Guests)
          resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromUnit(guest.unit));
      }
    }
    resourceLoadList.AddRange((IEnumerable<string>) instance.PathsFromBattleMap(info.stage.map));
    return resourceLoadList;
  }

  [DebuggerHidden]
  private IEnumerator doStartBattle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CdoStartBattle\u003Ec__Iterator85B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void startBattle(BattleInfo battleInfo)
  {
    if (battleInfo != null)
      this.battleInfo = battleInfo;
    this.StartCoroutine(this.doStartBattle());
  }

  private bool duelHpSkillEffects(
    Dictionary<BattleskillSkill, List<BL.Unit>> skillTargets,
    Dictionary<BL.Unit, Tuple<int, int>> hpCount)
  {
    bool flag = false;
    foreach (BattleskillSkill key1 in skillTargets.Keys)
    {
      if (skillTargets[key1].Count<BL.Unit>() >= 1)
      {
        BE.SkillResource skillResource = this.environment.skillResource[key1.passive_effect.ID];
        List<BL.Unit> targets = skillTargets[key1];
        this.battleEffects.skillFieldEffectStartCore(key1.passive_effect, (BL.Unit) null, targets.ToList<BL.Unit>(), skillResource.effectPrefab, skillResource.targetEffectPrefab, targetAction: (System.Action) (() =>
        {
          foreach (BL.Unit key2 in targets)
            this.environment.unitResource[key2].unitParts.dispHpNumber(hpCount[key2].Item1, hpCount[key2].Item2);
        }));
        flag = true;
      }
    }
    return flag;
  }

  private void setBattleEffectSchedule(
    BattleTimeManager btm,
    BL.DuelTurn turn,
    BE.UnitResource attack,
    int preAttackerHP,
    BE.UnitResource defense,
    int preDefenseHP)
  {
    btm.setScheduleAction((System.Action) (() =>
    {
      if (turn.isAtackker)
        attack.unitParts.SetRun(true);
      else
        defense.unitParts.SetRun(true);
    }));
    if (((IEnumerable<BL.Skill>) turn.invokeDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
    {
      BattleskillGenre? genre1 = x.genre1;
      return genre1.GetValueOrDefault() == BattleskillGenre.attack && genre1.HasValue;
    })) || ((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
    {
      BattleskillGenre? genre1 = x.genre1;
      return genre1.GetValueOrDefault() == BattleskillGenre.defense && genre1.HasValue;
    })))
    {
      btm.setScheduleAction((System.Action) (() =>
      {
        if (((IEnumerable<BL.Skill>) turn.invokeDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
        {
          BattleskillGenre? genre1 = x.genre1;
          return genre1.GetValueOrDefault() == BattleskillGenre.attack && genre1.HasValue;
        })))
        {
          BL.Skill skill = ((IEnumerable<BL.Skill>) turn.invokeDuelSkills).FirstOrDefault<BL.Skill>((Func<BL.Skill, bool>) (x =>
          {
            BattleskillGenre? genre1 = x.genre1;
            return genre1.GetValueOrDefault() == BattleskillGenre.attack && genre1.HasValue;
          }));
          if (skill != null)
          {
            if (turn.isAtackker)
              attack.unitParts.DispSkillIconEffect(skill.skill);
            else
              defense.unitParts.DispSkillIconEffect(skill.skill);
          }
        }
        if (!((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills).Any<BL.Skill>((Func<BL.Skill, bool>) (x =>
        {
          BattleskillGenre? genre1 = x.genre1;
          return genre1.GetValueOrDefault() == BattleskillGenre.defense && genre1.HasValue;
        })))
          return;
        BL.Skill skill1 = ((IEnumerable<BL.Skill>) turn.invokeDefenderDuelSkills).FirstOrDefault<BL.Skill>((Func<BL.Skill, bool>) (x =>
        {
          BattleskillGenre? genre1 = x.genre1;
          return genre1.GetValueOrDefault() == BattleskillGenre.defense && genre1.HasValue;
        }));
        if (skill1 == null)
          return;
        if (!turn.isAtackker)
          attack.unitParts.DispSkillIconEffect(skill1.skill);
        else
          defense.unitParts.DispSkillIconEffect(skill1.skill);
      }));
      btm.setEnableWait(1f);
    }
    btm.setEnableWait(0.5f);
    btm.setScheduleAction((System.Action) (() =>
    {
      if (turn.isAtackker)
      {
        attack.unitParts.SetRun(false);
        if (preDefenseHP != turn.defenderRestHp)
          defense.unitParts.dispHpNumber(preDefenseHP, turn.defenderRestHp);
        defense.unitParts.DispDamageEffect(turn);
        if (preAttackerHP != turn.attackerRestHp)
          attack.unitParts.dispHpNumber(preAttackerHP, turn.attackerRestHp);
      }
      else
      {
        defense.unitParts.SetRun(false);
        if (preAttackerHP != turn.attackerRestHp)
          attack.unitParts.dispHpNumber(preAttackerHP, turn.attackerRestHp);
        attack.unitParts.DispDamageEffect(turn);
        if (preDefenseHP != turn.defenderRestHp)
          defense.unitParts.dispHpNumber(preDefenseHP, turn.defenderRestHp);
      }
      defense.unitParts.setHpGauge(preDefenseHP, turn.defenderRestHp);
      attack.unitParts.setHpGauge(preAttackerHP, turn.attackerRestHp);
    }));
    btm.setEnableWait(1.5f);
    btm.setScheduleAction((System.Action) (() =>
    {
      attack.unitParts.SetRun(false);
      defense.unitParts.SetRun(false);
    }));
  }

  public void startDuel(DuelResult duelResult, DuelEnvironment duelEnv = null, bool isStack = false)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAC duelCAnonStoreyDac1 = new NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAC();
    // ISSUE: reference to a compiler-generated field
    duelCAnonStoreyDac1.duelResult = duelResult;
    // ISSUE: reference to a compiler-generated field
    duelCAnonStoreyDac1.\u003C\u003Ef__this = this;
    // ISSUE: reference to a compiler-generated field
    duelCAnonStoreyDac1.afterDuelSchedules = new List<System.Action>();
    // ISSUE: reference to a compiler-generated field
    duelCAnonStoreyDac1.btm = this.getManager<BattleTimeManager>();
    this.mIsBattleEnable = false;
    // ISSUE: reference to a compiler-generated field
    duelCAnonStoreyDac1.storys = (List<BL.Story>) null;
    BL.Stage stage = (BL.Stage) null;
    if (this.environment != null)
    {
      // ISSUE: reference to a compiler-generated field
      BL.Unit attack = duelCAnonStoreyDac1.duelResult.attack;
      // ISSUE: reference to a compiler-generated field
      BL.Unit defense = duelCAnonStoreyDac1.duelResult.defense;
      // ISSUE: reference to a compiler-generated field
      duelCAnonStoreyDac1.duelResult.attack = CopyUtil.DeepCopy<BL.Unit>(attack);
      // ISSUE: reference to a compiler-generated field
      duelCAnonStoreyDac1.duelResult.defense = CopyUtil.DeepCopy<BL.Unit>(defense);
      if (attack.playerUnit.equip_gear_ids != null)
      {
        for (int index = 0; index < attack.playerUnit.equip_gear_ids.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          duelCAnonStoreyDac1.duelResult.attack.playerUnit.equip_gear_ids[index] = attack.playerUnit.equip_gear_ids[index];
        }
      }
      if (defense.playerUnit.equip_gear_ids != null)
      {
        for (int index = 0; index < defense.playerUnit.equip_gear_ids.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          duelCAnonStoreyDac1.duelResult.defense.playerUnit.equip_gear_ids[index] = defense.playerUnit.equip_gear_ids[index];
        }
      }
      if (this.noDuelScene)
      {
        BE.UnitResource unitResource1 = this.environment.unitResource[defense];
        BE.UnitResource unitResource2 = this.environment.unitResource[attack];
        unitResource1.unitParts.SetEffectMode(true);
        unitResource2.unitParts.SetEffectMode(true);
      }
      // ISSUE: reference to a compiler-generated field
      attack.hp -= duelCAnonStoreyDac1.duelResult.attackDamage;
      // ISSUE: reference to a compiler-generated field
      defense.hp -= duelCAnonStoreyDac1.duelResult.defenseDamage;
      // ISSUE: reference to a compiler-generated field
      if (duelCAnonStoreyDac1.duelResult.moveUnit.hp > 0)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.btm.setScheduleAction((System.Action) (() => this.environment.core.getUnitPosition(duelResult.moveUnit).actionActionUnit(this.environment.core)));
      }
      if (this.noDuelScene)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.afterDuelSchedules.Add((System.Action) (() =>
        {
          // ISSUE: variable of a compiler-generated type
          NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAC duelCAnonStoreyDac = duelCAnonStoreyDac1;
          // ISSUE: variable of a compiler-generated type
          NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAD duelCAnonStoreyDad = this;
          this.environment.core.setCurrentUnitWith((BL.Unit) null, (Action<BL.UnitPosition>) (_ => { }));
          BE.UnitResource defenseUnitR = this.environment.unitResource[defense];
          BE.UnitResource attackUnitR = this.environment.unitResource[attack];
          int preAttackerHP = duelResult.attack.hp;
          int preDefenseHP = duelResult.defense.hp;
          Singleton<CommonRoot>.GetInstance();
          this.selectNode.setMaskActive(true);
          btm.setScheduleAction((System.Action) (() =>
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            duelCAnonStoreyDad.\u003C\u003Ef__this.environment.core.lookDirection(duelCAnonStoreyDad.defense, duelCAnonStoreyDad.attack);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            duelCAnonStoreyDad.\u003C\u003Ef__this.environment.core.lookDirection(duelCAnonStoreyDad.attack, duelCAnonStoreyDad.defense);
          }));
          btm.setEnableWait(0.5f);
          foreach (BL.DuelTurn turn in duelResult.turns)
          {
            this.setBattleEffectSchedule(btm, turn, attackUnitR, preAttackerHP, defenseUnitR, preDefenseHP);
            preAttackerHP = turn.attackerRestHp;
            preDefenseHP = turn.defenderRestHp;
          }
          btm.setScheduleAction((System.Action) (() =>
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            BE.UnitResource unitResource = duelCAnonStoreyDad.\u003C\u003Ef__this.environment.unitResource[duelCAnonStoreyDac.duelResult.moveUnit];
            defenseUnitR.unitParts.SetEffectMode(false);
            attackUnitR.unitParts.SetEffectMode(false);
          }));
          this.selectNode.setMaskActive(false);
        }));
      }
      Dictionary<BattleskillSkill, List<BL.Unit>> lifeAbsorbSkillTarget = new Dictionary<BattleskillSkill, List<BL.Unit>>();
      Dictionary<BattleskillSkill, List<BL.Unit>> curseReflectionSkillTarget = new Dictionary<BattleskillSkill, List<BL.Unit>>();
      Dictionary<BL.Unit, Tuple<int, int>> effectTargetsAddHp = new Dictionary<BL.Unit, Tuple<int, int>>();
      Dictionary<BL.Unit, Tuple<int, int>> effectTargetsSubHp = new Dictionary<BL.Unit, Tuple<int, int>>();
      Dictionary<BattleskillSkill, Tuple<BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>>> effectTargetsSnake = new Dictionary<BattleskillSkill, Tuple<BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>>>();
      // ISSUE: reference to a compiler-generated field
      BattleFuncs.applyDuelSkillEffects(duelCAnonStoreyDac1.duelResult, (BL.ISkillEffectListUnit) attack, (BL.ISkillEffectListUnit) defense, this.environment.core, (Action<BL.ISkillEffectListUnit, int>) ((target, prevHp) => effectTargetsAddHp[target as BL.Unit] = new Tuple<int, int>(prevHp, target.hp)), (Action<BL.ISkillEffectListUnit, int>) ((target, prevHp) => effectTargetsSubHp[target as BL.Unit] = new Tuple<int, int>(prevHp, target.hp)), (Action<BattleskillSkill, BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>>) ((skill, unit, targets) => effectTargetsSnake[skill] = new Tuple<BL.Unit, Dictionary<BL.Unit, Tuple<int, int>>>(unit, targets)), lifeAbsorbSkillTarget, curseReflectionSkillTarget);
      if (effectTargetsAddHp.Count >= 1)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.afterDuelSchedules.Add((System.Action) (() =>
        {
          if (!this.duelHpSkillEffects(lifeAbsorbSkillTarget, effectTargetsAddHp))
            return;
          btm.setEnableWait(0.5f);
        }));
      }
      if (effectTargetsSubHp.Count >= 1)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.afterDuelSchedules.Add((System.Action) (() =>
        {
          if (!this.duelHpSkillEffects(curseReflectionSkillTarget, effectTargetsSubHp))
            return;
          btm.setEnableWait(1.5f);
        }));
      }
      if (effectTargetsSnake.Count >= 1)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.afterDuelSchedules.Add((System.Action) (() =>
        {
          // ISSUE: variable of a compiler-generated type
          NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAC duelCAnonStoreyDac = duelCAnonStoreyDac1;
          // ISSUE: variable of a compiler-generated type
          NGBattleManager.\u003CstartDuel\u003Ec__AnonStoreyDAD duelCAnonStoreyDad = this;
          foreach (BattleskillSkill key1 in effectTargetsSnake.Keys)
          {
            BattleskillSkill skill = key1;
            if (effectTargetsSnake[skill].Item2.Count<KeyValuePair<BL.Unit, Tuple<int, int>>>() >= 1)
            {
              BattleskillFieldEffect fe = skill.skill_type != BattleskillSkillType.duel ? skill.passive_effect : skill.field_effect;
              BE.SkillResource skillResource = this.environment.skillResource[fe.ID];
              this.battleEffects.skillFieldEffectStartCore(fe, (BL.Unit) null, effectTargetsSnake[skill].Item2.Keys.ToList<BL.Unit>(), skillResource.effectPrefab, skillResource.targetEffectPrefab);
              btm.setScheduleAction((System.Action) (() =>
              {
                // ISSUE: reference to a compiler-generated field
                foreach (BL.Unit key2 in duelCAnonStoreyDad.effectTargetsSnake[skill].Item2.Keys)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  duelCAnonStoreyDad.\u003C\u003Ef__this.environment.unitResource[key2].unitParts.dispHpNumber(duelCAnonStoreyDad.effectTargetsSnake[skill].Item2[key2].Item1, duelCAnonStoreyDad.effectTargetsSnake[skill].Item2[key2].Item2);
                }
              }));
              btm.setEnableWait(1.5f);
            }
          }
        }));
      }
      attack.commit();
      defense.commit();
      // ISSUE: reference to a compiler-generated field
      this.environment.core.updateUnitBattleStatus(duelCAnonStoreyDac1.duelResult, attack, defense);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      duelCAnonStoreyDac1.storys = this.environment.core.getDuelStorys(duelCAnonStoreyDac1.duelResult.moveUnit, duelCAnonStoreyDac1.duelResult.moveUnit != attack ? duelCAnonStoreyDac1.duelResult.attack : duelCAnonStoreyDac1.duelResult.defense);
      stage = this.environment.core.stage;
      // ISSUE: reference to a compiler-generated field
      duelCAnonStoreyDac1.btm.setScheduleAction((System.Action) (() =>
      {
        foreach (BL.Story story in storys)
          story.isRead = true;
        this.checkReinforcementForBattle(duelResult.moveUnit, duelResult.moveUnit != attack ? duelResult.attack : duelResult.defense);
        this.checkReinforceUnitForSmash();
        this.saveEnvironment();
      }));
    }
    if (duelEnv == null)
    {
      // ISSUE: reference to a compiler-generated field
      if (duelCAnonStoreyDac1.storys == null)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.storys = new List<BL.Story>();
      }
      if (stage == null)
        stage = new BL.Stage(1);
      duelEnv = new DuelEnvironment();
      // ISSUE: reference to a compiler-generated field
      duelEnv.storys = duelCAnonStoreyDac1.storys;
      duelEnv.stage = stage;
    }
    if (this.noDuelScene)
    {
      if (this.topScene != Singleton<NGSceneManager>.GetInstance().sceneName)
      {
        // ISSUE: reference to a compiler-generated field
        duelCAnonStoreyDac1.btm.backSceneWithReturnWait();
      }
      else
        this.mIsBattleEnable = true;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      duelCAnonStoreyDac1.btm.changeSceneWithReturnWait(this.duelScene, (isStack ? 1 : 0) != 0, new System.Action(duelCAnonStoreyDac1.\u003C\u003Em__1263), (object) duelCAnonStoreyDac1.duelResult, (object) duelEnv);
    }
    // ISSUE: reference to a compiler-generated field
    if (duelCAnonStoreyDac1.afterDuelSchedules.Count < 1)
      return;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    duelCAnonStoreyDac1.btm.setScheduleAction(new System.Action(duelCAnonStoreyDac1.\u003C\u003Em__1264));
  }

  public void checkReinforcementForBattle(BL.Unit attack, BL.Unit defence)
  {
    List<BL.UnitPosition> list = this.environment.core.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => x.unit.playerUnit.reinforcement != null && !x.unit.isDead && !x.unit.isEnable && x.unit.playerUnit.reinforcement.isSpawnForBattle(attack, defence))).ToList<BL.UnitPosition>();
    if (list.Count <= 0)
      return;
    foreach (BL.UnitPosition unitPosition in list)
    {
      if (!this.environment.core.spawnUnits.value.Contains(unitPosition))
      {
        this.environment.core.spawnUnits.value.Add(unitPosition);
        this.environment.core.spawnUnits.commit();
      }
    }
  }

  public void checkReinforceUnitForSmash()
  {
    IEnumerable<BL.UnitPosition> source = this.environment.core.unitPositions.value.Where<BL.UnitPosition>((Func<BL.UnitPosition, bool>) (x => !x.unit.isDead && !x.unit.isEnable && this.environment.core.isReinforceUnitForSmash(x.unit.playerUnit)));
    if (source.Count<BL.UnitPosition>() <= 0)
      return;
    foreach (BL.UnitPosition unitPosition in source)
    {
      if (!this.environment.core.spawnUnits.value.Contains(unitPosition))
      {
        this.environment.core.spawnUnits.value.Add(unitPosition);
        this.environment.core.spawnUnits.commit();
      }
    }
  }

  public void startStory(BL.Story story)
  {
    this.getManager<BattleTimeManager>().changeSceneWithReturnWait(this.storyScene, true, (System.Action) null, (object) story.scriptId);
  }

  public bool isBattleEnable
  {
    get => this.mIsBattleEnable && Singleton<NGSceneManager>.GetInstance().isSceneInitialized;
    set
    {
      if (value)
      {
        string sceneName = Singleton<NGSceneManager>.GetInstance().sceneName;
        if (sceneName == null || !(sceneName == this.topScene))
          return;
        this.mIsBattleEnable = value;
      }
      else
        this.mIsBattleEnable = value;
    }
  }

  public GameObject popupOpen(
    GameObject prefab,
    bool alert = false,
    EventDelegate ed = null,
    bool isCloned = false,
    bool nonBattleEnableControl = false,
    bool isUnmask = false,
    bool isViewBack = true,
    bool isNonSe = false)
  {
    PopupManager instance = Singleton<PopupManager>.GetInstance();
    if (!nonBattleEnableControl)
      this.isBattleEnable = false;
    if (!alert)
      return instance.open(prefab, isUnmask, isCloned: isCloned, isViewBack: isViewBack, isNonSe: isNonSe);
    if (ed == null)
      ed = new EventDelegate((MonoBehaviour) this, "doPopupDismiss");
    return instance.openAlert(prefab, isUnmask, ed: ed, isCloned: isCloned, isViewBack: isViewBack, isNonSe: isNonSe);
  }

  [DebuggerHidden]
  private IEnumerator doDismissWait()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleManager.\u003CdoDismissWait\u003Ec__Iterator85C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void popupDismiss(bool nonBattleEnableControl = false)
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (nonBattleEnableControl)
      return;
    this.StartCoroutine(this.doDismissWait());
  }

  public void popupCloseAll(bool nonBattleEnableControl = false)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    if (nonBattleEnableControl)
      return;
    this.StartCoroutine(this.doDismissWait());
  }

  public void doPopupDismiss() => this.popupDismiss();

  public Persist<BE> GetSaveData()
  {
    return this.isEarth ? Persist.earthBattleEnvironment : Persist.battleEnvironment;
  }

  public void deleteSavedEnvironment() => this.GetSaveData().Delete();

  public bool hasSavedEnvironment() => this.GetSaveData().Exists;

  public void saveEnvironment(bool forcibly = false)
  {
    if (!forcibly && this.mBattleInfo.pvp)
      return;
    this.GetSaveData().Data = this.environment;
    foreach (BL.Unit unit in this.environment.core.playerUnits.value)
      unit.SaveEquipedGears();
    this.GetSaveData().Flush();
  }

  public void loadEnvironment()
  {
    this.environment = this.GetSaveData().Data;
    foreach (BL.Unit unit in this.environment.core.playerUnits.value)
      unit.LoadEquipedGears();
  }

  private class OrderValues
  {
    private int _order;
    private float _unitAngleValue;
    private float _cameraAngleYValue;
    private Vector3 _cameraPositionOffsetValue;
    private Vector3 _unitPositionOffsetValue;
    private Vector3 _unitShadowOffsetValue;
    private Quaternion _unitNonTransformRotationValue;

    public OrderValues(int order, NGBattleManager parent)
    {
      this._order = order;
      if (order == 0)
      {
        this._unitAngleValue = parent.unitAngle;
        this._cameraAngleYValue = 0.0f;
        this._cameraPositionOffsetValue = parent.cameraPositionOffset;
        this._unitPositionOffsetValue = new Vector3(0.0f, 0.0f, -0.5f);
        this._unitShadowOffsetValue = new Vector3(0.0f, 0.0f, -0.3f);
        this._unitNonTransformRotationValue = Quaternion.identity;
      }
      else
      {
        this._unitAngleValue = parent.unitAngle * -1f;
        this._cameraAngleYValue = 180f;
        this._cameraPositionOffsetValue = new Vector3(parent.cameraPositionOffset.x, parent.cameraPositionOffset.y, parent.cameraPositionOffset.z * -1f);
        this._unitPositionOffsetValue = new Vector3(0.0f, 0.0f, 0.5f);
        this._unitShadowOffsetValue = new Vector3(0.0f, 0.0f, 0.3f);
        this._unitNonTransformRotationValue = Quaternion.Euler(0.0f, 180f, 0.0f);
      }
    }

    public int order => this._order;

    public float unitAngleValue => this._unitAngleValue;

    public float cameraAngleYValue => this._cameraAngleYValue;

    public Vector3 cameraPositionOffsetValue => this._cameraPositionOffsetValue;

    public Vector3 unitPositionOffsetValue => this._unitPositionOffsetValue;

    public Vector3 unitShadowOffsetValue => this._unitShadowOffsetValue;

    public Quaternion unitNonTransformRotationValue => this._unitNonTransformRotationValue;
  }
}
