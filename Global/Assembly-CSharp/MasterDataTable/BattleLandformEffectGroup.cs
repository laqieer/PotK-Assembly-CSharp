// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformEffectGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformEffectGroup
  {
    public int ID;
    public string play_prefab_file_name;

    public static BattleLandformEffectGroup Parse(MasterDataReader reader)
    {
      return new BattleLandformEffectGroup()
      {
        ID = reader.ReadInt(),
        play_prefab_file_name = reader.ReadString(true)
      };
    }
  }
}
