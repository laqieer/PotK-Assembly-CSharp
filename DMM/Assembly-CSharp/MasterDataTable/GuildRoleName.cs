﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildRoleName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildRoleName
  {
    public int ID;
    public string name;

    public static GuildRoleName Parse(MasterDataReader reader) => new GuildRoleName()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true)
    };
  }
}
