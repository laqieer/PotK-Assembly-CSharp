// Decompiled with JetBrains decompiler
// Type: Unit00487Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00487Menu : Unit00486Menu
{
  public override bool isComposeUnit(PlayerUnit baseUnit, PlayerMaterialUnit unit)
  {
    bool flag = false;
    if (unit.unit.IsBuildup)
    {
      if (baseUnit.buildup_count < baseUnit.buildup_limit)
      {
        if (unit.unit.hp_buildup != 0 && !baseUnit.hp.is_max && baseUnit.hp.buildup < baseUnit.unit.buildup_limit_release_id.hp_limit_release_cnt)
          flag = true;
        if (unit.unit.strength_buildup != 0 && !baseUnit.strength.is_max && baseUnit.strength.buildup < baseUnit.unit.buildup_limit_release_id.strength_limit_release_cnt)
          flag = true;
        if (unit.unit.vitality_buildup != 0 && !baseUnit.vitality.is_max && baseUnit.vitality.buildup < baseUnit.unit.buildup_limit_release_id.vitality_limit_release_cnt)
          flag = true;
        if (unit.unit.intelligence_buildup != 0 && !baseUnit.intelligence.is_max && baseUnit.intelligence.buildup < baseUnit.unit.buildup_limit_release_id.intelligence_limit_release_cnt)
          flag = true;
        if (unit.unit.mind_buildup != 0 && !baseUnit.mind.is_max && baseUnit.mind.buildup < baseUnit.unit.buildup_limit_release_id.mind_limit_release_cnt)
          flag = true;
        if (unit.unit.agility_buildup != 0 && !baseUnit.agility.is_max && baseUnit.agility.buildup < baseUnit.unit.buildup_limit_release_id.agility_limit_release_cnt)
          flag = true;
        if (unit.unit.dexterity_buildup != 0 && !baseUnit.dexterity.is_max && baseUnit.dexterity.buildup < baseUnit.unit.buildup_limit_release_id.dexterity_limit_release_cnt)
          flag = true;
        if (unit.unit.lucky_buildup != 0 && !baseUnit.lucky.is_max && baseUnit.lucky.buildup < baseUnit.unit.buildup_limit_release_id.lucky_limit_release_cnt)
          flag = true;
      }
      else
        flag = false;
    }
    return flag;
  }

  protected override void returnScene(List<UnitIconInfo> list, PlayerUnit _basePlayerUnit)
  {
    PlayerUnit[] array = list.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (z => !z.playerUnit.favorite)).Select<UnitIconInfo, PlayerUnit>((Func<UnitIconInfo, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>();
    Unit00420Scene.changeScene(false, _basePlayerUnit, array);
    Singleton<NGSceneManager>.GetInstance().destroyScene("unit004_8_7");
  }

  [DebuggerHidden]
  public override IEnumerator Init(
    Player player,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits,
    PlayerUnit[] selectUnits,
    PlayerDeck[] playerDeck,
    bool isEquip,
    int selMax)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00487Menu.\u003CInit\u003Ec__Iterator34B()
    {
      player = player,
      basePlayerUnit = basePlayerUnit,
      playerUnits = playerUnits,
      selMax = selMax,
      playerMaterialUnits = playerMaterialUnits,
      isEquip = isEquip,
      playerDeck = playerDeck,
      selectUnits = selectUnits,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EselMax = selMax,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003EselectUnits = selectUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected override void SetPrice(PlayerUnit[] materialPlayerUnits)
  {
    int num = CalcUnitCompose.priceStringth(this.baseUnit, materialPlayerUnits);
    this.TxtNumberzeny.SetTextLocalize(num.ToString());
    if (num > this.player.money)
    {
      this.TxtNumberzeny.color = Color.red;
      this.ibtnEnter.isEnabled = false;
    }
    else
    {
      this.TxtNumberzeny.color = Color.white;
      if (materialPlayerUnits.Length > 0)
        this.ibtnEnter.isEnabled = true;
      else
        this.ibtnEnter.isEnabled = false;
    }
  }

  protected override void Select(UnitIconBase unitIcon) => base.Select(unitIcon);
}
