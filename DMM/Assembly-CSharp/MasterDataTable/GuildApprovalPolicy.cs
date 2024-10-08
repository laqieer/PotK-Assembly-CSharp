﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildApprovalPolicy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GuildApprovalPolicy
  {
    public int ID;
    public string name;
    public bool default_manual;

    public static GuildApprovalPolicy Parse(MasterDataReader reader) => new GuildApprovalPolicy()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      default_manual = reader.ReadBool()
    };
  }
}
