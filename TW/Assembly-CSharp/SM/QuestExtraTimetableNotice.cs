﻿// Decompiled with JetBrains decompiler
// Type: SM.QuestExtraTimetableNotice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestExtraTimetableNotice : KeyCompare
  {
    public int _quest_extra_s;
    public DateTime? start_at;

    public QuestExtraTimetableNotice()
    {
    }

    public QuestExtraTimetableNotice(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this._quest_extra_s = (int) (long) json[nameof (quest_extra_s)];
      this.start_at = json[nameof (start_at)] != null ? new DateTime?(DateTime.Parse((string) json[nameof (start_at)])) : new DateTime?();
    }

    public QuestExtraS quest_extra_s
    {
      get
      {
        if (MasterData.QuestExtraS.ContainsKey(this._quest_extra_s))
          return MasterData.QuestExtraS[this._quest_extra_s];
        Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this._quest_extra_s + "]"));
        return (QuestExtraS) null;
      }
    }
  }
}
