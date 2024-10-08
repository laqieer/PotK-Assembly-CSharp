﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TowerFloorName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TowerFloorName
  {
    public int ID;
    public string prefix;
    public string suffix;
    public int interval;

    public static TowerFloorName Parse(MasterDataReader reader) => new TowerFloorName()
    {
      ID = reader.ReadInt(),
      prefix = reader.ReadStringOrNull(true),
      suffix = reader.ReadStringOrNull(true),
      interval = reader.ReadInt()
    };
  }
}
