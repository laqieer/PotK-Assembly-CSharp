﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GvgPeriod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GvgPeriod
  {
    public int ID;
    public int rule_no;
    public string rule_name;
    public string rule_detail;

    public static GvgPeriod Parse(MasterDataReader reader) => new GvgPeriod()
    {
      ID = reader.ReadInt(),
      rule_no = reader.ReadInt(),
      rule_name = reader.ReadStringOrNull(true),
      rule_detail = reader.ReadStringOrNull(true)
    };
  }
}
