// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemyReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleStageEnemyReward
  {
    public int ID;
    public int exp;
    public int money;
    public int drop_id;

    public static BattleStageEnemyReward Parse(MasterDataReader reader)
    {
      return new BattleStageEnemyReward()
      {
        ID = reader.ReadInt(),
        exp = reader.ReadInt(),
        money = reader.ReadInt(),
        drop_id = reader.ReadInt()
      };
    }
  }
}
