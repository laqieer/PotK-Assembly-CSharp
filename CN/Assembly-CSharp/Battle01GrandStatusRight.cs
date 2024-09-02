﻿// Decompiled with JetBrains decompiler
// Type: Battle01GrandStatusRight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle01GrandStatusRight : NGBattleMenuBase
{
  [SerializeField]
  private UILabel unit;
  [SerializeField]
  private UILabel item;
  [SerializeField]
  private UILabel zeny;
  private bool is_push;
  private BL.BattleModified<BL.StructValue<int>> dropUnitModified;
  private BL.BattleModified<BL.StructValue<int>> dropItemModified;
  private BL.BattleModified<BL.StructValue<int>> dropMoneyModified;

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01GrandStatusRight.\u003ConInitAsync\u003Ec__Iterator84A()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (this.dropMoneyModified.isChangedOnce())
    {
      float money = (float) this.dropMoneyModified.value.value;
      foreach (BL.Unit unit in this.env.core.playerUnits.value)
        unit.skillEffects.Where(BattleskillEffectLogicEnum.ratio_money).ForEach<BL.SkillEffect>((Action<BL.SkillEffect>) (e => money *= e.effect.GetFloat("percentage") / 100f));
      this.setText(this.zeny, (int) money);
    }
    if (this.dropItemModified.isChangedOnce())
      this.setText(this.item, this.dropItemModified.value.value);
    if (!this.dropUnitModified.isChangedOnce())
      return;
    this.setText(this.unit, this.dropUnitModified.value.value);
  }

  public Transform getLabelTransform(BL.DropData drop)
  {
    switch (drop.reward.Type)
    {
      case MasterDataTable.CommonRewardType.unit:
      case MasterDataTable.CommonRewardType.material_unit:
        return ((Component) this.unit).transform;
      case MasterDataTable.CommonRewardType.supply:
      case MasterDataTable.CommonRewardType.gear:
        return ((Component) this.item).transform;
      case MasterDataTable.CommonRewardType.money:
        return ((Component) this.zeny).transform;
      default:
        return (Transform) null;
    }
  }
}
