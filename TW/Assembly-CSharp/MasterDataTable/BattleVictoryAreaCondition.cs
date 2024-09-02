// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleVictoryAreaCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
