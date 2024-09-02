// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraM
  {
    public int ID;
    public string name;
    public int priority;
    public int? description_QuestExtraDescription;
    public int background_QuestCommonBackground;
    public int? button_type;
    public string background_button_name;
    public int category_QuestExtraCategory;

    public static QuestExtraM Parse(MasterDataReader reader)
    {
      return new QuestExtraM()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        description_QuestExtraDescription = reader.ReadIntOrNull(),
        background_QuestCommonBackground = reader.ReadInt(),
        button_type = reader.ReadIntOrNull(),
        background_button_name = reader.ReadString(true),
        category_QuestExtraCategory = reader.ReadInt()
      };
    }

    public QuestExtraDescription description
    {
      get
      {
        if (!this.description_QuestExtraDescription.HasValue)
          return (QuestExtraDescription) null;
        QuestExtraDescription description;
        if (!MasterData.QuestExtraDescription.TryGetValue(this.description_QuestExtraDescription.Value, out description))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraDescription[" + (object) this.description_QuestExtraDescription.Value + "]"));
        return description;
      }
    }

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground background;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out background))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return background;
      }
    }

    public QuestExtraCategory category
    {
      get
      {
        QuestExtraCategory category;
        if (!MasterData.QuestExtraCategory.TryGetValue(this.category_QuestExtraCategory, out category))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraCategory[" + (object) this.category_QuestExtraCategory + "]"));
        return category;
      }
    }
  }
}
