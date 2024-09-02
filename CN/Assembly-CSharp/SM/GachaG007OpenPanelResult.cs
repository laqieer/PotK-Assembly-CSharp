﻿// Decompiled with JetBrains decompiler
// Type: SM.GachaG007OpenPanelResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaG007OpenPanelResult : KeyCompare
  {
    public int open_panel_position;
    public GachaG007PlayerSheet player_sheet;

    public GachaG007OpenPanelResult()
    {
    }

    public GachaG007OpenPanelResult(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.open_panel_position = (int) (long) json[nameof (open_panel_position)];
      this.player_sheet = json[nameof (player_sheet)] != null ? new GachaG007PlayerSheet((Dictionary<string, object>) json[nameof (player_sheet)]) : (GachaG007PlayerSheet) null;
    }
  }
}
