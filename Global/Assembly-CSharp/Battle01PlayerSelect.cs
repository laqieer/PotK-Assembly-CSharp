// Decompiled with JetBrains decompiler
// Type: Battle01PlayerSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return ResourceManager.Load<GameObject>("Prefabs/battle/Battle01 Player Unit");
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
    Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator70B maskCIterator70B = new Battle01PlayerSelect.\u003CdoSelectMask\u003Ec__Iterator70B();
    return (IEnumerator) maskCIterator70B;
  }
}
