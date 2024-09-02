// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PlayerLevelUpStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
