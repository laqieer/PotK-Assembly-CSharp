﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitIllustPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitIllustPattern
  {
    public int ID;
    public float illust_x;
    public float illust_y;
    public float illust_scale;

    public static UnitIllustPattern Parse(MasterDataReader reader) => new UnitIllustPattern()
    {
      ID = reader.ReadInt(),
      illust_x = reader.ReadFloat(),
      illust_y = reader.ReadFloat(),
      illust_scale = reader.ReadFloat()
    };
  }
}
