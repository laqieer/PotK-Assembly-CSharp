// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKindCorrelations
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearKindCorrelations
  {
    public int ID;
    public int attacker_GearKind;
    public int defender_GearKind;
    public bool is_advantage;

    public static GearKindCorrelations Parse(MasterDataReader reader) => new GearKindCorrelations()
    {
      ID = reader.ReadInt(),
      attacker_GearKind = reader.ReadInt(),
      defender_GearKind = reader.ReadInt(),
      is_advantage = reader.ReadBool()
    };

    public GearKind attacker
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.attacker_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.attacker_GearKind + "]"));
        return gearKind;
      }
    }

    public GearKind defender
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.defender_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.defender_GearKind + "]"));
        return gearKind;
      }
    }
  }
}
