﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelClipEventEffectDataPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillDuelClipEventEffectDataPreload
  {
    public int ID;
    public int duel_effect_id;
    public string clipeventeffectdata_file_name;

    public static BattleskillDuelClipEventEffectDataPreload Parse(MasterDataReader reader)
    {
      return new BattleskillDuelClipEventEffectDataPreload()
      {
        ID = reader.ReadInt(),
        duel_effect_id = reader.ReadInt(),
        clipeventeffectdata_file_name = reader.ReadString(true)
      };
    }
  }
}
