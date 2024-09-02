// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStageClear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleStageClear
  {
    public int ID;
    public int reward_group_id;
    public int only_first;
    public int entity_type_CommonRewardType;
    public int reward_id;
    private string _reward_message;

    public string reward_message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._reward_message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("battle_BattleStageClear_reward_message_" + (object) this.ID, out Translation) ? Translation : this._reward_message;
      }
      set => this._reward_message = value;
    }

    public static BattleStageClear Parse(MasterDataReader reader)
    {
      return new BattleStageClear()
      {
        ID = reader.ReadInt(),
        reward_group_id = reader.ReadInt(),
        only_first = reader.ReadInt(),
        entity_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_message = reader.ReadString(true)
      };
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
