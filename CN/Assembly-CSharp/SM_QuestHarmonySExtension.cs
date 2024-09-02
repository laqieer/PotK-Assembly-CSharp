// Decompiled with JetBrains decompiler
// Type: SM_QuestHarmonySExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
