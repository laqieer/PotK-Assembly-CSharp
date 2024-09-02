// Decompiled with JetBrains decompiler
// Type: SM_EnemyTopInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_EnemyTopInfo
{
  public static IEnumerable<IGrouping<int, EnemyTopInfo>> GroupBy(this EnemyTopInfo[] self)
  {
    return ((IEnumerable<EnemyTopInfo>) self).GroupBy<EnemyTopInfo, int>((Func<EnemyTopInfo, int>) (x => MasterData.UnitUnit[x.unit_id].history_group_number));
  }
}
