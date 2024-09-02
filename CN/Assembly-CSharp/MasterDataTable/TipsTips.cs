// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TipsTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class TipsTips
  {
    public int ID;
    public string description;
    public int weight;

    public static TipsTips Parse(MasterDataReader reader)
    {
      return new TipsTips()
      {
        ID = reader.ReadInt(),
        description = reader.ReadString(true),
        weight = reader.ReadInt()
      };
    }
  }
}
