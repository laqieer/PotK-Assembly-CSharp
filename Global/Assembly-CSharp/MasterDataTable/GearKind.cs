// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearKind
  {
    public int ID;
    private string _name;
    public int can_equip;
    public int same_element;
    public bool is_composite;
    public int colosseum_preempt_coefficient;

    public GearKindEnum Enum => (GearKindEnum) this.ID;

    public bool isEquip
    {
      get => this.Enum != GearKindEnum.smith && this.Enum != GearKindEnum.unique_wepon;
    }

    public bool isNonWeapon
    {
      get
      {
        return this.Enum == GearKindEnum.shield || this.Enum == GearKindEnum.accessories || this.Enum == GearKindEnum.smith;
      }
    }

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("gear_GearKind_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static GearKind Parse(MasterDataReader reader)
    {
      return new GearKind()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        can_equip = reader.ReadInt(),
        same_element = reader.ReadInt(),
        is_composite = reader.ReadBool(),
        colosseum_preempt_coefficient = reader.ReadInt()
      };
    }

    public Future<GameObject> LoadFieldWeaponModel()
    {
      return ResourceManager.LoadOrNull<GameObject>(string.Format("GearKinds/{0}/3D/field_weapon/prefab", (object) this.ID));
    }
  }
}
