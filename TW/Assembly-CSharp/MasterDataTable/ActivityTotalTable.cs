// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityTotalTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ActivityTotalTable
  {
    public int ID;
    public string activity_title;
    public string activity_content;
    public int activity_type;
    public int time_type_id;
    public DateTime start_at;
    public DateTime end_at;
    public int activity_picture;
    public int? priority;
    public bool is_novice;

    public static ActivityTotalTable Parse(MasterDataReader reader)
    {
      return new ActivityTotalTable()
      {
        ID = reader.ReadInt(),
        activity_title = reader.ReadString(true),
        activity_content = reader.ReadString(true),
        activity_type = reader.ReadInt(),
        time_type_id = reader.ReadInt(),
        start_at = reader.ReadDateTime(),
        end_at = reader.ReadDateTime(),
        activity_picture = reader.ReadInt(),
        priority = reader.ReadIntOrNull(),
        is_novice = reader.ReadBool()
      };
    }
  }
}
