﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeasonTicketSeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

    public Future<Sprite> LoadThumneilF()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>("SeasonTicket/thum");
    }

    public Future<Sprite> LoadLargeF()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>("SeasonTicket/large");
    }
  }
}
