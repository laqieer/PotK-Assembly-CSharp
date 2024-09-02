// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DailyMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    public int mission_type_MissionType;

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
        end_at = reader.ReadDateTimeOrNull(),
        mission_type_MissionType = reader.ReadInt()
      };
    }

    public MissionType mission_type => (MissionType) this.mission_type_MissionType;
  }
}
