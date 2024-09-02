// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalDeck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalDeck
  {
    public int ID;
    public string name;
    public int result_icon;
    public string description;
    public int prize_first;
    public int prize_second;
    public int prize_third;

    public static SlotS001MedalDeck Parse(MasterDataReader reader)
    {
      return new SlotS001MedalDeck()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        result_icon = reader.ReadInt(),
        description = reader.ReadString(true),
        prize_first = reader.ReadInt(),
        prize_second = reader.ReadInt(),
        prize_third = reader.ReadInt()
      };
    }
  }
}
