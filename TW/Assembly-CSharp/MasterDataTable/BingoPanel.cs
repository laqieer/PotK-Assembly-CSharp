// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BingoPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BingoPanel
  {
    public int ID;
    public int bingo_id;
    public int panel_id;
    public string name;
    public string detail;
    public string scene_name;
    public int init_count;
    public int clear_count;
    public int reward_group_id;

    public static BingoPanel Parse(MasterDataReader reader)
    {
      return new BingoPanel()
      {
        ID = reader.ReadInt(),
        bingo_id = reader.ReadInt(),
        panel_id = reader.ReadInt(),
        name = reader.ReadString(true),
        detail = reader.ReadString(true),
        scene_name = reader.ReadString(true),
        init_count = reader.ReadInt(),
        clear_count = reader.ReadInt(),
        reward_group_id = reader.ReadInt()
      };
    }
  }
}
