// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoRewardGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoRewardGroup
  {
    public int ID;
    public int reward_group_id;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string reward_message;

    public static BingoRewardGroup Parse(MasterDataReader reader)
    {
      return new BingoRewardGroup()
      {
        ID = reader.ReadInt(),
        reward_group_id = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_message = reader.ReadString(true)
      };
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
