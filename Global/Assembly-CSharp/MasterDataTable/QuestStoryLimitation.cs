// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryLimitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryLimitation
  {
    public int ID;
    public int quest_s_id_QuestStoryS;

    public static QuestStoryLimitation Parse(MasterDataReader reader)
    {
      return new QuestStoryLimitation()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestStoryS = reader.ReadInt()
      };
    }

    public QuestStoryS quest_s_id
    {
      get
      {
        QuestStoryS questSId;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_s_id_QuestStoryS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_s_id_QuestStoryS + "]"));
        return questSId;
      }
    }
  }
}
