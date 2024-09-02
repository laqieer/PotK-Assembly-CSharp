// Decompiled with JetBrains decompiler
// Type: SM_QuestCharacterMExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_QuestCharacterMExtension
{
  public static PlayerCharacterQuestM[] FilterDisabled(
    this PlayerCharacterQuestM[] self,
    Dictionary<int, bool> playableQuestIDsMap)
  {
    return ((IEnumerable<PlayerCharacterQuestM>) self).Select<PlayerCharacterQuestM, PlayerCharacterQuestM>((Func<PlayerCharacterQuestM, PlayerCharacterQuestM>) (quest =>
    {
      quest.player_quests = ((IEnumerable<PlayerCharacterQuestS>) quest.player_quests).Where<PlayerCharacterQuestS>((Func<PlayerCharacterQuestS, bool>) (questDetail => !questDetail.quest_character_s.start_at.HasValue || questDetail.quest_character_s.start_at.Value.CompareTo(ServerTime.NowAppTime()) <= 0)).ToArray<PlayerCharacterQuestS>();
      if (!playableQuestIDsMap.ContainsKey(quest._quest_m_id))
        quest.is_playable = false;
      return quest;
    })).Where<PlayerCharacterQuestM>((Func<PlayerCharacterQuestM, bool>) (quest => quest.player_quests.Length > 0)).ToArray<PlayerCharacterQuestM>();
  }
}
