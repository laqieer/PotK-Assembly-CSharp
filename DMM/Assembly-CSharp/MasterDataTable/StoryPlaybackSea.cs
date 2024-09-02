// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackSea
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackSea
  {
    public int ID;
    public string name;
    public int quest_QuestSeaS;
    public int priority;

    public static StoryPlaybackSea Parse(MasterDataReader reader) => new StoryPlaybackSea()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      quest_QuestSeaS = reader.ReadInt(),
      priority = reader.ReadInt()
    };

    public QuestSeaS quest
    {
      get
      {
        QuestSeaS questSeaS;
        if (!MasterData.QuestSeaS.TryGetValue(this.quest_QuestSeaS, out questSeaS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestSeaS[" + (object) this.quest_QuestSeaS + "]"));
        return questSeaS;
      }
    }
  }
}
