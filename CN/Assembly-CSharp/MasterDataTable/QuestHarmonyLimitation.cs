// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestHarmonyLimitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestHarmonyLimitation
  {
    public int ID;
    public int quest_s_id_QuestHarmonyS;

    public static QuestHarmonyLimitation Parse(MasterDataReader reader)
    {
      return new QuestHarmonyLimitation()
      {
        ID = reader.ReadInt(),
        quest_s_id_QuestHarmonyS = reader.ReadInt()
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
