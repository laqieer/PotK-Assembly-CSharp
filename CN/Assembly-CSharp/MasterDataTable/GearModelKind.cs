// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearModelKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GearModelKind
  {
    public int ID;
    public string name;
    public int kind_GearKind;

    public static GearModelKind Parse(MasterDataReader reader)
    {
      return new GearModelKind()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        kind_GearKind = reader.ReadInt()
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
  }
}
