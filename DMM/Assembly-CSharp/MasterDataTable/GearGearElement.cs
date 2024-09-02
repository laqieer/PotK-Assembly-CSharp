// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearGearElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearGearElement
  {
    public int ID;
    public int gear_GearGear;
    public int element_CommonElement;

    public static GearGearElement Parse(MasterDataReader reader) => new GearGearElement()
    {
      ID = reader.ReadInt(),
      gear_GearGear = reader.ReadInt(),
      element_CommonElement = reader.ReadInt()
    };

    public GearGear gear
    {
      get
      {
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear + "]"));
        return gearGear;
      }
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;
  }
}
