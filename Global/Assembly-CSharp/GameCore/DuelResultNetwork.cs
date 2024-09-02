// Decompiled with JetBrains decompiler
// Type: GameCore.DuelResultNetwork
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    public int distance;
    public int[] beforeAttakerAilmentEffectIDs;
    public int[] beforeDefenderAilmentEffectIDs;
    public bool disableAffterSkills;
  }
}
