// Decompiled with JetBrains decompiler
// Type: InventoryItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class InventoryItem
{
  private static readonly float[] GearRankSellPriceRate = new float[16]
  {
    1f,
    1f,
    2f,
    3f,
    4f,
    5f,
    6f,
    7f,
    8f,
    9f,
    10f,
    11f,
    12f,
    13f,
    14f,
    15f
  };
  private static readonly int BrokenSellValue = 1;
  public ItemInfo Item;
  public ItemIcon icon;
  public bool select;
  public int index;
  public int selectCount;
  public bool Gray;
  public bool removeButton;

  public InventoryItem() => this.removeButton = true;

  public InventoryItem(ItemInfo item) => this.Item = item;

  public InventoryItem(PlayerItem playerItem) => this.Item = new ItemInfo(playerItem);

  public InventoryItem(PlayerMaterialGear playerItem, int sameIndex = 0)
  {
    this.Item = new ItemInfo(playerItem, sameIndex);
  }

  public string GetName() => this.Item.Name();

  public string GetDescription() => this.Item.Description();

  public int GetSingleSellPrice() => this.Item.SellPrice();

  public int GetSellPrice()
  {
    return !this.select ? 0 : (this.Item.itemType == ItemInfo.ItemType.Supply ? this.Item.SellPrice() * this.selectCount : (!this.Item.broken ? (this.Item.itemType != ItemInfo.ItemType.Exchangable ? (int) ((double) this.Item.SellPrice() * (double) InventoryItem.GearRankSellPriceRate[this.Item.gearLevel]) : this.Item.SellPrice() * this.selectCount) : InventoryItem.BrokenSellValue));
  }

  public int GetRepairPrice(int zenyBoostCntCnt = 0)
  {
    int repairPrice = this.Item.RepairPrice();
    if (zenyBoostCntCnt > 0)
      repairPrice *= zenyBoostCntCnt + 1;
    return repairPrice;
  }

  public Future<Sprite> LoadSpriteThumbnail() => this.Item.LoadSpriteThumbnail();
}
