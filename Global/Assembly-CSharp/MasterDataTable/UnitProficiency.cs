// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitProficiency
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
