﻿// Decompiled with JetBrains decompiler
// Type: SM_EnemyTopInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_EnemyTopInfo
{
  public static IEnumerable<IGrouping<int, EnemyTopInfo>> GroupBy(this EnemyTopInfo[] self)
  {
    return ((IEnumerable<EnemyTopInfo>) self).GroupBy<EnemyTopInfo, int>((Func<EnemyTopInfo, int>) (x => MasterData.UnitUnit[x.unit_id].same_character_id));
  }
}
