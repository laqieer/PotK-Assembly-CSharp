﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GachaTutorialbutton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GachaTutorialbutton
  {
    public int ID;
    public int gacha_id;
    public int? count;
    public int? period_id;
    public string url;

    public static GachaTutorialbutton Parse(MasterDataReader reader) => new GachaTutorialbutton()
    {
      ID = reader.ReadInt(),
      gacha_id = reader.ReadInt(),
      count = reader.ReadIntOrNull(),
      period_id = reader.ReadIntOrNull(),
      url = reader.ReadString(true)
    };
  }
}
