// Decompiled with JetBrains decompiler
// Type: SM.Banner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Banner : KeyCompare
  {
    public int duration_seconds;
    public string url;
    public Transition transition;
    public DateTime? end_at;
    public int priority;
    public int id;
    public bool show_exp;

    public Banner()
    {
    }

    public Banner(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.duration_seconds = (int) (long) json[nameof (duration_seconds)];
      this.url = (string) json[nameof (url)];
      this.transition = json[nameof (transition)] != null ? new Transition((Dictionary<string, object>) json[nameof (transition)]) : (Transition) null;
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
      this.priority = (int) (long) json[nameof (priority)];
      this.id = (int) (long) json[nameof (id)];
      this.show_exp = (bool) json[nameof (show_exp)];
    }
  }
}
