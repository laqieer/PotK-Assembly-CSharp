// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthBattleStagePanelEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthBattleStagePanelEvent
  {
    public int ID;
    public int stage_id;
    public int set_group;
    public int group_appearance;
    public int position_x;
    public int position_y;
    public int drop_table_id;

    public static EarthBattleStagePanelEvent Parse(MasterDataReader reader)
    {
      return new EarthBattleStagePanelEvent()
      {
        ID = reader.ReadInt(),
        stage_id = reader.ReadInt(),
        set_group = reader.ReadInt(),
        group_appearance = reader.ReadInt(),
        position_x = reader.ReadInt(),
        position_y = reader.ReadInt(),
        drop_table_id = reader.ReadInt()
      };
    }
  }
}
