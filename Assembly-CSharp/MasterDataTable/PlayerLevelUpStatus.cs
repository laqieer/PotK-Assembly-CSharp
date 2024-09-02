// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PlayerLevelUpStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class PlayerLevelUpStatus
  {
    public int ID;
    public int ap;
    public int cost;
    public int friend;

    public static PlayerLevelUpStatus Parse(MasterDataReader reader) => new PlayerLevelUpStatus()
    {
      ID = reader.ReadInt(),
      ap = reader.ReadInt(),
      cost = reader.ReadInt(),
      friend = reader.ReadInt()
    };
  }
}
