﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildBase
  {
    public int ID;
    public int base_type_GuildBaseType;
    public int release_level;

    public static GuildBase Parse(MasterDataReader reader) => new GuildBase()
    {
      ID = reader.ReadInt(),
      base_type_GuildBaseType = reader.ReadInt(),
      release_level = reader.ReadInt()
    };

    public GuildBaseType base_type => (GuildBaseType) this.base_type_GuildBaseType;
  }
}
