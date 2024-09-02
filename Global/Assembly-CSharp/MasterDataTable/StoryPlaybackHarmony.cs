// Decompiled with JetBrains decompiler
// Type: MasterDataTable.StoryPlaybackHarmony
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class StoryPlaybackHarmony
  {
    public int ID;
    private string _name;
    public int quest_QuestHarmonyS;
    public int priority;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("story_playback_StoryPlaybackHarmony_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

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
