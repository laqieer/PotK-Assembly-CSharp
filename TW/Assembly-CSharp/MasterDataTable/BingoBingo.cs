// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoBingo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoBingo
  {
    public int ID;
    public DateTime? end_at;
    public string complete_reward_group_ids;
    public string header_image_name;
    public int priority;

    public static BingoBingo Parse(MasterDataReader reader)
    {
      return new BingoBingo()
      {
        ID = reader.ReadInt(),
        end_at = reader.ReadDateTimeOrNull(),
        complete_reward_group_ids = reader.ReadStringOrNull(true),
        header_image_name = reader.ReadStringOrNull(true),
        priority = reader.ReadInt()
      };
    }
  }
}
