// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCharacterReleaseCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCharacterReleaseCondition
  {
    public int ID;
    public int quest_s_QuestCharacterS;
    public int? required_quest_s_QuestCharacterS;
    public int? required_unit_UnitUnit;
    public int? required_unit_level;

    public static QuestCharacterReleaseCondition Parse(MasterDataReader reader)
    {
      return new QuestCharacterReleaseCondition()
      {
        ID = reader.ReadInt(),
        quest_s_QuestCharacterS = reader.ReadInt(),
        required_quest_s_QuestCharacterS = reader.ReadIntOrNull(),
        required_unit_UnitUnit = reader.ReadIntOrNull(),
        required_unit_level = reader.ReadIntOrNull()
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

    public QuestCharacterS required_quest_s
    {
      get
      {
        if (!this.required_quest_s_QuestCharacterS.HasValue)
          return (QuestCharacterS) null;
        QuestCharacterS requiredQuestS;
        if (!MasterData.QuestCharacterS.TryGetValue(this.required_quest_s_QuestCharacterS.Value, out requiredQuestS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.required_quest_s_QuestCharacterS.Value + "]"));
        return requiredQuestS;
      }
    }

    public UnitUnit required_unit
    {
      get
      {
        if (!this.required_unit_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit requiredUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.required_unit_UnitUnit.Value, out requiredUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.required_unit_UnitUnit.Value + "]"));
        return requiredUnit;
      }
    }
  }
}
