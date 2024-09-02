// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeasonTicketSeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SeasonTicketSeasonTicket
  {
    public int ID;
    public string name;
    public int max_quantity;
    public string description;
    public int increase_match;

    public static SeasonTicketSeasonTicket Parse(MasterDataReader reader)
    {
      return new SeasonTicketSeasonTicket()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        max_quantity = reader.ReadInt(),
        description = reader.ReadString(true),
        increase_match = reader.ReadInt()
      };
    }

    public Future<Sprite> LoadThumneilF() => ResourceManager.Load<Sprite>("SeasonTicket/thum");

    public Future<Sprite> LoadLargeF() => ResourceManager.Load<Sprite>("SeasonTicket/large");
  }
}
