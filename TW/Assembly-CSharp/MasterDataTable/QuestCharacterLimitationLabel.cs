﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCharacterLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCharacterLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestCharacterS;
    public string label;

    public static QuestCharacterLimitationLabel Parse(MasterDataReader reader)
    {
      return new QuestCharacterLimitationLabel()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestCharacterS = reader.ReadInt(),
        label = reader.ReadString(true)
      };
    }

    public QuestCharacterS quest_s_id
    {
      get
      {
        QuestCharacterS questSId;
        if (!MasterData.QuestCharacterS.TryGetValue(this.quest_s_id_QuestCharacterS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestCharacterS[" + (object) this.quest_s_id_QuestCharacterS + "]"));
        return questSId;
      }
    }
  }
}
