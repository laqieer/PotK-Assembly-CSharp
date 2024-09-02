// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCharacterDisplayCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCharacterDisplayCondition
  {
    public int ID;
    public int quest_s_QuestCharacterS;
    public int priority;
    public int unit_UnitUnit;
    private string _name;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("quest_character_QuestCharacterDisplayCondition_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static QuestCharacterDisplayCondition Parse(MasterDataReader reader)
    {
      return new QuestCharacterDisplayCondition()
      {
        ID = reader.ReadInt(),
        quest_s_QuestCharacterS = reader.ReadInt(),
        priority = reader.ReadInt(),
        unit_UnitUnit = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }

    public QuestCharacterS quest_s
    {
      get
      {
        QuestCharacterS questS;
        if (!MasterData.QuestCharacterS.TryGetValue(this.quest_s_QuestCharacterS, out questS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.quest_s_QuestCharacterS + "]"));
        return questS;
      }
    }

    public UnitUnit unit
    {
      get
      {
        UnitUnit unit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_UnitUnit, out unit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_UnitUnit + "]"));
        return unit;
      }
    }
  }
}
