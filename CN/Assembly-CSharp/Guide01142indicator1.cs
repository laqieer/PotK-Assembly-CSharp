﻿// Decompiled with JetBrains decompiler
// Type: Guide01142indicator1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guide01142indicator1 : Unit00443indicator
{
  [SerializeField]
  private UILabel txtSPAttack1;
  [SerializeField]
  private UILabel txtSPAttack2;

  public override void Init(GearGear gear)
  {
    this.SetParam(gear);
    this.SetSkillDeteilEvent(gear);
    this.SetSpecialAttack(gear);
    this.Weapon.Init(gear.kind_GearKind);
    this.SetSPAttackTxt(gear);
  }

  public void SetSPAttackTxt(GearGear gear)
  {
    UnitFamily[] family = gear.SpecialAttackTargets;
    if (family.Length >= 1)
    {
      this.txtSPAttack1.SetTextLocalize(((IEnumerable<UnitFamilyValue>) MasterData.UnitFamilyValueList).First<UnitFamilyValue>((Func<UnitFamilyValue, bool>) (x => (UnitFamily) x.ID == family[0])).name);
      if (family.Length == 2)
        this.txtSPAttack2.SetTextLocalize(((IEnumerable<UnitFamilyValue>) MasterData.UnitFamilyValueList).First<UnitFamilyValue>((Func<UnitFamilyValue, bool>) (x => (UnitFamily) x.ID == family[1])).name);
      else
        this.txtSPAttack2.SetTextLocalize("-");
    }
    else
    {
      this.txtSPAttack1.SetTextLocalize("-");
      this.txtSPAttack2.SetTextLocalize("-");
    }
  }
}
