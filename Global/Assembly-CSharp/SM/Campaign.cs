// Decompiled with JetBrains decompiler
// Type: SM.Campaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
