// Decompiled with JetBrains decompiler
// Type: SM.PlayerGachaTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
