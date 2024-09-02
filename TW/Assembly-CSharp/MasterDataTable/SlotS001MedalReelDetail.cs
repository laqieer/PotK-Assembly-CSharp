// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalReelDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalReelDetail
  {
    public int ID;
    public int reel_detail_id;
    public int row_id;
    public int icon_id;

    public static SlotS001MedalReelDetail Parse(MasterDataReader reader)
    {
      return new SlotS001MedalReelDetail()
      {
        ID = reader.ReadInt(),
        reel_detail_id = reader.ReadInt(),
        row_id = reader.ReadInt(),
        icon_id = reader.ReadInt()
      };
    }
  }
}
