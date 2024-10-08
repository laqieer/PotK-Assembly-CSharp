﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearRankIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

namespace MasterDataTable
{
  [Serializable]
  public class GearRankIncr
  {
    public int ID;
    public int gear_kind_GearKind;
    public int group_id;
    public int level;
    public int power;
    public int physical_defense;
    public int magic_defense;
    public int hit;
    public int critical;
    public int evasion;
    public int hp_incremental;
    public int strength_incremental;
    public int vitality_incremental;
    public int intelligence_incremental;
    public int mind_incremental;
    public int agility_incremental;
    public int dexterity_incremental;
    public int lucky_incremental;

    public static GearRankIncr FromRank(GearKind kind, int group_id, int rank) => ((IEnumerable<GearRankIncr>) MasterData.GearRankIncrList).SingleOrDefault<GearRankIncr>((Func<GearRankIncr, bool>) (x => x.gear_kind.Enum == kind.Enum && x.group_id == group_id && x.level == rank)) ?? ((IEnumerable<GearRankIncr>) MasterData.GearRankIncrList).SingleOrDefault<GearRankIncr>((Func<GearRankIncr, bool>) (x => x.gear_kind.Enum == kind.Enum && x.group_id == 1 && x.level == rank));

    public static GearRankIncr Parse(MasterDataReader reader) => new GearRankIncr()
    {
      ID = reader.ReadInt(),
      gear_kind_GearKind = reader.ReadInt(),
      group_id = reader.ReadInt(),
      level = reader.ReadInt(),
      power = reader.ReadInt(),
      physical_defense = reader.ReadInt(),
      magic_defense = reader.ReadInt(),
      hit = reader.ReadInt(),
      critical = reader.ReadInt(),
      evasion = reader.ReadInt(),
      hp_incremental = reader.ReadInt(),
      strength_incremental = reader.ReadInt(),
      vitality_incremental = reader.ReadInt(),
      intelligence_incremental = reader.ReadInt(),
      mind_incremental = reader.ReadInt(),
      agility_incremental = reader.ReadInt(),
      dexterity_incremental = reader.ReadInt(),
      lucky_incremental = reader.ReadInt()
    };

    public GearKind gear_kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.gear_kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.gear_kind_GearKind + "]"));
        return gearKind;
      }
    }
  }
}
