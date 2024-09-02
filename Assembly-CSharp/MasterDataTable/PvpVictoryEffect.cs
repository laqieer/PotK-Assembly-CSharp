// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpVictoryEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class PvpVictoryEffect
  {
    public int ID;
    public int victory_type_PvpVictoryTypeEnum;

    public static PvpVictoryEffect Parse(MasterDataReader reader) => new PvpVictoryEffect()
    {
      ID = reader.ReadInt(),
      victory_type_PvpVictoryTypeEnum = reader.ReadInt()
    };

    public PvpVictoryTypeEnum victory_type => (PvpVictoryTypeEnum) this.victory_type_PvpVictoryTypeEnum;
  }
}
