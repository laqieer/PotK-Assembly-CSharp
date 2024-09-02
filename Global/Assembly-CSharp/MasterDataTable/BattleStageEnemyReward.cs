// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemyReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
