// Decompiled with JetBrains decompiler
// Type: SM.CrossFestaCampaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class CrossFestaCampaign : KeyCompare
  {
    public DateTime? start_at;
    public string description;
    public string title;
    public string thumbnail;
    public string input_form_url;
    public DateTime? end_at;
    public int id;

    public CrossFestaCampaign()
    {
    }

    public CrossFestaCampaign(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.description = (string) json[nameof (description)];
      this.title = (string) json[nameof (title)];
      this.thumbnail = json[nameof (thumbnail)] != null ? (string) json[nameof (thumbnail)] : (string) null;
      this.input_form_url = json[nameof (input_form_url)] != null ? (string) json[nameof (input_form_url)] : (string) null;
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
