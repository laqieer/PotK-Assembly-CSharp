// Decompiled with JetBrains decompiler
// Type: GameCore.DuelResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class DuelResult : ActionResult
  {
    public bool isPlayerAttack;
    public BL.Unit moveUnit;
    public BL.Unit attack;
    public AttackStatus attackAttackStatus;
    public AttackStatus colosseumNewAAS;
    public int? attackDuelSupportId;
    public int attackDuelSupportHitIncr;
    public int attackDuelSupportEvasionIncr;
    public int attackDuelSupportCriticalIncr;
    public int attackDuelSupportCriticalEvasionIncr;
    public BL.Unit defense;
    public AttackStatus defenseAttackStatus;
    public AttackStatus colosseumNewDAS;
    public int? defenseDuelSupportId;
    public int defenseDuelSupportHitIncr;
    public int defenseDuelSupportEvasionIncr;
    public int defenseDuelSupportCriticalIncr;
    public int defenseDuelSupportCriticalEvasionIncr;
    public BL.DuelTurn[] turns;
    public int attackDamage;
    public int attackFromDamage;
    public int defenseDamage;
    public int defenseFromDamage;
    public bool isDieAttack;
    public bool isDieDefense;
    public bool isBossBattle;
    public bool isFirstBoss;
    public bool isColosseum;
    public bool disableDuelSkillEffects;
    public int[] beforeAttakerAilmentEffectIDs;
    public int[] beforeDefenderAilmentEffectIDs;
    public int distance;

    public override ActionResultNetwork ToNetworkLocal(BL env)
    {
      return (ActionResultNetwork) new DuelResultNetwork()
      {
        isPlayerAttack = this.isPlayerAttack,
        moveUnit = (this.moveUnit != null ? this.moveUnit.ToNetwork(env) : new int?()),
        attack = (this.attack != null ? this.attack.ToNetwork(env) : new int?()),
        attackAttackStatus = this.attackAttackStatus,
        colosseumNewAAS = this.colosseumNewAAS,
        attackDuelSupportId = this.attackDuelSupportId,
        attackDuelSupportHitIncr = this.attackDuelSupportHitIncr,
        attackDuelSupportEvasionIncr = this.attackDuelSupportEvasionIncr,
        attackDuelSupportCriticalIncr = this.attackDuelSupportCriticalIncr,
        attackDuelSupportCriticalEvasionIncr = this.attackDuelSupportCriticalEvasionIncr,
        defense = (this.defense != null ? this.defense.ToNetwork(env) : new int?()),
        defenseAttackStatus = this.defenseAttackStatus,
        colosseumNewDAS = this.colosseumNewDAS,
        defenseDuelSupportId = this.defenseDuelSupportId,
        defenseDuelSupportHitIncr = this.defenseDuelSupportHitIncr,
        defenseDuelSupportEvasionIncr = this.defenseDuelSupportEvasionIncr,
        defenseDuelSupportCriticalIncr = this.defenseDuelSupportCriticalIncr,
        defenseDuelSupportCriticalEvasionIncr = this.defenseDuelSupportCriticalEvasionIncr,
        turns = this.turns,
        attackDamage = this.attackDamage,
        attackFromDamage = this.attackFromDamage,
        defenseDamage = this.defenseDamage,
        defenseFromDamage = this.defenseFromDamage,
        isDieAttack = this.isDieAttack,
        isDieDefense = this.isDieDefense,
        isBossBattle = this.isBossBattle,
        isFirstBoss = this.isFirstBoss,
        isColosseum = this.isColosseum,
        distance = this.distance,
        beforeAttakerAilmentEffectIDs = this.beforeAttakerAilmentEffectIDs,
        beforeDefenderAilmentEffectIDs = this.beforeDefenderAilmentEffectIDs,
        disableAffterSkills = this.disableDuelSkillEffects
      };
    }

    public static ActionResult FromNetwork(ActionResultNetwork nnw, BL env)
    {
      if (!(nnw is DuelResultNetwork duelResultNetwork))
        return (ActionResult) null;
      return (ActionResult) new DuelResult()
      {
        moveUnit = BL.Unit.FromNetwork(duelResultNetwork.moveUnit, env),
        attack = BL.Unit.FromNetwork(duelResultNetwork.attack, env),
        attackAttackStatus = duelResultNetwork.attackAttackStatus,
        colosseumNewAAS = duelResultNetwork.colosseumNewAAS,
        attackDuelSupportId = duelResultNetwork.attackDuelSupportId,
        attackDuelSupportHitIncr = duelResultNetwork.attackDuelSupportHitIncr,
        attackDuelSupportEvasionIncr = duelResultNetwork.attackDuelSupportEvasionIncr,
        attackDuelSupportCriticalIncr = duelResultNetwork.attackDuelSupportCriticalIncr,
        attackDuelSupportCriticalEvasionIncr = duelResultNetwork.attackDuelSupportCriticalEvasionIncr,
        defense = BL.Unit.FromNetwork(duelResultNetwork.defense, env),
        defenseAttackStatus = duelResultNetwork.defenseAttackStatus,
        colosseumNewDAS = duelResultNetwork.colosseumNewDAS,
        defenseDuelSupportId = duelResultNetwork.defenseDuelSupportId,
        defenseDuelSupportHitIncr = duelResultNetwork.defenseDuelSupportHitIncr,
        defenseDuelSupportEvasionIncr = duelResultNetwork.defenseDuelSupportEvasionIncr,
        defenseDuelSupportCriticalIncr = duelResultNetwork.defenseDuelSupportCriticalIncr,
        defenseDuelSupportCriticalEvasionIncr = duelResultNetwork.defenseDuelSupportCriticalEvasionIncr,
        turns = duelResultNetwork.turns,
        attackDamage = duelResultNetwork.attackDamage,
        attackFromDamage = duelResultNetwork.attackFromDamage,
        defenseDamage = duelResultNetwork.defenseDamage,
        defenseFromDamage = duelResultNetwork.defenseFromDamage,
        isDieAttack = duelResultNetwork.isDieAttack,
        isDieDefense = duelResultNetwork.isDieDefense,
        isBossBattle = duelResultNetwork.isBossBattle,
        isFirstBoss = duelResultNetwork.isFirstBoss,
        isColosseum = duelResultNetwork.isColosseum,
        distance = duelResultNetwork.distance,
        beforeAttakerAilmentEffectIDs = duelResultNetwork.beforeAttakerAilmentEffectIDs,
        beforeDefenderAilmentEffectIDs = duelResultNetwork.beforeDefenderAilmentEffectIDs,
        disableDuelSkillEffects = duelResultNetwork.disableAffterSkills,
        isPlayerAttack = BL.Unit.FromNetwork(duelResultNetwork.attack, env).isPlayerControl
      };
    }

    public BL.Unit playerUnit() => this.isPlayerAttack ? this.attack : this.defense;

    public int[] playerUnitBeforeAilmentEffectIDs()
    {
      return this.isPlayerAttack ? this.beforeAttakerAilmentEffectIDs : this.beforeDefenderAilmentEffectIDs;
    }

    public BL.Unit enemyUnit() => this.isPlayerAttack ? this.defense : this.attack;

    public int[] enemyUnitBeforeAilmentEffectIDs()
    {
      return this.isPlayerAttack ? this.beforeDefenderAilmentEffectIDs : this.beforeAttakerAilmentEffectIDs;
    }

    public AttackStatus playerAttackStatus()
    {
      return this.isPlayerAttack ? this.attackAttackStatus : this.defenseAttackStatus;
    }

    public AttackStatus enemyAttackStatus()
    {
      return this.isPlayerAttack ? this.defenseAttackStatus : this.attackAttackStatus;
    }

    public AttackStatus playerColosseumNAS()
    {
      return this.isPlayerAttack ? this.colosseumNewAAS : this.colosseumNewDAS;
    }

    public AttackStatus enemyColosseumNAS()
    {
      return this.isPlayerAttack ? this.colosseumNewDAS : this.colosseumNewAAS;
    }

    public int playerAttackDamage() => this.isPlayerAttack ? this.attackDamage : this.defenseDamage;

    public int enemyAttackDamage() => this.isPlayerAttack ? this.defenseDamage : this.attackDamage;

    public bool isHeal
    {
      get
      {
        return this.attackAttackStatus.magicBullet != null && this.attackAttackStatus.magicBullet.isHeal;
      }
    }

    public IntimateDuelSupport attackDuelSupport
    {
      get
      {
        return this.attackDuelSupportId.HasValue ? MasterData.IntimateDuelSupport[this.attackDuelSupportId.Value] : (IntimateDuelSupport) null;
      }
      set => this.attackDuelSupportId = value?.ID;
    }

    public IntimateDuelSupport defenseDuelSupport
    {
      get
      {
        return this.defenseDuelSupportId.HasValue ? MasterData.IntimateDuelSupport[this.defenseDuelSupportId.Value] : (IntimateDuelSupport) null;
      }
      set => this.defenseDuelSupportId = value?.ID;
    }
  }
}
