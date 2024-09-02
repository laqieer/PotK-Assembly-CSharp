// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SlotS001MedalReel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class SlotS001MedalReel
  {
    public int ID;
    public int reel_id;
    public int reel_detail_id;

    public static SlotS001MedalReel Parse(MasterDataReader reader)
    {
      return new SlotS001MedalReel()
      {
        ID = reader.ReadInt(),
        reel_id = reader.ReadInt(),
        reel_detail_id = reader.ReadInt()
      };
    }
  }
}
