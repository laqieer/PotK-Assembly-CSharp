﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PeriodBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class PeriodBackground
  {
    public int ID;
    public string background_image_name;

    public static PeriodBackground Parse(MasterDataReader reader) => new PeriodBackground()
    {
      ID = reader.ReadInt(),
      background_image_name = reader.ReadString(true)
    };
  }
}
