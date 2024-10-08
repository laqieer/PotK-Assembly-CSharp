﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTypeTicketExclude
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitTypeTicketExclude
  {
    public int ID;
    public int ticket_id_UnitTypeTicket;
    public int ticket_type_id_UnitTypeTicketType;
    public string ticket_type_param;

    public static UnitTypeTicketExclude Parse(MasterDataReader reader) => new UnitTypeTicketExclude()
    {
      ID = reader.ReadInt(),
      ticket_id_UnitTypeTicket = reader.ReadInt(),
      ticket_type_id_UnitTypeTicketType = reader.ReadInt(),
      ticket_type_param = reader.ReadString(true)
    };

    public UnitTypeTicket ticket_id
    {
      get
      {
        UnitTypeTicket unitTypeTicket;
        if (!MasterData.UnitTypeTicket.TryGetValue(this.ticket_id_UnitTypeTicket, out unitTypeTicket))
          Debug.LogError((object) ("Key not Found: MasterData.UnitTypeTicket[" + (object) this.ticket_id_UnitTypeTicket + "]"));
        return unitTypeTicket;
      }
    }

    public UnitTypeTicketType ticket_type_id => (UnitTypeTicketType) this.ticket_type_id_UnitTypeTicketType;
  }
}
