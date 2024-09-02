// Decompiled with JetBrains decompiler
// Type: SM.PlayerGachaTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
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

    public GachaTicket ticket => MasterData.GachaTicket[this.ticket_id];
  }
}
