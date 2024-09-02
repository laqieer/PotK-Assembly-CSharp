// Decompiled with JetBrains decompiler
// Type: Unit0544Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections.Generic;
using UniLinq;

#nullable disable
public class Unit0544Menu : Unit0044Menu
{
  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu0544SortAndFilter;
  }

  protected override void ChangeDetailScene(ItemInfo item)
  {
    Unit05443Scene.changeSceneLimited(true, item);
  }

  protected override void BottomInfoUpdate()
  {
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}", (object) ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Count<PlayerItem>()));
  }
}
