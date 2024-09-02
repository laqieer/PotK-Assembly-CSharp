// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpRankingCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpRankingCondition
  {
    public int ID;
    public string disp_text;
    public string image_name;
    public int priority;

    public static PvpRankingCondition Parse(MasterDataReader reader)
    {
      return new PvpRankingCondition()
      {
        ID = reader.ReadInt(),
        disp_text = reader.ReadString(true),
        image_name = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }
  }
}
