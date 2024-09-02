// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestSeaM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestSeaM
  {
    public int ID;
    public string name;
    public int quest_xl_QuestSeaXL;
    public int quest_l_QuestSeaL;
    public int number_m;
    public int priority;
    public int background_QuestCommonBackground;
    public string background_button_name;
    public string short_name;

    public static QuestSeaM Parse(MasterDataReader reader) => new QuestSeaM()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      quest_xl_QuestSeaXL = reader.ReadInt(),
      quest_l_QuestSeaL = reader.ReadInt(),
      number_m = reader.ReadInt(),
      priority = reader.ReadInt(),
      background_QuestCommonBackground = reader.ReadInt(),
      background_button_name = reader.ReadString(true),
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

    public QuestSeaL quest_l
    {
      get
      {
        QuestSeaL questSeaL;
        if (!MasterData.QuestSeaL.TryGetValue(this.quest_l_QuestSeaL, out questSeaL))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaL[" + (object) this.quest_l_QuestSeaL + "]"));
        return questSeaL;
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
