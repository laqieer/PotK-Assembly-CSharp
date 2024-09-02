// Decompiled with JetBrains decompiler
// Type: SM.UnitTicketUnit_choices
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class UnitTicketUnit_choices : KeyCompare
  {
    public int[] unit_types;
    public int unit_id;

    public UnitTicketUnit_choices()
    {
    }

    public UnitTicketUnit_choices(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.unit_types = ((IEnumerable<object>) json[nameof (unit_types)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      this.unit_id = (int) (long) json[nameof (unit_id)];
    }
  }
}
