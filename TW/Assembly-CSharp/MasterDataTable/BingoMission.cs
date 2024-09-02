// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoMission
  {
    public int ID;
    public int bingo_id;
    public int panel_id;
    public string name;
    public string detail;
    public string scene_name;
    public int? scene_arg;
    public int clear_count;
    public int reward_group_id;

    public static BingoMission Parse(MasterDataReader reader)
    {
      return new BingoMission()
      {
        ID = reader.ReadInt(),
        bingo_id = reader.ReadInt(),
        panel_id = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene_name = reader.ReadString(true),
        scene_arg = reader.ReadIntOrNull(),
        clear_count = reader.ReadInt(),
        reward_group_id = reader.ReadInt()
      };
    }
  }
}
