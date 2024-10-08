﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonChapterBG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestCommonChapterBG
  {
    public int ID;
    public string bg_heaven;
    public string bg_lost_ragnarok;

    public static QuestCommonChapterBG Parse(MasterDataReader reader) => new QuestCommonChapterBG()
    {
      ID = reader.ReadInt(),
      bg_heaven = reader.ReadStringOrNull(true),
      bg_lost_ragnarok = reader.ReadStringOrNull(true)
    };
  }
}
