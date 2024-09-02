// Decompiled with JetBrains decompiler
// Type: UnitTypeEnumExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;

#nullable disable
public static class UnitTypeEnumExtensions
{
  public static string TypeNameKey(this UnitTypeEnum unitType)
  {
    string str = "UNIT_KILLER_TYPE_";
    switch (unitType)
    {
      case UnitTypeEnum.ouki:
        return str + "BLN";
      case UnitTypeEnum.meiki:
        return str + "VIT";
      case UnitTypeEnum.kouki:
        return str + "FRC";
      case UnitTypeEnum.maki:
        return str + "MAG";
      case UnitTypeEnum.syuki:
        return str + "GRD";
      case UnitTypeEnum.syouki:
        return str + "DEX";
      default:
        Debug.LogWarning((object) "タイプ不一致");
        return string.Empty;
    }
  }
}
