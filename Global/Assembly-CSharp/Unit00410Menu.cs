// Decompiled with JetBrains decompiler
// Type: Unit00410Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private List<PlayerUnit> m_playerUnitsCache;

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerDeck[] playerDeck,
    Player player,
    PlayerUnit[] playerUnits,
    bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00410Menu.\u003CInit\u003Ec__Iterator296()
    {
      playerUnits = playerUnits,
      isEquip = isEquip,
      playerDeck = playerDeck,
      player = player,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003Eplayer = player,
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
      if (!selectedUnitIcon.playerUnit.unit.IsMaterialUnit || selectedUnitIcon.playerUnit.unit.is_buildup_only == 1)
        num3 += selectedUnitIcon.playerUnit.unit.rarity.sell_rarity_medal * selectedUnitIcon.SelectedCount;
    }
    if (this.selectedUnitIcons.Count > 0 && num1 <= this.SelectMax)
    {
      this.ibtnEnter.GetComponent<UISprite>().color = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
      ((Collider) this.ibtnEnter.GetComponent<BoxCollider>()).enabled = true;
    }
    else
    {
      this.ibtnEnter.GetComponent<UISprite>().color = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
      ((Collider) this.ibtnEnter.GetComponent<BoxCollider>()).enabled = false;
    }
    this.TxtNumberzeny.SetTextLocalize(string.Format("{0}", (object) num2));
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}", (object) num3));
    this.TxtNumberselect.color = num1 < this.SelectMax ? Color.white : Color.red;
    this.TxtNumberselect.SetTextLocalize(string.Format("{0}/{1}", (object) num1, (object) this.SelectMax));
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
    return (IEnumerator) new Unit00410Menu.\u003CIbtnYesAsync\u003Ec__Iterator297()
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
    List<PlayerUnit> playerUnitList = new List<PlayerUnit>();
    if (unitCount == 1)
      playerUnitList.Add(iconInfo.playerUnit);
    else
      playerUnitList = this.m_playerUnitsCache.Where<PlayerUnit>((Func<PlayerUnit, bool>) (t => t.unit.ID == iconInfo.playerUnit.unit.ID)).Take<PlayerUnit>(unitCount).ToList<PlayerUnit>();
    return playerUnitList;
  }

  [DebuggerHidden]
  private IEnumerator OpenPopup(UnitIconInfo unitIconInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00410Menu.\u003COpenPopup\u003Ec__Iterator298()
    {
      unitIconInfo = unitIconInfo,
      \u003C\u0024\u003EunitIconInfo = unitIconInfo,
      \u003C\u003Ef__this = this
    };
  }
}
