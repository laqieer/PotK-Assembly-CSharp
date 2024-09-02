// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearReisouFusion
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearReisouFusion
  {
    public int ID;
    public int holy_ID_GearGear;
    public int chaos_ID_GearGear;
    public int mythology_ID_GearGear;
    public int cost_zeny;
    public int cost_medal;

    public static GearReisouFusion Parse(MasterDataReader reader) => new GearReisouFusion()
    {
      ID = reader.ReadInt(),
      holy_ID_GearGear = reader.ReadInt(),
      chaos_ID_GearGear = reader.ReadInt(),
      mythology_ID_GearGear = reader.ReadInt(),
      cost_zeny = reader.ReadInt(),
      cost_medal = reader.ReadInt()
    };

    public GearGear holy_ID
    {
      get
      {
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.holy_ID_GearGear, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.holy_ID_GearGear + "]"));
        return gearGear;
      }
    }

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

    public GearGear mythology_ID
    {
      get
      {
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.mythology_ID_GearGear, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.mythology_ID_GearGear + "]"));
        return gearGear;
      }
    }
  }
}
