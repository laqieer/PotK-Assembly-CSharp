// Decompiled with JetBrains decompiler
// Type: SM.GachaPeriod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaPeriod : KeyCompare
  {
    public bool display_count_down;
    public DateTime? start_at;
    public DateTime? end_at;

    public GachaPeriod()
    {
    }

    public GachaPeriod(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.display_count_down = (bool) json[nameof (display_count_down)];
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }
  }
}
