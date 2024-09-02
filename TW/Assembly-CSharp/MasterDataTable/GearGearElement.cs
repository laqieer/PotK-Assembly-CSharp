// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearGearElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearGearElement
  {
    public int ID;
    public int gear_GearGear;
    public int element_CommonElement;

    public static GearGearElement Parse(MasterDataReader reader)
    {
      return new GearGearElement()
      {
        ID = reader.ReadInt(),
        gear_GearGear = reader.ReadInt(),
        element_CommonElement = reader.ReadInt()
      };
    }

    public GearGear gear
    {
      get
      {
        GearGear gear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear, out gear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear + "]"));
        return gear;
      }
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;
  }
}
