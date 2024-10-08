﻿// Decompiled with JetBrains decompiler
// Type: SM.Period
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Period : KeyCompare
  {
    public string event_name;
    public int priority;
    public DateTime start_at;
    public int period_id;
    public DateTime end_at;

    public Period()
    {
    }

    public Period(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.event_name = (string) json[nameof (event_name)];
      this.priority = (int) (long) json[nameof (priority)];
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.period_id = (int) (long) json[nameof (period_id)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
    }
  }
}
