// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EmblemRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EmblemRarity
  {
    public int ID;
    public string name;
    public int index;

    public static EmblemRarity Parse(MasterDataReader reader)
    {
      return new EmblemRarity()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        index = reader.ReadInt()
      };
    }
  }
}
