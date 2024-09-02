// Decompiled with JetBrains decompiler
// Type: MasterDataTable.Bag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class Bag
  {
    public int ID;
    public int Type;
    public int Grade1;
    public int Grade2;

    public static Bag Parse(MasterDataReader reader)
    {
      return new Bag()
      {
        ID = reader.ReadInt(),
        Type = reader.ReadInt(),
        Grade1 = reader.ReadInt(),
        Grade2 = reader.ReadInt()
      };
    }
  }
}
