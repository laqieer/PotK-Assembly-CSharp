// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestSeaS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class QuestSeaS
  {
    public int ID;
    public string name;
    public int priority;
    public int quest_xl_QuestSeaXL;
    public int quest_l_QuestSeaL;
    public int quest_m_QuestSeaM;
    public int number_s;
    public int? has_reward;
    public int lost_ap;
    public int stage_BattleStage;
    public bool disable_continue;
    public int gender_restriction_UnitGender;
    public bool story_only;

    public static QuestSeaS Parse(MasterDataReader reader) => new QuestSeaS()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      priority = reader.ReadInt(),
      quest_xl_QuestSeaXL = reader.ReadInt(),
      quest_l_QuestSeaL = reader.ReadInt(),
      quest_m_QuestSeaM = reader.ReadInt(),
      number_s = reader.ReadInt(),
      has_reward = reader.ReadIntOrNull(),
      lost_ap = reader.ReadInt(),
      stage_BattleStage = reader.ReadInt(),
      disable_continue = reader.ReadBool(),
      gender_restriction_UnitGender = reader.ReadInt(),
      story_only = reader.ReadBool()
    };

    public QuestSeaXL quest_xl
    {
      get
      {
        QuestSeaXL questSeaXl;
        if (!MasterData.QuestSeaXL.TryGetValue(this.quest_xl_QuestSeaXL, out questSeaXl))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaXL[" + (object) this.quest_xl_QuestSeaXL + "]"));
        return questSeaXl;
      }
    }

    public QuestSeaL quest_l
    {
      get
      {
        QuestSeaL questSeaL;
        if (!MasterData.QuestSeaL.TryGetValue(this.quest_l_QuestSeaL, out questSeaL))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaL[" + (object) this.quest_l_QuestSeaL + "]"));
        return questSeaL;
      }
    }

    public QuestSeaM quest_m
    {
      get
      {
        QuestSeaM questSeaM;
        if (!MasterData.QuestSeaM.TryGetValue(this.quest_m_QuestSeaM, out questSeaM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaM[" + (object) this.quest_m_QuestSeaM + "]"));
        return questSeaM;
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

    public UnitGender gender_restriction => (UnitGender) this.gender_restriction_UnitGender;

    public StoryPlaybackSeaDetail GetStoryDetail(StoryPlaybackTiming timing) => ((IEnumerable<StoryPlaybackSeaDetail>) this.StoryDetails()).SingleOrDefault<StoryPlaybackSeaDetail>((Func<StoryPlaybackSeaDetail, bool>) (x => x.timing == timing));

    public StoryPlaybackSeaDetail[] StoryDetails() => ((IEnumerable<StoryPlaybackSeaDetail>) MasterData.StoryPlaybackSeaDetailList).Where<StoryPlaybackSeaDetail>((Func<StoryPlaybackSeaDetail, bool>) (x => x.quest_s_id.ID == this.ID)).ToArray<StoryPlaybackSeaDetail>();

    public string GetBackgroundPath() => this.quest_m != null && this.quest_m.background != null && !string.IsNullOrEmpty(this.quest_m.background.background_name) ? string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) this.quest_m.background.background_name) : Consts.GetInstance().DEFULAT_BACKGROUND;
  }
}
