// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearKindRatio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearKindRatio
  {
    public int ID;
    public int kind_GearKind;
    public int family_UnitFamily;
    public float ratio;

    public static GearKindRatio Parse(MasterDataReader reader)
    {
      return new GearKindRatio()
      {
        ID = reader.ReadInt(),
        kind_GearKind = reader.ReadInt(),
        family_UnitFamily = reader.ReadInt(),
        ratio = reader.ReadFloat()
      };
    }

    public GearKind kind
    {
      get
      {
        GearKind kind;
        if (!MasterData.GearKind.TryGetValue(this.kind_GearKind, out kind))
          Debug.LogError((object) ("Key not Found: MasterData.GearKind[" + (object) this.kind_GearKind + "]"));
        return kind;
      }
    }

    public UnitFamily family => (UnitFamily) this.family_UnitFamily;
  }
}
