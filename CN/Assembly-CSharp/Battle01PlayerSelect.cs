// Decompiled with JetBrains decompiler
// Type: Battle01PlayerSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01PlayerSelect : BattleHorizontalSelect<BL.Unit>
{
  protected override void initialize(BE e)
  {
    this.modified = BL.Observe<BL.ClassValue<List<BL.Unit>>>(e.core.playerUnits);
  }

  protected override Future<GameObject> resPrefab()
  {
    return Res.Prefabs.battle.Battle01_Player_Unit.Load<GameObject>();
  }

  protected override void setParts(GameObject o, BL.Unit parts)
  {
    Battle01PlayerUnit component = o.GetComponent<Battle01PlayerUnit>();
    component.setUnit(parts);
    component.isViewCounter = true;
  }

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    Battle01PlayerUnit inParents = NGUITools.FindInParents<Battle01PlayerUnit>(UICamera.selectedObject);
    if (!Object.op_Inequality((Object) inParents, (Object) null))
      return;
    BL.Unit unit = inParents.getUnit();
    if (unit == null || unit.isDead || unit == this.env.core.unitCurrent.unit)
      return;
    this.battleManager.getManager<BattleTimeManager>().setCurrentUnit(unit);
    this.battleManager.StartCoroutine(this.doSelectMask());
  }

  [DebuggerHidden]
  private IEnumerator doSelectMask()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator852 maskCIterator852 = new Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator852();
    return (IEnumerator) maskCIterator852;
  }
}
