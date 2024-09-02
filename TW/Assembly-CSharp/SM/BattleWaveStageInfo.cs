// Decompiled with JetBrains decompiler
// Type: SM.BattleWaveStageInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class BattleWaveStageInfo : KeyCompare
  {
    public int[] enemy;
    public int stage_id;
    public PlayerUnit[] user_deck_units;
    public BattleWaveStageInfoPanel_item[] panel_item;
    public BattleWaveStageInfoUser_deck_enemy_item[] user_deck_enemy_item;
    public PlayerItem[] user_deck_gears;
    public int[] user_deck_enemy;
    public BattleWaveStageInfoEnemy_item[] enemy_item;
    public int[] panel;

    public BattleWaveStageInfo()
    {
    }

    public BattleWaveStageInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.enemy = ((IEnumerable<object>) json[nameof (enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.stage_id = (int) (long) json[nameof (stage_id)];
      List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
      foreach (object json1 in (List<object>) json[nameof (user_deck_units)])
        playerUnitList.Add(json1 != null ? new PlayerUnit((Dictionary<string, object>) json1) : (PlayerUnit) null);
      this.user_deck_units = playerUnitList.ToArray();
      List<BattleWaveStageInfoPanel_item> stageInfoPanelItemList = new List<BattleWaveStageInfoPanel_item>();
      foreach (object json2 in (List<object>) json[nameof (panel_item)])
        stageInfoPanelItemList.Add(json2 != null ? new BattleWaveStageInfoPanel_item((Dictionary<string, object>) json2) : (BattleWaveStageInfoPanel_item) null);
      this.panel_item = stageInfoPanelItemList.ToArray();
      List<BattleWaveStageInfoUser_deck_enemy_item> userDeckEnemyItemList = new List<BattleWaveStageInfoUser_deck_enemy_item>();
      foreach (object json3 in (List<object>) json[nameof (user_deck_enemy_item)])
        userDeckEnemyItemList.Add(json3 != null ? new BattleWaveStageInfoUser_deck_enemy_item((Dictionary<string, object>) json3) : (BattleWaveStageInfoUser_deck_enemy_item) null);
      this.user_deck_enemy_item = userDeckEnemyItemList.ToArray();
      List<PlayerItem> playerItemList = new List<PlayerItem>();
      foreach (object json4 in (List<object>) json[nameof (user_deck_gears)])
        playerItemList.Add(json4 != null ? new PlayerItem((Dictionary<string, object>) json4) : (PlayerItem) null);
      this.user_deck_gears = playerItemList.ToArray();
      this.user_deck_enemy = ((IEnumerable<object>) json[nameof (user_deck_enemy)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      List<BattleWaveStageInfoEnemy_item> stageInfoEnemyItemList = new List<BattleWaveStageInfoEnemy_item>();
      foreach (object json5 in (List<object>) json[nameof (enemy_item)])
        stageInfoEnemyItemList.Add(json5 != null ? new BattleWaveStageInfoEnemy_item((Dictionary<string, object>) json5) : (BattleWaveStageInfoEnemy_item) null);
      this.enemy_item = stageInfoEnemyItemList.ToArray();
      this.panel = ((IEnumerable<object>) json[nameof (panel)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
    }
  }
}
