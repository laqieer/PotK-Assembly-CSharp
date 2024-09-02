// Decompiled with JetBrains decompiler
// Type: InventoryItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class InventoryItem
{
  public MasterDataTable.CommonRewardType rewardType = MasterDataTable.CommonRewardType.gear;
  public PlayerItem Item;
  public ItemIcon icon;
  public bool select;
  public int index;
  public int selectCount;
  public int quantity;
  public bool Gray;
  public bool removeButton;
  public int[] selectIDS;

  public InventoryItem(PlayerItem item)
  {
    this.Item = item;
    this.rewardType = MasterDataTable.CommonRewardType.gear;
    if (!(item != (PlayerItem) null) || item.gear != null)
      return;
    this.rewardType = MasterDataTable.CommonRewardType.supply;
  }

  public InventoryItem Copy()
  {
    return new InventoryItem(this.Item)
    {
      select = this.select
    };
  }

  public void SetSelectIDS(int[] ids) => this.selectIDS = ids;

  public string GetName()
  {
    string empty = string.Empty;
    return this.rewardType != MasterDataTable.CommonRewardType.gear ? this.Item.supply.name : this.Item.gear.name;
  }

  public string GetDescription()
  {
    string empty = string.Empty;
    return this.rewardType != MasterDataTable.CommonRewardType.gear ? this.Item.supply.description : string.Empty;
  }

  public int GetSellPrice()
  {
    return this.rewardType != MasterDataTable.CommonRewardType.gear ? this.Item.supply.sell_price : this.Item.gear.sell_price;
  }

  public Future<Sprite> LoadSpriteThumbnail()
  {
    return this.rewardType != MasterDataTable.CommonRewardType.gear ? this.Item.supply.LoadSpriteThumbnail() : this.Item.gear.LoadSpriteThumbnail();
  }
}
