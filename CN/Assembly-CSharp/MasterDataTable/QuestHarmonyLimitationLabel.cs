// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyLimitationLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyLimitationLabel
  {
    public int ID;
    public int quest_s_id_QuestHarmonyS;
    public string label;

    public static QuestHarmonyLimitationLabel Parse(MasterDataReader reader)
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
        QuestHarmonyS questSId;
        if (!MasterData.QuestHarmonyS.TryGetValue(this.quest_s_id_QuestHarmonyS, out questSId))
          Debug.LogError((object) ("Key not Found: MasterData.QuestHarmonyS[" + (object) this.quest_s_id_QuestHarmonyS + "]"));
        return questSId;
      }
    }
  }
}
