﻿// Decompiled with JetBrains decompiler
// Type: QuestDetailManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections.Generic;

public class QuestDetailManager
{
  private Dictionary<string, QuestDetailData> cache_ = new Dictionary<string, QuestDetailData>();

  private static string generateKey(CommonQuestType type, int id) => string.Format("{0}:{1}", (object) (int) type, (object) id);

  public QuestDetailData getData(CommonQuestType type, int id, bool bwave = false)
  {
    string key = QuestDetailManager.generateKey(type, id);
    QuestDetailData questDetailData = (QuestDetailData) null;
    if (!this.cache_.TryGetValue(key, out questDetailData))
    {
      questDetailData = new QuestDetailData(type, id, bwave);
      this.cache_.Add(key, questDetailData);
    }
    return questDetailData;
  }
}
