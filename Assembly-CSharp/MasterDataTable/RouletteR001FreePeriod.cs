// Decompiled with JetBrains decompiler
// Type: MasterDataTable.RouletteR001FreePeriod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class RouletteR001FreePeriod
  {
    public int ID;
    public string name;
    public DateTime? start_at;
    public DateTime? end_at;

    public static RouletteR001FreePeriod Parse(MasterDataReader reader) => new RouletteR001FreePeriod()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull()
    };
  }
}
