// Decompiled with JetBrains decompiler
// Type: Battle01PlayerSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator91D maskCIterator91D = new Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator91D();
    return (IEnumerator) maskCIterator91D;
  }
}
