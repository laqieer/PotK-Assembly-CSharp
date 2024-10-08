﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillDuelEffectPreload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleskillDuelEffectPreload
  {
    public int ID;
    public int duel_effect_id;
    public string effect_file_name;

    public static BattleskillDuelEffectPreload Parse(
      MasterDataReader reader)
    {
      return new BattleskillDuelEffectPreload()
      {
        ID = reader.ReadInt(),
        duel_effect_id = reader.ReadInt(),
        effect_file_name = reader.ReadString(true)
      };
    }
  }
}
