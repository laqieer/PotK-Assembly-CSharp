﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMoviePath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestMoviePath
  {
    public int ID;
    public string ios_path;
    public string android_path;
    public string title;
    public string windows_path;

    public static QuestMoviePath Parse(MasterDataReader reader) => new QuestMoviePath()
    {
      ID = reader.ReadInt(),
      ios_path = reader.ReadString(true),
      android_path = reader.ReadString(true),
      title = reader.ReadString(true),
      windows_path = reader.ReadString(true)
    };
  }
}
