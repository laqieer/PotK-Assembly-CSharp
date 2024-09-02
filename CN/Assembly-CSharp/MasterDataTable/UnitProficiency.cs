// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitProficiency
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitProficiency
  {
    public int ID;
    public string proficiency;

    public static UnitProficiency Parse(MasterDataReader reader)
    {
      return new UnitProficiency()
      {
        ID = reader.ReadInt(),
        proficiency = reader.ReadString(true)
      };
    }
  }
}
