﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.IntimateDuelSupport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class IntimateDuelSupport
  {
    public int ID;
    public int intimate_value;
    public int hit;
    public int evasion;
    public int critical;
    public int critical_evasion;

    public static IntimateDuelSupport Parse(MasterDataReader reader) => new IntimateDuelSupport()
    {
      ID = reader.ReadInt(),
      intimate_value = reader.ReadInt(),
      hit = reader.ReadInt(),
      evasion = reader.ReadInt(),
      critical = reader.ReadInt(),
      critical_evasion = reader.ReadInt()
    };
  }
}
