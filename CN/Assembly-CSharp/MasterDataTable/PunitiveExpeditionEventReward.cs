// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PunitiveExpeditionEventReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PunitiveExpeditionEventReward
  {
    public int ID;
    public int period;
    public int point_type_EventPointType;
    public int must_point;
    public int point;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string display_text1;
    public string display_text2;
    public string image_name;
    public int alignment;

    public static PunitiveExpeditionEventReward Parse(MasterDataReader reader)
    {
      return new PunitiveExpeditionEventReward()
      {
        ID = reader.ReadInt(),
        period = reader.ReadInt(),
        point_type_EventPointType = reader.ReadInt(),
        must_point = reader.ReadInt(),
        point = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        display_text1 = reader.ReadString(true),
        display_text2 = reader.ReadString(true),
        image_name = reader.ReadString(true),
        alignment = reader.ReadInt()
      };
    }

    public EventPointType point_type => (EventPointType) this.point_type_EventPointType;

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
