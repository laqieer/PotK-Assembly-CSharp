﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InitimateBreakthrough
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class InitimateBreakthrough
  {
    public int ID;
    public int character_id;
    public int target_character_id;

    public static InitimateBreakthrough Parse(MasterDataReader reader)
    {
      return new InitimateBreakthrough()
      {
        ID = reader.ReadInt(),
        character_id = reader.ReadInt(),
        target_character_id = reader.ReadInt()
      };
    }
  }
}
