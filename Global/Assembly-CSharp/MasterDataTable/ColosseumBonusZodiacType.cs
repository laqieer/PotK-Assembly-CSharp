﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumBonusZodiacType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ColosseumBonusZodiacType
  {
    public int ID;
    public string name;
    public int value;

    public static ColosseumBonusZodiacType Parse(MasterDataReader reader)
    {
      return new ColosseumBonusZodiacType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        value = reader.ReadInt()
      };
    }
  }
}
