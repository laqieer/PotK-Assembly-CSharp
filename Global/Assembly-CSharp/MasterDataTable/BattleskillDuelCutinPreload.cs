﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelCutinPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillDuelCutinPreload
  {
    public int ID;
    public int duel_effect_id;
    public int unit_UnitUnit;

    public static BattleskillDuelCutinPreload Parse(MasterDataReader reader)
    {
      return new BattleskillDuelCutinPreload()
      {
        ID = reader.ReadInt(),
        duel_effect_id = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt()
      };
    }

    public UnitUnit unit
    {
      get
      {
        UnitUnit unit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unit;
      }
    }
  }
}
