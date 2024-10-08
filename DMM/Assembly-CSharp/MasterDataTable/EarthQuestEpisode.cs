﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestEpisode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestEpisode
  {
    public int ID;
    public int chapter_EarthQuestChapter;
    public string episode;
    public string episode_name;
    public int stage_index;
    public int stage_BattleStage;
    public string background_name;
    public int? script;

    public static EarthQuestEpisode Parse(MasterDataReader reader) => new EarthQuestEpisode()
    {
      ID = reader.ReadInt(),
      chapter_EarthQuestChapter = reader.ReadInt(),
      episode = reader.ReadString(true),
      episode_name = reader.ReadString(true),
      stage_index = reader.ReadInt(),
      stage_BattleStage = reader.ReadInt(),
      background_name = reader.ReadString(true),
      script = reader.ReadIntOrNull()
    };

    public EarthQuestChapter chapter
    {
      get
      {
        EarthQuestChapter earthQuestChapter;
        if (!MasterData.EarthQuestChapter.TryGetValue(this.chapter_EarthQuestChapter, out earthQuestChapter))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestChapter[" + (object) this.chapter_EarthQuestChapter + "]"));
        return earthQuestChapter;
      }
    }

    public BattleStage stage
    {
      get
      {
        BattleStage battleStage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out battleStage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return battleStage;
      }
    }
  }
}
