// Decompiled with JetBrains decompiler
// Type: SM.SerialCampaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class SerialCampaign : KeyCompare
  {
    public DateTime? start_at;
    public int id;
    public string name;
    public DateTime? end_at;

    public SerialCampaign()
    {
    }

    public SerialCampaign(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.id = (int) (long) json[nameof (id)];
      this.name = (string) json[nameof (name)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }
  }
}
