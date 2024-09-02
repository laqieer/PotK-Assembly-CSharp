﻿// Decompiled with JetBrains decompiler
// Type: SM.EnemyDetailInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class EnemyDetailInfo : KeyCompare
  {
    public EnemyDetailInfoQuest_infos[] quest_infos;

    public EnemyDetailInfo()
    {
    }

    public EnemyDetailInfo(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<EnemyDetailInfoQuest_infos> detailInfoQuestInfosList = new List<EnemyDetailInfoQuest_infos>();
      foreach (object json1 in (List<object>) json[nameof (quest_infos)])
        detailInfoQuestInfosList.Add(json1 != null ? new EnemyDetailInfoQuest_infos((Dictionary<string, object>) json1) : (EnemyDetailInfoQuest_infos) null);
      this.quest_infos = detailInfoQuestInfosList.ToArray();
    }
  }
}
