﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InformationCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class InformationCategory
  {
    public int ID;
    public string name;

    public static InformationCategory Parse(MasterDataReader reader) => new InformationCategory()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true)
    };
  }
}
