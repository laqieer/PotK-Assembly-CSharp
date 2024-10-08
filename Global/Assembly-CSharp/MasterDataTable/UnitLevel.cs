﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitLevel
  {
    public int ID;
    public int pattern_id;
    public int level;
    public int from_exp;
    public int to_exp;

    public static UnitLevel Parse(MasterDataReader reader)
    {
      return new UnitLevel()
      {
        ID = reader.ReadInt(),
        pattern_id = reader.ReadInt(),
        level = reader.ReadInt(),
        from_exp = reader.ReadInt(),
        to_exp = reader.ReadInt()
      };
    }
  }
}
