// Decompiled with JetBrains decompiler
// Type: BattleWaveFinalize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class BattleWaveFinalize : BattleMonoBehaviour
{
  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleWaveFinalize.\u003CStart_Battle\u003Ec__Iterator9B2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private BattleWaveFinishInfo CreateBattleFinishInfo(
    int stage_id,
    List<BL.Unit> enemys,
    List<Tuple<BL.DropData, int>> dropDatas)
  {
    BattleWaveFinishInfo battleFinishInfo = new BattleWaveFinishInfo();
    battleFinishInfo.stage_id = stage_id;
    List<int> intList1 = new List<int>();
    List<int> intList2 = new List<int>();
    List<int> intList3 = new List<int>();
    List<int> intList4 = new List<int>();
    List<int> intList5 = new List<int>();
    List<int> intList6 = new List<int>();
    foreach (BL.Unit unit in this.env.core.enemyUnits.value)
    {
      if (unit.hasDrop && unit.drop.isCompleted)
        intList1.Add(unit.playerUnit.id);
      intList2.Add(unit.playerUnit.id);
      intList3.Add(unit.hp > 0 ? 0 : 1);
      intList4.Add(unit.killCount);
      if (unit.killedBy != null)
      {
        intList5.Add(unit.playerUnit.level - unit.killedBy.playerUnit.level);
        intList6.Add(unit.overkillDamage);
      }
      else
      {
        intList5.Add(0);
        intList6.Add(0);
      }
    }
    battleFinishInfo.drop_entity_ids = intList1.ToArray();
    battleFinishInfo.enemy_results_enemy_id = intList2.ToArray();
    battleFinishInfo.enemy_results_dead_count = intList3.ToArray();
    battleFinishInfo.enemy_results_kill_count = intList4.ToArray();
    battleFinishInfo.enemy_results_level_difference = intList5.ToArray();
    battleFinishInfo.enemy_results_overkill_damage = intList6.ToArray();
    List<int> intList7 = new List<int>();
    foreach (Tuple<BL.DropData, int> dropData in dropDatas)
      intList7.Add(dropData.Item2);
    battleFinishInfo.panel_entity_ids = intList7.ToArray();
    return battleFinishInfo;
  }
}
