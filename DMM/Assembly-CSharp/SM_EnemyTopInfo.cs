// Decompiled with JetBrains decompiler
// Type: SM_EnemyTopInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;

public static class SM_EnemyTopInfo
{
  public static IEnumerable<IGrouping<int, EnemyTopInfo>> GroupBy(
    this EnemyTopInfo[] self)
  {
    return ((IEnumerable<EnemyTopInfo>) self).GroupBy<EnemyTopInfo, int>((Func<EnemyTopInfo, int>) (x => MasterData.UnitUnit[x.unit_id].same_character_id));
  }
}
