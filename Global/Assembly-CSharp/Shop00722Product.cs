﻿// Decompiled with JetBrains decompiler
// Type: Shop00722Product
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00722Product : MonoBehaviour
{
  [SerializeField]
  private GameObject dynThum;
  [SerializeField]
  private UILabel txtProductName;
  [SerializeField]
  private UILabel txtProductAmount;
  private Action<ShopContent> btnAction;
  private ShopContent contentData;

  [DebuggerHidden]
  public IEnumerator Init(ShopContent content, Action<ShopContent> action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Product.\u003CInit\u003Ec__Iterator3E7()
    {
      content = content,
      action = action,
      \u003C\u0024\u003Econtent = content,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPush()
  {
    if (this.btnAction == null || this.contentData.entity_type == MasterDataTable.CommonRewardType.battle_medal || this.contentData.entity_type == MasterDataTable.CommonRewardType.medal || this.contentData.entity_type == MasterDataTable.CommonRewardType.gacha_ticket)
      return;
    this.btnAction(this.contentData);
  }
}
