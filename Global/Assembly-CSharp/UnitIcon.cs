// Decompiled with JetBrains decompiler
// Type: UnitIcon
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
public class UnitIcon : UnitIconBase
{
  private const int PLAYER_BACK = 0;
  public GameObject[] backgrounds;
  public GameObject[] bottomNotFriendlyOrNot;
  public UITweener[] bottomNotFriendlyTweeners;
  public UI2DSprite rarityStar;
  public UI2DSprite type;
  public GameObject favorite;
  public GameObject newUnit;
  public GameObject selectUnit;
  public GameObject unknown;
  public UILabel[] textLevels;
  public BoxCollider buttonBoxCollider;
  public GameObject removeButton;
  public GameObject backObject;
  public GameObject bottomBaseObject;
  public GameObject breakWeapon;
  public GameObject breakWeaponOnlyBottom;
  public PrincessTypeIcon princessType;
  public UILabel txtCost;
  [SerializeField]
  private GameObject colosseumResultParent;
  [SerializeField]
  private GameObject[] colosseumResult;
  [SerializeField]
  private GameObject[] regulations;
  [SerializeField]
  private UI2DSprite unitSilhouette;
  [SerializeField]
  private Sprite heavensSilhouette;
  [SerializeField]
  private Sprite earthSilhouette;
  private System.Action colosseumResultEndFunction;
  public static readonly int Width = 123;
  public static readonly int Height = 147;
  public static readonly int HeightEarth = 151;
  public static readonly int ColumnValue = 5;
  public static readonly int RowValue = 8;
  public static readonly int RowScreenValue = 5;
  public static readonly int ScreenValue = UnitIcon.ColumnValue * UnitIcon.RowScreenValue;
  public static readonly int MaxValue = UnitIcon.ColumnValue * UnitIcon.RowValue;
  private GearKindIcon weaponIcon;
  private static Dictionary<int, UnitIcon.SpriteCache> spriteCache = new Dictionary<int, UnitIcon.SpriteCache>();
  public UnitIcon.BottomMode bottomMode;
  public UnitIcon.BackgroundMode backgroundMode;

  public UnitIcon.BottomMode BottomModeValue
  {
    get => this.bottomMode;
    set
    {
      if (value == UnitIcon.BottomMode.Nothing)
        ((IEnumerable<GameObject>) this.bottomNotFriendlyOrNot).ForEach<GameObject>((Action<GameObject>) (go => go.SetActive(false)));
      else
        ((IEnumerable<GameObject>) this.bottomNotFriendlyOrNot).ToggleOnce((int) value);
      this.bottomMode = value;
    }
  }

  public UnitIcon.BackgroundMode BackgroundModeValue
  {
    get => this.backgroundMode;
    set
    {
      this.backgroundMode = value;
      ((IEnumerable<GameObject>) this.backgrounds).ToggleOnce((int) value);
    }
  }

  public bool Favorite
  {
    get => this.favorite.activeSelf;
    set => this.favorite.SetActive(value);
  }

  public bool BreakWeapon
  {
    get => this.breakWeapon.activeSelf;
    set => this.breakWeapon.SetActive(value);
  }

  public bool BreakWeaponOnlyBottom
  {
    get => this.breakWeaponOnlyBottom.activeSelf;
    set => this.breakWeaponOnlyBottom.SetActive(value);
  }

  public bool NewUnit
  {
    get => this.newUnit.activeSelf;
    set => this.newUnit.SetActive(value);
  }

  public bool SelectUnit
  {
    get => this.selectUnit.activeSelf;
    set => this.selectUnit.SetActive(value);
  }

  public bool Unknown
  {
    get => this.unknown.activeSelf;
    set => this.unknown.SetActive(value);
  }

