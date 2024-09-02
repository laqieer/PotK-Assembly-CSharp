// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpVictoryEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpVictoryEffect
  {
    public int ID;
    public int victory_type_PvpVictoryTypeEnum;

    public static PvpVictoryEffect Parse(MasterDataReader reader)
    {
      return new PvpVictoryEffect()
      {
        ID = reader.ReadInt(),
        victory_type_PvpVictoryTypeEnum = reader.ReadInt()
      };
    }

    public PvpVictoryTypeEnum victory_type
    {
      get => (PvpVictoryTypeEnum) this.victory_type_PvpVictoryTypeEnum;
    }
  }
}
