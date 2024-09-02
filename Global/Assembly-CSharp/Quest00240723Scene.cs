// Decompiled with JetBrains decompiler
// Type: Quest00240723Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class Quest00240723Scene : NGSceneBase
{
  public Quest00240723Menu menu;

  public static void ChangeScene0024(bool stack, int L, bool passOriginID)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_4", (stack ? 1 : 0) != 0, (object) L, (object) passOriginID);
  }

  public static void ChangeScene0024(bool stack, int L)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_4", (stack ? 1 : 0) != 0, (object) L);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int L, bool passOriginID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00240723Scene.\u003ConStartSceneAsync\u003Ec__Iterator21C()
    {
      passOriginID = passOriginID,
      L = L,
      \u003C\u0024\u003EpassOriginID = passOriginID,
      \u003C\u0024\u003EL = L,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int L)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00240723Scene.\u003ConStartSceneAsync\u003Ec__Iterator21D()
    {
      L = L,
      \u003C\u0024\u003EL = L,
      \u003C\u003Ef__this = this
    };
  }

  private int SeekChoiceLnum(PlayerStoryQuestS[] StoryData, int L)
  {
    return ((IEnumerable<PlayerStoryQuestS>) StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l_QuestStoryL == L && x.quest_story_s.quest_l.origin_id.HasValue)).Count<PlayerStoryQuestS>() != 0 || !((IEnumerable<PlayerStoryQuestS>) StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.origin_id.HasValue)).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (x => x.quest_story_s.quest_l.origin_id.Value)).Contains<int>(L) ? L : ((IEnumerable<PlayerStoryQuestS>) StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.origin_id.HasValue && x.quest_story_s.quest_l.origin_id.Value == L)).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (y => y.quest_story_s.quest_l_QuestStoryL)).First<int>();
  }
}
