﻿// Decompiled with JetBrains decompiler
// Type: Bugu00522Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class Bugu00522Menu : Bugu005SelectItemListMenuBase
{
  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052BuildupBaseSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null && !x.isExchangable() && x.gear.kind.Enum != GearKindEnum.accessories)).ToList<PlayerItem>();
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    Bugu0058Scene.changeScene(true, item);
  }
}
