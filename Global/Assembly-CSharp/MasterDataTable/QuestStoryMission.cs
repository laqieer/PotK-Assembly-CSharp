// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryMission
  {
    public int ID;
    public int quest_s_QuestStoryS;
    public int priority;
    private string _name;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_story_QuestStoryMission_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestStoryMission Parse(MasterDataReader reader)
    {
      return new QuestStoryMission()
      {
        ID = reader.ReadInt(),
        quest_s_QuestStoryS = reader.ReadInt(),
        priority = reader.ReadInt(),
        name = reader.ReadString(true),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt()
      };
    }

    public QuestStoryS quest_s
    {
      get
      {
        QuestStoryS questS;
        if (!MasterData.QuestStoryS.TryGetValue(this.quest_s_QuestStoryS, out questS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestStoryS[" + (object) this.quest_s_QuestStoryS + "]"));
        return questS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
