﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformEffectGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
