// Decompiled with JetBrains decompiler
// Type: QuestMConverter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public class QuestMConverter
{
  public int ID;
  public string name;
  public int priority;
  public string background_image_name;
  public float offset_x;
  public float offset_y;
  public float scale;

  public QuestMConverter(QuestCharacterM quest)
  {
    this.ID = quest.ID;
    this.name = quest.name;
    this.priority = quest.priority;
    this.background_image_name = quest.background.background_name;
    this.offset_x = quest.background.offset_x;
    this.offset_y = quest.background.offset_y;
    this.scale = quest.background.scale;
  }

  public QuestMConverter(QuestHarmonyM quest)
  {
    this.ID = quest.ID;
    this.name = quest.name;
    this.priority = quest.priority;
    this.background_image_name = quest.background.background_name;
    this.offset_x = quest.background.offset_x;
    this.offset_y = quest.background.offset_y;
    this.scale = quest.background.scale;
  }
}
