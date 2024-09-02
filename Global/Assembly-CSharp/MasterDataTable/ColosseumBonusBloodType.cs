// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumBonusBloodType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ColosseumBonusBloodType
  {
    public int ID;
    public string name;
    public int value;

    public static ColosseumBonusBloodType Parse(MasterDataReader reader)
    {
      return new ColosseumBonusBloodType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        value = reader.ReadInt()
      };
    }
  }
}
