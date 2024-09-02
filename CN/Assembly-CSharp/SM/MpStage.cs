// Decompiled with JetBrains decompiler
// Type: SM.MpStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    public int stage_id;
    public int point;
    public int turns;
    public int groupid;
    public DateTime end_at;
    public int id;

    public MpStage()
    {
    }

    public MpStage(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.stage_id = (int) (long) json[nameof (stage_id)];
      this.point = (int) (long) json[nameof (point)];
      this.turns = (int) (long) json[nameof (turns)];
      this.groupid = (int) (long) json[nameof (groupid)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
      this.id = (int) (long) json[nameof (id)];
    }

    public string victory_condition
    {
      get
      {
        return Consts.Format(Consts.GetInstance().VERSUS_VICTORY_CONDITION, (IDictionary) new Hashtable()
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
        return Consts.Format(Consts.GetInstance().VERSUS_VICTORY_SUB_CONDITION1, (IDictionary) new Hashtable()
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
        return Consts.Format(Consts.GetInstance().VERSUS_VICTORY_SUB_CONDITION2, (IDictionary) new Hashtable()
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
