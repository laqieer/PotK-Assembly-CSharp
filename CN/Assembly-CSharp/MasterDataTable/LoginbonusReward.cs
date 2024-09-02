// Decompiled with JetBrains decompiler
// Type: MasterDataTable.LoginbonusReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

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
    public string reward_message;
    public string next_reward_message;
    public int character_id;
    public string que_name1;
    public string que_name2;
    public float character_scale;
    public float character_x;
    public float character_y;

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
