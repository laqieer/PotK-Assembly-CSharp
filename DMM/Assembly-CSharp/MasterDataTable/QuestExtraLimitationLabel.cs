﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestExtraS;
    public string label;

    public static QuestExtraLimitationLabel Parse(MasterDataReader reader) => new QuestExtraLimitationLabel()
    {
      ID = reader.ReadInt(),
      quest_s_id_QuestExtraS = reader.ReadInt(),
      label = reader.ReadString(true)
    };

    public QuestExtraS quest_s_id
    {
      get
      {
        QuestExtraS questExtraS;
        if (!MasterData.QuestExtraS.TryGetValue(this.quest_s_id_QuestExtraS, out questExtraS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraS[" + (object) this.quest_s_id_QuestExtraS + "]"));
        return questExtraS;
      }
    }
  }
}
