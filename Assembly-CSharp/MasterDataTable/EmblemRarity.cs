﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EmblemRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EmblemRarity
  {
    public int ID;
    public string name;
    public int index;

    public static EmblemRarity Parse(MasterDataReader reader) => new EmblemRarity()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      index = reader.ReadInt()
    };
  }
}
