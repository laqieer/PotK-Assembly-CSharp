// Decompiled with JetBrains decompiler
// Type: QuestConverterData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;

#nullable disable
public class QuestConverterData
{
  public int? id_XL;
  public int id_L;
  public int id_M;
  public int id_S;
  public bool is_new;
  public bool is_clear;
  public string title_M;
  public string title_S;
  public int numM_in_thisL;
  public int numS_in_thisM;
  public int lost_ap;
  public string victory_sub_name;
  public string victory_name;
  public string hscroll_bg_name;
  public string sub_bg_name;
  public bool canPlay;
  public int? has_reward;
  public string seek_index;
  public int? button_folder_ID;
  public CommonQuestType type;
  public CommonQuestMode? mode;
  public float offset_x;
  public float offset_y;
  public float scale;
  public int? remain_battle_count;
  public int daily_limit;
  public int daily_limit_strictly;
  public int max_battle_count_limit;
  public int[] clear_rewards;
  public QuestWave wave;

  public QuestConverterData(PlayerStoryQuestS story)
  {
    this.SetData(new int?(story.quest_story_s.quest_xl_QuestStoryXL), story.quest_story_s.quest_l_QuestStoryL, story.quest_story_s.quest_m_QuestStoryM, story.quest_story_s.ID, story.is_new, story.is_clear, story.quest_story_s.quest_m.number_m, story.quest_story_s.number_s, story.quest_story_s.quest_m.name, story.quest_story_s.name, story.consumed_ap, story.quest_story_s.stage.victory_condition.sub_name, story.quest_story_s.stage.victory_condition.name, story.quest_story_s.quest_m.background_button_name, story.quest_story_s.quest_m.background.background_name, true, story.quest_story_s.has_reward, string.Empty, new int?(), CommonQuestType.Story, new CommonQuestMode?(story.quest_story_s.quest_l.quest_mode), story.quest_story_s.quest_m.background.offset_x, story.quest_story_s.quest_m.background.offset_y, story.quest_story_s.quest_m.background.scale, new int?(), 0, 0, 0, story.clear_rewards, (QuestWave) null);
  }

  public QuestConverterData(PlayerExtraQuestS extra)
  {
    this.SetData(new int?(), extra.quest_extra_s.quest_l_QuestExtraL, extra.quest_extra_s.quest_m_QuestExtraM, extra.quest_extra_s.ID, extra.is_new, extra.is_clear, extra.quest_extra_s.quest_m.priority, extra.quest_extra_s.number_s, extra.quest_extra_s.quest_m.name, extra.quest_extra_s.name, extra.consumed_ap, extra.quest_extra_s.stage.victory_condition.sub_name, extra.quest_extra_s.stage.victory_condition.name, extra.quest_extra_s.quest_m.background_button_name, extra.quest_extra_s.quest_m.background.background_name, !extra.time_locked_at.HasValue, extra.quest_extra_s.has_reward, extra.seek_index, extra.quest_extra_s.quest_m.button_type, CommonQuestType.Extra, new CommonQuestMode?(), extra.quest_extra_s.quest_m.background.offset_x, extra.quest_extra_s.quest_m.background.offset_y, extra.quest_extra_s.quest_m.background.scale, extra.remain_battle_count, extra.daily_limit, extra.daily_limit_strictly, extra.max_battle_count_limit, extra.clear_rewards, extra.quest_extra_s.wave);
  }

  private void SetData(
    int? xl,
    int l,
    int m,
    int s,
    bool thisnew,
    bool thisclear,
    int numM,
    int numS,
    string titleM,
    string titleS,
    int ap,
    string victSubName,
    string victName,
    string hscroll_bg,
    string sub_bg,
    bool canPlay,
    int? reward,
    string seek,
    int? folderID,
    CommonQuestType questtype,
    CommonQuestMode? questmode,
    float offset_x,
    float offset_y,
    float scale,
    int? remainBattleCount,
    int dailyLimit,
    int dailyLimitStrictly,
    int maxBattleCountLimit,
    int[] clear_rewards,
    QuestWave wave)
  {
    this.id_XL = xl;
    this.id_L = l;
    this.id_M = m;
    this.id_S = s;
    this.is_new = thisnew;
    this.is_clear = thisclear;
    this.numM_in_thisL = numM;
    this.numS_in_thisM = numS;
    this.title_M = titleM;
    this.title_S = titleS;
    this.lost_ap = ap;
    this.victory_sub_name = victSubName;
    this.victory_name = victName;
    this.hscroll_bg_name = hscroll_bg;
    this.sub_bg_name = sub_bg;
    this.has_reward = reward;
    this.seek_index = seek;
    this.button_folder_ID = folderID;
    this.type = questtype;
    this.mode = questmode;
    this.offset_x = offset_x;
    this.offset_y = offset_y;
    this.scale = scale;
    this.remain_battle_count = remainBattleCount;
    this.daily_limit = dailyLimit;
    this.daily_limit_strictly = dailyLimitStrictly;
    this.max_battle_count_limit = maxBattleCountLimit;
    this.clear_rewards = clear_rewards;
    this.wave = wave;
    if (this.remain_battle_count.HasValue)
    {
      if (this.remain_battle_count.Value > 0 && canPlay)
        this.canPlay = true;
      else
        this.canPlay = false;
    }
    else
      this.canPlay = canPlay;
  }
}
