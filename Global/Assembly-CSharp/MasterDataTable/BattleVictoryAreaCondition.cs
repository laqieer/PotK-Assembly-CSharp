// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleVictoryAreaCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleVictoryAreaCondition
  {
    public int ID;
    public int group_id;
    public int area_x;
    public int area_y;

    public static BattleVictoryAreaCondition Parse(MasterDataReader reader)
    {
      return new BattleVictoryAreaCondition()
      {
        ID = reader.ReadInt(),
        group_id = reader.ReadInt(),
        area_x = reader.ReadInt(),
        area_y = reader.ReadInt()
      };
    }
  }
}
