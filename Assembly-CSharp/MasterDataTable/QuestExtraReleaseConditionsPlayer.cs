// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraReleaseConditionsPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraReleaseConditionsPlayer
  {
    public int ID;
    public int quest_m_QuestExtraM;
    public string comparison_operator;
    public int? player_level;

    public static QuestExtraReleaseConditionsPlayer Parse(
      MasterDataReader reader)
    {
      return new QuestExtraReleaseConditionsPlayer()
      {
        ID = reader.ReadInt(),
        quest_m_QuestExtraM = reader.ReadInt(),
        comparison_operator = reader.ReadStringOrNull(true),
        player_level = reader.ReadIntOrNull()
      };
    }

    public QuestExtraM quest_m
    {
      get
      {
        QuestExtraM questExtraM;
        if (!MasterData.QuestExtraM.TryGetValue(this.quest_m_QuestExtraM, out questExtraM))
          Debug.LogError((object) ("Key not Found: MasterData.QuestExtraM[" + (object) this.quest_m_QuestExtraM + "]"));
        return questExtraM;
      }
    }
  }
}
