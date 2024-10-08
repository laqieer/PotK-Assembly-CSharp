﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DuelEffectPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class DuelEffectPreload
  {
    public int ID;
    public int duel_controller_id;
    public string effect_file_name;

    public static DuelEffectPreload Parse(MasterDataReader reader) => new DuelEffectPreload()
    {
      ID = reader.ReadInt(),
      duel_controller_id = reader.ReadInt(),
      effect_file_name = reader.ReadString(true)
    };
  }
}
