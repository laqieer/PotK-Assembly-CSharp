﻿// Decompiled with JetBrains decompiler
// Type: ShopItemGetResultInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class ShopItemGetResultInfo
{
  public MasterDataTable.CommonRewardType rewardType;
  public int rewardId;
  public int quantity;

  public ShopItemGetResultInfo(MasterDataTable.CommonRewardType type, int reward_id, int quantity)
  {
    this.rewardId = reward_id;
    this.rewardType = type;
    this.quantity = quantity;
  }
}
