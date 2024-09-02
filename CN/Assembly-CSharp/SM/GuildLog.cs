// Decompiled with JetBrains decompiler
// Type: SM.GuildLog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GuildLog : KeyCompare
  {
    public bool is_deleted;
    public string log_id;
    public string created_at;
    public GuildLogTransition transition;
    public string log_author_id;
    public string log_author_name;
    public string log_text;
    public int log_type;

    public GuildLog()
    {
    }

    public GuildLog(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.is_deleted = (bool) json[nameof (is_deleted)];
      this.log_id = (string) json[nameof (log_id)];
      this.created_at = json[nameof (created_at)] != null ? (string) json[nameof (created_at)] : (string) null;
      this.transition = json[nameof (transition)] != null ? new GuildLogTransition((Dictionary<string, object>) json[nameof (transition)]) : (GuildLogTransition) null;
      this.log_author_id = json[nameof (log_author_id)] != null ? (string) json[nameof (log_author_id)] : (string) null;
      this.log_author_name = json[nameof (log_author_name)] != null ? (string) json[nameof (log_author_name)] : (string) null;
      this.log_text = (string) json[nameof (log_text)];
      this.log_type = (int) (long) json[nameof (log_type)];
    }
  }
}
