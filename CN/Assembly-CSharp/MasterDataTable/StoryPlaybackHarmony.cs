// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackHarmony
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackHarmony
  {
    public int ID;
    public string name;
    public int quest_QuestHarmonyS;
    public int priority;

    public static StoryPlaybackHarmony Parse(MasterDataReader reader)
    {
      return new StoryPlaybackHarmony()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        quest_QuestHarmonyS = reader.ReadInt(),
        priority = reader.ReadInt()
      };
    }

    public QuestHarmonyS quest
    {
      get
      {
        QuestHarmonyS quest;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.quest_QuestHarmonyS, out quest))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.quest_QuestHarmonyS + "]"));
        return quest;
      }
    }
  }
}
