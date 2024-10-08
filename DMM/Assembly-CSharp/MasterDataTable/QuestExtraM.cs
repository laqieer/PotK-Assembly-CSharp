﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraM
  {
    public int ID;
    public string name;
    public int priority;
    public int? description;
    public int background_QuestCommonBackground;
    public int? button_type;
    public string background_button_name;
    public int category_QuestExtraCategory;
    public int? quest_ll_QuestExtraLL;
    public int? banner_image_id;

    public static QuestExtraM Parse(MasterDataReader reader) => new QuestExtraM()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      priority = reader.ReadInt(),
      description = reader.ReadIntOrNull(),
      background_QuestCommonBackground = reader.ReadInt(),
      button_type = reader.ReadIntOrNull(),
      background_button_name = reader.ReadString(true),
      category_QuestExtraCategory = reader.ReadInt(),
      quest_ll_QuestExtraLL = reader.ReadIntOrNull(),
      banner_image_id = reader.ReadIntOrNull()
    };

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground commonBackground;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out commonBackground))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return commonBackground;
      }
    }

    public QuestExtraCategory category
    {
      get
      {
        QuestExtraCategory questExtraCategory;
        if (!MasterData.QuestExtraCategory.TryGetValue(this.category_QuestExtraCategory, out questExtraCategory))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraCategory[" + (object) this.category_QuestExtraCategory + "]"));
        return questExtraCategory;
      }
    }

    public QuestExtraLL quest_ll
    {
      get
      {
        if (!this.quest_ll_QuestExtraLL.HasValue)
          return (QuestExtraLL) null;
        QuestExtraLL questExtraLl;
        if (!MasterData.QuestExtraLL.TryGetValue(this.quest_ll_QuestExtraLL.Value, out questExtraLl))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraLL[" + (object) this.quest_ll_QuestExtraLL.Value + "]"));
        return questExtraLl;
      }
    }
  }
}
