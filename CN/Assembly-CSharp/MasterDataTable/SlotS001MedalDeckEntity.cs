// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalDeckEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
