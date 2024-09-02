// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitMaterialQuestInfo
  {
    public int ID;
    public int unit_id;
    public string short_desc;
    public string long_desc;

    public static UnitMaterialQuestInfo Parse(MasterDataReader reader)
    {
      return new UnitMaterialQuestInfo()
      {
        ID = reader.ReadInt(),
        unit_id = reader.ReadInt(),
        short_desc = reader.ReadString(true),
        long_desc = reader.ReadString(true)
      };
    }
  }
}
