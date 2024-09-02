// Decompiled with JetBrains decompiler
// Type: Unit00499Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit00499Menu : BackButtonMenuBase
{
  private Dictionary<int, Unit00499Menu.EvolutionSelectMap> dicSelector_;
  [SerializeField]
  protected UILabel TxtHpBefore;
  [SerializeField]
  protected UILabel TxtHpAfter;
  [SerializeField]
  protected UILabel TxtJobnameBefore;
  [SerializeField]
  protected UILabel TxtJobnameAfter;
  [SerializeField]
  protected UILabel TxtLuckyBefore;
  [SerializeField]
  protected UILabel TxtLuckyAfter;
  [SerializeField]
  protected UILabel TxtLvBefore;
  [SerializeField]
  protected UILabel TxtLvAfter;
  [SerializeField]
  protected UILabel TxtLvmaxBefore;
  [SerializeField]
  protected UILabel TxtLvmaxAfter;
  [SerializeField]
  protected UILabel TxtMagicBefore;
  [SerializeField]
  protected UILabel TxtMagicAfter;
  [SerializeField]
  protected UILabel TxtPowerBefore;
  [SerializeField]
  protected UILabel TxtPowerAfter;
  [SerializeField]
  protected UILabel TxtPrincesstypeBefore;
  [SerializeField]
  protected UILabel TxtPrincesstypeAfter;
  [SerializeField]
  protected UILabel TxtProtectBefore;
  [SerializeField]
  protected UILabel TxtProtectAfter;
  [SerializeField]
  protected UILabel TxtSpeedBefore;
  [SerializeField]
  protected UILabel TxtSpeedAfter;
  [SerializeField]
  protected UILabel TxtSpiritBefore;
  [SerializeField]
  protected UILabel TxtSpiritAfter;
  [SerializeField]
  protected UILabel TxtTechniqueBefore;
  [SerializeField]
  protected UILabel TxtTechniqueAfter;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtCostBefore;
  [SerializeField]
  protected UILabel TxtCostAfter;
  [SerializeField]
  protected GameObject hpStatusMaxStar;
  [SerializeField]
  protected GameObject powerStatusMaxStar;
  [SerializeField]
  protected GameObject magicStatusMaxStar;
  [SerializeField]
  protected GameObject protectStatusMaxStar;
  [SerializeField]
  protected GameObject spiritStatusMaxStar;
  [SerializeField]
  protected GameObject speedStatusMaxStar;
  [SerializeField]
  protected GameObject techniqueStatusMaxStar;
  [SerializeField]
  protected GameObject luckyStatusMaxStar;
  [SerializeField]
  protected GameObject afterHpStatusMaxStar;
  [SerializeField]
  protected GameObject afterPowerStatusMaxStar;
  [SerializeField]
  protected GameObject afterMagicStatusMaxStar;
  [SerializeField]
  protected GameObject afterProtectStatusMaxStar;
  [SerializeField]
  protected GameObject afterSpiritStatusMaxStar;
  [SerializeField]
  protected GameObject afterSpeedStatusMaxStar;
  [SerializeField]
  protected GameObject afterTechniqueStatusMaxStar;
  [SerializeField]
  protected GameObject afterLuckyStatusMaxStar;
  [SerializeField]
  protected UILabel TxtTransZeny;
  [SerializeField]
  protected GameObject DialogBox;
  [SerializeField]
  protected UILabel TxtMaterialName;
  [SerializeField]
  protected UILabel TxtMaterialPlace;
  [SerializeField]
  protected GameObject[] TransUpParameter;
  public GameObject DirTransmigration;
  public GameObject comShortage;
  public GameObject[] comShortages;
  public GameObject[] linkEvolutionUnits;
  public UILabel[] linkTransUnitsPossessionLabel;
  public GameObject[] linkTransUnits;
  public GameObject linkBeforeUnit;
  public GameObject linkAfterUnit;
  public UIButton evolutionBtn;
  public UIButton transBtn;
  public bool isLevel;
  public Unit00499Evolution evolutionMenu;
  public List<int> materialUnitIds;
  public List<int> materialMaterialUnitIds;
  public int selectEvolutionPatternId;
  protected PlayerUnit baseUnit;
  protected bool isUnit;
  protected bool isMoney;
  protected bool isFavorite;
  private Unit00499Scene.Mode sceneMode;
  private GameObject StatusUpPrefab;

  private static bool isUnitSelectable(UnitUnit unit) => unit.IsNormalUnit;

  private static Unit00499Menu.UnitCondition getUnitCondition(
    PlayerUnit playerUnit,
    PlayerDeck[] decks)
  {
    foreach (PlayerDeck deck in decks)
    {
      if (deck != null)
      {
        foreach (PlayerUnit playerUnit1 in deck.player_units)
        {
          if (!(playerUnit1 == (PlayerUnit) null) && playerUnit1.id == playerUnit.id)
            return Unit00499Menu.UnitCondition.Organized;
        }
      }
    }
    return playerUnit.favorite ? Unit00499Menu.UnitCondition.Favarite : Unit00499Menu.UnitCondition.Normal;
  }

  [DebuggerHidden]
  public IEnumerator InitEvolutionUnits(
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits,
    GameObject unitIconPrefab,
    Unit00499EvolutionIndicator eIndicator,
    int patternId,
    UnitUnit[] evoUnits,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitEvolutionUnits\u003Ec__Iterator3A2()
    {
      eIndicator = eIndicator,
      patternId = patternId,
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      evoUnits = evoUnits,
      unitIconPrefab = unitIconPrefab,
      fromEarth = fromEarth,
      \u003C\u0024\u003EeIndicator = eIndicator,
      \u003C\u0024\u003EpatternId = patternId,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003EevoUnits = evoUnits,
      \u003C\u0024\u003EunitIconPrefab = unitIconPrefab,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  private void setEventMaterialClicked(
    UnitIcon icon,
    LongPressButton toSelect,
    bool fromEarth,
    Unit00499Menu.EvolutionSelectMap selector,
    int column,
    bool canCompleted)
  {
    if (Object.op_Equality((Object) toSelect, (Object) null) || !canCompleted)
    {
      icon.onClick = (Action<UnitIconBase>) (x =>
      {
        if (fromEarth)
          return;
        this.ShowMaterialQuestInfo(x.Unit);
      });
      icon.SetButtonDetailEvent(icon.PlayerUnit, ((IEnumerable<Unit00499Menu.SelectCell>) selector.selected_).Where<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (x => x != null)).Select<Unit00499Menu.SelectCell, PlayerUnit>((Func<Unit00499Menu.SelectCell, PlayerUnit>) (c => c.unit_)).ToArray<PlayerUnit>());
    }
    else
    {
      icon.button.isEnabled = false;
      ((Collider) icon.buttonBoxCollider).enabled = false;
      EventDelegate.Set(toSelect.onClick, (EventDelegate.Callback) (() =>
      {
        if (this.IsPushAndSet())
          return;
        this.doUnitSelector(selector, column);
      }));
      if (icon.PlayerUnit != (PlayerUnit) null)
        EventDelegate.Set(toSelect.onLongPress, (EventDelegate.Callback) (() => Unit0042Scene.changeScene(true, icon.PlayerUnit, ((IEnumerable<Unit00499Menu.SelectCell>) selector.selected_).Where<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (x => x != null)).Select<Unit00499Menu.SelectCell, PlayerUnit>((Func<Unit00499Menu.SelectCell, PlayerUnit>) (c => c.unit_)).ToArray<PlayerUnit>())));
      else
        toSelect.onLongPress.Clear();
    }
  }

  private void doUnitSelector(Unit00499Menu.EvolutionSelectMap selector, int column)
  {
    UnitUnit sample = selector.samples_[column];
    Unit00492Menu.Param param = new Unit00492Menu.Param()
    {
      baseUnit_ = selector.selected_[column] == null ? (PlayerUnit) null : selector.selected_[column].unit_
    };
    param.selectedUnits_ = ((IEnumerable<Unit00499Menu.SelectCell>) selector.selected_).Where<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (c => c != null && (param.baseUnit_ == (PlayerUnit) null || param.baseUnit_.id != c.unit_.id) && c.unit_.unit.ID == sample.ID)).Select<Unit00499Menu.SelectCell, PlayerUnit>((Func<Unit00499Menu.SelectCell, PlayerUnit>) (cc => cc.unit_)).ToArray<PlayerUnit>();
    param.units_ = ((IEnumerable<Unit00499Menu.SelectCell>) selector.sources_[sample.ID]).Select<Unit00499Menu.SelectCell, PlayerUnit>((Func<Unit00499Menu.SelectCell, PlayerUnit>) (c => c.unit_)).ToArray<PlayerUnit>();
    param.onUpdate_ = (Unit00492Menu.Param.EventUpdateUnit) (unit =>
    {
      Unit00499Menu.SelectCell selectCell = ((IEnumerable<Unit00499Menu.SelectCell>) selector.selected_).FirstOrDefault<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (c => c != null && c.unit_.id == unit.id));
      if (selectCell == null)
        return;
      PlayerDeck[] decks = SMManager.Get<PlayerDeck[]>();
      if (Unit00499Menu.getUnitCondition(unit, decks) == Unit00499Menu.UnitCondition.Normal)
        return;
      selector.setUnselected(selectCell.column_);
    });
    param.onResult_ = (Unit00492Menu.Param.EventResult) (result =>
    {
      if (result == (PlayerUnit) null || param.baseUnit_ != (PlayerUnit) null && param.baseUnit_.id == result.id)
        return;
      selector.setSelected(((IEnumerable<Unit00499Menu.SelectCell>) selector.sources_[sample.ID]).First<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (c => c.unit_.id == result.id)), column);
    });
    Unit00468Scene.changeScene00492EvolutionMaterial(true, param);
  }

  public void updateCheckEnableButton(int patternId)
  {
    this.isUnit = this.dicSelector_ != null && this.dicSelector_.ContainsKey(patternId) && this.dicSelector_[patternId].isCompletedSelect;
    this.isFavorite = true;
  }

  public List<int> getEvolutionMaterialSelectedUnitIds(int patternId)
  {
    return this.dicSelector_ != null && this.dicSelector_.ContainsKey(patternId) ? ((IEnumerable<Unit00499Menu.SelectCell>) this.dicSelector_[patternId].selected_).Where<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (c => c != null && c.unit_.unit.IsNormalUnit)).Select<Unit00499Menu.SelectCell, int>((Func<Unit00499Menu.SelectCell, int>) (cc => cc.unit_.id)).ToList<int>() : new List<int>();
  }

  public List<int> getEvolutionMaterialSelectedMaterialIds(int patternId)
  {
    return this.dicSelector_ != null && this.dicSelector_.ContainsKey(patternId) ? ((IEnumerable<Unit00499Menu.SelectCell>) this.dicSelector_[patternId].selected_).Where<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (c => c != null && c.unit_.unit.IsMaterialUnit)).Select<Unit00499Menu.SelectCell, int>((Func<Unit00499Menu.SelectCell, int>) (cc => cc.unit_.id)).ToList<int>() : new List<int>();
  }

  [DebuggerHidden]
  private IEnumerator ShowTransmigrationPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CShowTransmigrationPopup\u003Ec__Iterator3A3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Transmigration()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CTransmigration\u003Ec__Iterator3A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator Evolution()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CEvolution\u003Ec__Iterator3A5()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void InitNumber(
    int v1,
    int v2,
    bool isNormalUnit1,
    bool isNormalUnit2,
    UILabel source,
    UILabel target)
  {
    Action<string, UILabel> action = (Action<string, UILabel>) ((v, label) =>
    {
      label.SetTextLocalize(v);
      ((Component) label).gameObject.SetActive(true);
    });
    action(!isNormalUnit1 ? "---" : v1.ToString(), source);
    if (!isNormalUnit1)
      source.color = Color.white;
    action(!isNormalUnit2 ? "---" : v2.ToString(), target);
    if (isNormalUnit2)
      return;
    target.color = Color.white;
  }

  protected void setStatusMaxStar(GameObject go, bool isDisp) => go.SetActive(isDisp);

  [DebuggerHidden]
  public IEnumerator InitPlayer(
    PlayerUnit playerUnit,
    PlayerUnit targetPlayerUnit,
    GameObject unitIconPrefab,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitPlayer\u003Ec__Iterator3A6()
    {
      unitIconPrefab = unitIconPrefab,
      playerUnit = playerUnit,
      targetPlayerUnit = targetPlayerUnit,
      fromEarth = fromEarth,
      \u003C\u0024\u003EunitIconPrefab = unitIconPrefab,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EtargetPlayerUnit = targetPlayerUnit,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void SetStatusText(PlayerUnit playerUnit, PlayerUnit targetPlayerUnit)
  {
    this.InitNumber(playerUnit.total_hp, targetPlayerUnit.total_hp, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtHpBefore, this.TxtHpAfter);
    this.InitNumber(playerUnit.total_strength, targetPlayerUnit.total_strength, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtPowerBefore, this.TxtPowerAfter);
    this.InitNumber(playerUnit.total_intelligence, targetPlayerUnit.total_intelligence, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtMagicBefore, this.TxtMagicAfter);
    this.InitNumber(playerUnit.total_vitality, targetPlayerUnit.total_vitality, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtProtectBefore, this.TxtProtectAfter);
    this.InitNumber(playerUnit.total_mind, targetPlayerUnit.total_mind, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtSpiritBefore, this.TxtSpiritAfter);
    this.InitNumber(playerUnit.total_agility, targetPlayerUnit.total_agility, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtSpeedBefore, this.TxtSpeedAfter);
    this.InitNumber(playerUnit.total_dexterity, targetPlayerUnit.total_dexterity, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtTechniqueBefore, this.TxtTechniqueAfter);
    this.InitNumber(playerUnit.total_lucky, targetPlayerUnit.total_lucky, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtLuckyBefore, this.TxtLuckyAfter);
    this.InitNumber(playerUnit.level, targetPlayerUnit.level, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtLvBefore, this.TxtLvAfter);
    this.InitNumber(playerUnit.max_level, targetPlayerUnit.max_level, playerUnit.unit.IsNormalUnit, targetPlayerUnit.unit.IsNormalUnit, this.TxtLvmaxBefore, this.TxtLvmaxAfter);
    if (playerUnit.unit.IsNormalUnit)
    {
      this.setStatusMaxStar(this.hpStatusMaxStar, playerUnit.hp.is_max);
      this.setStatusMaxStar(this.powerStatusMaxStar, playerUnit.strength.is_max);
      this.setStatusMaxStar(this.magicStatusMaxStar, playerUnit.intelligence.is_max);
      this.setStatusMaxStar(this.protectStatusMaxStar, playerUnit.vitality.is_max);
      this.setStatusMaxStar(this.spiritStatusMaxStar, playerUnit.mind.is_max);
      this.setStatusMaxStar(this.speedStatusMaxStar, playerUnit.agility.is_max);
      this.setStatusMaxStar(this.techniqueStatusMaxStar, playerUnit.dexterity.is_max);
      this.setStatusMaxStar(this.luckyStatusMaxStar, playerUnit.lucky.is_max);
    }
    else
    {
      this.setStatusMaxStar(this.hpStatusMaxStar, false);
      this.setStatusMaxStar(this.powerStatusMaxStar, false);
      this.setStatusMaxStar(this.magicStatusMaxStar, false);
      this.setStatusMaxStar(this.protectStatusMaxStar, false);
      this.setStatusMaxStar(this.spiritStatusMaxStar, false);
      this.setStatusMaxStar(this.speedStatusMaxStar, false);
      this.setStatusMaxStar(this.techniqueStatusMaxStar, false);
      this.setStatusMaxStar(this.luckyStatusMaxStar, false);
    }
    if (targetPlayerUnit.unit.IsNormalUnit)
    {
      this.setStatusMaxStar(this.afterHpStatusMaxStar, targetPlayerUnit.hp.is_max);
      this.setStatusMaxStar(this.afterPowerStatusMaxStar, targetPlayerUnit.strength.is_max);
      this.setStatusMaxStar(this.afterMagicStatusMaxStar, targetPlayerUnit.intelligence.is_max);
      this.setStatusMaxStar(this.afterProtectStatusMaxStar, targetPlayerUnit.vitality.is_max);
      this.setStatusMaxStar(this.afterSpiritStatusMaxStar, targetPlayerUnit.mind.is_max);
      this.setStatusMaxStar(this.afterSpeedStatusMaxStar, targetPlayerUnit.agility.is_max);
      this.setStatusMaxStar(this.afterTechniqueStatusMaxStar, targetPlayerUnit.dexterity.is_max);
      this.setStatusMaxStar(this.afterLuckyStatusMaxStar, targetPlayerUnit.lucky.is_max);
    }
    else
    {
      this.setStatusMaxStar(this.afterHpStatusMaxStar, false);
      this.setStatusMaxStar(this.afterPowerStatusMaxStar, false);
      this.setStatusMaxStar(this.afterMagicStatusMaxStar, false);
      this.setStatusMaxStar(this.afterProtectStatusMaxStar, false);
      this.setStatusMaxStar(this.afterSpiritStatusMaxStar, false);
      this.setStatusMaxStar(this.afterSpeedStatusMaxStar, false);
      this.setStatusMaxStar(this.afterTechniqueStatusMaxStar, false);
      this.setStatusMaxStar(this.luckyStatusMaxStar, false);
    }
    this.TxtPrincesstypeBefore.SetTextLocalize(playerUnit.unit_type.name);
    this.TxtPrincesstypeAfter.SetTextLocalize(targetPlayerUnit.unit_type.name);
    this.TxtCostBefore.SetTextLocalize(playerUnit.unit.cost);
    this.TxtCostAfter.SetTextLocalize(targetPlayerUnit.unit.cost);
    this.TxtJobnameBefore.SetTextLocalize(playerUnit.unit.job.name);
    this.TxtJobnameAfter.SetTextLocalize(targetPlayerUnit.unit.job.name);
  }

  [DebuggerHidden]
  private IEnumerator InitUnitIcon(
    UnitIcon unitIcon,
    PlayerUnit unit,
    PlayerUnit[] units,
    bool before,
    bool fromEarth)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitUnitIcon\u003Ec__Iterator3A7()
    {
      before = before,
      unitIcon = unitIcon,
      unit = unit,
      units = units,
      fromEarth = fromEarth,
      \u003C\u0024\u003Ebefore = before,
      \u003C\u0024\u003EunitIcon = unitIcon,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eunits = units,
      \u003C\u0024\u003EfromEarth = fromEarth
    };
  }

  [DebuggerHidden]
  public IEnumerator InitTransmigrationUnits(
    PlayerUnit[] playerUnits,
    PlayerMaterialUnit[] playerMaterialUnits,
    GameObject unitIconPrefab,
    UILabel[] label,
    GameObject[] objects,
    UnitUnit[] evoUnits,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitTransmigrationUnits\u003Ec__Iterator3A8()
    {
      playerUnits = playerUnits,
      playerMaterialUnits = playerMaterialUnits,
      objects = objects,
      evoUnits = evoUnits,
      unitIconPrefab = unitIconPrefab,
      label = label,
      fromEarth = fromEarth,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EplayerMaterialUnits = playerMaterialUnits,
      \u003C\u0024\u003Eobjects = objects,
      \u003C\u0024\u003EevoUnits = evoUnits,
      \u003C\u0024\u003EunitIconPrefab = unitIconPrefab,
      \u003C\u0024\u003Elabel = label,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitTitle(string titleText)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitTitle\u003Ec__Iterator3A9()
    {
      titleText = titleText,
      \u003C\u0024\u003EtitleText = titleText,
      \u003C\u003Ef__this = this
    };
  }

  public List<int> GetMaterialUnitIDS(PlayerUnit baseUnit, PlayerUnit[] units, UnitUnit[] evo)
  {
    List<int> list = new List<int>();
    ((IEnumerable<UnitUnit>) evo).ForEach<UnitUnit>((Action<UnitUnit>) (x =>
    {
      if (!x.IsNormalUnit)
        return;
      foreach (PlayerUnit playerUnit in (IEnumerable<PlayerUnit>) ((IEnumerable<PlayerUnit>) units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (y => x.ID == y.unit.ID)).OrderBy<PlayerUnit, int>((Func<PlayerUnit, int>) (y => y.level)))
      {
        if ((playerUnit.id != baseUnit.id || !baseUnit.unit.IsNormalUnit) && !list.Contains(playerUnit.id))
        {
          list.Add(playerUnit.id);
          break;
        }
      }
    }));
    return list;
  }

  public List<int> GetMaterialMaterialUnitIDS(
    PlayerUnit baseUnit,
    PlayerMaterialUnit[] materialUnits,
    UnitUnit[] evo)
  {
    List<int> list = new List<int>();
    ((IEnumerable<UnitUnit>) evo).ForEach<UnitUnit>((Action<UnitUnit>) (x =>
    {
      if (!x.IsMaterialUnit)
        return;
      IEnumerable<PlayerMaterialUnit> playerMaterialUnits = ((IEnumerable<PlayerMaterialUnit>) materialUnits).Where<PlayerMaterialUnit>((Func<PlayerMaterialUnit, bool>) (y => x.ID == y.unit.ID));
      foreach (PlayerMaterialUnit playerMaterialUnit in playerMaterialUnits)
      {
        PlayerMaterialUnit z = playerMaterialUnit;
        if (list.Count<int>((Func<int, bool>) (w => w == z.id)) + (z.id != baseUnit.id || !baseUnit.unit.IsMaterialUnit ? 0 : 1) <= z.quantity)
        {
          list.Add(z.id);
          break;
        }
      }
    }));
    return list;
  }

  private void SetTransUpStatus(GameObject dst, GameObject go, int value)
  {
    dst.transform.Clear();
    dst.SetActive(false);
    if (value <= 0)
      return;
    dst.SetActive(true);
    go.CloneAndGetComponent<UnitTransAddStatus>(dst.transform).Init(value);
  }

  [DebuggerHidden]
  public IEnumerator Init(
    PlayerUnit playerUnit,
    PlayerUnit[] targetPlayerUnits,
    Unit00499Scene.Mode sceneMode,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInit\u003Ec__Iterator3AA()
    {
      sceneMode = sceneMode,
      playerUnit = playerUnit,
      fromEarth = fromEarth,
      targetPlayerUnits = targetPlayerUnits,
      \u003C\u0024\u003EsceneMode = sceneMode,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EfromEarth = fromEarth,
      \u003C\u0024\u003EtargetPlayerUnits = targetPlayerUnits,
      \u003C\u003Ef__this = this
    };
  }

  public virtual bool CheckEnabledButton(int money)
  {
    this.comShortage.SetActive(false);
    bool flag = false;
    Player player = SMManager.Get<Player>();
    if (money > player.money)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(0);
      this.isMoney = false;
    }
    if (!this.isUnit)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(1);
    }
    if (!this.isLevel)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(2);
    }
    if (!this.isFavorite)
    {
      flag = true;
      ((IEnumerable<GameObject>) this.comShortages).ToggleOnce(3);
    }
    this.comShortage.SetActive(flag);
    return (!this.isMoney || !this.isUnit || !this.isLevel ? 1 : (!this.isFavorite ? 1 : 0)) == 0;
  }

  private void ShowMaterialQuestInfo(UnitUnit materail)
  {
    bool flag = !this.DialogBox.activeInHierarchy;
    this.DialogBox.SetActive(true);
    if (flag)
    {
      UITweener[] tweeners = NGTween.findTweeners(this.DialogBox, true);
      NGTween.playTweens(tweeners, NGTween.Kind.START_END);
      NGTween.playTweens(tweeners, NGTween.Kind.START);
      foreach (UITweener uiTweener in tweeners)
        uiTweener.onFinished.Clear();
    }
    this.TxtMaterialName.SetText(materail.name);
    UnitMaterialQuestInfo materialQuestInfo = ((IEnumerable<UnitMaterialQuestInfo>) MasterData.UnitMaterialQuestInfoList).SingleOrDefault<UnitMaterialQuestInfo>((Func<UnitMaterialQuestInfo, bool>) (x => x.unit_id == materail.ID));
    if (materialQuestInfo == null)
      this.TxtMaterialPlace.SetText(string.Empty);
    else
      this.TxtMaterialPlace.SetText(materialQuestInfo.long_desc);
  }

  public UITweener[] EndTweensMaterialQuestInfo(bool isForce = false)
  {
    if (!this.DialogBox.activeInHierarchy)
      return (UITweener[]) null;
    UITweener[] tweeners = NGTween.findTweeners(this.DialogBox, true);
    if (!isForce && ((IEnumerable<UITweener>) tweeners).Any<UITweener>((Func<UITweener, bool>) (x => ((Behaviour) x).enabled)))
      return (UITweener[]) null;
    NGTween.playTweens(tweeners, NGTween.Kind.START_END, true);
    NGTween.playTweens(tweeners, NGTween.Kind.END);
    return tweeners;
  }

  public void HideMaterialQuestInfo()
  {
    UITweener[] tweens = this.EndTweensMaterialQuestInfo();
    if (tweens == null)
      return;
    NGTween.setOnTweenFinished(tweens, (MonoBehaviour) this, "HideDialogBox");
  }

  private void HideDialogBox() => this.DialogBox.SetActive(false);

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnCom()
  {
    if (!this.isUnit || !this.isMoney || !this.isLevel || !this.isFavorite || this.evolutionMenu.isMovingIndicator || this.IsPushAndSet())
      return;
    Consts instance = Consts.GetInstance();
    this.StartCoroutine(this.confirmExecute(instance.unit_004_9_9_confirm_evolution_title, instance.unit_004_9_9_confirm_evolution_message, this.selectEvolutionPatternId, this.Evolution()));
  }

  [DebuggerHidden]
  private IEnumerator confirmExecute(
    string title,
    string message,
    int currentPatternId,
    IEnumerator execute)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CconfirmExecute\u003Ec__Iterator3AB()
    {
      title = title,
      message = message,
      currentPatternId = currentPatternId,
      execute = execute,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Emessage = message,
      \u003C\u0024\u003EcurrentPatternId = currentPatternId,
      \u003C\u0024\u003Eexecute = execute,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnTrans()
  {
    if (this.IsPush || !this.isUnit || !this.isMoney || !this.isLevel || !this.isFavorite)
      return;
    this.StartCoroutine(this.ShowTransmigrationPopup());
  }

  private enum UnitCondition
  {
    Normal,
    Selected,
    Favarite,
    Organized,
  }

  private class SelectCell
  {
    public SelectCell(PlayerUnit unit, int id, Unit00499Menu.UnitCondition uc = Unit00499Menu.UnitCondition.Normal)
    {
      this.unit_ = unit;
      this.id_ = id;
      this.condition_ = uc;
      this.column_ = -1;
    }

    public PlayerUnit unit_ { get; private set; }

    public void setUnit(PlayerUnit u) => this.unit_ = u;

    public int id_ { get; private set; }

    public Unit00499Menu.UnitCondition condition_ { get; private set; }

    public void setCondition(Unit00499Menu.UnitCondition uc) => this.condition_ = uc;

    public bool isSelectable => this.condition_ == Unit00499Menu.UnitCondition.Normal;

    public int column_ { get; private set; }

    public void setColumn(int column = -1)
    {
      this.column_ = column;
      if (column >= 0)
      {
        this.condition_ = Unit00499Menu.UnitCondition.Selected;
      }
      else
      {
        if (this.condition_ != Unit00499Menu.UnitCondition.Selected)
          return;
        this.condition_ = Unit00499Menu.UnitCondition.Normal;
      }
    }
  }

  private class EvolutionSelectMap
  {
    private Dictionary<int, bool> dicSelectable_;

    public UnitUnit[] samples_ { get; private set; }

    public Dictionary<int, Unit00499Menu.SelectCell[]> sources_ { get; private set; }

    public Unit00499Menu.SelectCell[] selected_ { get; private set; }

    public int selectedCount_ { get; private set; }

    public bool isCompletedSelect => this.selectedCount_ == this.selected_.Length;

    public bool isSelectable(int id) => this.dicSelectable_[id];

    public static Unit00499Menu.EvolutionSelectMap create(
      PlayerUnit baseUnit,
      PlayerUnit[] playerunits,
      PlayerMaterialUnit[] materials,
      UnitUnit[] evosamples)
    {
      if (baseUnit == (PlayerUnit) null || playerunits == null || playerunits.Length == 0 || evosamples == null || evosamples.Length == 0)
        return (Unit00499Menu.EvolutionSelectMap) null;
      Unit00499Menu.EvolutionSelectMap evolutionSelectMap = new Unit00499Menu.EvolutionSelectMap();
      evolutionSelectMap.samples_ = evosamples;
      evolutionSelectMap.selectedCount_ = 0;
      int length = evosamples.Length;
      evolutionSelectMap.selected_ = new Unit00499Menu.SelectCell[length];
      List<int> list = ((IEnumerable<UnitUnit>) evosamples).Select<UnitUnit, int>((Func<UnitUnit, int>) (s => s.ID)).Distinct<int>().ToList<int>();
      Dictionary<int, List<Unit00499Menu.SelectCell>> dictionary = list.ToDictionary<int, int, List<Unit00499Menu.SelectCell>>((Func<int, int>) (k => k), (Func<int, List<Unit00499Menu.SelectCell>>) (k => new List<Unit00499Menu.SelectCell>()));
      evolutionSelectMap.dicSelectable_ = list.ToDictionary<int, int, bool>((Func<int, int>) (k => k), (Func<int, bool>) (k => false));
      int num1 = 1;
      PlayerDeck[] decks = SMManager.Get<PlayerDeck[]>();
      foreach (PlayerUnit playerunit in playerunits)
      {
        List<Unit00499Menu.SelectCell> selectCellList;
        if (baseUnit.id != playerunit.id && dictionary.TryGetValue(playerunit.unit.ID, out selectCellList))
          selectCellList.Add(new Unit00499Menu.SelectCell(playerunit, num1++, Unit00499Menu.getUnitCondition(playerunit, decks)));
      }
      foreach (List<Unit00499Menu.SelectCell> source in dictionary.Values)
      {
        if (source.Any<Unit00499Menu.SelectCell>())
        {
          UnitUnit unit = source.First<Unit00499Menu.SelectCell>().unit_.unit;
          evolutionSelectMap.dicSelectable_[unit.ID] = Unit00499Menu.isUnitSelectable(unit);
        }
      }
      foreach (PlayerMaterialUnit material in materials)
      {
        List<Unit00499Menu.SelectCell> selectCellList;
        if (dictionary.TryGetValue(material.unit.ID, out selectCellList))
        {
          int num2 = material.quantity - (material.id != baseUnit.id ? 0 : 1);
          for (int count = 0; count < num2 && count < length; ++count)
            selectCellList.Add(new Unit00499Menu.SelectCell(PlayerUnit.CreateByPlayerMaterialUnit(material, count), num1++));
        }
      }
      evolutionSelectMap.sources_ = dictionary.ToDictionary<KeyValuePair<int, List<Unit00499Menu.SelectCell>>, int, Unit00499Menu.SelectCell[]>((Func<KeyValuePair<int, List<Unit00499Menu.SelectCell>>, int>) (k => k.Key), (Func<KeyValuePair<int, List<Unit00499Menu.SelectCell>>, Unit00499Menu.SelectCell[]>) (k => k.Value.ToArray()));
      return evolutionSelectMap;
    }

    public void selectAuto(bool ignoreSelectable = true)
    {
      for (int column = 0; column < this.samples_.Length; ++column)
      {
        UnitUnit sample = this.samples_[column];
        if (!ignoreSelectable || !this.isSelectable(sample.ID))
        {
          Unit00499Menu.SelectCell cell = ((IEnumerable<Unit00499Menu.SelectCell>) this.sources_[sample.ID]).FirstOrDefault<Unit00499Menu.SelectCell>((Func<Unit00499Menu.SelectCell, bool>) (s => s.isSelectable));
          if (cell != null)
            this.setSelected(cell, column);
        }
      }
    }

    public void setSelected(Unit00499Menu.SelectCell cell, int column)
    {
      if (cell == null)
      {
        this.setUnselected(column);
      }
      else
      {
        if (cell.column_ == column)
          return;
        this.setUnselected(cell);
        if (column < 0 || column >= this.selected_.Length)
          return;
        this.setUnselected(column);
        this.selected_[column] = cell;
        cell.setColumn(column);
        ++this.selectedCount_;
      }
    }

    public void setUnselected(Unit00499Menu.SelectCell cell) => this.setUnselected(cell.column_);

    public void setUnselected(int column)
    {
      if (column < 0 || column >= this.selected_.Length || this.selected_[column] == null)
        return;
      Unit00499Menu.SelectCell selectCell = this.selected_[column];
      this.selected_[column] = (Unit00499Menu.SelectCell) null;
      selectCell.setColumn();
      --this.selectedCount_;
    }

    public bool[] trySelecting()
    {
      bool[] flagArray = new bool[this.samples_.Length];
      Dictionary<int, Queue<PlayerUnit>> dictionary = new Dictionary<int, Queue<PlayerUnit>>();
      foreach (KeyValuePair<int, Unit00499Menu.SelectCell[]> source in this.sources_)
      {
        Queue<PlayerUnit> playerUnitQueue = new Queue<PlayerUnit>();
        foreach (Unit00499Menu.SelectCell selectCell in source.Value)
          playerUnitQueue.Enqueue(selectCell.unit_);
        dictionary.Add(source.Key, playerUnitQueue);
      }
      for (int index = 0; index < this.samples_.Length; ++index)
      {
        Queue<PlayerUnit> playerUnitQueue = dictionary[this.samples_[index].ID];
        flagArray[index] = playerUnitQueue.Count > 0;
        if (flagArray[index])
          playerUnitQueue.Dequeue();
      }
      return flagArray;
    }

    public bool updateNormalUnit(PlayerUnit[] playerUnits)
    {
      bool flag = false;
      PlayerDeck[] decks = SMManager.Get<PlayerDeck[]>();
      foreach (Unit00499Menu.SelectCell[] source in this.sources_.Values)
      {
        if (source.Length != 0 && ((IEnumerable<Unit00499Menu.SelectCell>) source).First<Unit00499Menu.SelectCell>().unit_.unit.IsNormalUnit)
        {
          foreach (Unit00499Menu.SelectCell selectCell in source)
          {
            Unit00499Menu.SelectCell ic = selectCell;
            ic.setUnit(((IEnumerable<PlayerUnit>) playerUnits).First<PlayerUnit>((Func<PlayerUnit, bool>) (pu => pu.id == ic.unit_.id)));
            Unit00499Menu.UnitCondition unitCondition = Unit00499Menu.getUnitCondition(ic.unit_, decks);
            if (ic.condition_ != unitCondition)
            {
              if (ic.condition_ == Unit00499Menu.UnitCondition.Selected)
              {
                if (unitCondition == Unit00499Menu.UnitCondition.Favarite || unitCondition == Unit00499Menu.UnitCondition.Organized)
                {
                  this.setUnselected(ic.column_);
                  ic.setCondition(unitCondition);
                  flag = true;
                }
              }
              else
              {
                ic.setCondition(unitCondition);
                flag = true;
              }
            }
          }
        }
      }
      return flag;
    }
  }

  private enum TransBonusIndex
  {
    HP,
    ATK,
    MAG,
    DEF,
    MEN,
    SPD,
    TEC,
    LUC,
    MAX,
  }
}
