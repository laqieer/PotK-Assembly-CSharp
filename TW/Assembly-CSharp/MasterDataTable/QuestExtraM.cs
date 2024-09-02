// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    public int? description;
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
        description = reader.ReadIntOrNull(),
        background_QuestCommonBackground = reader.ReadInt(),
        button_type = reader.ReadIntOrNull(),
        background_button_name = reader.ReadString(true),
        category_QuestExtraCategory = reader.ReadInt()
      };
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
