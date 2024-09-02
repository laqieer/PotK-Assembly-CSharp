// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PlayerLevelUpStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PlayerLevelUpStatus
  {
    public int ID;
    public int ap;
    public int cost;
    public int friend;

    public static PlayerLevelUpStatus Parse(MasterDataReader reader)
    {
      return new PlayerLevelUpStatus()
      {
        ID = reader.ReadInt(),
        ap = reader.ReadInt(),
        cost = reader.ReadInt(),
        friend = reader.ReadInt()
      };
    }
  }
}
