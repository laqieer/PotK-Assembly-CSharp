// Decompiled with JetBrains decompiler
// Type: SM_PlayerUnitExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public static class SM_PlayerUnitExtension
{
  public static int AmountHavingTargetUnit(
    this PlayerUnit[] self,
    int entity_id,
    MasterDataTable.CommonRewardType entity_type)
  {
    int ret = 0;
    int quantity = 0;
    if (entity_type == MasterDataTable.CommonRewardType.unit)
      ((IEnumerable<PlayerUnit>) ((IEnumerable<PlayerUnit>) self).Where<PlayerUnit>((Func<PlayerUnit, bool>) (pi => pi.unit != null && pi.unit.ID == entity_id)).ToArray<PlayerUnit>()).ForEach<PlayerUnit>((Action<PlayerUnit>) (ar => ret = ++quantity));
    return ret;
  }
}
