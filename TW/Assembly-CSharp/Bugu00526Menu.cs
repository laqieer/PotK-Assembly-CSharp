// Decompiled with JetBrains decompiler
// Type: Bugu00526Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu00526Menu : Bugu005SelectItemListMenuBase
{
  [SerializeField]
  private UIScrollView ScrollView;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052DrillingBaseSortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null && !x.gear.disappearance_num.HasValue && x.gear.kind.isEquip && (x.gear_level_limit != x.gear_level_limit_max ? 0 : (x.gear_level == x.gear_level_limit ? 1 : 0)) == 0)).ToList<PlayerItem>();
  }

  protected override void SelectItemProc(GameCore.ItemInfo item)
  {
    Bugu0059Scene.changeScene(true, item);
  }
}
