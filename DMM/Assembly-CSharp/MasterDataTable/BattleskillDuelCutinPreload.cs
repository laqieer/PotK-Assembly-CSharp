﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelCutinPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleskillDuelCutinPreload
  {
    public int ID;
    public int duel_effect_id;
    public int unit_UnitUnit;

    public static BattleskillDuelCutinPreload Parse(
      MasterDataReader reader)
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
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unitUnit;
      }
    }
  }
}
