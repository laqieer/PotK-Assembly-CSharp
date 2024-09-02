// Decompiled with JetBrains decompiler
// Type: Bugu00526Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections.Generic;

public class Bugu00526Menu : Bugu005SelectItemListMenuBase
{
  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist() => Persist.bugu0052DrillingBaseSortAndFilter;

  protected override List<PlayerItem> GetItemList()
  {
    List<PlayerItem> playerItemList = new List<PlayerItem>();
    foreach (PlayerItem playerItem in SMManager.Get<PlayerItem[]>())
    {
      if (playerItem.gear != null && (!playerItem.gear.disappearance_num.HasValue || playerItem.isReisouSet) && (playerItem.gear.kind.isEquip && !playerItem.gear.isReisou()) && (playerItem.gear_level_limit != playerItem.gear_level_limit_max || playerItem.gear_level != playerItem.gear_level_limit || playerItem.isReisouSet && !(playerItem.equipReisou == (PlayerItem) null) && playerItem.equipReisou.gear_level != playerItem.equipReisou.gear_level_limit))
        playerItemList.Add(playerItem);
    }
    return playerItemList;
  }

  protected override void SelectItemProc(ItemInfo item) => Bugu0059Scene.changeScene(true, item);

  protected virtual void OnEnable()
  {
    if (!this.scroll.scrollView.isDragging)
      return;
    this.scroll.scrollView.Press(false);
  }
}
