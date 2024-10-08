﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestChapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestChapter
  {
    public int ID;
    public string chapter;
    public string chapter_name;

    public static EarthQuestChapter Parse(MasterDataReader reader) => new EarthQuestChapter()
    {
      ID = reader.ReadInt(),
      chapter = reader.ReadString(true),
      chapter_name = reader.ReadString(true)
    };
  }
}
