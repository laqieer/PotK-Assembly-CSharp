// Decompiled with JetBrains decompiler
// Type: MasterDataTable.LoginbonusReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class LoginbonusReward
  {
    public int ID;
    public int loginbonus_LoginbonusLoginbonus;
    public int number;
    public int reward_type_CommonRewardType;
    public int reward_id;
    public int reward_quantity;
    private string _reward_message;
    private string _next_reward_message;
    public int character_id;
    public string que_name1;
    public string que_name2;
    public float character_scale;
    public float character_x;
    public float character_y;

    public string reward_message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._reward_message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("loginbonus_LoginbonusReward_reward_message_" + (object) this.ID, out Translation) ? Translation : this._reward_message;
      }
      set => this._reward_message = value;
    }

    public string next_reward_message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._next_reward_message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("loginbonus_LoginbonusReward_next_reward_message_" + (object) this.ID, out Translation) ? Translation : this._next_reward_message;
      }
      set => this._next_reward_message = value;
    }

    public static LoginbonusReward Parse(MasterDataReader reader)
    {
      return new LoginbonusReward()
      {
        ID = reader.ReadInt(),
        loginbonus_LoginbonusLoginbonus = reader.ReadInt(),
        number = reader.ReadInt(),
        reward_type_CommonRewardType = reader.ReadInt(),
        reward_id = reader.ReadInt(),
        reward_quantity = reader.ReadInt(),
        reward_message = reader.ReadString(true),
        next_reward_message = reader.ReadString(true),
        character_id = reader.ReadInt(),
        que_name1 = reader.ReadStringOrNull(true),
        que_name2 = reader.ReadStringOrNull(true),
        character_scale = reader.ReadFloat(),
        character_x = reader.ReadFloat(),
        character_y = reader.ReadFloat()
      };
    }

    public LoginbonusLoginbonus loginbonus
    {
      get
      {
        LoginbonusLoginbonus loginbonus;
        if (!MasterData.LoginbonusLoginbonus.TryGetValue(this.loginbonus_LoginbonusLoginbonus, out loginbonus))
          Debug.LogError((object) ("Key not Found: MasterData.LoginbonusLoginbonus[" + (object) this.loginbonus_LoginbonusLoginbonus + "]"));
        return loginbonus;
      }
    }

    public CommonRewardType reward_type => (CommonRewardType) this.reward_type_CommonRewardType;
  }
}
