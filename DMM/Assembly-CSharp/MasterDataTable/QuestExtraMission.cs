﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static QuestExtraMission Parse(MasterDataReader reader) => new QuestExtraMission()
    {
      ID = reader.ReadInt(),
      quest_s_QuestExtraS = reader.ReadInt(),
      priority = reader.ReadInt(),
      name = reader.ReadString(true),
      entity_type_CommonRewardType = reader.ReadInt(),
      entity_id = reader.ReadInt(),
      quantity = reader.ReadInt()
    };

    public QuestExtraS quest_s
    {
      get
      {
        QuestExtraS questExtraS;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_s_QuestExtraS, out questExtraS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_s_QuestExtraS + "]"));
        return questExtraS;
      }
    }

    public CommonRewardType entity_type => (CommonRewardType) this.entity_type_CommonRewardType;
  }
}
