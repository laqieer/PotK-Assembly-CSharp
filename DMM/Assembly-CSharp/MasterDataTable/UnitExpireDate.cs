﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitExpireDate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitExpireDate
  {
    public int ID;
    public DateTime end_at;

    public static UnitExpireDate Parse(MasterDataReader reader) => new UnitExpireDate()
    {
      ID = reader.ReadInt(),
      end_at = reader.ReadDateTime()
    };
  }
}
