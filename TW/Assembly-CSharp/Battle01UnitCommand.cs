// Decompiled with JetBrains decompiler
// Type: Battle01UnitCommand
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01UnitCommand : NGBattleMenuBase
{
  [SerializeField]
  private SelectParts selectParts;
  private SelectParts completeSelectParts;
  private BL.ForceID forceId;
  private BL.BattleModified<BL.CurrentUnit> unitModified;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01UnitCommand.\u003ConInitAsync\u003Ec__Iterator940()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.unitModified.isChangedOnce())
      return;
    this.selectCurrentUnitCommand(this.unitModified.value.unit);
  }

  private void selectCurrentUnitCommand(BL.Unit unit)
  {
    if (unit == null)
    {
      this.forceId = BL.ForceID.none;
    }
    else
    {
      BL.ForceID forceId = this.env.core.getForceID(unit);
      bool flag = this.forceId != forceId;
      this.forceId = forceId;
      if (this.env.core.isCompleted(unit))
      {
        this.completeSelectParts.setValue(1);
      }
      else
      {
        this.completeSelectParts.setValue(0);
        if (unit.IsDontAction)
        {
          if (flag)
            this.selectParts.setFirstValue(0);
          else
            this.selectParts.setValue(0);
        }
        else if (unit.hasOugi)
        {
          if (unit.hasMapSkill)
          {
            if (flag)
              this.selectParts.setFirstValue(2);
            else
              this.selectParts.setValue(2);
          }
          else if (flag)
            this.selectParts.setFirstValue(3);
          else
            this.selectParts.setValue(3);
        }
        else if (unit.hasMapSkill)
        {
          if (flag)
            this.selectParts.setFirstValue(1);
          else
            this.selectParts.setValue(1);
        }
        else if (flag)
          this.selectParts.setFirstValue(0);
        else
          this.selectParts.setValue(0);
      }
    }
  }
}
