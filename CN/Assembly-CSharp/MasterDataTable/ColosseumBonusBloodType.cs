﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumBonusBloodType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ColosseumBonusBloodType
  {
    public int ID;
    public string name;
    public int value;

    public static ColosseumBonusBloodType Parse(MasterDataReader reader)
    {
      return new ColosseumBonusBloodType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        value = reader.ReadInt()
      };
    }
  }
}
