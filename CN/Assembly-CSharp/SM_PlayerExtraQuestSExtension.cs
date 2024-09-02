// Decompiled with JetBrains decompiler
// Type: SM_PlayerExtraQuestSExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public static class SM_PlayerExtraQuestSExtension
{
  public static PlayerExtraQuestS[] L(this PlayerExtraQuestS[] self)
  {
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => q.seek_index == "l" || q.seek_index == nameof (L))).CheckMasterData().Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.quest_l.ID == b.quest_extra_s.quest_l.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.quest_l.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] M(this PlayerExtraQuestS[] self)
  {
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.seek_index == "m" || x.seek_index == nameof (M))).CheckMasterData().Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.quest_m.ID == b.quest_extra_s.quest_m.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.quest_m.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] M(this PlayerExtraQuestS[] self, int l)
  {
    return ((IEnumerable<PlayerExtraQuestS>) self).CheckMasterData().Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => (q.seek_index == nameof (l) || q.seek_index == "L") && q.quest_extra_s.quest_l.ID == l)).Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.quest_m.ID == b.quest_extra_s.quest_m.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.quest_m.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] S(this PlayerExtraQuestS[] self, int l, int m)
  {
    return ((IEnumerable<PlayerExtraQuestS>) self).CheckMasterData().Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => q.quest_extra_s.quest_l.ID == l && q.quest_extra_s.quest_m.ID == m)).Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.ID == b.quest_extra_s.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] L_ClearedStory(this PlayerExtraQuestS[] self)
  {
    Dictionary<int, StoryPlaybackExtra> dic = ((IEnumerable<StoryPlaybackExtra>) MasterData.StoryPlaybackExtraList).ToDictionary<StoryPlaybackExtra, int>((Func<StoryPlaybackExtra, int>) (x => x.quest.ID));
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => q.is_clear && dic.ContainsKey(q.quest_extra_s.ID))).Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.quest_l.ID == b.quest_extra_s.quest_l.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.quest_l.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] M_ClearedStory(this PlayerExtraQuestS[] self, int l)
  {
    Dictionary<int, StoryPlaybackExtra> dic = ((IEnumerable<StoryPlaybackExtra>) MasterData.StoryPlaybackExtraList).ToDictionary<StoryPlaybackExtra, int>((Func<StoryPlaybackExtra, int>) (x => x.quest.ID));
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => q.quest_extra_s.quest_l.ID == l && q.is_clear && dic.ContainsKey(q.quest_extra_s.ID))).Distinct<PlayerExtraQuestS>((IEqualityComparer<PlayerExtraQuestS>) new LambdaEqualityComparer<PlayerExtraQuestS>((Func<PlayerExtraQuestS, PlayerExtraQuestS, bool>) ((a, b) => a.quest_extra_s.quest_m.ID == b.quest_extra_s.quest_m.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.quest_m.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static PlayerExtraQuestS[] S_ClearedStory(this PlayerExtraQuestS[] self, int l, int m)
  {
    Dictionary<int, StoryPlaybackExtra> dic = ((IEnumerable<StoryPlaybackExtra>) MasterData.StoryPlaybackExtraList).ToDictionary<StoryPlaybackExtra, int>((Func<StoryPlaybackExtra, int>) (x => x.quest.ID));
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (q => q.quest_extra_s.quest_l.ID == l && q.quest_extra_s.quest_m.ID == m && q.is_clear && dic.ContainsKey(q.quest_extra_s.ID))).OrderBy<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.priority)).ToArray<PlayerExtraQuestS>();
  }

  public static StoryPlaybackStory[] Stories(this PlayerExtraQuestS[] self)
  {
    Dictionary<int, StoryPlaybackStory> dic = ((IEnumerable<StoryPlaybackStory>) MasterData.StoryPlaybackStoryList).ToDictionary<StoryPlaybackStory, int>((Func<StoryPlaybackStory, int>) (x => x.quest.ID));
    return ((IEnumerable<PlayerExtraQuestS>) self).Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x => x.is_clear && dic.ContainsKey(x.quest_extra_s.ID))).Select<PlayerExtraQuestS, StoryPlaybackStory>((Func<PlayerExtraQuestS, StoryPlaybackStory>) (x => dic[x.quest_extra_s.ID])).OrderByDescending<StoryPlaybackStory, int>((Func<StoryPlaybackStory, int>) (x => x.priority)).ToArray<StoryPlaybackStory>();
  }

  public static bool HasStory(this PlayerExtraQuestS self)
  {
    return self.StoryDetails().Any<StoryPlaybackStoryDetail>();
  }

  public static List<StoryPlaybackStoryDetail> StoryDetails(this PlayerExtraQuestS self)
  {
    foreach (StoryPlaybackStory storyPlaybackStory in MasterData.StoryPlaybackStoryList)
    {
      StoryPlaybackStory storyPlayBack = storyPlaybackStory;
      if (storyPlayBack.quest.ID == self.quest_extra_s.ID)
        return ((IEnumerable<StoryPlaybackStoryDetail>) MasterData.StoryPlaybackStoryDetailList).Where<StoryPlaybackStoryDetail>((Func<StoryPlaybackStoryDetail, bool>) (x => x.story.quest.ID == storyPlayBack.quest.ID)).ToList<StoryPlaybackStoryDetail>();
    }
    return new List<StoryPlaybackStoryDetail>();
  }

  public static PlayerQuestGate GetPlayerQuestGate(this PlayerExtraQuestS self)
  {
    PlayerQuestGate[] source = SMManager.Get<PlayerQuestGate[]>();
    return source == null ? (PlayerQuestGate) null : ((IEnumerable<PlayerQuestGate>) source).SingleOrDefault<PlayerQuestGate>((Func<PlayerQuestGate, bool>) (x => ((IEnumerable<int>) x.quest_ids).Any<int>((Func<int, bool>) (y => y == self._quest_extra_s))));
  }

  public static IEnumerable<PlayerExtraQuestS> CheckMasterData(
    this IEnumerable<PlayerExtraQuestS> self)
  {
    return self.Where<PlayerExtraQuestS>((Func<PlayerExtraQuestS, bool>) (x =>
    {
      if (MasterData.QuestExtraS.ContainsKey(x._quest_extra_s))
        return true;
      Debug.LogError((object) ("ExtraQuest ID" + (object) x._quest_extra_s + "がマスターデータから見つかりませんでした。"));
      return false;
    }));
  }
}
