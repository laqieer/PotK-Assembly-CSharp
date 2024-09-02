// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumTotalVictoryReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ColosseumTotalVictoryReward
  {
    public int ID;
    public int victory_value;
    public string reward_type;
    public int reward_id;
    public int reward_value;
    public string reward_title;
    public string reward_description;

    public static ColosseumTotalVictoryReward Parse(MasterDataReader reader)
    {
      return new ColosseumTotalVictoryReward()
      {
        ID = reader.ReadInt(),
        victory_value = reader.ReadInt(),
        reward_type = reader.ReadString(true),
        reward_id = reader.ReadInt(),
        reward_value = reader.ReadInt(),
        reward_title = reader.ReadString(true),
        reward_description = reader.ReadString(true)
      };
    }
  }
}
