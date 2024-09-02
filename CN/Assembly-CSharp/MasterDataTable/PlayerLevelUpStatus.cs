// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PlayerLevelUpStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
