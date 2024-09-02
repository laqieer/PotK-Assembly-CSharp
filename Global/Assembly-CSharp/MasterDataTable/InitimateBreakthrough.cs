// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InitimateBreakthrough
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
