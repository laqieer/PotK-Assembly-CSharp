// Decompiled with JetBrains decompiler
// Type: Unit00486Menu
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
public class Unit00486Menu : UnitSelectMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UIButton ibtnEnter;
  private List<UnitIconInfo> firstSelectedUnitIcons;
  protected Player player;
  protected int playerUnitMax;

  public List<UnitIconInfo> SelectedUnitIcons => this.selectedUnitIcons;

  protected virtual void SetPrice(PlayerUnit[] materialPlayerUnits)
  {
    int num = CalcUnitCompose.priceCompose(this.baseUnit, materialPlayerUnits);
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

  public override void UpdateInfomation()
  {
    List<PlayerUnit> selectUnit = new List<PlayerUnit>();
    this.selectedUnitIcons.ForEach((Action<UnitIconInfo>) (icon => selectUnit.Add(icon.playerUnit)));
    this.SetPrice(selectUnit.ToArray());
    this.TxtNumberselect.SetTextLocalize(string.Format("{0}/{1}", (object) this.selectedUnitIcons.Count, (object) this.SelectMax));
    this.TxtNumberselect.color = this.selectedUnitIcons.Count <= this.SelectMax - 1 ? Color.white : Color.red;
    this.TxtNumberpossession.SetTextLocalize(string.Format("{0}/{1}", (object) this.playerUnitMax, (object) this.player.max_units));
  }

  public virtual bool isComposeUnit(PlayerUnit baseUnit, PlayerUnit unit)
  {
    IEnumerable<PlayerUnitSkills> source = ((IEnumerable<PlayerUnitSkills>) baseUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.level < x.skill.upper_level));
    bool isSkill = source.Any<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (unitBase => ((IEnumerable<PlayerUnitSkills>) unit.skills).Count<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => unitBase.skill_id == x.skill_id)) > 0));
    if (unit.unit.same_character_id == baseUnit.unit.same_character_id && source.Count<PlayerUnitSkills>() > 0)
      isSkill = true;
    else
      ((IEnumerable<PlayerUnitSkills>) baseUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.level < x.skill.upper_level)).ForEach<PlayerUnitSkills>((Action<PlayerUnitSkills>) (y =>
      {
        if (baseUnit.unit.same_character_id == unit.unit.same_character_id || ((IEnumerable<PlayerUnitSkills>) unit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (z => y.skill_id == z.skill_id)).Count<PlayerUnitSkills>() == 0)
          return;
        isSkill = true;
      }));
    bool flag1 = false;
    if (unit.unit.hp_compose != 0 && baseUnit.hp.compose < baseUnit.UnitTypeParameter.hp_compose_max)
      flag1 = true;
    if (unit.unit.strength_compose != 0 && baseUnit.strength.compose < baseUnit.UnitTypeParameter.strength_compose_max)
      flag1 = true;
    if (unit.unit.vitality_compose != 0 && baseUnit.vitality.compose < baseUnit.UnitTypeParameter.vitality_compose_max)
      flag1 = true;
    if (unit.unit.intelligence_compose != 0 && baseUnit.intelligence.compose < baseUnit.UnitTypeParameter.intelligence_compose_max)
      flag1 = true;
    if (unit.unit.mind_compose != 0 && baseUnit.mind.compose < baseUnit.UnitTypeParameter.mind_compose_max)
      flag1 = true;
    if (unit.unit.agility_compose != 0 && baseUnit.agility.compose < baseUnit.UnitTypeParameter.agility_compose_max)
      flag1 = true;
    if (unit.unit.dexterity_compose != 0 && baseUnit.dexterity.compose < baseUnit.UnitTypeParameter.dexterity_compose_max)
      flag1 = true;
    if ((baseUnit.unit.same_character_id == unit.unit.same_character_id || unit.unit.lucky_compose != 0) && baseUnit.lucky.compose < baseUnit.UnitTypeParameter.lucky_compose_max)
      flag1 = true;
    bool flag2 = false;
    if (baseUnit.unit.ID == unit.unit.ID && (baseUnit.breakthrough_count < baseUnit.unit.breakthrough_limit || baseUnit.lucky.compose < baseUnit.UnitTypeParameter.lucky_compose_max || baseUnit.hp.inheritance < unit.hp.inheritance || baseUnit.strength.inheritance < unit.strength.inheritance || baseUnit.intelligence.inheritance < unit.intelligence.inheritance || baseUnit.vitality.inheritance < unit.vitality.inheritance || baseUnit.agility.inheritance < unit.agility.inheritance || baseUnit.dexterity.inheritance < unit.dexterity.inheritance || baseUnit.mind.inheritance < unit.mind.inheritance || baseUnit.lucky.inheritance < unit.lucky.inheritance))
      flag2 = true;
    bool flag3 = false;
    if (unit.unit.IsBreakThrough && baseUnit.breakthrough_count < baseUnit.unit.breakthrough_limit)
      flag3 = unit.unit.CheckBreakThroughMaterial(baseUnit);
    bool flag4 = UnitDetailIcon.IsSkillUpMaterial(unit, baseUnit);
    if (unit.unit.IsBuildup)
    {
      int num;
      flag4 = (num = 0) != 0;
      flag3 = num != 0;
      flag2 = num != 0;
      flag1 = num != 0;
      isSkill = num != 0;
    }
    return isSkill || flag1 || flag2 || flag3 || flag4;
  }

  protected void CreateSelectIconInfo(PlayerUnit[] selectUnits, bool updateFirst = true)
  {
    this.selectedUnitIcons.Clear();
    int num = 0;
    foreach (PlayerUnit selectUnit in selectUnits)
    {
      PlayerUnit x = selectUnit;
      UnitIconInfo unitIconInfo = this.allUnitInfos.FirstOrDefault<UnitIconInfo>((Func<UnitIconInfo, bool>) (y => y.playerUnit.id == x.id && !y.playerUnit.favorite));
      if (unitIconInfo != null)
      {
        this.selectedUnitIcons.Add(unitIconInfo);
        unitIconInfo.select = num;
        unitIconInfo.gray = true;
        ++num;
      }
    }
    this.selectedUnitIcons = this.selectedUnitIcons.OrderBy<UnitIconInfo, int>((Func<UnitIconInfo, int>) (ui => ui.select)).ToList<UnitIconInfo>();
    if (!updateFirst)
      return;
    this.firstSelectedUnitIcons = new List<UnitIconInfo>((IEnumerable<UnitIconInfo>) this.selectedUnitIcons);
  }

  [DebuggerHidden]
  public IEnumerator UpdateInfoAndScrollExtend(
    PlayerUnit[] playerUnits,
    PlayerUnit[] materialUnits,
    bool updateFirst = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Menu.\u003CUpdateInfoAndScrollExtend\u003Ec__Iterator2D9()
    {
      playerUnits = playerUnits,
      materialUnits = materialUnits,
      updateFirst = updateFirst,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EmaterialUnits = materialUnits,
      \u003C\u0024\u003EupdateFirst = updateFirst,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator Initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Menu.\u003CInitialize\u003Ec__Iterator2DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(
    Player player,
    PlayerUnit basePlayerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit[] selectUnits,
    PlayerDeck[] playerDeck,
    bool isEquip,
    int selMax)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00486Menu.\u003CInit\u003Ec__Iterator2DB()
    {
      player = player,
      basePlayerUnit = basePlayerUnit,
      playerUnits = playerUnits,
      selMax = selMax,
      isEquip = isEquip,
      playerDeck = playerDeck,
      selectUnits = selectUnits,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EselMax = selMax,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003EplayerDeck = playerDeck,
      \u003C\u0024\u003EselectUnits = selectUnits,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void returnScene(List<UnitIconInfo> list, PlayerUnit _basePlayerUnit)
  {
    PlayerUnit[] array = list.Where<UnitIconInfo>((Func<UnitIconInfo, bool>) (z => !z.playerUnit.favorite)).Select<UnitIconInfo, PlayerUnit>((Func<UnitIconInfo, PlayerUnit>) (x => x.playerUnit)).ToArray<PlayerUnit>();
    Unit00484Scene.changeScene(false, _basePlayerUnit, array, Unit00468Scene.Mode.Unit0048);
    Singleton<NGSceneManager>.GetInstance().destroyScene("unit004_8_6");
  }

  public override void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.returnScene(this.firstSelectedUnitIcons, this.baseUnit);
  }

  public virtual void IbtnClear() => this.IbtnClearS();

  public virtual void IbtnEnter()
  {
    if (this.IsPushAndSet())
      return;
    this.returnScene(this.selectedUnitIcons, this.baseUnit);
  }

  public override void onBackButton() => this.IbtnBack();
}
