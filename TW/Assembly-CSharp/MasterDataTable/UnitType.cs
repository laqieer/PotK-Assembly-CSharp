// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
