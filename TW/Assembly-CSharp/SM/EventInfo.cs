// Decompiled with JetBrains decompiler
// Type: SM.EventInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class EventInfo : KeyCompare
  {
    public DateTime start_at;
    public DateTime end_at;
    public DateTime final_at;
    public int period_id;
    public int period_type;
    public bool is_bonus_term;
    public string banner_image_url;
    public int category_id;

    public EventInfo()
    {
    }

    public EventInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.final_at = DateTime.Parse((string) json[nameof (final_at)]);
      this.period_id = (int) (long) json[nameof (period_id)];
      this.period_type = (int) (long) json[nameof (period_type)];
      this.is_bonus_term = (bool) json[nameof (is_bonus_term)];
      this.banner_image_url = (string) json[nameof (banner_image_url)];
      this.category_id = (int) (long) json[nameof (category_id)];
    }

    public SM.Period Period()
    {
      SM.Period[] source = SMManager.Get<SM.Period[]>();
      return source != null && source.Length > 0 ? ((IEnumerable<SM.Period>) source).FirstOrDefault<SM.Period>((Func<SM.Period, bool>) (x => x.period_id == this.period_id)) : (SM.Period) null;
    }
  }
}
