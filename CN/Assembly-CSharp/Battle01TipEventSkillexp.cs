// Decompiled with JetBrains decompiler
// Type: Battle01TipEventSkillexp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01TipEventSkillexp : Battle01TipEventBase
{
  private UnitIcon unitIcon;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventSkillexp.\u003ConInitAsync\u003Ec__Iterator86F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetIcon(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01TipEventSkillexp.\u003CdoSetIcon\u003Ec__Iterator870()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public override void setData(BL.DropData e, BL.Unit unit)
  {
    Debug.LogWarning((object) (" ==== setData:" + (object) e.reward.Type));
    if (e.reward.Type != MasterDataTable.CommonRewardType.gear_experience_point)
      return;
    this.setText(Consts.Format(Consts.GetInstance().TipEvent_text_skillexp, (IDictionary) new Dictionary<string, string>()
    {
      ["skill"] = unit.playerUnit.equippedGearName
    }));
    Singleton<NGBattleManager>.GetInstance().StartCoroutine(this.doSetIcon(unit.unit));
  }
}
