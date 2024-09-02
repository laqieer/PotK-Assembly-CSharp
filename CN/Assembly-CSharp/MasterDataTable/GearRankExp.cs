﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRankExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
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

    public static GearRankExp Parse(MasterDataReader reader)
    {
      return new GearRankExp()
      {
        ID = reader.ReadInt(),
        level = reader.ReadInt(),
        from_exp = reader.ReadInt(),
        to_exp = reader.ReadInt(),
        sell_compensate = reader.ReadFloat()
      };
    }
  }
}
