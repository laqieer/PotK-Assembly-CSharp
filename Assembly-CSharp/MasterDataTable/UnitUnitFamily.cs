// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitFamily
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitFamily
  {
    public int ID;
    public int unit_UnitUnit;
    public int element_UnitFamily;

    public static UnitUnitFamily Parse(MasterDataReader reader) => new UnitUnitFamily()
    {
      ID = reader.ReadInt(),
      unit_UnitUnit = reader.ReadInt(),
      element_UnitFamily = reader.ReadInt()
    };

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

    public UnitFamily element => (UnitFamily) this.element_UnitFamily;
  }
}
