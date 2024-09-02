// Decompiled with JetBrains decompiler
// Type: GameCore.Reward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
