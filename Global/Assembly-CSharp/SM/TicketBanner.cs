// Decompiled with JetBrains decompiler
// Type: SM.TicketBanner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class TicketBanner : KeyCompare
  {
    public string front_url;
    public string title_url;
    public int gacha_id;

    public TicketBanner()
    {
    }

    public TicketBanner(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.front_url = (string) json[nameof (front_url)];
      this.title_url = (string) json[nameof (title_url)];
      this.gacha_id = (int) (long) json[nameof (gacha_id)];
    }
  }
}
