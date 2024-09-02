// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKindIncr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static GearKindIncr Parse(MasterDataReader reader) => new GearKindIncr()
    {
      ID = reader.ReadInt(),
      attack_kind_GearKind = reader.ReadInt(),
      defense_kind_GearKind = reader.ReadInt(),
      proficiency_UnitProficiency = reader.ReadInt(),
      attack = reader.ReadInt(),
      hit = reader.ReadInt()
    };

    public GearKind attack_kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.attack_kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.attack_kind_GearKind + "]"));
        return gearKind;
      }
    }

    public GearKind defense_kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.defense_kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.defense_kind_GearKind + "]"));
        return gearKind;
      }
    }

    public UnitProficiency proficiency
    {
      get
      {
        UnitProficiency unitProficiency;
        if (!MasterData.UnitProficiency.TryGetValue(this.proficiency_UnitProficiency, out unitProficiency))
          Debug.LogError((object) ("Key not Found: MasterData.UnitProficiency[" + (object) this.proficiency_UnitProficiency + "]"));
        return unitProficiency;
      }
    }
  }
}
