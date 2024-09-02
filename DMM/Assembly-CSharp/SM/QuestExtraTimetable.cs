// Decompiled with JetBrains decompiler
// Type: SM.QuestExtraTimetable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

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
      foreach (object obj in (List<object>) json[nameof (notice)])
        extraTimetableNoticeList.Add(obj == null ? (QuestExtraTimetableNotice) null : new QuestExtraTimetableNotice((Dictionary<string, object>) obj));
      this.notice = extraTimetableNoticeList.ToArray();
    }
  }
}
