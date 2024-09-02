// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ShopShop
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ShopShop
  {
    public int ID;
    public string name;
    public string description;
    public bool _enable;
    public DateTime? start_at;
    public DateTime? end_at;
    public int? month_start_at;
    public int? month_end_at;
    public int? day_start_at;
    public int? day_end_at;
    public bool sunday_enable;
    public bool monday_enable;
    public bool tuesday_enable;
    public bool wednesday_enable;
    public bool thursday_enable;
    public bool friday_enable;
    public bool saturday_enable;

    public static ShopShop Parse(MasterDataReader reader)
    {
      return new ShopShop()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        _enable = reader.ReadBool(),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull(),
        month_start_at = reader.ReadIntOrNull(),
        month_end_at = reader.ReadIntOrNull(),
        day_start_at = reader.ReadIntOrNull(),
        day_end_at = reader.ReadIntOrNull(),
        sunday_enable = reader.ReadBool(),
        monday_enable = reader.ReadBool(),
        tuesday_enable = reader.ReadBool(),
        wednesday_enable = reader.ReadBool(),
        thursday_enable = reader.ReadBool(),
        friday_enable = reader.ReadBool(),
        saturday_enable = reader.ReadBool()
      };
    }
  }
}
