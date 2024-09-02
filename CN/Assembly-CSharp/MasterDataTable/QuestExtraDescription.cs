// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraDescription
  {
    public int ID;
    public string description;
    public string image_url;
    public int? image_width;
    public int? image_height;

    public static QuestExtraDescription Parse(MasterDataReader reader)
    {
      return new QuestExtraDescription()
      {
        ID = reader.ReadInt(),
        description = reader.ReadStringOrNull(true),
        image_url = reader.ReadStringOrNull(true),
        image_width = reader.ReadIntOrNull(),
        image_height = reader.ReadIntOrNull()
      };
    }
  }
}
