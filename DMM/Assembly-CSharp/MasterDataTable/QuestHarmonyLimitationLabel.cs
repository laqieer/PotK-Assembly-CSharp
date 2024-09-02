// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestHarmonyS;
    public string label;

    public static QuestHarmonyLimitationLabel Parse(
      MasterDataReader reader)
    {
      return new QuestHarmonyLimitationLabel()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestHarmonyS = reader.ReadInt(),
        label = reader.ReadString(true)
      };
    }

    public QuestHarmonyS quest_s_id
    {
      get
      {
        QuestHarmonyS questHarmonyS;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.quest_s_id_QuestHarmonyS, out questHarmonyS))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.quest_s_id_QuestHarmonyS + "]"));
        return questHarmonyS;
      }
    }
  }
}
