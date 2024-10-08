﻿// Decompiled with JetBrains decompiler
// Type: SM.EnemyDetailInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (quest_infos)])
        detailInfoQuestInfosList.Add(obj == null ? (EnemyDetailInfoQuest_infos) null : new EnemyDetailInfoQuest_infos((Dictionary<string, object>) obj));
      this.quest_infos = detailInfoQuestInfosList.ToArray();
    }
  }
}
