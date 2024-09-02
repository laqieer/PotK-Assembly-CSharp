// Decompiled with JetBrains decompiler
// Type: PlayerQuestSConverter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;

#nullable disable
public class PlayerQuestSConverter
{
  public int _quest_s_id;
  public bool is_clear;
  public int consumed_ap;
  public bool enable_autobattle;
  public bool is_new;
  public int[] clear_rewards;
  public QuestSConverter questS;

  public PlayerQuestSConverter(PlayerCharacterQuestS quest)
  {
    this._quest_s_id = quest._quest_character_s;
    this.is_clear = quest.is_clear;
    this.consumed_ap = quest.consumed_ap;
    this.enable_autobattle = quest.enable_autobattle;
    this.is_new = quest.is_new;
    this.clear_rewards = quest.clear_rewards;
    this.questS = new QuestSConverter(quest.quest_character_s, quest.consumed_ap);
  }

  public PlayerQuestSConverter(PlayerHarmonyQuestS quest)
  {
    this._quest_s_id = quest._quest_harmony_s;
    this.is_clear = quest.is_clear;
    this.consumed_ap = quest.consumed_ap;
    this.enable_autobattle = quest.enable_autobattle;
    this.is_new = quest.is_new;
    this.clear_rewards = quest.clear_rewards;
    this.questS = new QuestSConverter(quest.quest_harmony_s, quest.consumed_ap);
  }
}
