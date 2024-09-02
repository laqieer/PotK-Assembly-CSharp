// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalReelIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalReelIcon
  {
    public int ID;
    public string name;
    public string description;
    public int medal_flg;
    public string file_name;

    public static SlotS001MedalReelIcon Parse(MasterDataReader reader)
    {
      return new SlotS001MedalReelIcon()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true),
        medal_flg = reader.ReadInt(),
        file_name = reader.ReadString(true)
      };
    }
  }
}
