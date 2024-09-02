// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelCutinPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

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
