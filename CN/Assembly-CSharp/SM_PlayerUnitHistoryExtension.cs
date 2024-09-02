// Decompiled with JetBrains decompiler
// Type: SM_PlayerUnitHistoryExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerUnitHistoryExtension
{
  public static PlayerUnitHistory[] AllPlayers(this PlayerUnitHistory[] self)
  {
    return ((IEnumerable<PlayerUnitHistory>) self).Where<PlayerUnitHistory>((Func<PlayerUnitHistory, bool>) (x => MasterData.UnitUnit[x.unit_id].character.category == UnitCategory.player)).ToArray<PlayerUnitHistory>();
  }

  public static PlayerUnitHistory[] AllEnemies(this PlayerUnitHistory[] self)
  {
    return ((IEnumerable<PlayerUnitHistory>) self).Where<PlayerUnitHistory>((Func<PlayerUnitHistory, bool>) (x => MasterData.UnitUnit[x.unit_id].character.category == UnitCategory.enemy)).ToArray<PlayerUnitHistory>();
  }
}
