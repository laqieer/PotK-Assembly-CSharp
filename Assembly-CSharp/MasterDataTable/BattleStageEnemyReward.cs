// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageEnemyReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleStageEnemyReward
  {
    public int ID;
    public int exp;
    public int money;
    public int drop_id;

    public static BattleStageEnemyReward Parse(MasterDataReader reader) => new BattleStageEnemyReward()
    {
      ID = reader.ReadInt(),
      exp = reader.ReadInt(),
      money = reader.ReadInt(),
      drop_id = reader.ReadInt()
    };
  }
}
