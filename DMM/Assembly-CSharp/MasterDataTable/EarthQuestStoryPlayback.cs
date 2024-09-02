// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestStoryPlayback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestStoryPlayback
  {
    public int ID;
    public int episode_EarthQuestEpisode;
    public int timing_StoryPlaybackTiming;
    public int? stage_enemy_BattleStageEnemy;
    public int attack_timing_type;
    public int script_id;
    public string title;

    public static EarthQuestStoryPlayback Parse(MasterDataReader reader) => new EarthQuestStoryPlayback()
    {
      ID = reader.ReadInt(),
      episode_EarthQuestEpisode = reader.ReadInt(),
      timing_StoryPlaybackTiming = reader.ReadInt(),
      stage_enemy_BattleStageEnemy = reader.ReadIntOrNull(),
      attack_timing_type = reader.ReadInt(),
      script_id = reader.ReadInt(),
      title = reader.ReadString(true)
    };

    public EarthQuestEpisode episode
    {
      get
      {
        EarthQuestEpisode earthQuestEpisode;
        if (!MasterData.EarthQuestEpisode.TryGetValue(this.episode_EarthQuestEpisode, out earthQuestEpisode))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestEpisode[" + (object) this.episode_EarthQuestEpisode + "]"));
        return earthQuestEpisode;
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
  }
}
