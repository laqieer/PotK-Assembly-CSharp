﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerPlaybackStoryDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerPlaybackStoryDetail
  {
    public int ID;
    public string name;
    public int stage_TowerStage;
    public int story_TowerPlaybackStory;
    public int timing_StoryPlaybackTiming;
    public int? stage_enemy_BattleStageEnemy;
    public int attack_timing_type;
    public int script_id;
    public int timing_parameter_0;
    public int timing_parameter_1;
    public int timing_parameter_2;
    public int timing_parameter_3;

    public static TowerPlaybackStoryDetail Parse(MasterDataReader reader) => new TowerPlaybackStoryDetail()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      stage_TowerStage = reader.ReadInt(),
      story_TowerPlaybackStory = reader.ReadInt(),
      timing_StoryPlaybackTiming = reader.ReadInt(),
      stage_enemy_BattleStageEnemy = reader.ReadIntOrNull(),
      attack_timing_type = reader.ReadInt(),
      script_id = reader.ReadInt(),
      timing_parameter_0 = reader.ReadInt(),
      timing_parameter_1 = reader.ReadInt(),
      timing_parameter_2 = reader.ReadInt(),
      timing_parameter_3 = reader.ReadInt()
    };

    public TowerStage stage
    {
      get
      {
        TowerStage towerStage;
        if (!MasterData.TowerStage.TryGetValue(this.stage_TowerStage, out towerStage))
          Debug.LogError((object) ("Key not Found: MasterData.TowerStage[" + (object) this.stage_TowerStage + "]"));
        return towerStage;
      }
    }

    public TowerPlaybackStory story
    {
      get
      {
        TowerPlaybackStory towerPlaybackStory;
        if (!MasterData.TowerPlaybackStory.TryGetValue(this.story_TowerPlaybackStory, out towerPlaybackStory))
          Debug.LogError((object) ("Key not Found: MasterData.TowerPlaybackStory[" + (object) this.story_TowerPlaybackStory + "]"));
        return towerPlaybackStory;
      }
    }

    public StoryPlaybackTiming timing => (StoryPlaybackTiming) this.timing_StoryPlaybackTiming;

    public BattleStageEnemy stage_enemy
    {
      get
      {
        if (!this.stage_enemy_BattleStageEnemy.HasValue)
          return (BattleStageEnemy) null;
        BattleStageEnemy battleStageEnemy;
        if (!MasterData.BattleStageEnemy.TryGetValue(this.stage_enemy_BattleStageEnemy.Value, out battleStageEnemy))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStageEnemy[" + (object) this.stage_enemy_BattleStageEnemy.Value + "]"));
        return battleStageEnemy;
      }
    }

    public Tuple<StoryPlaybackTiming, int, object[]> toTuple()
    {
      object[] objArray;
      switch (this.timing)
      {
        case StoryPlaybackTiming.turn_start:
          objArray = new object[3]
          {
            (object) this.attack_timing_type,
            (object) this.timing_parameter_0,
            (object) this.timing_parameter_1
          };
          break;
        case StoryPlaybackTiming.in_area:
          objArray = new object[5]
          {
            (object) this.attack_timing_type,
            (object) (this.timing_parameter_1 - 1),
            (object) (this.timing_parameter_0 - 1),
            (object) this.timing_parameter_3,
            (object) this.timing_parameter_2
          };
          break;
        case StoryPlaybackTiming.defeat_player:
          if (this.stage_enemy_BattleStageEnemy.HasValue)
          {
            objArray = new object[1]
            {
              (object) this.stage_enemy_BattleStageEnemy
            };
            break;
          }
          objArray = new object[0];
          Debug.LogError((object) ("ScriptID=" + this.script_id.ToString() + ",StoryPlaybackTiming.defeat_playerのパラメータ不足"));
          break;
        case StoryPlaybackTiming.wave_clear:
          objArray = new object[1]
          {
            (object) this.timing_parameter_0
          };
          break;
        default:
          if (this.stage_enemy_BattleStageEnemy.HasValue)
          {
            objArray = new object[2]
            {
              (object) this.attack_timing_type,
              (object) this.stage_enemy_BattleStageEnemy
            };
            break;
          }
          objArray = new object[0];
          break;
      }
      return Tuple.Create<StoryPlaybackTiming, int, object[]>(this.timing, this.script_id, objArray);
    }
  }
}
