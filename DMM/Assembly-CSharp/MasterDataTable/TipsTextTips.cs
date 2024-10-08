﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.TipsTextTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class TipsTextTips
  {
    public int ID;
    public string title;
    public string description;
    public string subtitle;
    public string sourcename;
    public string image_name;
    public bool enable;

    public static TipsTextTips Parse(MasterDataReader reader) => new TipsTextTips()
    {
      ID = reader.ReadInt(),
      title = reader.ReadString(true),
      description = reader.ReadString(true),
      subtitle = reader.ReadString(true),
      sourcename = reader.ReadString(true),
      image_name = reader.ReadString(true),
      enable = reader.ReadBool()
    };
  }
}
