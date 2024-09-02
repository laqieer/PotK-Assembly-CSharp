// Decompiled with JetBrains decompiler
// Type: SM.PvPCampaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PvPCampaign : KeyCompare
  {
    public string image_url;
    public Campaign campaign;

    public PvPCampaign()
    {
    }

    public PvPCampaign(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.image_url = (string) json[nameof (image_url)];
      this.campaign = json[nameof (campaign)] != null ? new Campaign((Dictionary<string, object>) json[nameof (campaign)]) : (Campaign) null;
    }
  }
}
