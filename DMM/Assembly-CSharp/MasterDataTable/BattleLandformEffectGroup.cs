﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformEffectGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformEffectGroup
  {
    public int ID;
    public string play_prefab_file_name;

    public static BattleLandformEffectGroup Parse(MasterDataReader reader) => new BattleLandformEffectGroup()
    {
      ID = reader.ReadInt(),
      play_prefab_file_name = reader.ReadString(true)
    };
  }
}
