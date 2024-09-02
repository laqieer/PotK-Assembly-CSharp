// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpClassReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpClassReward
  {
    public int ID;
    public int class_kind_PvpClassKind;
    public int class_reward_type_PvpClassRewardTypeEnum;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string reward_message;

    public static PvpClassReward Parse(MasterDataReader reader)
    {
      return new PvpClassReward()
      {
        ID = reader.ReadInt(),
        class_kind_PvpClassKind = reader.ReadInt(),
        class_reward_type_PvpClassRewardTypeEnum = reader.ReadInt(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_message = reader.ReadString(true)
      };
    }

    public PvpClassKind class_kind
    {
      get
      {
        PvpClassKind classKind;
        if (!MasterData.PvpClassKind.TryGetValue(this.class_kind_PvpClassKind, out classKind))
          Debug.LogError((object) ("Key not Found: MasterData.PvpClassKind[" + (object) this.class_kind_PvpClassKind + "]"));
        return classKind;
      }
    }

    public PvpClassRewardTypeEnum class_reward_type
    {
      get => (PvpClassRewardTypeEnum) this.class_reward_type_PvpClassRewardTypeEnum;
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
