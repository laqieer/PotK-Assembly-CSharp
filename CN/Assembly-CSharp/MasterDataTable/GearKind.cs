// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearKind
  {
    public int ID;
    public string name;
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
      string path = string.Format("GearKinds/{0}/3D/field_weapon/prefab", (object) this.ID);
      return Singleton<ResourceManager>.GetInstance().LoadOrNull<GameObject>(path);
    }
  }
}
