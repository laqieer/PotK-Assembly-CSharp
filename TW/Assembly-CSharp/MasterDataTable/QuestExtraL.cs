// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraL
  {
    public int ID;
    public string name;
    public int priority;
    public int? description;
    public string background_image_name;
    public int category_QuestExtraCategory;

    public static QuestExtraL Parse(MasterDataReader reader)
    {
      return new QuestExtraL()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        description = reader.ReadIntOrNull(),
        background_image_name = reader.ReadString(true),
        category_QuestExtraCategory = reader.ReadInt()
      };
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
