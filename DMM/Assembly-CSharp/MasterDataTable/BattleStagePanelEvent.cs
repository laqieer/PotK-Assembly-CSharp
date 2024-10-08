﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleStagePanelEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleStagePanelEvent
  {
    public int ID;
    public int initial_coordinate_x;
    public int initial_coordinate_y;

    public static BattleStagePanelEvent Parse(MasterDataReader reader) => new BattleStagePanelEvent()
    {
      ID = reader.ReadInt(),
      initial_coordinate_x = reader.ReadInt(),
      initial_coordinate_y = reader.ReadInt()
    };
  }
}
