// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitDescription
  {
    public int ID;
    public string description;
    public string cv_name;
    public string illustrator_name;

    public static UnitUnitDescription Parse(MasterDataReader reader)
    {
      return new UnitUnitDescription()
      {
        ID = reader.ReadInt(),
        description = reader.ReadString(true),
        cv_name = reader.ReadString(true),
        illustrator_name = reader.ReadString(true)
      };
    }
  }
}
