// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStagePanelEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleStagePanelEvent
  {
    public int ID;
    public int initial_coordinate_x;
    public int initial_coordinate_y;

    public static BattleStagePanelEvent Parse(MasterDataReader reader)
    {
      return new BattleStagePanelEvent()
      {
        ID = reader.ReadInt(),
        initial_coordinate_x = reader.ReadInt(),
        initial_coordinate_y = reader.ReadInt()
      };
    }
  }
}
