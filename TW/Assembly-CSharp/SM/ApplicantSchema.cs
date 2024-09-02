// Decompiled with JetBrains decompiler
// Type: SM.ApplicantSchema
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class ApplicantSchema : KeyCompare
  {
    public PlayershipSchema player;
    public DateTime applied_at;

    public ApplicantSchema()
    {
    }

    public ApplicantSchema(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.player = json[nameof (player)] != null ? new PlayershipSchema((Dictionary<string, object>) json[nameof (player)]) : (PlayershipSchema) null;
      this.applied_at = DateTime.Parse((string) json[nameof (applied_at)]);
    }
  }
}
