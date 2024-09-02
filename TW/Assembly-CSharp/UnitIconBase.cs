// Decompiled with JetBrains decompiler
// Type: UnitIconBase
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
public class UnitIconBase : IconPrefabBase
{
  protected PlayerUnit playerUnit;
  [SerializeField]
  protected GameObject breakThrough;
  [SerializeField]
  protected GameObject specialIconRoot;
  [SerializeField]
  protected GameObject[] specialIcons;
  public GameObject numberBase;
  public GameObject[] numbers;
  public GameObject checkIcon;
  public GameObject for_battle;
  public GameObject equip;
  public GameObject selectMarker;
  public UI2DSprite icon;
  protected Sprite defaultIconSprite;
  protected bool gray;
  protected bool selected;
  protected bool marker;
  public int SelIndex;
  protected bool deckUnit;
  private UnitIcon unitIcon;
  protected System.Action pressEvent;
  private Action<UnitIconBase> onClick_;
  public LongPressButton button;
  public GameObject friendlyEffect;
  public GameObject friendlyEffectEarth;
  public UILabel txtNum;
  private readonly int MARKER_ALPHA_TWEEN = 49;
  [SerializeField]
  protected GameObject bottomLevel;
  [SerializeField]
  protected GameObject bottomRarity;
  [SerializeField]
  protected GameObject bottomCost;
  [SerializeField]
  protected GameObject bottomNum;
  public System.Action markerDisplayFinished;
  [SerializeField]
  private GameObject m_crossForOneDigitCount;
  [SerializeField]
  private GameObject m_crossForTwoDigitsCount;
  [SerializeField]
  private GameObject m_crossForThreeDigitsCount;
  [SerializeField]
  private GameObject m_crossForFourDigitsCount;
  [SerializeField]
  private GameObject[] m_onesDigit;
  [SerializeField]
  private GameObject[] m_tensDigit;
  [SerializeField]
  private GameObject[] m_hundredsDigit;
  [SerializeField]
  private GameObject[] m_thousandsDigit;
  [SerializeField]
  private GameObject m_checkForSelected;
  [SerializeField]
  private GameObject[] m_tensDigitForSelected;
  [SerializeField]
  private GameObject[] m_onesDigitForSelected;
  [SerializeField]
  private GameObject[] earthNumParents;
  [SerializeField]
  private EarthUnitNumIcon[] earthUnitNumIcon;
  private int specialIconType;

