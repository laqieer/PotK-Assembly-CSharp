// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryL
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryL
  {
    public int ID;
    private string _name;
    public int priority;
    public int? origin_id;
    public int quest_xl_QuestStoryXL;
    public int quest_mode_CommonQuestMode;
    public int number_l;
    private string _short_name;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_story_QuestStoryL_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string short_name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._short_name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_story_QuestStoryL_short_name_" + (object) this.ID, out Translation) ? Translation : this._short_name;
      }
      set => this._short_name = value;
    }

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
