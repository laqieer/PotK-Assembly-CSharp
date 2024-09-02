// Decompiled with JetBrains decompiler
// Type: QuestSConverter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class QuestSConverter
{
  public QuestSConverter.DataType data_type;
  public int ID;
  public string name;
  public int unit_id;
  public int target_unit_id;
  public int quest_m_id;
  public int priority;
  public int? has_reward;
  public int lost_ap;
  public int stage_BattleStage;
  public bool disable_continue;
  public UnitUnit unit;
  public UnitUnit target_unit;
  public BattleStage stage;
  public QuestMConverter quest_m;
  public UnitGender gender_restriction;

  public QuestSConverter(QuestCharacterS quest, int lost_ap)
  {
    this.data_type = QuestSConverter.DataType.Character;
    this.ID = quest.ID;
    this.name = quest.name;
    this.unit_id = quest.unit_UnitUnit;
    this.target_unit_id = 0;
    this.priority = quest.priority;
    this.has_reward = quest.has_reward;
    this.lost_ap = lost_ap <= 0 ? quest.lost_ap : lost_ap;
    this.stage_BattleStage = quest.stage_BattleStage;
    this.disable_continue = quest.disable_continue;
    this.unit = quest.unit;
    this.target_unit = (UnitUnit) null;
    this.stage = quest.stage;
    this.quest_m = new QuestMConverter(quest.quest_m);
    this.gender_restriction = quest.gender_restriction;
  }

  public QuestSConverter(QuestHarmonyS quest, int lost_ap)
  {
    this.data_type = QuestSConverter.DataType.Harmony;
    this.ID = quest.ID;
    this.name = quest.name;
    this.unit_id = quest.unit_UnitUnit;
    this.target_unit_id = quest.target_unit_UnitUnit;
    this.priority = quest.priority;
    this.has_reward = quest.has_reward;
    this.lost_ap = lost_ap <= 0 ? quest.lost_ap : lost_ap;
    this.stage_BattleStage = quest.stage_BattleStage;
    this.disable_continue = false;
    this.unit = quest.unit;
    this.target_unit = quest.target_unit;
    this.stage = quest.stage;
    this.quest_m = new QuestMConverter(quest.quest_m);
    this.gender_restriction = quest.gender_restriction;
  }

  public enum DataType
  {
    Character,
    Harmony,
  }
}
