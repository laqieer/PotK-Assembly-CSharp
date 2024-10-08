﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRankExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearRankExp
  {
    public int ID;
    public int level;
    public int from_exp;
    public int to_exp;
    public float sell_compensate;

    public static GearRankExp Parse(MasterDataReader reader) => new GearRankExp()
    {
      ID = reader.ReadInt(),
      level = reader.ReadInt(),
      from_exp = reader.ReadInt(),
      to_exp = reader.ReadInt(),
      sell_compensate = reader.ReadFloat()
    };
  }
}
