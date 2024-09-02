// Decompiled with JetBrains decompiler
// Type: SM.GachaStepup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaStepup : KeyCompare
  {
    public int? total_count;
    public int? current_count;

    public GachaStepup()
    {
    }

    public GachaStepup(Dictionary<string, object> json)
    {
      this._hasKey = false;
      int? nullable1;
      if (json[nameof (total_count)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (total_count)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.total_count = nullable1;
      int? nullable3;
      if (json[nameof (current_count)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (current_count)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.current_count = nullable3;
    }
  }
}
