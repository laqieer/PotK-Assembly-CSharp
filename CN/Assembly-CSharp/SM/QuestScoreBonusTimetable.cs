// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreBonusTimetable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreBonusTimetable : KeyCompare
  {
    public QuestScoreBonusRule[] rules;
    public string message_text;
    public DateTime start_at;
    public int quest_s_id;
    public DateTime end_at;

    public QuestScoreBonusTimetable()
    {
    }

    public QuestScoreBonusTimetable(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<QuestScoreBonusRule> questScoreBonusRuleList = new List<QuestScoreBonusRule>();
      foreach (object json1 in (List<object>) json[nameof (rules)])
        questScoreBonusRuleList.Add(json1 != null ? new QuestScoreBonusRule((Dictionary<string, object>) json1) : (QuestScoreBonusRule) null);
      this.rules = questScoreBonusRuleList.ToArray();
      this.message_text = (string) json[nameof (message_text)];
      this.start_at = DateTime.Parse((string) json[nameof (start_at)]);
      this.quest_s_id = (int) (long) json[nameof (quest_s_id)];
      this.end_at = DateTime.Parse((string) json[nameof (end_at)]);
    }
  }
}
