// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InitimateBreakthrough
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class InitimateBreakthrough
  {
    public int ID;
    public int character_id;
    public int target_character_id;

    public static InitimateBreakthrough Parse(MasterDataReader reader) => new InitimateBreakthrough()
    {
      ID = reader.ReadInt(),
      character_id = reader.ReadInt(),
      target_character_id = reader.ReadInt()
    };
  }
}
