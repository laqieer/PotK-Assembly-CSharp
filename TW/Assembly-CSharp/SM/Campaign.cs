// Decompiled with JetBrains decompiler
// Type: SM.Campaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Campaign : KeyCompare
  {
    public string name;
    public int value;
    public int campaign_type_id;

    public Campaign()
    {
    }

    public Campaign(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.name = (string) json[nameof (name)];
      this.value = (int) (long) json[nameof (value)];
      this.campaign_type_id = (int) (long) json[nameof (campaign_type_id)];
    }
  }
}
