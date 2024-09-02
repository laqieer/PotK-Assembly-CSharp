// Decompiled with JetBrains decompiler
// Type: InventoryItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;

public class InventoryItem
{
  public static readonly int GearRankMax = 10;
  private static readonly int BrokenSellValue = 1;
  public GameCore.ItemInfo Item;
  public ItemIcon icon;
  public bool select;
  public int index;
  public int selectCount;
  public bool Gray;
  public bool removeButton;

  public InventoryItem() => this.removeButton = true;

  public InventoryItem(GameCore.ItemInfo item) => this.Item = item;

  public InventoryItem(PlayerItem playerItem, bool bExpireDate = false, Func<bool> checkEquipped = null) => this.Item = new GameCore.ItemInfo(playerItem, bExpireDate, checkEquipped);

  public InventoryItem(PlayerMaterialGear playerItem, int sameIndex = 0) => this.Item = new GameCore.ItemInfo(playerItem, sameIndex);

  public string GetName() => this.Item.Name();

  public string GetDescription() => this.Item.Description();

  public long GetSingleSellPrice() => this.Item.SellPrice();

  public long GetSellPrice()
  {
    if (!this.select)
      return 0;
    long num1;
    if (this.Item.itemType != GameCore.ItemInfo.ItemType.Supply)
    {
      if (this.Item.broken)
      {
        num1 = (long) InventoryItem.BrokenSellValue;
      }
      else
      {
        float num2 = this.Item.gearLevel == 0 ? 1f : 1f * (float) this.Item.gearLevel;
        num1 = this.Item.itemType != GameCore.ItemInfo.ItemType.Exchangable ? (this.Item.itemType != GameCore.ItemInfo.ItemType.Gear ? (long) ((double) this.Item.SellPrice() * (double) num2) * (long) this.selectCount : (long) ((double) this.Item.SellPrice() * (double) num2)) : this.Item.SellPrice() * (long) this.selectCount;
      }
    }
    else
      num1 = this.Item.SellPrice() * (long) this.selectCount;
    return num1;
  }

  public int GetRepairPrice(int zenyBoostCntCnt = 0)
  {
    int num = this.Item.RepairPrice();
    if (zenyBoostCntCnt > 0)
      num *= zenyBoostCntCnt + 1;
    return num;
  }

  public Future<UnityEngine.Sprite> LoadSpriteThumbnail() => this.Item.LoadSpriteThumbnail();
}
