// Decompiled with JetBrains decompiler
// Type: Hard.MasterDataTable.UnitRegressionUnitType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;

namespace Hard.MasterDataTable
{
  public struct UnitRegressionUnitType
  {
    public int unit_id;
    public UnitTypeEnum unit_type;
    public UnitTypeEnum target_type;

    public bool IsMatch(PlayerUnit pu) => this.unit_id == pu._unit && this.unit_type == (UnitTypeEnum) pu._unit_type;
  }
}
