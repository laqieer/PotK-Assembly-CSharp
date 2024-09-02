// Decompiled with JetBrains decompiler
// Type: SM.PvpLogicCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class PvpLogicCondition : KeyCompare
  {
    public int category;
    public int logic;
    public int groupid;
    public int value;
    public int id;

    public PvpLogicCondition()
    {
    }

    public PvpLogicCondition(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.category = (int) (long) json[nameof (category)];
      this.logic = (int) (long) json[nameof (logic)];
      this.groupid = (int) (long) json[nameof (groupid)];
      this.value = (int) (long) json[nameof (value)];
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
