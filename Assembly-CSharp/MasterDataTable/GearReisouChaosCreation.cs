// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearReisouChaosCreation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearReisouChaosCreation
  {
    public int ID;
    public int chaos_ID_GearGear;
    public int cost_sand;
    public int cost_medal;

    public static GearReisouChaosCreation Parse(MasterDataReader reader) => new GearReisouChaosCreation()
    {
      ID = reader.ReadInt(),
      chaos_ID_GearGear = reader.ReadInt(),
      cost_sand = reader.ReadInt(),
      cost_medal = reader.ReadInt()
    };

    public GearGear chaos_ID
    {
      get
      {
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.chaos_ID_GearGear, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.chaos_ID_GearGear + "]"));
        return gearGear;
      }
    }
  }
}
