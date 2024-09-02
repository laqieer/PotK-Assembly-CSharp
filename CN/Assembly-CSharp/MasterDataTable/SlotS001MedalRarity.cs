// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalRarity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalRarity
  {
    public int ID;
    public string name;
    public int index;

    public static SlotS001MedalRarity Parse(MasterDataReader reader)
    {
      return new SlotS001MedalRarity()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        index = reader.ReadInt()
      };
    }
  }
}
