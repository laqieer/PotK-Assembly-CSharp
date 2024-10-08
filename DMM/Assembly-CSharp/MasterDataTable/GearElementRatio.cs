﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearElementRatio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearElementRatio
  {
    public int ID;
    public int element_CommonElement;
    public int family_UnitFamily;
    public float ratio;

    public static GearElementRatio Parse(MasterDataReader reader) => new GearElementRatio()
    {
      ID = reader.ReadInt(),
      element_CommonElement = reader.ReadInt(),
      family_UnitFamily = reader.ReadInt(),
      ratio = reader.ReadFloat()
    };

    public CommonElement element => (CommonElement) this.element_CommonElement;

    public UnitFamily family => (UnitFamily) this.family_UnitFamily;
  }
}
