// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBonusRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreBonusRule : KeyCompare
  {
    public int? target_skill_id;
    public int bonus_type;
    public int? target_job_id;
    public int? target_unit_id;

    public QuestScoreBonusRule()
    {
    }

    public QuestScoreBonusRule(Dictionary<string, object> json)
    {
      this._hasKey = false;
      int? nullable1;
      if (json[nameof (target_skill_id)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (target_skill_id)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.target_skill_id = nullable1;
      this.bonus_type = (int) (long) json[nameof (bonus_type)];
      int? nullable3;
      if (json[nameof (target_job_id)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (target_job_id)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.target_job_id = nullable3;
      int? nullable5;
      if (json[nameof (target_unit_id)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (target_unit_id)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.target_unit_id = nullable5;
    }
  }
}
