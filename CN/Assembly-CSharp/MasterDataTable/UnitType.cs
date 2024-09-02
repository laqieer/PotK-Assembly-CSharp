// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitType
  {
    public int ID;
    public string name;

    public static UnitType Parse(MasterDataReader reader)
    {
      return new UnitType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }

    public UnitTypeEnum Enum => (UnitTypeEnum) this.ID;
  }
}
