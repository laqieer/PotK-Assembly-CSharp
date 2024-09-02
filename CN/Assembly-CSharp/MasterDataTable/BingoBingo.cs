// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoBingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoBingo
  {
    public int ID;
    public string name;
    public string message;
    public int cleared_bingo_id;
    public string complete_reward_group_ids;

    public static BingoBingo Parse(MasterDataReader reader)
    {
      return new BingoBingo()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        message = reader.ReadString(true),
        cleared_bingo_id = reader.ReadInt(),
        complete_reward_group_ids = reader.ReadString(true)
      };
    }
  }
}
