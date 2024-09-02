// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraMission
  {
    public int ID;
    public int quest_s_QuestExtraS;
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
        return LocalizationManager.TryGetTermTranslation("quest_extra_QuestExtraMission_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestExtraMission Parse(MasterDataReader reader)
    {
      return new QuestExtraMission()
      {
        ID = reader.ReadInt(),
        quest_s_QuestExtraS = reader.ReadInt(),
        priority = reader.ReadInt(),
        name = reader.ReadString(true),
        entity_type_CommonRewardType = reader.ReadInt(),
        entity_id = reader.ReadInt(),
        quantity = reader.ReadInt()
      };
    }

    public QuestExtraS quest_s
    {
      get
      {
        QuestExtraS questS;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_s_QuestExtraS, out questS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_s_QuestExtraS + "]"));
        return questS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
