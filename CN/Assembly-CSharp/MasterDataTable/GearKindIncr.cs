﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKindIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearKindIncr
  {
    public int ID;
    public int attack_kind_GearKind;
    public int defense_kind_GearKind;
    public int proficiency_UnitProficiency;
    public int attack;
    public int hit;

    public static GearKindIncr Parse(MasterDataReader reader)
    {
      return new GearKindIncr()
      {
        ID = reader.ReadInt(),
        attack_kind_GearKind = reader.ReadInt(),
        defense_kind_GearKind = reader.ReadInt(),
        proficiency_UnitProficiency = reader.ReadInt(),
        attack = reader.ReadInt(),
        hit = reader.ReadInt()
      };
    }

    public GearKind attack_kind
    {
      get
      {
        GearKind attackKind;
        if (!MasterData.GearKind.TryGetValue(this.attack_kind_GearKind, out attackKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.attack_kind_GearKind + "]"));
        return attackKind;
      }
    }

    public GearKind defense_kind
    {
      get
      {
        GearKind defenseKind;
        if (!MasterData.GearKind.TryGetValue(this.defense_kind_GearKind, out defenseKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.defense_kind_GearKind + "]"));
        return defenseKind;
      }
    }

    public UnitProficiency proficiency
    {
      get
      {
        UnitProficiency proficiency;
        if (!MasterData.UnitProficiency.TryGetValue(this.proficiency_UnitProficiency, out proficiency))
          Debug.LogError((object) ("Key not Found: MasterData.UnitProficiency[" + (object) this.proficiency_UnitProficiency + "]"));
        return proficiency;
      }
    }
  }
}
