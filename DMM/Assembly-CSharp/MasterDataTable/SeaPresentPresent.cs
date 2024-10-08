﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeaPresentPresent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class SeaPresentPresent
  {
    public int ID;
    public int gear_id;
    public float trust_base;

    public static SeaPresentPresent Parse(MasterDataReader reader) => new SeaPresentPresent()
    {
      ID = reader.ReadInt(),
      gear_id = reader.ReadInt(),
      trust_base = reader.ReadFloat()
    };
  }
}
