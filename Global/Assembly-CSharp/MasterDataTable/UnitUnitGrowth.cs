﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitGrowth
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitGrowth
  {
    public int ID;
    public float hp_growth;
    public float strength_growth;
    public float intelligence_growth;
    public float vitality_growth;
    public float mind_growth;
    public float agility_growth;
    public float dexterity_growth;
    public float lucky_growth;

    public static UnitUnitGrowth Parse(MasterDataReader reader)
    {
      return new UnitUnitGrowth()
      {
        ID = reader.ReadInt(),
        hp_growth = reader.ReadFloat(),
        strength_growth = reader.ReadFloat(),
        intelligence_growth = reader.ReadFloat(),
        vitality_growth = reader.ReadFloat(),
        mind_growth = reader.ReadFloat(),
        agility_growth = reader.ReadFloat(),
        dexterity_growth = reader.ReadFloat(),
        lucky_growth = reader.ReadFloat()
      };
    }
  }
}
