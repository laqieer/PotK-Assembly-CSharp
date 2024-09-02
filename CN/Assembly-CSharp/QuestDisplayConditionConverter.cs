// Decompiled with JetBrains decompiler
// Type: QuestDisplayConditionConverter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class QuestDisplayConditionConverter
{
  public int ID;
  public int quest_s_id;
  public int priority;
  public int unit_UnitUnit;
  public string name;
  public QuestSConverter quest_s;
  public UnitUnit unit;

  public QuestDisplayConditionConverter(QuestCharacterDisplayCondition quest)
  {
    this.ID = quest.ID;
    this.quest_s_id = quest.quest_s_QuestCharacterS;
    this.priority = quest.priority;
    this.unit_UnitUnit = quest.unit_UnitUnit;
    this.name = quest.name;
    this.quest_s = new QuestSConverter(quest.quest_s, 0);
    this.unit = quest.unit;
  }

  public QuestDisplayConditionConverter(QuestHarmonyDisplayCondition quest)
  {
    this.ID = quest.ID;
    this.quest_s_id = quest.quest_s_QuestHarmonyS;
    this.priority = quest.priority;
    this.unit_UnitUnit = quest.unit_UnitUnit;
    this.name = quest.name;
    this.quest_s = new QuestSConverter(quest.quest_s, 0);
    this.unit = quest.unit;
  }
}
