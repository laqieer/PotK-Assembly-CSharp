// Decompiled with JetBrains decompiler
// Type: SM.StartParameter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace SM
{
  [Serializable]
  public class StartParameter : KeyCompare
  {
    public int?[] activity_ids;

    public StartParameter()
    {
    }

    public StartParameter(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.activity_ids = ((IEnumerable<object>) json[nameof (activity_ids)]).Select<object, int?>((Func<object, int?>) (s =>
      {
        long? nullable = (long?) s;
        return nullable.HasValue ? new int?((int) nullable.Value) : new int?();
      })).ToArray<int?>();
    }
  }
}
