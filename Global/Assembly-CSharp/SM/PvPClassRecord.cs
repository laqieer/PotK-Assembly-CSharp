// Decompiled with JetBrains decompiler
// Type: SM.PvPClassRecord
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PvPClassRecord : KeyCompare
  {
    public int current_season_win_count;
    public PvPRecord pvp_record;
    public int season_class_up;
    public int season_title_count;
    public int current_season_loss_count;
    public int top3;
    public int top;
    public int top10;
    public int season_class_down;
    public int top30;
    public int best_ranking;
    public int season_class_stay;
    public int top1000;
    public int top100;
    public int current_season_draw_count;

    public PvPClassRecord()
    {
    }

    public PvPClassRecord(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.current_season_win_count = (int) (long) json[nameof (current_season_win_count)];
      this.pvp_record = json[nameof (pvp_record)] != null ? new PvPRecord((Dictionary<string, object>) json[nameof (pvp_record)]) : (PvPRecord) null;
      this.season_class_up = (int) (long) json[nameof (season_class_up)];
      this.season_title_count = (int) (long) json[nameof (season_title_count)];
      this.current_season_loss_count = (int) (long) json[nameof (current_season_loss_count)];
      this.top3 = (int) (long) json[nameof (top3)];
      this.top = (int) (long) json[nameof (top)];
      this.top10 = (int) (long) json[nameof (top10)];
      this.season_class_down = (int) (long) json[nameof (season_class_down)];
      this.top30 = (int) (long) json[nameof (top30)];
      this.best_ranking = (int) (long) json[nameof (best_ranking)];
      this.season_class_stay = (int) (long) json[nameof (season_class_stay)];
      this.top1000 = (int) (long) json[nameof (top1000)];
      this.top100 = (int) (long) json[nameof (top100)];
      this.current_season_draw_count = (int) (long) json[nameof (current_season_draw_count)];
    }
  }
}
