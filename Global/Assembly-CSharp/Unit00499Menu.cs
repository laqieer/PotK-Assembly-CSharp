// Decompiled with JetBrains decompiler
// Type: Unit00499Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public int selectEvolutionPatturnId;
  protected PlayerUnit baseUnit;
  protected bool isUnit;
  protected bool isMoney;
  protected bool isFavorite;
  private Unit00499Scene.Mode sceneMode;
  private GameObject StatusUpPrefab;

  [DebuggerHidden]
  private IEnumerator ShowTransmigrationPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CShowTransmigrationPopup\u003Ec__Iterator2F5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Transmigration()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CTransmigration\u003Ec__Iterator2F6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator Evolution()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CEvolution\u003Ec__Iterator2F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void InitNumber(int v1, int v2, UILabel source, UILabel target)
  {
    Action<int, UILabel> action = (Action<int, UILabel>) ((v, label) =>
    {
      label.SetTextLocalize(v.ToString());
      ((Component) label).gameObject.SetActive(true);
    });
    action(v1, source);
    action(v2, target);
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
    return (IEnumerator) new Unit00499Menu.\u003CInitPlayer\u003Ec__Iterator2F8()
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
    this.InitNumber(playerUnit.total_hp, targetPlayerUnit.total_hp, this.TxtHpBefore, this.TxtHpAfter);
    this.InitNumber(playerUnit.total_strength, targetPlayerUnit.total_strength, this.TxtPowerBefore, this.TxtPowerAfter);
    this.InitNumber(playerUnit.total_intelligence, targetPlayerUnit.total_intelligence, this.TxtMagicBefore, this.TxtMagicAfter);
    this.InitNumber(playerUnit.total_vitality, targetPlayerUnit.total_vitality, this.TxtProtectBefore, this.TxtProtectAfter);
    this.InitNumber(playerUnit.total_mind, targetPlayerUnit.total_mind, this.TxtSpiritBefore, this.TxtSpiritAfter);
    this.InitNumber(playerUnit.total_agility, targetPlayerUnit.total_agility, this.TxtSpeedBefore, this.TxtSpeedAfter);
    this.InitNumber(playerUnit.total_dexterity, targetPlayerUnit.total_dexterity, this.TxtTechniqueBefore, this.TxtTechniqueAfter);
    this.InitNumber(playerUnit.total_lucky, targetPlayerUnit.total_lucky, this.TxtLuckyBefore, this.TxtLuckyAfter);
    this.InitNumber(playerUnit.level, targetPlayerUnit.level, this.TxtLvBefore, this.TxtLvAfter);
    this.InitNumber(playerUnit.max_level, targetPlayerUnit.max_level, this.TxtLvmaxBefore, this.TxtLvmaxAfter);
    this.setStatusMaxStar(this.hpStatusMaxStar, playerUnit.hp.is_max);
    this.setStatusMaxStar(this.powerStatusMaxStar, playerUnit.strength.is_max);
    this.setStatusMaxStar(this.magicStatusMaxStar, playerUnit.intelligence.is_max);
    this.setStatusMaxStar(this.protectStatusMaxStar, playerUnit.vitality.is_max);
    this.setStatusMaxStar(this.spiritStatusMaxStar, playerUnit.mind.is_max);
    this.setStatusMaxStar(this.speedStatusMaxStar, playerUnit.agility.is_max);
    this.setStatusMaxStar(this.techniqueStatusMaxStar, playerUnit.dexterity.is_max);
    this.setStatusMaxStar(this.luckyStatusMaxStar, playerUnit.lucky.is_max);
    this.setStatusMaxStar(this.afterHpStatusMaxStar, targetPlayerUnit.hp.is_max);
    this.setStatusMaxStar(this.afterPowerStatusMaxStar, targetPlayerUnit.strength.is_max);
    this.setStatusMaxStar(this.afterMagicStatusMaxStar, targetPlayerUnit.intelligence.is_max);
    this.setStatusMaxStar(this.afterProtectStatusMaxStar, targetPlayerUnit.vitality.is_max);
    this.setStatusMaxStar(this.afterSpiritStatusMaxStar, targetPlayerUnit.mind.is_max);
    this.setStatusMaxStar(this.afterSpeedStatusMaxStar, targetPlayerUnit.agility.is_max);
    this.setStatusMaxStar(this.afterTechniqueStatusMaxStar, targetPlayerUnit.dexterity.is_max);
    this.setStatusMaxStar(this.afterLuckyStatusMaxStar, targetPlayerUnit.lucky.is_max);
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
    return (IEnumerator) new Unit00499Menu.\u003CInitUnitIcon\u003Ec__Iterator2F9()
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
  public IEnumerator InitEvolutionUnits(
    PlayerUnit[] playerUnits,
    GameObject unitIconPrefab,
    UILabel[] label,
    GameObject[] objects,
    UnitUnit[] evoUnits,
    bool fromEarth = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit00499Menu.\u003CInitEvolutionUnits\u003Ec__Iterator2FA()
    {
      playerUnits = playerUnits,
      objects = objects,
      evoUnits = evoUnits,
      unitIconPrefab = unitIconPrefab,
      label = label,
      fromEarth = fromEarth,
      \u003C\u0024\u003EplayerUnits = playerUnits,
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
    return (IEnumerator) new Unit00499Menu.\u003CInitTitle\u003Ec__Iterator2FB()
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
      foreach (PlayerUnit playerUnit in ((IEnumerable<PlayerUnit>) units).Where<PlayerUnit>((Func<PlayerUnit, bool>) (y => x.ID == y.unit.ID)))
      {
        if (playerUnit.id != baseUnit.id && !list.Contains(playerUnit.id))
        {
          list.Add(playerUnit.id);
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
    return (IEnumerator) new Unit00499Menu.\u003CInit\u003Ec__Iterator2FC()
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
    if (!this.isUnit || !this.isMoney || !this.isLevel || !this.isFavorite)
      return;
    this.StartCoroutine(this.Evolution());
  }

  public virtual void IbtnTrans()
  {
    if (this.IsPush || !this.isUnit || !this.isMoney || !this.isLevel || !this.isFavorite)
      return;
    this.StartCoroutine(this.ShowTransmigrationPopup());
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
