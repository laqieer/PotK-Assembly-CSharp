// Decompiled with JetBrains decompiler
// Type: SM_QuestCharacterMExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

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
    })).Where<PlayerCharacterQuestM>((Func<PlayerCharacterQuestM, bool>) (quest => (uint) quest.player_quests.Length > 0U)).ToArray<PlayerCharacterQuestM>();
  }
}
