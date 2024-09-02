// Decompiled with JetBrains decompiler
// Type: SM.PlayerCrossFestaSerial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerCrossFestaSerial : KeyCompare
  {
    public string player_id;
    public bool unlock;
    public string serial_code;
    public int campaign_achieve_id;
    public int campaign_id;

    public PlayerCrossFestaSerial()
    {
    }

    public PlayerCrossFestaSerial(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player_id = (string) json[nameof (player_id)];
      this.unlock = (bool) json[nameof (unlock)];
      this.serial_code = (string) json[nameof (serial_code)];
      this.campaign_achieve_id = (int) (long) json[nameof (campaign_achieve_id)];
      this.campaign_id = (int) (long) json[nameof (campaign_id)];
    }
  }
}
