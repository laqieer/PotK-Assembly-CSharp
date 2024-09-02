// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryM
  {
    public int ID;
    public string name;
    public int quest_xl_QuestStoryXL;
    public int quest_l_QuestStoryL;
    public int number_m;
    public int priority;
    public int background_QuestCommonBackground;
    public string background_button_name;
    public string short_name;

    public static QuestStoryM Parse(MasterDataReader reader) => new QuestStoryM()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      quest_xl_QuestStoryXL = reader.ReadInt(),
      quest_l_QuestStoryL = reader.ReadInt(),
      number_m = reader.ReadInt(),
      priority = reader.ReadInt(),
      background_QuestCommonBackground = reader.ReadInt(),
      background_button_name = reader.ReadString(true),
      short_name = reader.ReadString(true)
    };

    public QuestStoryXL quest_xl
    {
      get
      {
        QuestStoryXL questStoryXl;
        if (!MasterData.QuestStoryXL.TryGetValue(this.quest_xl_QuestStoryXL, out questStoryXl))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryXL[" + (object) this.quest_xl_QuestStoryXL + "]"));
        return questStoryXl;
      }
    }

    public QuestStoryL quest_l
    {
      get
      {
        QuestStoryL questStoryL;
        if (!MasterData.QuestStoryL.TryGetValue(this.quest_l_QuestStoryL, out questStoryL))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryL[" + (object) this.quest_l_QuestStoryL + "]"));
        return questStoryL;
      }
    }

    public QuestCommonBackground background
    {
      get
      {
        QuestCommonBackground commonBackground;
        if (!MasterData.QuestCommonBackground.TryGetValue(this.background_QuestCommonBackground, out commonBackground))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCommonBackground[" + (object) this.background_QuestCommonBackground + "]"));
        return commonBackground;
      }
    }
  }
}
