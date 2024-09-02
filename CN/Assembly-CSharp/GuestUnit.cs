// Decompiled with JetBrains decompiler
// Type: GuestUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class GuestUnit
{
  public static int[] GetGuestsID(int stageID)
  {
    List<int> intList = new List<int>();
    List<KeyValuePair<int, BattleStageGuest>> list = MasterData.BattleStageGuest.Where<KeyValuePair<int, BattleStageGuest>>((Func<KeyValuePair<int, BattleStageGuest>, bool>) (x => x.Value.stage_BattleStage == stageID)).ToList<KeyValuePair<int, BattleStageGuest>>();
    foreach (KeyValuePair<int, BattleStageGuest> keyValuePair in list)
    {
      KeyValuePair<int, BattleStageGuest> unit = keyValuePair;
      if (MasterData.BattleStagePlayer.Any<KeyValuePair<int, BattleStagePlayer>>((Func<KeyValuePair<int, BattleStagePlayer>, bool>) (x => x.Value.stage_BattleStage == stageID && x.Value.deck_position == unit.Value.deck_position)))
        intList.Add(unit.Value.ID);
    }
    return intList.ToArray();
  }
}
