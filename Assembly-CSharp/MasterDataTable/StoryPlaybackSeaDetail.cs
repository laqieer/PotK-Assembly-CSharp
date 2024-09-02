// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackSeaDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackSeaDetail
  {
    public int ID;
    public string name;
    public int quest_s_id_QuestSeaS;
    public int story_StoryPlaybackSea;
    public int timing_StoryPlaybackTiming;
    public int? stage_enemy_BattleStageEnemy;
    public int attack_timing_type;
    public int script_id;
    public int timing_parameter_0;
    public int timing_parameter_1;
    public int timing_parameter_2;
    public int timing_parameter_3;
    public bool continuous_flag;

    public static StoryPlaybackSeaDetail Parse(MasterDataReader reader) => new StoryPlaybackSeaDetail()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      quest_s_id_QuestSeaS = reader.ReadInt(),
      story_StoryPlaybackSea = reader.ReadInt(),
      timing_StoryPlaybackTiming = reader.ReadInt(),
      stage_enemy_BattleStageEnemy = reader.ReadIntOrNull(),
      attack_timing_type = reader.ReadInt(),
      script_id = reader.ReadInt(),
      timing_parameter_0 = reader.ReadInt(),
      timing_parameter_1 = reader.ReadInt(),
      timing_parameter_2 = reader.ReadInt(),
      timing_parameter_3 = reader.ReadInt(),
      continuous_flag = reader.ReadBool()
    };

    public QuestSeaS quest_s_id
    {
      get
      {
        QuestSeaS questSeaS;
        if (!MasterData.QuestSeaS.TryGetValue(this.quest_s_id_QuestSeaS, out questSeaS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaS[" + (object) this.quest_s_id_QuestSeaS + "]"));
        return questSeaS;
      }
    }

    public StoryPlaybackSea story
    {
      get
      {
        StoryPlaybackSea storyPlaybackSea;
        if (!MasterData.StoryPlaybackSea.TryGetValue(this.story_StoryPlaybackSea, out storyPlaybackSea))
          Debug.LogError((object) ("Key not Found: MasterData.StoryPlaybackSea[" + (object) this.story_StoryPlaybackSea + "]"));
        return storyPlaybackSea;
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
