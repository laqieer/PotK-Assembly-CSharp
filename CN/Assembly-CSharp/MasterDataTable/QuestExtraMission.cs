﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraMission
  {
    public int ID;
    public int quest_s_QuestExtraS;
    public int priority;
    public string name;
    public int entity_type_CommonRewardType;
    public int entity_id;
    public int quantity;

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
