// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ActivityReward
  {
    public int ID;
    public int activity_id;
    public int step_id;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    public string reward_title;
    public string reward_message;
    public string show_title;
    public string show_text;
    public string next_reward_title;
    public string next_reward_text;
    public string activity_subtitle;

    public static ActivityReward Parse(MasterDataReader reader)
    {
      return new ActivityReward()
      {
        ID = reader.ReadInt(),
        activity_id = reader.ReadInt(),
        step_id = reader.ReadInt(),
        reward_type_id_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_title = reader.ReadString(true),
        reward_message = reader.ReadString(true),
        show_title = reader.ReadString(true),
        show_text = reader.ReadString(true),
        next_reward_title = reader.ReadString(true),
        next_reward_text = reader.ReadString(true),
        activity_subtitle = reader.ReadString(true)
      };
    }

    public CommonRewardType reward_type_id
    {
      get => (CommonRewardType) this.reward_type_id_CommonRewardType;
    }
  }
}
