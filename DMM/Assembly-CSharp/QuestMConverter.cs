// Decompiled with JetBrains decompiler
// Type: QuestMConverter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;

public class QuestMConverter
{
  public int ID;
  public string name;
  public int priority;
  public string background_image_name;
  public float offset_x;
  public float offset_y;
  public float scale;

  public string background_image_path => string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) this.background_image_name);

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
