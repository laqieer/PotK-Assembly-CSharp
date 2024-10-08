﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCharacterDisplayCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

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
    public string name;

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
