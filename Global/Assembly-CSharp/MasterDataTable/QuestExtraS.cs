// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraS
  {
    public int ID;
    private string _name;
    public int quest_l_QuestExtraL;
    public int quest_m_QuestExtraM;
    public int number_s;
    public int banner_id;
    public int? has_reward;
    public int lost_ap;
    public int priority;
    public int stage_BattleStage;
    public int extra_quest_area_CommonExtraQuestArea;
    public bool disable_continue;
    public string seek_index;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraS_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestExtraS Parse(MasterDataReader reader)
    {
      return new QuestExtraS()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        quest_l_QuestExtraL = reader.ReadInt(),
        quest_m_QuestExtraM = reader.ReadInt(),
        number_s = reader.ReadInt(),
        banner_id = reader.ReadInt(),
        has_reward = reader.ReadIntOrNull(),
        lost_ap = reader.ReadInt(),
        priority = reader.ReadInt(),
        stage_BattleStage = reader.ReadInt(),
        extra_quest_area_CommonExtraQuestArea = reader.ReadInt(),
        disable_continue = reader.ReadBool(),
        seek_index = reader.ReadString(true)
      };
    }

    public QuestExtraL quest_l
    {
      get
      {
        QuestExtraL questL;
        if (!MasterData.QuestExtraL.TryGetValue(this.quest_l_QuestExtraL, out questL))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraL[" + (object) this.quest_l_QuestExtraL + "]"));
        return questL;
      }
    }

    public QuestExtraM quest_m
    {
      get
      {
        QuestExtraM questM;
        if (!MasterData.QuestExtraM.TryGetValue(this.quest_m_QuestExtraM, out questM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraM[" + (object) this.quest_m_QuestExtraM + "]"));
        return questM;
      }
    }

    public BattleStage stage
    {
      get
      {
        BattleStage stage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out stage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return stage;
      }
    }

    public CommonExtraQuestArea extra_quest_area
    {
      get => (CommonExtraQuestArea) this.extra_quest_area_CommonExtraQuestArea;
    }

    public StoryPlaybackExtraDetail[] ExtraDetails()
    {
      return ((IEnumerable<StoryPlaybackExtraDetail>) MasterData.StoryPlaybackExtraDetailList).Where<StoryPlaybackExtraDetail>((Func<StoryPlaybackExtraDetail, bool>) (x => x.extra.quest.ID == this.ID)).ToArray<StoryPlaybackExtraDetail>();
    }

    public StoryPlaybackExtraDetail GetExtraDetail(StoryPlaybackTiming timing)
    {
      return ((IEnumerable<StoryPlaybackExtraDetail>) this.ExtraDetails()).SingleOrDefault<StoryPlaybackExtraDetail>((Func<StoryPlaybackExtraDetail, bool>) (x => x.timing == timing));
    }

    public string GetBackgroundPath()
    {
      return this.quest_m != null && this.quest_m.background != null && !string.IsNullOrEmpty(this.quest_m.background.background_name) ? string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) this.quest_m.background.background_name) : Consts.GetInstance().DEFAULT_BACKGROUND;
    }
  }
}
