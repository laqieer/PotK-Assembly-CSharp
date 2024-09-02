// Decompiled with JetBrains decompiler
// Type: SM.PlayerGachaTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PlayerGachaTicket : KeyCompare
  {
    public int ticket_id;
    public int quantity;

    public PlayerGachaTicket()
    {
    }

    public PlayerGachaTicket(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.ticket_id = (int) (long) json[nameof (ticket_id)];
      this.quantity = (int) (long) json[nameof (quantity)];
    }

    public MasterDataTable.GachaTicket ticket => MasterData.GachaTicket[this.ticket_id];
  }
}
