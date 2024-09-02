// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalDeckEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalDeckEntity
  {
    public int ID;
    public int deck_id;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int? reward_quantity;

    public static SlotS001MedalDeckEntity Parse(MasterDataReader reader)
    {
      return new SlotS001MedalDeckEntity()
      {
        ID = reader.ReadInt(),
        deck_id = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadIntOrNull()
      };
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
