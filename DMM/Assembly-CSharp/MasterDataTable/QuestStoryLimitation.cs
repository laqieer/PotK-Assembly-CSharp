// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryLimitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryLimitation
  {
    public int ID;
    public int quest_s_id_QuestStoryS;

    public static QuestStoryLimitation Parse(MasterDataReader reader) => new QuestStoryLimitation()
    {
      ID = reader.ReadInt(),
      quest_s_id_QuestStoryS = reader.ReadInt()
    };

    public QuestStoryS quest_s_id
    {
      get
      {
        QuestStoryS questStoryS;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_s_id_QuestStoryS, out questStoryS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_s_id_QuestStoryS + "]"));
        return questStoryS;
      }
    }
  }
}
