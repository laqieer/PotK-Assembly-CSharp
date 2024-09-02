// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TotalPaymentBonusReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TotalPaymentBonusReward
  {
    public int ID;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;

    public static TotalPaymentBonusReward Parse(MasterDataReader reader) => new TotalPaymentBonusReward()
    {
      ID = reader.ReadInt(),
      reward_type_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_quantity = reader.ReadInt()
    };

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
