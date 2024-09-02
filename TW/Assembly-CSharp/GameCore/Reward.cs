// Decompiled with JetBrains decompiler
// Type: GameCore.Reward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using UnityEngine;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class Reward
  {
    [SerializeField]
    private CommonRewardType type;
    [SerializeField]
    private int id;
    [SerializeField]
    private int quantity;

    public Reward(CommonRewardType type, int id, int quantity)
    {
      this.type = type;
      this.id = id;
      this.quantity = quantity;
    }

    public CommonRewardType Type => this.type;

    public int Id => this.id;

    public int Quantity => this.quantity;
  }
}
