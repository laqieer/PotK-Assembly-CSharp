// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKindRatio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearKindRatio
  {
    public int ID;
    public int kind_GearKind;
    public int family_UnitFamily;
    public float ratio;

    public static GearKindRatio Parse(MasterDataReader reader) => new GearKindRatio()
    {
      ID = reader.ReadInt(),
      kind_GearKind = reader.ReadInt(),
      family_UnitFamily = reader.ReadInt(),
      ratio = reader.ReadFloat()
    };

    public GearKind kind
    {
      get
      {
        GearKind gearKind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind, out gearKind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind + "]"));
        return gearKind;
      }
    }

    public UnitFamily family => (UnitFamily) this.family_UnitFamily;
  }
}
