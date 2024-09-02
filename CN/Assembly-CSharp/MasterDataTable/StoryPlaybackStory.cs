// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackStory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackStory
  {
    public int ID;
    public string name;
    public int quest_QuestStoryS;
    public int priority;

    public static StoryPlaybackStory Parse(MasterDataReader reader)
    {
      return new StoryPlaybackStory()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        quest_QuestStoryS = reader.ReadInt(),
        priority = reader.ReadInt()
      };
    }

    public QuestStoryS quest
    {
      get
      {
        QuestStoryS quest;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_QuestStoryS, out quest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_QuestStoryS + "]"));
        return quest;
      }
    }
  }
}
