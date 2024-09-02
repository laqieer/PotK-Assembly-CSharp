// Decompiled with JetBrains decompiler
// Type: SM.GachaG007PlayerSheet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaG007PlayerSheet : KeyCompare
  {
    public int current_count;
    public int? total_count;
    public GachaG007PlayerPanel[] player_panels;
    public int sheet_series_id;
    public int button_type;
    public bool can_push_button;

    public GachaG007PlayerSheet()
    {
    }

    public GachaG007PlayerSheet(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.current_count = (int) (long) json[nameof (current_count)];
      int? nullable1;
      if (json[nameof (total_count)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (total_count)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.total_count = nullable1;
      List<GachaG007PlayerPanel> gachaG007PlayerPanelList = new List<GachaG007PlayerPanel>();
      foreach (object json1 in (List<object>) json[nameof (player_panels)])
        gachaG007PlayerPanelList.Add(json1 != null ? new GachaG007PlayerPanel((Dictionary<string, object>) json1) : (GachaG007PlayerPanel) null);
      this.player_panels = gachaG007PlayerPanelList.ToArray();
      this.sheet_series_id = (int) (long) json[nameof (sheet_series_id)];
      this.button_type = (int) (long) json[nameof (button_type)];
      this.can_push_button = (bool) json[nameof (can_push_button)];
    }
  }
}
