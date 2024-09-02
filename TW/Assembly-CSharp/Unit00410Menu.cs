// Decompiled with JetBrains decompiler
// Type: Unit00410Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00410Menu : UnitSelectMenuBase
{
  [SerializeField]
  private GameObject ibtnEnter;
  private bool isOverAlert;

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerDeck[] playerDeck,
    Player player,
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits,
    bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00410Menu.\u003CInit\u003Ec__Iterator33B()
    {
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      isEquip = isEquip,
      playerDeck = playerDeck,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u003Ef__this = this
    };
  }

  public override void UpdateInfomation()
  {
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
    foreach (UnitIconInfo selectedUnitIcon in this.selectedUnitIcons)
    {
      if (selectedUnitIcon != null && selectedUnitIcon.playerUnit != (PlayerUnit) null)
        playerUnitList.Add(selectedUnitIcon.playerUnit);
      num2 += selectedUnitIcon.playerUnit.unit._base_sell_price * selectedUnitIcon.playerUnit.level * selectedUnitIcon.SelectedCount;
      num1 += selectedUnitIcon.SelectedCount;
      if (!selectedUnitIcon.unit.IsMaterialUnit || selectedUnitIcon.unit.is_buildup_only == 1)
        num3 += selectedUnitIcon.unit.rarity.sell_rarity_medal * selectedUnitIcon.SelectedCount;
    }
    if (this.selectedUnitIcons.Count > 0 && num1 <= this.SelectMax)
      this.ibtnEnter.GetComponent<UIButton>().isEnabled = true;
    else
      this.ibtnEnter.GetComponent<UIButton>().isEnabled = false;
    Player player = SMManager.Get<Player>();
    this.TxtNumberzeny.SetTextLocalize(string.Format("{0}", (object) num2));
    this.TxtNumberzeny.color = num2 + player.money > Consts.GetInstance().MONEY_MAX ? Color.red : Color.white;
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}", (object) num3));
    this.TxtNumberpossession.color = num3 + player.medal > Consts.GetInstance().MEDAL_MAX ? Color.red : Color.white;
    this.TxtNumberselect.color = num1 < this.SelectMax ? Color.white : Color.red;
    this.TxtNumberselect.SetTextLocalize(string.Format("{0}/{1}", (object) num1, (object) this.SelectMax));
    this.isOverAlert = num2 + player.money > Consts.GetInstance().MONEY_MAX || num3 + player.medal > Consts.GetInstance().MEDAL_MAX;
  }

  protected override void Select(UnitIconBase unitIconBase)
  {
    if (unitIconBase.PlayerUnit == (PlayerUnit) null)
      base.Select(unitIconBase);
    else if (unitIconBase.PlayerUnit.unit.IsNormalUnit)
      base.Select(unitIconBase);
    else
      this.StartCoroutine(this.OpenPopup(this.GetUnitInfoAll(unitIconBase.PlayerUnit)));
  }

  [DebuggerHidden]
  private IEnumerator IbtnYesAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00410Menu.\u003CIbtnYesAsync\u003Ec__Iterator33C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnYes()
  {
    if (this.IsPushAndSet())
      return;
    base.IbtnYes();
    this.StartCoroutine(this.IbtnYesAsync());
  }

  public override void IbtnBack() => base.IbtnBack();

  private List<PlayerUnit> ExpandPlayerUnits(UnitIconInfo iconInfo, int unitCount)
  {
    if ((unitCount > iconInfo.count || unitCount == 0) && Debug.isDebugBuild)
      Debug.LogError((object) ("Illegal unitCount specified. ID: " + (object) iconInfo.playerUnit.unit.ID + ", unitCount: " + (object) unitCount + ", iconInfo.count: " + (object) iconInfo.count));
    if (unitCount < 1)
      return (List<PlayerUnit>) null;
    List<PlayerUnit> playerUnitList1 = new List<PlayerUnit>();
    PlayerUnit[] source1 = SMManager.Get<PlayerUnit[]>();
    PlayerMaterialUnit[] source2 = SMManager.Get<PlayerMaterialUnit[]>();
    if (unitCount == 1)
      playerUnitList1.Add(iconInfo.playerUnit);
    else
      playerUnitList1 = !iconInfo.playerUnit.unit.IsNormalUnit ? ((IEnumerable<PlayerMaterialUnit>) source2).Where<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (t => t.id == iconInfo.playerUnit.id)).SelectMany<PlayerMaterialUnit, PlayerUnit>((Func<PlayerMaterialUnit, IEnumerable<PlayerUnit>>) (x =>
      {
        List<PlayerUnit> playerUnitList2 = new List<PlayerUnit>();
        for (int count = 0; count < iconInfo.SelectedCount; ++count)
          playerUnitList2.Add(PlayerUnit.CreateByPlayerMaterialUnit(x, count));
        return (IEnumerable<PlayerUnit>) playerUnitList2;
      })).ToList<PlayerUnit>() : ((IEnumerable<PlayerUnit>) source1).Where<PlayerUnit>((Func<PlayerUnit, bool>) (t => t.unit.ID == iconInfo.playerUnit.unit.ID)).Take<PlayerUnit>(unitCount).ToList<PlayerUnit>();
    return playerUnitList1;
  }

  [DebuggerHidden]
  private IEnumerator OpenPopup(UnitIconInfo unitIconInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00410Menu.\u003COpenPopup\u003Ec__Iterator33D()
    {
      unitIconInfo = unitIconInfo,
      \u003C\u0024\u003EunitIconInfo = unitIconInfo,
      \u003C\u003Ef__this = this
    };
  }
}
