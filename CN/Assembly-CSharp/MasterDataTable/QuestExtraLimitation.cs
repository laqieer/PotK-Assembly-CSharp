﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraLimitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraLimitation
  {
    public int ID;
    public int quest_s_id_QuestExtraS;

    public static QuestExtraLimitation Parse(MasterDataReader reader)
    {
      return new QuestExtraLimitation()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestExtraS = reader.ReadInt()
      };
    }

    public QuestExtraS quest_s_id
    {
      get
      {
        QuestExtraS questSId;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_s_id_QuestExtraS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_s_id_QuestExtraS + "]"));
        return questSId;
      }
    }
  }
}