  public UnitUnit unit { get; set; }

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.icon, (Object) null))
      return;
    this.defaultIconSprite = this.icon.sprite2D;
  }

  public PlayerUnit PlayerUnit => this.playerUnit;

  public UnitUnit Unit => this.unit;

  public bool BreakThrough
  {
    get => this.breakThrough.activeSelf;
    set => this.breakThrough.SetActive(value);
  }

  public void Select(int index, bool gray = true)
  {
    this.SelIndex = index;
    this.selected = true;
    this.DispNumber(index);
    if (this.unit.IsNormalUnit && Object.op_Inequality((Object) this.checkIcon, (Object) null))
      this.checkIcon.SetActive(false);
    this.Gray = gray;
  }

  public void DispNumber(int index)
  {
    this.numberBase.SetActive(true);
    ((IEnumerable<GameObject>) this.numbers).ToggleOnce(index);
  }

  public void SelectByCheckIcon(bool gray = true)
  {
    this.selected = true;
    this.numberBase.SetActive(true);
    ((IEnumerable<GameObject>) this.numbers).ForEach<GameObject>((Action<GameObject>) (go => go.SetActive(false)));
    if (Object.op_Inequality((Object) this.checkIcon, (Object) null))
      this.checkIcon.SetActive(true);
    this.Gray = gray;
  }

  public void HideCheckIcon()
  {
    this.numberBase.SetActive(false);
    ((IEnumerable<GameObject>) this.numbers).ForEach<GameObject>((Action<GameObject>) (go => go.SetActive(false)));
    if (!Object.op_Inequality((Object) this.checkIcon, (Object) null))
      return;
    this.checkIcon.SetActive(false);
  }

  public void DispEarthUnitNumberIcon(int num, bool isGorgeous, bool isLeft)
  {
    if (isLeft)
    {
      ((IEnumerable<GameObject>) this.earthNumParents).ToggleOnce(0);
      this.earthUnitNumIcon[0].SetNumIcon(num, isGorgeous);
    }
    else
    {
      ((IEnumerable<GameObject>) this.earthNumParents).ToggleOnce(1);
      this.earthUnitNumIcon[1].SetNumIcon(num, isGorgeous);
    }
  }

  public void HiddenEarthUnitNumberIcon(bool isLeft)
  {
    if (this.earthNumParents == null)
      return;
    ((IEnumerable<GameObject>) this.earthNumParents).ToggleOnce(-1);
  }

  public bool DeckUnit
  {
    get => this.deckUnit;
    set => this.deckUnit = value;
  }

  public bool Selected => this.selected;

  public bool ForBattle
  {
    get => this.for_battle.activeSelf;
    set => this.for_battle.SetActive(value);
  }

  public bool Equip
  {
    get => this.equip.activeSelf;
    set => this.equip.SetActive(value);
  }

  public bool SpecialIcon
  {
    get
    {
      return !Object.op_Equality((Object) this.specialIconRoot, (Object) null) && this.specialIconRoot.activeSelf;
    }
    set
    {
      if (!Object.op_Inequality((Object) this.specialIconRoot, (Object) null))
        return;
      this.specialIconRoot.SetActive(value);
    }
  }

  public int SpecialIconType
  {
    get => this.specialIconType;
    set
    {
      if (this.specialIconType == value)
        return;
      this.specialIconType = value;
      ((IEnumerable<GameObject>) this.specialIcons).ToggleOnce(this.specialIconType);
    }
  }

  public static int? GetSpecialIconType(string color_code)
  {
    QuestCommonSpecialColor commonSpecialColor = ((IEnumerable<QuestCommonSpecialColor>) MasterData.QuestCommonSpecialColorList).FirstOrDefault<QuestCommonSpecialColor>((Func<QuestCommonSpecialColor, bool>) (x => x.color_code == color_code));
    return commonSpecialColor != null ? new int?(commonSpecialColor.ID - 1) : new int?();
  }

  public UnitIcon UnitIcon
  {
    get => this.unitIcon;
    set => this.unitIcon = value;
  }

  public bool SelectMarker
  {
    get => !Object.op_Equality((Object) this.selectMarker, (Object) null) && this.marker;
    set
    {
      if (!Object.op_Inequality((Object) this.selectMarker, (Object) null))
        return;
      this.marker = value;
      this.selectMarker.SetActive(value);
      if (!value)
        return;
      UITweener[] array = ((IEnumerable<UITweener>) NGTween.findTweenersGroup(this.selectMarker, 49, false)).Where<UITweener>((Func<UITweener, bool>) (x => x.style != UITweener.Style.Loop)).ToArray<UITweener>();
      if (array.Length <= 0)
        return;
      array[0].SetOnFinished((EventDelegate.Callback) (() =>
      {
        if (this.markerDisplayFinished == null)
          return;
        this.markerDisplayFinished();
      }));
      NGTween.playTweens(array, this.MARKER_ALPHA_TWEEN);
    }
  }

  public void Deselect()
  {
    this.selected = false;
    this.numberBase.SetActive(false);
    ((IEnumerable<GameObject>) this.numbers).ForEach<GameObject>((Action<GameObject>) (go => go.SetActive(false)));
    if (Object.op_Inequality((Object) this.checkIcon, (Object) null))
      this.checkIcon.SetActive(false);
    this.Gray = false;
  }

  public void DeselectByCheckIcon()
  {
    this.selected = false;
    this.numberBase.SetActive(false);
    ((IEnumerable<GameObject>) this.numbers).ForEach<GameObject>((Action<GameObject>) (go => go.SetActive(false)));
    if (Object.op_Inequality((Object) this.checkIcon, (Object) null))
      this.checkIcon.SetActive(false);
    this.Gray = false;
  }

  public bool Gray
  {
    get => this.gray;
    set
    {
      if (this.gray == value)
        return;
      this.gray = value;
      NGTween.playTweens(((Component) this).GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !value);
    }
  }

  public void SetPressEvent(System.Action evt) => this.pressEvent = evt;

  public Coroutine StartCoroutine(IEnumerator e)
  {
    return Singleton<NGSceneManager>.GetInstance().StartCoroutine(e);
  }

  [DebuggerHidden]
  public virtual IEnumerator SetUnit(UnitUnit unit, CommonElement element, bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBase.\u003CSetUnit\u003Ec__IteratorBA9()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator SetUnitWithLongPressAction(
    UnitUnit unit,
    System.Action buttonEvent,
    bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBase.\u003CSetUnitWithLongPressAction\u003Ec__IteratorBAA()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBase.\u003CSetMaterialUnit\u003Ec__IteratorBAB()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    PlayerUnit basePlayerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBase.\u003CSetMaterialUnit\u003Ec__IteratorBAC()
    {
      playerUnit = playerUnit,
      isNew = isNew,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator SetPlayerUnit(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIconBase.\u003CSetPlayerUnit\u003Ec__IteratorBAD()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void SetRemoveButton()
  {
  }

  public Action<UnitIconBase> onClick
  {
    get => this.onClick_;
    set
    {
      this.onClick_ = value;
      if (this.onClick_ == null || !Object.op_Inequality((Object) this.button, (Object) null))
        return;
      EventDelegate.Set(this.button.onClick, (EventDelegate.Callback) (() => this.onClick_(this)));
    }
  }

  public void SetFriendlyEffect(bool bl, bool isEarthMode = false)
  {
    if (isEarthMode)
      this.friendlyEffectEarth.SetActive(bl);
    else
      this.friendlyEffect.SetActive(bl);
  }

  private void setNumTextGradientColor(Color top, Color bottom)
  {
    this.txtNum.gradientTop = top;
    this.txtNum.gradientBottom = bottom;
  }

  public void setNumText(int value = 0)
  {
    this.setNumTextGradientColor(new Color(1f, 1f, 1f), new Color(0.698039234f, 0.698039234f, 0.698039234f));
    this.txtNum.SetTextLocalize(value);
  }

  public void setText(string str = "")
  {
    this.setNumTextGradientColor(new Color(1f, 1f, 1f), new Color(0.698039234f, 0.698039234f, 0.698039234f));
    this.txtNum.SetTextLocalize(str);
  }

  private void ShowBottomInfos(UnitSortAndFilter.SORT_TYPES type)
  {
    this.bottomLevel.SetActive(type == UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy || type == UnitSortAndFilter.SORT_TYPES.Level || type == UnitSortAndFilter.SORT_TYPES.Rarity || type == UnitSortAndFilter.SORT_TYPES.GetOrder || type == UnitSortAndFilter.SORT_TYPES.UnitID || type == UnitSortAndFilter.SORT_TYPES.Attribute);
    this.bottomRarity.SetActive(type == UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy || type == UnitSortAndFilter.SORT_TYPES.Level || type == UnitSortAndFilter.SORT_TYPES.Rarity || type == UnitSortAndFilter.SORT_TYPES.GetOrder || type == UnitSortAndFilter.SORT_TYPES.UnitID || type == UnitSortAndFilter.SORT_TYPES.Attribute);
    this.bottomCost.SetActive(type == UnitSortAndFilter.SORT_TYPES.Cost);
    this.bottomNum.SetActive(type != UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy && type != UnitSortAndFilter.SORT_TYPES.Level && type != UnitSortAndFilter.SORT_TYPES.Rarity && type != UnitSortAndFilter.SORT_TYPES.Cost && type != UnitSortAndFilter.SORT_TYPES.GetOrder && type != UnitSortAndFilter.SORT_TYPES.UnitID && type != UnitSortAndFilter.SORT_TYPES.Attribute);
  }

  public void ShowBottomInfoComposeBase()
  {
    this.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
  }

  private void SetElementTextColor(CommonElement element)
  {
    Color[,] colorArray = new Color[12, 2]
    {
      {
        Color.white,
        Color.white
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.698039234f, 0.698039234f, 0.698039234f)
      },
      {
        new Color(1f, 0.509803951f, 0.380392164f),
        new Color(0.8784314f, 0.007843138f, 0.007843138f)
      },
      {
        new Color(0.596078455f, 1f, 0.5019608f),
        new Color(0.08627451f, 0.698039234f, 0.0f)
      },
      {
        new Color(1f, 0.905882359f, 0.02745098f),
        new Color(1f, 0.5411765f, 0.0f)
      },
      {
        new Color(0.349019617f, 1.0739131f, 1f),
        new Color(0.0117647061f, 0.407843143f, 0.8980392f)
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.698039234f, 0.698039234f, 0.698039234f)
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.8901961f, 0.858823538f, 0.635294139f)
      },
      {
        new Color(0.9372549f, 0.6509804f, 1f),
        new Color(0.6039216f, 0.0f, 0.9529412f)
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.698039234f, 0.698039234f, 0.698039234f)
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.698039234f, 0.698039234f, 0.698039234f)
      },
      {
        new Color(1f, 1f, 1f),
        new Color(0.698039234f, 0.698039234f, 0.698039234f)
      }
    };
    this.setNumTextGradientColor(colorArray[(int) element, 0], colorArray[(int) element, 1]);
  }

  public void ShowBottomInfosLevelOnly()
  {
    this.bottomLevel.SetActive(true);
    this.bottomRarity.SetActive(false);
    this.bottomCost.SetActive(false);
    this.bottomNum.SetActive(false);
  }

  public void ShowBottomInfo(UnitSortAndFilter.SORT_TYPES sort)
  {
    this.ShowBottomInfos(sort);
    switch (sort)
    {
      case UnitSortAndFilter.SORT_TYPES.FightingPower:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Combat);
        break;
      case UnitSortAndFilter.SORT_TYPES.PhysicalAttack:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).PhysicalAttack);
        break;
      case UnitSortAndFilter.SORT_TYPES.MagicAttack:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).MagicAttack);
        break;
      case UnitSortAndFilter.SORT_TYPES.Defence:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).PhysicalDefense);
        break;
      case UnitSortAndFilter.SORT_TYPES.MagicDefence:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).MagicDefense);
        break;
      case UnitSortAndFilter.SORT_TYPES.Hit:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Hit);
        break;
      case UnitSortAndFilter.SORT_TYPES.Critical:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Critical);
        break;
      case UnitSortAndFilter.SORT_TYPES.Avoid:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Evasion);
        break;
      case UnitSortAndFilter.SORT_TYPES.Speed:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Agility);
        break;
      case UnitSortAndFilter.SORT_TYPES.Dexterity:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Dexterity);
        break;
      case UnitSortAndFilter.SORT_TYPES.Luck:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Luck);
        break;
      case UnitSortAndFilter.SORT_TYPES.WeaponProficiency:
        this.setText(this.PlayerUnit.proficiency.proficiency);
        break;
      case UnitSortAndFilter.SORT_TYPES.ArmorProficiency:
        this.setText(this.PlayerUnit.shildProficiency().proficiency);
        break;
      case UnitSortAndFilter.SORT_TYPES.HP:
        this.setNumText(Judgement.NonBattleParameter.FromPlayerUnit(this.PlayerUnit).Hp);
        break;
    }
  }

  public void BottomGray(bool gray)
  {
    NGTween.playTweens(this.bottomLevel.GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !gray);
    NGTween.playTweens(this.bottomNum.GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !gray);
    NGTween.playTweens(this.bottomRarity.GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !gray);
    NGTween.playTweens(this.bottomCost.GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, !gray);
  }

  public void SetCounter(int number)
  {
    if (this.unit != null)
    {
      if (this.unit.IsNormalUnit)
      {
        this.HideCounter();
      }
      else
      {
        if (number > 9999)
          number = 9999;
        int num1 = number % 10;
        int num2 = number % 100 / 10;
        int num3 = number % 1000 / 100;
        int num4 = number % 10000 / 1000;
        UnitIconBase.CounterDigits digits = UnitIconBase.CounterDigits.OneDigit;
        if (number < 1)
        {
          this.HideCounter();
        }
        else
        {
          if (number >= 10)
            digits = number >= 100 ? (number >= 1000 ? UnitIconBase.CounterDigits.FourDigits : UnitIconBase.CounterDigits.ThreeDigits) : UnitIconBase.CounterDigits.TwoDigits;
          this.SetCross(digits);
          this.SetOnesDigit(num1);
          this.SetTensDigit(num2, digits);
          this.SetHundredsDigit(num3, digits);
          this.SetThousandsDigit(num4, digits);
        }
      }
    }
    else
      this.HideCounter();
  }

  private void SetOnesDigit(int num)
  {
    if (num > -1 && num < 10)
    {
      ((IEnumerable<GameObject>) this.m_onesDigit).ToggleOnceEx(num);
    }
    else
    {
      if (!Debug.isDebugBuild)
        return;
      Debug.LogError((object) ("Illegal parameter (num): " + (object) num));
    }
  }

  private void SetTensDigit(int num, UnitIconBase.CounterDigits digits)
  {
    if (num > -1 && num < 10)
    {
      if (UnitIconBase.CounterDigits.TwoDigits > digits)
        ((IEnumerable<GameObject>) this.m_tensDigit).ToggleOnceEx(-1);
      else
        ((IEnumerable<GameObject>) this.m_tensDigit).ToggleOnceEx(num);
    }
    else
    {
      if (!Debug.isDebugBuild)
        return;
      Debug.LogError((object) ("Illegal parameter (num): " + (object) num));
    }
  }

  private void SetHundredsDigit(int num, UnitIconBase.CounterDigits digits)
  {
    if (num > -1 && num < 10)
    {
      if (UnitIconBase.CounterDigits.ThreeDigits > digits)
        ((IEnumerable<GameObject>) this.m_hundredsDigit).ToggleOnceEx(-1);
      else
        ((IEnumerable<GameObject>) this.m_hundredsDigit).ToggleOnceEx(num);
    }
    else
    {
      if (!Debug.isDebugBuild)
        return;
      Debug.LogError((object) ("Illegal parameter (num): " + (object) num));
    }
  }

  private void SetThousandsDigit(int num, UnitIconBase.CounterDigits digits)
  {
    if (num > -1 && num < 10)
    {
      if (UnitIconBase.CounterDigits.FourDigits > digits)
        ((IEnumerable<GameObject>) this.m_thousandsDigit).ToggleOnceEx(-1);
      else
        ((IEnumerable<GameObject>) this.m_thousandsDigit).ToggleOnceEx(num);
    }
    else
    {
      if (!Debug.isDebugBuild)
        return;
      Debug.LogError((object) ("Illegal parameter (num): " + (object) num));
    }
  }

  private void SetCross(UnitIconBase.CounterDigits digits)
  {
    ((IEnumerable<GameObject>) new GameObject[4]
    {
      this.m_crossForOneDigitCount,
      this.m_crossForTwoDigitsCount,
      this.m_crossForThreeDigitsCount,
      this.m_crossForFourDigitsCount
    }).ToggleOnceEx((int) digits);
  }

  private void HideCounter()
  {
    if (Object.op_Inequality((Object) this.m_crossForOneDigitCount, (Object) null))
      this.m_crossForOneDigitCount.SetActive(false);
    if (Object.op_Inequality((Object) this.m_crossForTwoDigitsCount, (Object) null))
      this.m_crossForTwoDigitsCount.SetActive(false);
    if (Object.op_Inequality((Object) this.m_crossForThreeDigitsCount, (Object) null))
      this.m_crossForThreeDigitsCount.SetActive(false);
    if (Object.op_Inequality((Object) this.m_crossForFourDigitsCount, (Object) null))
      this.m_crossForFourDigitsCount.SetActive(false);
    ((IEnumerable<GameObject>) this.m_onesDigit).ToggleOnceEx(-1);
    ((IEnumerable<GameObject>) this.m_tensDigit).ToggleOnceEx(-1);
    ((IEnumerable<GameObject>) this.m_hundredsDigit).ToggleOnceEx(-1);
    ((IEnumerable<GameObject>) this.m_thousandsDigit).ToggleOnceEx(-1);
  }

  public void SetSelectionCounter(int selectedQuantity)
  {
    if (selectedQuantity < 0 || selectedQuantity > 99)
    {
      Debug.LogWarning((object) ("Illegal parameter specified for SetSelectionCounter(). Paramerter: " + selectedQuantity.ToString()));
    }
    else
    {
      bool flag = false;
      if (this.unit == null)
        flag = true;
      else if (this.unit.IsNormalUnit)
        flag = true;
      if (flag)
      {
        this.HideSelectedQuantityCounter();
        if (!Object.op_Inequality((Object) this.m_checkForSelected, (Object) null))
          return;
        this.m_checkForSelected.SetActive(false);
      }
      else
      {
        if (selectedQuantity > 0)
        {
          this.SetOnesDigitNumberForSelectedQuantity(selectedQuantity % 10);
          this.SetTensDigitNumberForSelectedQuantity(selectedQuantity / 10);
          this.Gray = true;
        }
        else
        {
          this.HideSelectedQuantityCounter();
          this.Gray = false;
        }
        if (!Object.op_Inequality((Object) this.m_checkForSelected, (Object) null))
          return;
        this.m_checkForSelected.SetActive(selectedQuantity > 0);
      }
    }
  }

  private void HideSelectedQuantityCounter()
  {
    foreach (GameObject gameObject in this.m_onesDigitForSelected)
      gameObject.SetActive(false);
    foreach (GameObject gameObject in this.m_tensDigitForSelected)
      gameObject.SetActive(false);
  }

  private void SetTensDigitNumberForSelectedQuantity(int number)
  {
    for (int index = 0; index < this.m_tensDigitForSelected.Length; ++index)
      this.m_tensDigitForSelected[index].SetActive(index == number);
  }

  private void SetOnesDigitNumberForSelectedQuantity(int number)
  {
    for (int index = 0; index < this.m_onesDigitForSelected.Length; ++index)
      this.m_onesDigitForSelected[index].SetActive(index == number);
  }

  private enum EarthNumIndex
  {
    Left,
    Right,
  }

  private enum CounterDigits
  {
    OneDigit,
    TwoDigits,
    ThreeDigits,
    FourDigits,
  }
}
