// Decompiled with JetBrains decompiler
// Type: SM.CrossFestaAchieve
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class CrossFestaAchieve : KeyCompare
  {
    public int id;
    public string thumbnail;
    public DateTime? start_at;
    public string description;
    public DateTime? end_at;

    public CrossFestaAchieve()
    {
    }

    public CrossFestaAchieve(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.id = (int) (long) json[nameof (id)];
      this.thumbnail = (string) json[nameof (thumbnail)];
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
      this.description = (string) json[nameof (description)];
      this.end_at = json[nameof (end_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (end_at)])) : new DateTime?();
    }
  }
}
