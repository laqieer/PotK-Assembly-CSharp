// Decompiled with JetBrains decompiler
// Type: MasterDataTable.Bag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
