// Decompiled with JetBrains decompiler
// Type: GameCore.DuelResultNetwork
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class DuelResultNetwork : ActionResultNetwork
  {
    public bool isPlayerAttack;
    public int? moveUnit;
    public int? attack;
    public AttackStatus attackAttackStatus;
    public AttackStatus colosseumNewAAS;
    public int? attackDuelSupportId;
    public int attackDuelSupportHitIncr;
    public int attackDuelSupportEvasionIncr;
    public int attackDuelSupportCriticalIncr;
    public int attackDuelSupportCriticalEvasionIncr;
    public int? defense;
    public AttackStatus defenseAttackStatus;
    public AttackStatus colosseumNewDAS;
    public int? defenseDuelSupportId;
    public int defenseDuelSupportHitIncr;
    public int defenseDuelSupportEvasionIncr;
    public int defenseDuelSupportCriticalIncr;
    public int defenseDuelSupportCriticalEvasionIncr;
    public BL.DuelTurnNetwork[] turns;
    public int attackDamage;
    public int attackFromDamage;
    public int defenseDamage;
    public int defenseFromDamage;
    public bool isDieAttack;
    public bool isDieDefense;
    public bool isBossBattle;
    public bool isFirstBoss;
    public bool isColosseum;
    public int distance;
    public int[] beforeAttakerAilmentEffectIDs;
    public int[] beforeDefenderAilmentEffectIDs;
    public bool disableAffterSkills;
  }
}
