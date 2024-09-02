// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DailyMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class DailyMission
  {
    public int ID;
    public bool _enable;
    public int priority;
    public int num;
    public int limit_count;
    public string name;
    public string detail;
    public string scene;
    public DateTime? start_at;
    public DateTime? end_at;

    public static DailyMission Parse(MasterDataReader reader)
    {
      return new DailyMission()
      {
        ID = reader.ReadInt(),
        _enable = reader.ReadBool(),
        priority = reader.ReadInt(),
        num = reader.ReadInt(),
        limit_count = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene = reader.ReadString(true),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull()
      };
    }
  }
}
