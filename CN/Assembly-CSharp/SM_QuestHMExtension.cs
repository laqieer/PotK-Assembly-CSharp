// Decompiled with JetBrains decompiler
// Type: SM_QuestHMExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_QuestHMExtension
{
  public static PlayerHarmonyQuestM[] FilterDisabled(
    this PlayerHarmonyQuestM[] self,
    Dictionary<int, bool> playableQuestIDsMap)
  {
    return ((IEnumerable<PlayerHarmonyQuestM>) self).Select<PlayerHarmonyQuestM, PlayerHarmonyQuestM>((Func<PlayerHarmonyQuestM, PlayerHarmonyQuestM>) (quest =>
    {
      quest.player_quests = ((IEnumerable<PlayerHarmonyQuestS>) quest.player_quests).Where<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (questDetail => !questDetail.quest_harmony_s.start_at.HasValue || questDetail.quest_harmony_s.start_at.Value.CompareTo(ServerTime.NowAppTime()) <= 0)).ToArray<PlayerHarmonyQuestS>();
      if (!playableQuestIDsMap.ContainsKey(quest._quest_m_id))
        quest.is_playable = false;
      return quest;
    })).Where<PlayerHarmonyQuestM>((Func<PlayerHarmonyQuestM, bool>) (quest => quest.player_quests.Length > 0)).ToArray<PlayerHarmonyQuestM>();
  }
}
