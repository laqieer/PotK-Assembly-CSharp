﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DuelEffectPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DuelEffectPreload
  {
    public int ID;
    public int duel_controller_id;
    public string effect_file_name;

    public static DuelEffectPreload Parse(MasterDataReader reader)
    {
      return new DuelEffectPreload()
      {
        ID = reader.ReadInt(),
        duel_controller_id = reader.ReadInt(),
        effect_file_name = reader.ReadString(true)
      };
    }
  }
}
