﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitUnitDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitUnitDescription
  {
    public int ID;
    public string description;
    public string cv_name;
    public string illustrator_name;

    public static UnitUnitDescription Parse(MasterDataReader reader) => new UnitUnitDescription()
    {
      ID = reader.ReadInt(),
      description = reader.ReadString(true),
      cv_name = reader.ReadString(true),
      illustrator_name = reader.ReadString(true)
    };
  }
}
