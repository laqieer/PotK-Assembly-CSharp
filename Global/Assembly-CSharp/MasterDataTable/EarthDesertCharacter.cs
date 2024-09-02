// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthDesertCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthDesertCharacter
  {
    public int ID;
    public int desert_logic_EarthJoinLogicType;
    public string desert_logic_arg;
    public int character_id;

    public static EarthDesertCharacter Parse(MasterDataReader reader)
    {
      return new EarthDesertCharacter()
      {
        ID = reader.ReadInt(),
        desert_logic_EarthJoinLogicType = reader.ReadInt(),
        desert_logic_arg = reader.ReadStringOrNull(true),
        character_id = reader.ReadInt()
      };
    }

    public EarthJoinLogicType desert_logic
    {
      get => (EarthJoinLogicType) this.desert_logic_EarthJoinLogicType;
    }
  }
}
