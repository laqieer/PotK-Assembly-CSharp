// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleVictoryAreaCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
