// Decompiled with JetBrains decompiler
// Type: Unit0046IndiStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Unit0046IndiStatus : MonoBehaviour
{
  public const int GUN = 5;
  public const int STAFF = 6;
  public UILabel HP;
  public UILabel PAt;
  public UILabel MAt;
  public UILabel PDe;
  public UILabel MDe;

  public void SetText(PlayerUnit pUnit)
  {
    Judgement.NonBattleParameter nonBattleParameter = Judgement.NonBattleParameter.FromPlayerUnit(pUnit);
    int kindGearKind = pUnit.unit.kind_GearKind;
    this.HP.SetTextLocalize(nonBattleParameter.Hp.ToString());
    if (kindGearKind != 5 && kindGearKind != 6)
    {
      this.PAt.SetTextLocalize(nonBattleParameter.PhysicalAttack.ToString());
      this.MAt.SetText("-");
    }
    else
    {
      this.PAt.SetText("-");
      this.MAt.SetTextLocalize(nonBattleParameter.MagicAttack.ToString());
    }
    this.PDe.SetTextLocalize(nonBattleParameter.PhysicalDefense.ToString());
    this.MDe.SetTextLocalize(nonBattleParameter.MagicDefense.ToString());
  }

  public void RemoveText()
  {
    ((IEnumerable<UILabel>) ((Component) this).GetComponentsInChildren<UILabel>()).ForEach<UILabel>((Action<UILabel>) (x => x.SetText("-")));
  }
}
