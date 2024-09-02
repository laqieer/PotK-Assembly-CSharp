// Decompiled with JetBrains decompiler
// Type: MasterDataTable.JobChangeMaterials
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class JobChangeMaterials
  {
    public int ID;
    public int? material1_UnitUnit;
    public int quantity1;
    public int? material2_UnitUnit;
    public int quantity2;
    public int? material3_UnitUnit;
    public int quantity3;
    public int? material4_UnitUnit;
    public int quantity4;
    public int? material5_UnitUnit;
    public int quantity5;
    public int cost;

    public static JobChangeMaterials Parse(MasterDataReader reader) => new JobChangeMaterials()
    {
      ID = reader.ReadInt(),
      material1_UnitUnit = reader.ReadIntOrNull(),
      quantity1 = reader.ReadInt(),
      material2_UnitUnit = reader.ReadIntOrNull(),
      quantity2 = reader.ReadInt(),
      material3_UnitUnit = reader.ReadIntOrNull(),
      quantity3 = reader.ReadInt(),
      material4_UnitUnit = reader.ReadIntOrNull(),
      quantity4 = reader.ReadInt(),
      material5_UnitUnit = reader.ReadIntOrNull(),
      quantity5 = reader.ReadInt(),
      cost = reader.ReadInt()
    };

    public UnitUnit material1
    {
      get
      {
        if (!this.material1_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material1_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material1_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public UnitUnit material2
    {
      get
      {
        if (!this.material2_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material2_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material2_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public UnitUnit material3
    {
      get
      {
        if (!this.material3_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material3_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material3_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public UnitUnit material4
    {
      get
      {
        if (!this.material4_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material4_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material4_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public UnitUnit material5
    {
      get
      {
        if (!this.material5_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.material5_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.material5_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }
  }
}