  public void SetButtonDetailEvent(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    if (!(playerUnit != (PlayerUnit) null))
      return;
    EventDelegate.Set(this.button.onLongPress, (EventDelegate.Callback) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0042Scene.changeScene(true, playerUnit, playerUnits);
    }));
  }

  public void SetEarthButtonDetalEvent(PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    if (!(playerUnit != (PlayerUnit) null))
      return;
    EventDelegate.Set(this.button.onLongPress, (EventDelegate.Callback) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0542Scene.changeScene(true, playerUnit, playerUnits);
    }));
  }

  [DebuggerHidden]
  public override IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CSetMaterialUnit\u003Ec__Iterator934()
    {
      playerUnit = playerUnit,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator SetPlayerUnit(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CSetPlayerUnit\u003Ec__Iterator935()
    {
      playerUnit = playerUnit,
      basePlayerUnit = basePlayerUnit,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetPlayerUnitEvolution(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CSetPlayerUnitEvolution\u003Ec__Iterator936()
    {
      playerUnit = playerUnit,
      basePlayerUnit = basePlayerUnit,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  public override void SetRemoveButton()
  {
    this.InitializeRemoveButton(true);
    this.button.onLongPress.Clear();
    this.Favorite = false;
  }

  public void SetMaterialUnitCache(PlayerUnit playerUnit, bool isNew, PlayerUnit[] playerUnits)
  {
    this.InitializeRemoveButton(false);
    this.setPlayerUnitCache(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0042Scene.changeScene(true, playerUnit, playerUnits);
    }));
  }

  public void SetPlayerUnitCache(PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    this.InitializeRemoveButton(false);
    this.setPlayerUnitCache(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0042Scene.changeScene(true, playerUnit, playerUnits);
    }));
  }

  public void setLevelText(PlayerUnit playerUnit)
  {
    if (!(playerUnit != (PlayerUnit) null))
      return;
    foreach (UILabel textLevel in this.textLevels)
      textLevel.SetTextLocalize(playerUnit.level.ToLocalizeNumberText());
  }

  public void setLevelText()
  {
    int number = 1;
    foreach (UILabel textLevel in this.textLevels)
      textLevel.SetTextLocalize(number.ToLocalizeNumberText());
  }

  public void setCostText(PlayerUnit playerUnit)
  {
    if (!(playerUnit != (PlayerUnit) null))
      return;
    this.txtCost.SetTextLocalize(playerUnit.unit.cost);
  }

  public void setBottom() => this.setLevelText();

  public void setBottom(PlayerUnit playerUnit)
  {
    this.setLevelText(playerUnit);
    this.setCostText(playerUnit);
    this.setNumText();
  }

  public void setLevelTextToString(string level)
  {
    foreach (UILabel textLevel in this.textLevels)
      textLevel.SetTextLocalize(level);
  }

  public void setSilhouette(bool isEarth)
  {
    this.unitSilhouette.sprite2D = !isEarth ? this.heavensSilhouette : this.earthSilhouette;
  }

  public static void ClearCache() => UnitIcon.spriteCache.Clear();

  private void setPlayerUnitCache(
    PlayerUnit playerUnit,
    System.Action buttonEvent,
    PlayerUnit basePlayerUnit = null)
  {
    this.playerUnit = playerUnit;
    this.Favorite = false;
    if (playerUnit != (PlayerUnit) null)
    {
      this.princessType.SetPrincessType(playerUnit);
      EventDelegate.Set(this.button.onLongPress, new EventDelegate.Callback(buttonEvent.Invoke));
      this.Favorite = playerUnit.favorite;
    }
    this.SelectUnit = false;
    this.SetUnitCache(this.playerUnit.unit, playerUnit.GetElement());
  }

  [DebuggerHidden]
  private IEnumerator setPlayerUnit(
    PlayerUnit playerUnit,
    System.Action buttonEvent,
    PlayerUnit basePlayerUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CsetPlayerUnit\u003Ec__Iterator937()
    {
      playerUnit = playerUnit,
      basePlayerUnit = basePlayerUnit,
      buttonEvent = buttonEvent,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator setSimpleUnit(PlayerUnit playerUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CsetSimpleUnit\u003Ec__Iterator938()
    {
      playerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator setBottomUnit(PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CsetBottomUnit\u003Ec__Iterator939()
    {
      playerUnit = playerUnit,
      playerUnits = playerUnits,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u003Ef__this = this
    };
  }

  public void setColosseumMatchingUnit(
    int unitId,
    int lv,
    Dictionary<int, UnitIcon.SpriteCache> cache)
  {
    this.SelectUnit = false;
    this.Favorite = false;
    ((Collider) this.buttonBoxCollider).enabled = false;
    UnitUnit unit = MasterData.UnitUnit[unitId];
    Dictionary<int, UnitIcon.SpriteCache> spriteCache = UnitIcon.spriteCache;
    UnitIcon.spriteCache = cache.ToDictionary<KeyValuePair<int, UnitIcon.SpriteCache>, int, UnitIcon.SpriteCache>((Func<KeyValuePair<int, UnitIcon.SpriteCache>, int>) (v => v.Key), (Func<KeyValuePair<int, UnitIcon.SpriteCache>, UnitIcon.SpriteCache>) (v => v.Value));
    this.SetUnitCache(unit, unit.GetElement());
    UnitIcon.spriteCache = spriteCache;
    ((IEnumerable<UILabel>) this.textLevels).ForEach<UILabel>((Action<UILabel>) (v => v.SetTextLocalize(lv)));
    this.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
  }

  public static bool IsCache(UnitUnit unit) => UnitIcon.spriteCache.ContainsKey(unit.ID);

  [DebuggerHidden]
  public static IEnumerator LoadSprite(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CLoadSprite\u003Ec__Iterator93A()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit
    };
  }

  public static Dictionary<int, UnitIcon.SpriteCache> CopyChach()
  {
    return UnitIcon.spriteCache.ToDictionary<KeyValuePair<int, UnitIcon.SpriteCache>, int, UnitIcon.SpriteCache>((Func<KeyValuePair<int, UnitIcon.SpriteCache>, int>) (v => v.Key), (Func<KeyValuePair<int, UnitIcon.SpriteCache>, UnitIcon.SpriteCache>) (v => v.Value));
  }

  public void SetRarities(UnitUnit unit) => RarityIcon.SetRarity(unit, this.rarityStar, false);

  [DebuggerHidden]
  public override IEnumerator SetUnit(UnitUnit unit, CommonElement element, bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CSetUnit\u003Ec__Iterator93B()
    {
      unit = unit,
      element = element,
      isGray = isGray,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003Eelement = element,
      \u003C\u0024\u003EisGray = isGray,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator SetUnitWithLongPressAction(
    UnitUnit unit,
    System.Action buttonEvent,
    bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitIcon.\u003CSetUnitWithLongPressAction\u003Ec__Iterator93C()
    {
      unit = unit,
      isGray = isGray,
      buttonEvent = buttonEvent,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EisGray = isGray,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u003Ef__this = this
    };
  }

  public void SetUnitCache(UnitUnit unit, CommonElement element)
  {
    this.unit = unit;
    if (unit != null)
    {
      UnitIcon.SpriteCache spriteCache;
      if (UnitIcon.spriteCache.TryGetValue(unit.ID, out spriteCache))
      {
        this.icon.sprite2D = spriteCache.thumbnail;
        this.icon.width = ((Texture) spriteCache.thumbnail.texture).width;
        this.icon.height = ((Texture) spriteCache.thumbnail.texture).height;
        GameObject gear = spriteCache.gear;
        if (Object.op_Equality((Object) this.weaponIcon, (Object) null))
        {
          GameObject gameObject = gear.Clone(((Component) this.type).transform);
          this.weaponIcon = gameObject.GetComponent<GearKindIcon>();
          gameObject.AddComponent<TweenColor>();
        }
        this.weaponIcon.Init(unit.kind, element);
        ((Behaviour) this.icon).enabled = true;
        this.BackgroundModeValue = UnitIcon.BackgroundMode.Visible;
        this.SetRarities(unit);
        ((Component) this.type).gameObject.SetActive(true);
        this.BottomModeValue = UnitIcon.BottomMode.NotFriendly;
        this.SelectUnit = false;
      }
      else
        this.ResetUnit();
    }
    else
      this.ResetUnit();
  }

  public void ResetUnit()
  {
    this.Deselect();
    if (Object.op_Inequality((Object) this.defaultIconSprite, (Object) null))
    {
      this.icon.sprite2D = this.defaultIconSprite;
      this.icon.width = ((Texture) this.defaultIconSprite.texture).width;
      this.icon.height = ((Texture) this.defaultIconSprite.texture).height;
    }
    this.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    ((Component) this.rarityStar).gameObject.SetActive(false);
    ((Component) this.type).gameObject.SetActive(false);
    this.BottomModeValue = UnitIcon.BottomMode.Nothing;
  }

  public IEnumerator SetSelectUnit()
  {
    this.SelectUnit = true;
    return this.SetUnit((UnitUnit) null, CommonElement.none, false);
  }

  public void RarityCenter()
  {
    this.bottomRarity.transform.localPosition = Vector2.op_Implicit(new Vector2(14f, 1f));
  }

  private void InitializeRemoveButton(bool enable)
  {
    this.backObject.SetActive(!enable);
    this.bottomBaseObject.SetActive(!enable);
    ((Component) this.icon).gameObject.SetActive(!enable);
    this.removeButton.SetActive(enable);
    this.princessType.DispPrincessType(!enable);
    if (!enable)
      return;
    this.unit = (UnitUnit) null;
  }

  public bool isViewBackObject
  {
    get => this.backObject.activeSelf;
    set => this.backObject.SetActive(value);
  }

  public void SetEmpty()
  {
    ((Component) this.rarityStar).gameObject.SetActive(false);
    this.favorite.SetActive(false);
    this.newUnit.SetActive(false);
    this.selectUnit.SetActive(false);
    this.unknown.SetActive(false);
    this.removeButton.SetActive(false);
    ((IEnumerable<GameObject>) this.backgrounds).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    this.bottomBaseObject.SetActive(false);
    ((Component) this.icon).gameObject.SetActive(false);
    this.breakWeapon.SetActive(false);
    this.backgrounds[0].SetActive(true);
    this.for_battle.SetActive(false);
    this.colosseumResultParent.SetActive(false);
    this.princessType.DispPrincessType(false);
  }

  public void SetColosseumResult(
    UnitIcon.ColosseumResult result,
    float scale = 1f,
    float time = 0.0f,
    System.Action endFunction = null)
  {
    this.colosseumResultEndFunction = endFunction;
    if (result == UnitIcon.ColosseumResult.NONE)
    {
      this.colosseumResultParent.SetActive(false);
    }
    else
    {
      int index1 = (int) result;
      this.colosseumResultParent.SetActive(true);
      for (int index2 = 0; index2 < this.colosseumResult.Length; ++index2)
        this.colosseumResult[index2].SetActive(index2 == index1);
      if ((double) time <= 0.0)
        return;
      this.colosseumResult[index1].transform.localScale = new Vector3(scale, scale, 1f);
      iTween.ScaleTo(this.colosseumResult[index1], iTween.Hash((object) "x", (object) 1f, (object) "y", (object) 1f, (object) nameof (time), (object) time, (object) "easetype", (object) iTween.EaseType.easeInCubic, (object) "oncomplete", (object) "ColosseumResultEnd", (object) "oncompletetarget", (object) ((Component) this).gameObject));
    }
  }

  private void ColosseumResultEnd()
  {
    if (this.colosseumResultEndFunction == null)
      return;
    this.colosseumResultEndFunction();
  }

  public void SetColosseumResultAlphaLoop(float value = 0.5f, float time = 1f)
  {
    iTween.ValueTo(((Component) this).gameObject, iTween.Hash((object) "from", (object) 1f, (object) "to", (object) value, (object) nameof (time), (object) time, (object) "looptype", (object) iTween.LoopType.pingPong, (object) "onupdate", (object) "ColosseumResultAlphaLoopUpdate"));
  }

  private void ColosseumResultAlphaLoopUpdate(float value)
  {
    for (int index = 0; index < this.colosseumResult.Length; ++index)
    {
      if (this.colosseumResult[index].activeSelf)
        this.colosseumResult[index].GetComponent<UIWidget>().alpha = value;
    }
  }

  public void SetRegulation(UnitIcon.Regulation flg)
  {
    if (flg == UnitIcon.Regulation.None)
    {
      foreach (GameObject regulation in this.regulations)
        regulation.SetActive(false);
    }
    else
      ((IEnumerable<GameObject>) this.regulations).ToggleOnce((int) flg);
  }

  public class SpriteCache
  {
    public Sprite thumbnail;
    public GameObject gear;

    public SpriteCache(Sprite s, GameObject o)
    {
      this.thumbnail = s;
      this.gear = o;
    }
  }

  public enum ColosseumResult
  {
    WIN,
    DROW,
    LOSE,
    NONE,
  }

  public enum BottomMode
  {
    Nothing,
    NotFriendly,
    Friendly,
    FriendlyEarth,
  }

  public enum BackgroundMode
  {
    PlayerShadow,
    EnemyShadow,
    Visible,
    Empty,
  }

  public enum Regulation
  {
    Default,
    WithBroken,
    None,
  }
}
