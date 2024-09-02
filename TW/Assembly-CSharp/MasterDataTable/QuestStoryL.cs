// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryL
  {
    public int ID;
    public string name;
    public int priority;
    public int? origin_id;
    public int quest_xl_QuestStoryXL;
    public int quest_mode_CommonQuestMode;
    public int number_l;
    public string short_name;

    public static QuestStoryL Parse(MasterDataReader reader)
    {
      return new QuestStoryL()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        priority = reader.ReadInt(),
        origin_id = reader.ReadIntOrNull(),
        quest_xl_QuestStoryXL = reader.ReadInt(),
        quest_mode_CommonQuestMode = reader.ReadInt(),
        number_l = reader.ReadInt(),
        short_name = reader.ReadString(true)
      };
    }

    public QuestStoryXL quest_xl
    {
      get
      {
        QuestStoryXL questXl;
        if (!MasterData.QuestStoryXL.TryGetValue(this.quest_xl_QuestStoryXL, out questXl))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryXL[" + (object) this.quest_xl_QuestStoryXL + "]"));
        return questXl;
      }
    }

    public CommonQuestMode quest_mode => (CommonQuestMode) this.quest_mode_CommonQuestMode;
  }
}
