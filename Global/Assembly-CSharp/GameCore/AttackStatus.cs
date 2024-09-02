// Decompiled with JetBrains decompiler
// Type: GameCore.AttackStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class AttackStatus
  {
    public BL.MagicBullet magicBullet;
    public Judgement.BeforeDuelParameter duelParameter;
    public float elementAttackRate;

    public bool isMagic { get; set; }

    public bool isHeal => this.magicBullet != null && this.magicBullet.isHeal;

    public bool isDrain => this.magicBullet != null && this.magicBullet.isDrain;

    public float drainRate => this.magicBullet != null ? this.magicBullet.drainRate : 0.0f;

    public float attackRate { get; set; }

    public int attack => NC.Clamp(1, int.MaxValue, (int) this.originalAttack);

    public float originalAttack
    {
      get
      {
        return this.isMagic ? this.duelParameter.CalcMagicAttack(this.attackRate) : this.duelParameter.CalcPhysicalAttack(this.attackRate);
      }
    }

    public int heal_attack
    {
      get
      {
        return ((IEnumerable<BattleskillEffect>) this.magicBullet.skill.Effects).Any<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_heal)) ? ((IEnumerable<BattleskillEffect>) this.magicBullet.skill.Effects).SingleOrDefault<BattleskillEffect>((Func<BattleskillEffect, bool>) (x => x.effect_logic.Enum == BattleskillEffectLogicEnum.fix_heal)).GetInt("value") : NC.Clamp(1, int.MaxValue, this.duelParameter.attackerUnitParameter.MagicAttack);
      }
    }

    public int attackCount => this.duelParameter.AttackCount;

    public float hit => NC.Clampf(0.0f, 1f, (float) this.duelParameter.DisplayHit / 100f);

    public float critical => NC.Clampf(0.0f, 1f, (float) this.duelParameter.DisplayCritical / 100f);

    public int dexerityDisplay() => NC.Clamp(0, 100, this.duelParameter.DisplayHit);

    public int criticalDisplay() => NC.Clamp(0, 100, this.duelParameter.DisplayCritical);

    public int normalDamage() => this.attack * this.attackCount;

    public int expectationDamage()
    {
      return (int) ((double) (this.attack * this.attackCount) * (double) this.hit);
    }

    public void calcElementAttackRate(
      BL.ISkillEffectListUnit attack,
      BL.ISkillEffectListUnit defense)
    {
      this.elementAttackRate = BattleDuelSkill.getElementAttackRate(attack, this, defense);
    }

    public float realHit
    {
      get
      {
        return NC.Clampf(0.0f, 1f, this.hit + Mathf.Sin((float) ((1.0 - (double) this.hit) * 2.0 * 3.1415927410125732)) / 10f);
      }
    }

    public bool calcHit(float value) => (double) this.realHit >= (double) value;

    public string ShowAttackStatus()
    {
      return string.Format("magic({0}) attack({1}) heal({2}) count({3}) hit({4}) critical({5})", this.magicBullet == null ? (object) "-" : (object) (this.magicBullet.name + " : " + (object) this.magicBullet.cost), (object) this.attack, (object) this.heal_attack, (object) this.attackCount, (object) this.dexerityDisplay(), (object) this.criticalDisplay());
    }
  }
}
