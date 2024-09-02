// Decompiled with JetBrains decompiler
// Type: Unit05499Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit05499Menu : Unit00499Menu
{
  [DebuggerHidden]
  public IEnumerator Initialize(PlayerUnit beforeUnit, PlayerUnit[] targetUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05499Menu.\u003CInitialize\u003Ec__Iterator77F()
    {
      beforeUnit = beforeUnit,
      targetUnits = targetUnits,
      \u003C\u0024\u003EbeforeUnit = beforeUnit,
      \u003C\u0024\u003EtargetUnits = targetUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected override void SetStatusText(PlayerUnit playerUnit, PlayerUnit targetPlayerUnit)
  {
    this.InitNumber(playerUnit.total_hp, targetPlayerUnit.total_hp, true, true, this.TxtHpBefore, this.TxtHpAfter);
    this.InitNumber(playerUnit.total_strength, targetPlayerUnit.total_strength, true, true, this.TxtPowerBefore, this.TxtPowerAfter);
    this.InitNumber(playerUnit.total_intelligence, targetPlayerUnit.total_intelligence, true, true, this.TxtMagicBefore, this.TxtMagicAfter);
    this.InitNumber(playerUnit.total_vitality, targetPlayerUnit.total_vitality, true, true, this.TxtProtectBefore, this.TxtProtectAfter);
    this.InitNumber(playerUnit.total_mind, targetPlayerUnit.total_mind, true, true, this.TxtSpiritBefore, this.TxtSpiritAfter);
    this.InitNumber(playerUnit.total_agility, targetPlayerUnit.total_agility, true, true, this.TxtSpeedBefore, this.TxtSpeedAfter);
    this.InitNumber(playerUnit.total_dexterity, targetPlayerUnit.total_dexterity, true, true, this.TxtTechniqueBefore, this.TxtTechniqueAfter);
    this.InitNumber(playerUnit.total_lucky, targetPlayerUnit.total_lucky, true, true, this.TxtLuckyBefore, this.TxtLuckyAfter);
    this.InitNumber(playerUnit.level, targetPlayerUnit.level, true, true, this.TxtLvBefore, this.TxtLvAfter);
    this.InitNumber(playerUnit.max_level, targetPlayerUnit.max_level, true, true, this.TxtLvmaxBefore, this.TxtLvmaxAfter);
    this.setStatusMaxStar(this.hpStatusMaxStar, playerUnit.hp.is_max);
    this.setStatusMaxStar(this.powerStatusMaxStar, playerUnit.strength.is_max);
    this.setStatusMaxStar(this.magicStatusMaxStar, playerUnit.intelligence.is_max);
    this.setStatusMaxStar(this.protectStatusMaxStar, playerUnit.vitality.is_max);
    this.setStatusMaxStar(this.spiritStatusMaxStar, playerUnit.mind.is_max);
    this.setStatusMaxStar(this.speedStatusMaxStar, playerUnit.agility.is_max);
    this.setStatusMaxStar(this.techniqueStatusMaxStar, playerUnit.dexterity.is_max);
    this.setStatusMaxStar(this.luckyStatusMaxStar, playerUnit.lucky.is_max);
    this.TxtJobnameBefore.SetTextLocalize(playerUnit.unit.job.name);
    this.TxtJobnameAfter.SetTextLocalize(targetPlayerUnit.unit.job.name);
  }

  [DebuggerHidden]
  protected override IEnumerator Evolution()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05499Menu.\u003CEvolution\u003Ec__Iterator780()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override bool CheckEnabledButton(int money)
  {
    this.comShortage.SetActive(false);
    bool flag = false;
    SMManager.Get<Player>();
    if (!this.isUnit)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(1);
    }
    if (!this.isLevel)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(2);
    }
    if (!this.isFavorite)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(3);
    }
    this.comShortage.SetActive(flag);
    return this.isUnit && this.isLevel && this.isFavorite;
  }

  public override void IbtnBack() => base.IbtnBack();
}
