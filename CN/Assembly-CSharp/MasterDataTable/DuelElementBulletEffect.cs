﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DuelElementBulletEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DuelElementBulletEffect
  {
    public int ID;
    public string bullet_prefab_name;
    public int element_CommonElement;
    public string effect_name;

    public static DuelElementBulletEffect Parse(MasterDataReader reader)
    {
      return new DuelElementBulletEffect()
      {
        ID = reader.ReadInt(),
        bullet_prefab_name = reader.ReadStringOrNull(true),
        element_CommonElement = reader.ReadInt(),
        effect_name = reader.ReadStringOrNull(true)
      };
    }

    public CommonElement element => (CommonElement) this.element_CommonElement;
  }
}
