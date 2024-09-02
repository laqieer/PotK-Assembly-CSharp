// Decompiled with JetBrains decompiler
// Type: Bugu0052Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu0052Menu : Bugu005ItemListMenuBase
{
  [SerializeField]
  private UILabel TxtNumberPattern1;
  [SerializeField]
  private UIScrollView ScrollView;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0052SortAndFilter;
  }

  protected override List<PlayerItem> GetItemList()
  {
    return ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.isWeapon())).ToList<PlayerItem>();
  }

  protected override void BottomInfoUpdate()
  {
    Player player = SMManager.Get<Player>();
    this.TxtNumberPattern1.SetTextLocalize(Consts.Format(Consts.GetInstance().GEAR_0052_POSSESSION, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) this.InventoryItems.Count<InventoryItem>()
      },
      {
        (object) "max",
        (object) player.max_items
      }
    }));
  }
}
