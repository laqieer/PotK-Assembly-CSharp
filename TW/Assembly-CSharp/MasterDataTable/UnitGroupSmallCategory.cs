// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGroupSmallCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitGroupSmallCategory
  {
    public int ID;
    public string name;
    public string short_label_name;
    public string description;
    public DateTime? start_at;

    public static UnitGroupSmallCategory Parse(MasterDataReader reader)
    {
      return new UnitGroupSmallCategory()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        short_label_name = reader.ReadString(true),
        description = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull()
      };
    }

    public string GetSpriteName() => string.Format("s_classification_{0}", (object) this.ID);
  }
}
