// Decompiled with JetBrains decompiler
// Type: BattleWaveFinalize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleWaveFinalize.\u003CStart_Battle\u003Ec__IteratorA87()
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
    foreach (BL.Unit enemy in enemys)
    {
      if (enemy.hasDrop && enemy.drop.isCompleted)
        intList1.Add(enemy.playerUnit.id);
      intList2.Add(enemy.playerUnit.id);
      intList3.Add(enemy.hp > 0 ? 0 : 1);
      intList4.Add(enemy.killCount);
      if (enemy.killedBy != null)
      {
        intList5.Add(enemy.playerUnit.level - enemy.killedBy.playerUnit.level);
        intList6.Add(enemy.overkillDamage);
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
