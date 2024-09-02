// Decompiled with JetBrains decompiler
// Type: SM.QuestExtraTimetable
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
  public class QuestExtraTimetable : KeyCompare
  {
    public int[] emphasis;
    public QuestExtraTimetableNotice[] notice;

    public QuestExtraTimetable()
    {
    }

    public QuestExtraTimetable(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.emphasis = ((IEnumerable<object>) json[nameof (emphasis)]).Select<object, int>((Func<object, int>) (s => (int) (long) s)).ToArray<int>();
      List<QuestExtraTimetableNotice> extraTimetableNoticeList = new List<QuestExtraTimetableNotice>();
      foreach (object json1 in (List<object>) json[nameof (notice)])
        extraTimetableNoticeList.Add(json1 != null ? new QuestExtraTimetableNotice((Dictionary<string, object>) json1) : (QuestExtraTimetableNotice) null);
      this.notice = extraTimetableNoticeList.ToArray();
    }
  }
}
