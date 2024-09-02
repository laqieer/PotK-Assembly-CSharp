// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonStrengthComposePrice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class CommonStrengthComposePrice
  {
    public int ID;
    public int price;

    public static CommonStrengthComposePrice Parse(MasterDataReader reader)
    {
      return new CommonStrengthComposePrice()
      {
        ID = reader.ReadInt(),
        price = reader.ReadInt()
      };
    }
  }
}
