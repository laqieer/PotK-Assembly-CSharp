﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ColosseumBonusBloodType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
