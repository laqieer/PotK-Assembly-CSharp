// Decompiled with JetBrains decompiler
// Type: AI.Logic.AILogicBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace AI.Logic
{
  public abstract class AILogicBase
  {
    public BL env;

    public virtual void cleanup()
    {
      this.terminateAI();
      this.env.aiUnitPositions.value = (List<BL.AIUnit>) null;
      this.env.aiUnits.value = (List<BL.AIUnit>) null;
      this.env.aiActionUnits.value = (List<BL.AIUnit>) null;
      this.env.aiActionOrder.value = (Queue<BL.AIUnit>) null;
      this.env.aiDeads.value = (List<BL.AIUnit>) null;
    }

    public virtual bool terminateAI() => true;

    public virtual void initUnits(List<BL.UnitPosition> units, int max)
    {
      List<BL.AIUnit> aiUnitList1 = new List<BL.AIUnit>();
      List<BL.AIUnit> aiUnitList2 = new List<BL.AIUnit>();
      List<BL.AIUnit> aiUnitList3 = new List<BL.AIUnit>();
      foreach (BL.UnitPosition up in (IEnumerable<BL.UnitPosition>) this.env.unitPositions.value.OrderBy<BL.UnitPosition, int>((Func<BL.UnitPosition, int>) (x => x.unit.AIMoveGroupOrder)))
      {
        BL.AIUnit aiUnit = new BL.AIUnit(up, BL.AIType.normal);
        if (up.unit.isEnable && !up.unit.isDead && up.unit.hp > 0)
        {
          aiUnitList1.Add(aiUnit);
          if (units.Contains(up))
          {
            aiUnitList2.Add(aiUnit);
            aiUnitList3.Add(aiUnit);
          }
        }
      }
      this.env.aiUnitPositions.value = aiUnitList1;
      this.env.aiUnits.value = aiUnitList2;
      this.env.aiActionUnits.value = aiUnitList3;
      this.env.aiActionOrder.value = new Queue<BL.AIUnit>();
      this.env.aiDeads.value = new List<BL.AIUnit>();
      this.env.aiActionMax = max;
    }

    public abstract IEnumerator doExecute();

    public void reset()
    {
      List<BL.AIUnit> aiUnitList = new List<BL.AIUnit>();
      foreach (BL.AIUnit aiUnit in this.env.aiUnits.value)
        aiUnitList.Add(aiUnit);
      this.env.aiActionUnits.value = aiUnitList;
      this.env.aiActionOrder.value = new Queue<BL.AIUnit>();
      this.env.aiDeads.value = new List<BL.AIUnit>();
    }

    public bool isInitialized
    {
      get
      {
        return this.env.aiUnits.value != null && this.env.aiUnits.value.Count != 0 && this.env.aiActionUnits.value != null && this.env.aiActionUnits.value.Count != 0;
      }
    }

    public bool isCompleted
    {
      get
      {
        return this.env.aiActionUnits.value != null && this.env.aiActionUnits.value.Count == 0 && this.env.aiActionOrder.value != null && this.env.aiActionOrder.value.Count != 0;
      }
    }
  }
}
