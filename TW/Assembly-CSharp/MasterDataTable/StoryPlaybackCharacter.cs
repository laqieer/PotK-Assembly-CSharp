// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackCharacter
  {
    public int ID;
    public string name;
    public int quest_QuestCharacterS;
    public int priority;

    public static StoryPlaybackCharacter Parse(MasterDataReader reader)
    {
      return new StoryPlaybackCharacter()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        quest_QuestCharacterS = reader.ReadInt(),
        priority = reader.ReadInt()
      };
    }

    public QuestCharacterS quest
    {
      get
      {
        QuestCharacterS quest;
        if (!MasterData.QuestCharacterS.TryGetValue(this.quest_QuestCharacterS, out quest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.quest_QuestCharacterS + "]"));
        return quest;
      }
    }
  }
}
