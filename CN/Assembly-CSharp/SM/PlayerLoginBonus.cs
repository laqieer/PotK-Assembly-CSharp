// Decompiled with JetBrains decompiler
// Type: SM.PlayerLoginBonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerLoginBonus : KeyCompare
  {
    public PlayerLoginBonusRewards[] rewards;
    public int login_days;
    public int _loginbonus;

    public PlayerLoginBonus()
    {
    }

    public PlayerLoginBonus(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<PlayerLoginBonusRewards> loginBonusRewardsList = new List<PlayerLoginBonusRewards>();
      foreach (object json1 in (List<object>) json[nameof (rewards)])
        loginBonusRewardsList.Add(json1 != null ? new PlayerLoginBonusRewards((Dictionary<string, object>) json1) : (PlayerLoginBonusRewards) null);
      this.rewards = loginBonusRewardsList.ToArray();
      this.login_days = (int) (long) json[nameof (login_days)];
      this._loginbonus = (int) (long) json[nameof (loginbonus)];
    }

    public LoginbonusLoginbonus loginbonus
    {
      get
      {
        if (MasterData.LoginbonusLoginbonus.ContainsKey(this._loginbonus))
          return MasterData.LoginbonusLoginbonus[this._loginbonus];
        Debug.LogError((object) ("Key not Found: MasterData.LoginbonusLoginbonus[" + (object) this._loginbonus + "]"));
        return (LoginbonusLoginbonus) null;
      }
    }
  }
}
