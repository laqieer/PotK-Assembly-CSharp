// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ExploreRankingCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class ExploreRankingCondition
  {
    public int ID;
    public int? high;
    public int? low;
    public string display_text;
    public string image_name;

    public static ExploreRankingCondition Parse(MasterDataReader reader) => new ExploreRankingCondition()
    {
      ID = reader.ReadInt(),
      high = reader.ReadIntOrNull(),
      low = reader.ReadIntOrNull(),
      display_text = reader.ReadString(true),
      image_name = reader.ReadString(true)
    };
  }
}
