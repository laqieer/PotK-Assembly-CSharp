﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.RouletteR001FreelDeck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class RouletteR001FreelDeck
  {
    public int ID;
    public string name;
    public string description;

    public static RouletteR001FreelDeck Parse(MasterDataReader reader) => new RouletteR001FreelDeck()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      description = reader.ReadString(true)
    };
  }
}
