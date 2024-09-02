// Decompiled with JetBrains decompiler
// Type: SM.EventInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
  }
}
