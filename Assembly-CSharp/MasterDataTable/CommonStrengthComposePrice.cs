﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonStrengthComposePrice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CommonStrengthComposePrice
  {
    public int ID;
    public int price;

    public static CommonStrengthComposePrice Parse(MasterDataReader reader) => new CommonStrengthComposePrice()
    {
      ID = reader.ReadInt(),
      price = reader.ReadInt()
    };
  }
}
