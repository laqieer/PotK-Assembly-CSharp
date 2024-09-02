// Decompiled with JetBrains decompiler
// Type: SM.MpStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class MpStage : KeyCompare
  {
    public int turns;
    public int stage_id;
    public int point;
    public int id;
    public DateTime end_at;

    public MpStage()
    {
    }

    public MpStage(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.turns = (int) (long) json[nameof (turns)];
      this.stage_id = (int) (long) json[nameof (stage_id)];
      this.point = (int) (long) json[nameof (point)];
      this.id = (int) (long) json[nameof (id)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
    }

    public string victory_condition
    {
      get
      {
        return Consts.Lookup("VERSUS_VICTORY_CONDITION", (IDictionary) new Hashtable()
        {
          {
            (object) "cnt",
            (object) this.turns.ToLocalizeNumberText()
          }
        });
      }
    }

    public string victory_sub_condition
    {
      get
      {
        return Consts.Lookup("VERSUS_VICTORY_SUB_CONDITION1", (IDictionary) new Hashtable()
        {
          {
            (object) "cnt",
            (object) this.turns.ToLocalizeNumberText()
          }
        });
      }
    }

    public string victory_sub_condition2
    {
      get
      {
        return Consts.Lookup("VERSUS_VICTORY_SUB_CONDITION2", (IDictionary) new Hashtable()
        {
          {
            (object) "cnt",
            (object) this.turns.ToLocalizeNumberText()
          }
        });
      }
    }
  }
}
