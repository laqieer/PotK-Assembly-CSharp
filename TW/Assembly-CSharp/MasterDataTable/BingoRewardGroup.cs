// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoRewardGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    public string background_image_name;

    public static BingoRewardGroup Parse(MasterDataReader reader)
    {
      return new BingoRewardGroup()
      {
        ID = reader.ReadInt(),
        reward_group_id = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_message = reader.ReadString(true),
        background_image_name = reader.ReadStringOrNull(true)
      };
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
