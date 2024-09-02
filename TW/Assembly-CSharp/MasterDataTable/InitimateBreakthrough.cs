// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InitimateBreakthrough
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
