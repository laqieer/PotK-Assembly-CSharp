﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStagePanelEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
