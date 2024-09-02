﻿// Decompiled with JetBrains decompiler
// Type: SM_QuestCharacterSExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_QuestCharacterSExtension
{
  public static PlayerCharacterQuestS[] M(this PlayerCharacterQuestS[] self)
  {
    return ((IEnumerable<PlayerCharacterQuestS>) self).Distinct<PlayerCharacterQuestS>((IEqualityComparer<PlayerCharacterQuestS>) new LambdaEqualityComparer<PlayerCharacterQuestS>((Func<PlayerCharacterQuestS, PlayerCharacterQuestS, bool>) ((a, b) => a.quest_character_s.quest_m.ID == b.quest_character_s.quest_m.ID))).OrderBy<PlayerCharacterQuestS, int>((Func<PlayerCharacterQuestS, int>) (x => x.quest_character_s.quest_m.priority)).ToArray<PlayerCharacterQuestS>();
  }

  public static PlayerCharacterQuestS[] SelectReleased(this PlayerCharacterQuestS[] self)
  {
    return ((IEnumerable<PlayerCharacterQuestS>) self).Where<PlayerCharacterQuestS>((Func<PlayerCharacterQuestS, bool>) (questDetail => QuestCharacterS.CheckIsReleased(questDetail.quest_character_s.start_at))).ToArray<PlayerCharacterQuestS>();
  }
}
