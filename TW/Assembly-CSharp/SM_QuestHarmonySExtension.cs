﻿// Decompiled with JetBrains decompiler
// Type: SM_QuestHarmonySExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_QuestHarmonySExtension
{
  public static PlayerHarmonyQuestS[] SelectReleased(this PlayerHarmonyQuestS[] self)
  {
    return ((IEnumerable<PlayerHarmonyQuestS>) self).Where<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (questDetail => QuestCharacterS.CheckIsReleased(questDetail.quest_harmony_s.start_at))).ToArray<PlayerHarmonyQuestS>();
  }
}
