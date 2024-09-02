// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackExtraDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackExtraDetail
  {
    public int ID;
    private string _name;
    public int quest_QuestExtraS;
    public int extra_StoryPlaybackExtra;
    public int timing_StoryPlaybackTiming;
    public int? stage_enemy_BattleStageEnemy;
    public int attack_timing_type;
    public int script_ScriptScript;
    public int timing_parameter_0;
    public int timing_parameter_1;
    public int timing_parameter_2;
    public int timing_parameter_3;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("story_playback_StoryPlaybackExtraDetail_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static StoryPlaybackExtraDetail Parse(MasterDataReader reader)
    {
      return new StoryPlaybackExtraDetail()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        quest_QuestExtraS = reader.ReadInt(),
        extra_StoryPlaybackExtra = reader.ReadInt(),
        timing_StoryPlaybackTiming = reader.ReadInt(),
        stage_enemy_BattleStageEnemy = reader.ReadIntOrNull(),
        attack_timing_type = reader.ReadInt(),
        script_ScriptScript = reader.ReadInt(),
        timing_parameter_0 = reader.ReadInt(),
        timing_parameter_1 = reader.ReadInt(),
        timing_parameter_2 = reader.ReadInt(),
        timing_parameter_3 = reader.ReadInt()
      };
    }

    public QuestExtraS quest
    {
      get
      {
        QuestExtraS quest;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_QuestExtraS, out quest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_QuestExtraS + "]"));
        return quest;
      }
    }

    public StoryPlaybackExtra extra
    {
      get
      {
        StoryPlaybackExtra extra;
        if (!MasterData.StoryPlaybackExtra.TryGetValue(this.extra_StoryPlaybackExtra, out extra))
          Debug.LogError((object) ("Key not Found: MasterData.StoryPlaybackExtra[" + (object) this.extra_StoryPlaybackExtra + "]"));
        return extra;
      }
    }

    public StoryPlaybackTiming timing => (StoryPlaybackTiming) this.timing_StoryPlaybackTiming;

    public BattleStageEnemy stage_enemy
    {
      get
      {
        if (!this.stage_enemy_BattleStageEnemy.HasValue)
          return (BattleStageEnemy) null;
        BattleStageEnemy stageEnemy;
        if (!MasterData.BattleStageEnemy.TryGetValue(this.stage_enemy_BattleStageEnemy.Value, out stageEnemy))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStageEnemy[" + (object) this.stage_enemy_BattleStageEnemy.Value + "]"));
        return stageEnemy;
      }
    }

    public ScriptScript script
    {
      get
      {
        ScriptScript script;
        if (!MasterData.ScriptScript.TryGetValue(this.script_ScriptScript, out script))
          Debug.LogError((object) ("Key not Found: MasterData.ScriptScript[" + (object) this.script_ScriptScript + "]"));
        return script;
      }
    }

    public Tuple<StoryPlaybackTiming, int, object[]> toTuple()
    {
      object[] objArray;
      switch (this.timing)
      {
        case StoryPlaybackTiming.turn_start:
          objArray = new object[2]
          {
            (object) this.attack_timing_type,
            (object) this.timing_parameter_0
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
          Debug.LogError((object) ("ScriptID=" + this.script.ID.ToString() + ",StoryPlaybackTiming.defeat_playerのパラメータ不足"));
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
      return Tuple.Create<StoryPlaybackTiming, int, object[]>(this.timing, this.script.ID, objArray);
    }
  }
}
