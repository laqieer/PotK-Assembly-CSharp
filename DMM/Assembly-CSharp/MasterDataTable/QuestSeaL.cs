﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestSeaL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestSeaL
  {
    public int ID;
    public string name;
    public int priority;
    public int? origin_id;
    public int quest_xl_QuestSeaXL;
    public int quest_mode_CommonQuestMode;
    public int number_l;
    public string short_name;

    public static QuestSeaL Parse(MasterDataReader reader) => new QuestSeaL()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      priority = reader.ReadInt(),
      origin_id = reader.ReadIntOrNull(),
      quest_xl_QuestSeaXL = reader.ReadInt(),
      quest_mode_CommonQuestMode = reader.ReadInt(),
      number_l = reader.ReadInt(),
      short_name = reader.ReadString(true)
    };

    public QuestSeaXL quest_xl
    {
      get
      {
        QuestSeaXL questSeaXl;
        if (!MasterData.QuestSeaXL.TryGetValue(this.quest_xl_QuestSeaXL, out questSeaXl))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaXL[" + (object) this.quest_xl_QuestSeaXL + "]"));
        return questSeaXl;
      }
    }

    public CommonQuestMode quest_mode => (CommonQuestMode) this.quest_mode_CommonQuestMode;
  }
}
