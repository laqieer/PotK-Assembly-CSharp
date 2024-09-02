// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitGroupGenerationCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitGroupGenerationCategory
  {
    public int ID;
    public string name;
    public string short_label_name;
    public string description;
    public DateTime? start_at;

    public static UnitGroupGenerationCategory Parse(MasterDataReader reader)
    {
      return new UnitGroupGenerationCategory()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        short_label_name = reader.ReadString(true),
        description = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull()
      };
    }

    public string GetSpriteName() => string.Format("generation_{0}", (object) this.ID);
  }
}
