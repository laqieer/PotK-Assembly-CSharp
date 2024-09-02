// Decompiled with JetBrains decompiler
// Type: UnitIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class UnitIcon : UnitIconBase
{
  [SerializeField]
  protected UnityEngine.Sprite[] specialIconSprites;
  [SerializeField]
  protected UI2DSprite specialIcon;
  private int specialIconType;
  [SerializeField]
  private Vector3[] backgroundPosList;
  [SerializeField]
  private UnityEngine.Sprite[] backgroundSprites;
  [SerializeField]
  private UI2DSprite background;
  public UI2DSprite type;
  public GameObject favorite;
  public GameObject newUnit;
  public GameObject selectUnit;
  public GameObject unknown;
  public BoxCollider buttonBoxCollider;
  public GameObject breakWeapon;
  public GameObject breakWeaponOnlyBottom;
  public PrincessTypeIcon princessType;
  public GameObject hp_gauge;
  [SerializeField]
  private UI2DSprite colosseumResultParent;
  [SerializeField]
  private UnityEngine.Sprite[] colosseumResultSprites;
  [SerializeField]
  private Vector3[] regulationsPosList;
  [SerializeField]
  private GameObject regulations;
  [SerializeField]
  private GameObject seaPickupObj;
  [SerializeField]
  private GameObject seaGuestObj;
  [SerializeField]
  private GameObject getPieceObj;
  [Space(8f)]
  public GameObject dirUnity;
  [SerializeField]
  private GameObject dirTrueUnity;
  [SerializeField]
  private GameObject dirBuildUpUnity;
  [SerializeField]
  private UILabel txtTrueUnityValue;
  [SerializeField]
  private UILabel txtBuildUpUnityValue;
  [Space(8f)]
  [SerializeField]
  private GameObject dirUnityUpItem;
  [SerializeField]
  private UILabel txtUnityUpValue;
  [Space(8f)]
  [SerializeField]
  private BlinkSync bottomBlink;
  [SerializeField]
  private GameObject[] remainDays;
  [SerializeField]
  private UILabel[] txtRemainDays;
  private System.Action colosseumResultEndFunction;
  public static readonly int Width = 123;
  public static readonly int Height = 147;
  public static readonly int HeightWithHpGauge = 158;
  public static readonly int HeightEarth = 151;
  public static readonly int ColumnValue = 5;
  public static readonly int RowValue = 8;
  public static readonly int RowScreenValue = 5;
  public static readonly int ScreenValue = UnitIcon.ColumnValue * UnitIcon.RowScreenValue;
  public static readonly int MaxValue = UnitIcon.ColumnValue * UnitIcon.RowValue;
  private GearKindIcon weaponIcon;
  private UnitHpGauge hpGauge;
  private static Dictionary<ulong, UnitIcon.SpriteCache> spriteCache_ = new Dictionary<ulong, UnitIcon.SpriteCache>();
  private static Dictionary<ulong, UnitIcon.SpriteCache> spriteSeaCache_ = new Dictionary<ulong, UnitIcon.SpriteCache>();
  public UnitIcon.BackgroundMode backgroundMode;
  private const int SHIFT_METAMOR_ID = 32;
  private const int MAX_REMAINDAYS = 99;

  public bool SpecialIcon
  {
    get => !((UnityEngine.Object) this.specialIcon == (UnityEngine.Object) null) && this.specialIcon.gameObject.activeSelf;
    set
    {
      if (!((UnityEngine.Object) this.specialIcon != (UnityEngine.Object) null))
        return;
      this.specialIcon.gameObject.SetActive(value);
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
      if (this.specialIconType >= 0 && this.specialIconType < this.specialIconSprites.Length)
      {
        this.specialIcon.gameObject.SetActive(true);
        this.specialIcon.sprite2D = this.specialIconSprites[this.specialIconType];
        UI2DSprite specialIcon = this.specialIcon;
        Rect textureRect = this.specialIconSprites[this.specialIconType].textureRect;
        int width = (int) textureRect.width;
        textureRect = this.specialIconSprites[this.specialIconType].textureRect;
        int height = (int) textureRect.height;
        specialIcon.SetDimensions(width, height);
      }
      else
        this.specialIcon.gameObject.SetActive(false);
    }
  }

  public static int? GetSpecialIconType(string color_code)
  {
    QuestCommonSpecialColor commonSpecialColor = ((IEnumerable<QuestCommonSpecialColor>) MasterData.QuestCommonSpecialColorList).FirstOrDefault<QuestCommonSpecialColor>((Func<QuestCommonSpecialColor, bool>) (x => x.color_code == color_code));
    return commonSpecialColor != null ? new int?(commonSpecialColor.ID - 1) : new int?();
  }

  public UnitHpGauge HpGauge
  {
    get
    {
      if ((UnityEngine.Object) this.hp_gauge == (UnityEngine.Object) null)
        return (UnitHpGauge) null;
      if ((UnityEngine.Object) this.hpGauge == (UnityEngine.Object) null)
        this.hpGauge = this.hp_gauge.GetComponentInChildren<UnitHpGauge>(false);
      return this.hpGauge;
    }
  }

  private static Dictionary<ulong, UnitIcon.SpriteCache> spriteCache
  {
    get => !Singleton<NGGameDataManager>.GetInstance().IsSea ? UnitIcon.spriteCache_ : UnitIcon.spriteSeaCache_;
    set
    {
      if (Singleton<NGGameDataManager>.GetInstance().IsSea)
        UnitIcon.spriteSeaCache_ = value;
      else
        UnitIcon.spriteCache_ = value;
    }
  }

  public UnitIcon.BackgroundMode BackgroundModeValue
  {
    get => this.backgroundMode;
    set
    {
      if (value >= (UnitIcon.BackgroundMode) this.backgroundPosList.Length || value >= (UnitIcon.BackgroundMode) this.backgroundSprites.Length)
        return;
      this.backgroundMode = value;
      this.background.gameObject.SetActive(true);
      this.background.transform.localPosition = this.backgroundPosList[(int) value];
      this.background.sprite2D = this.backgroundSprites[(int) value];
      this.background.SetDimensions((int) this.backgroundSprites[(int) value].textureRect.width, (int) this.backgroundSprites[(int) value].textureRect.height);
    }
  }

  public static UnitIcon.BackgroundMode GetBackgroundMode(
    UnitUnit unit,
    PlayerUnit playerUnit)
  {
    if (playerUnit != (PlayerUnit) null && Player.Current != null && (Player.Current.IsCalledUnit(unit) && ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Any<PlayerUnit>((Func<PlayerUnit, bool>) (p => p == playerUnit))))
      return UnitIcon.BackgroundMode.Call;
    return !unit.awake_unit_flag ? UnitIcon.BackgroundMode.Visible : UnitIcon.BackgroundMode.AwakeUnit;
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

  public bool EnabledExpireDate { get; set; }

  public void SetButtonDetailEvent(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    if (!(playerUnit != (PlayerUnit) null))
      return;
    EventDelegate.Set(this.Button.onLongPress, (EventDelegate.Callback) (() =>
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
    EventDelegate.Set(this.Button.onLongPress, (EventDelegate.Callback) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0542Scene.changeScene(true, playerUnit, playerUnits);
    }));
  }

  public override IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    this.InitializeRemoveButton(false);
    IEnumerator e = this.setPlayerUnit(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0042Scene.changeScene(true, playerUnit, playerUnits, true);
    }));
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override IEnumerator SetPlayerUnit(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null,
    bool isMaterial = false,
    bool isMemory = false)
  {
    this.InitializeRemoveButton(false);
    IEnumerator e = this.setPlayerUnit(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Singleton<NGSceneManager>.GetInstance().LastHeaderType = new CommonRoot.HeaderType?(Singleton<CommonRoot>.GetInstance().headerType);
      Unit0042Scene.changeScene(true, playerUnit, playerUnits, isMaterial, isMemory);
    }), basePlayerUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator SetPlayerUnitEvolution(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null,
    bool isMaterial = false,
    bool isMemory = false)
  {
    this.InitializeRemoveButton(false);
    IEnumerator e = this.setPlayerUnit(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      if (Singleton<NGGameDataManager>.GetInstance().IsSea)
        Singleton<NGSceneManager>.GetInstance().LastHeaderType = new CommonRoot.HeaderType?(Singleton<CommonRoot>.GetInstance().headerType);
      Unit0042Scene.changeSceneEvolutionUnit(true, playerUnit, playerUnits, isMaterial, isMemory);
    }), basePlayerUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator SetPlayerUnitReincarnationType(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null,
    bool isMaterial = false,
    bool isMemory = false)
  {
    this.InitializeRemoveButton(false);
    IEnumerator e = this.setPlayerUnit(playerUnit, (System.Action) (() =>
    {
      if (this.pressEvent != null)
        this.pressEvent();
      Unit0042Scene.changeSceneReincarnationTypeUnit(true, playerUnit, playerUnits, isMaterial, isMemory);
    }), basePlayerUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator SetFacilityUnit(PlayerUnit facilityUnit)
  {
    UnitIcon unitIcon = this;
    unitIcon.InitializeRemoveButton(false);
    IEnumerator e = unitIcon.setSimpleUnit(facilityUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitIcon.BackgroundModeValue = UnitIcon.BackgroundMode.Visible;
    unitIcon.rarityStar.gameObject.SetActive(false);
  }

  public override void SetRemoveButton()
  {
    this.InitializeRemoveButton(true);
    this.Button.onLongPress.Clear();
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

  public void setBottom(PlayerUnit playerUnit)
  {
    this.setLevelText(playerUnit);
    this.setCostText(playerUnit);
    this.setCombatText();
  }

  public void setMemoryLevelText() => this.setLevelText(this.playerUnit.memory_level.ToString());

  public void setSilhouette(bool isEarth) => this.BackgroundModeValue = isEarth ? UnitIcon.BackgroundMode.Earth : UnitIcon.BackgroundMode.PlayerShadow;

  public static void ClearCache()
  {
    UnitIcon.spriteCache_.Clear();
    UnitIcon.spriteSeaCache_.Clear();
  }

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
      EventDelegate.Set(this.Button.onLongPress, new EventDelegate.Callback(buttonEvent.Invoke));
      this.Favorite = playerUnit.favorite;
    }
    this.SelectUnit = false;
    this.SetUnitCache(this.playerUnit.unit, playerUnit.GetElement(), this.playerUnit.job_id);
  }

  private IEnumerator setPlayerUnit(
    PlayerUnit playerUnit,
    System.Action buttonEvent,
    PlayerUnit basePlayerUnit = null)
  {
    UnitIcon unitIcon = this;
    // ISSUE: reference to a compiler-generated method
    IEnumerator e = unitIcon.\u003C\u003En__0(playerUnit, (PlayerUnit[]) null, basePlayerUnit, false, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitIcon.Favorite = false;
    if (playerUnit != (PlayerUnit) null)
    {
      EventDelegate.Set(unitIcon.Button.onLongPress, new EventDelegate.Callback(buttonEvent.Invoke));
      unitIcon.Favorite = playerUnit.favorite;
    }
    unitIcon.SelectUnit = false;
    if (unitIcon.playerUnit != (PlayerUnit) null)
    {
      unitIcon.princessType.SetPrincessType(playerUnit);
      unitIcon.CanAwake = false;
      e = unitIcon.SetUnit(unitIcon.playerUnit, playerUnit.GetElement(), false);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public IEnumerator setSimpleUnit(PlayerUnit playerUnit)
  {
    UnitIcon unitIcon = this;
    // ISSUE: reference to a compiler-generated method
    IEnumerator e = unitIcon.\u003C\u003En__0(playerUnit, (PlayerUnit[]) null, (PlayerUnit) null, false, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitIcon.SelectUnit = false;
    unitIcon.Favorite = false;
    if (unitIcon.playerUnit != (PlayerUnit) null)
    {
      unitIcon.Favorite = playerUnit.favorite;
      e = unitIcon.SetUnit(unitIcon.playerUnit, playerUnit.GetElement(), false);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public IEnumerator setBottomUnit(PlayerUnit playerUnit, PlayerUnit[] playerUnits)
  {
    UnitIcon unitIcon = this;
    // ISSUE: reference to a compiler-generated method
    IEnumerator e = unitIcon.\u003C\u003En__0(playerUnit, playerUnits, (PlayerUnit) null, false, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitIcon.SelectUnit = false;
    unitIcon.Favorite = false;
    unitIcon.icon.enabled = false;
    unitIcon.background.gameObject.SetActive(false);
    if (unitIcon.playerUnit != (PlayerUnit) null)
    {
      unitIcon.Favorite = playerUnit.favorite;
      EventDelegate.Set(unitIcon.Button.onLongPress, (EventDelegate.Callback) (() => Unit0042Scene.changeScene(true, playerUnit, playerUnits)));
      UnitUnit uu = playerUnit.unit;
      if ((UnityEngine.Object) unitIcon.weaponIcon == (UnityEngine.Object) null)
      {
        UnitIcon.SpriteCache spriteCache;
        GameObject self;
        if (UnitIcon.spriteCache.TryGetValue(UnitIcon.makeCacheKey(uu.ID, 0), out spriteCache))
        {
          self = spriteCache.gear;
        }
        else
        {
          Future<GameObject> SetGearPrefab = Res.Icons.GearKindIcon.Load<GameObject>();
          e = SetGearPrefab.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          self = SetGearPrefab.Result;
          SetGearPrefab = (Future<GameObject>) null;
        }
        if ((UnityEngine.Object) self != (UnityEngine.Object) null)
        {
          GameObject gameObject = self.Clone(unitIcon.type.transform);
          unitIcon.weaponIcon = gameObject.GetComponent<GearKindIcon>();
        }
      }
      unitIcon.type.gameObject.SetActive(true);
      unitIcon.weaponIcon.Init(uu.kind, playerUnit.GetElement());
      unitIcon.SetRarities(playerUnit);
      uu = (UnitUnit) null;
    }
  }

  public void setColosseumMatchingUnit(
    int unitId,
    int lv,
    int job_id,
    Dictionary<int, UnitIcon.SpriteCache> cache)
  {
    this.SelectUnit = false;
    this.Favorite = false;
    this.buttonBoxCollider.enabled = false;
    UnitUnit unit = MasterData.UnitUnit[unitId];
    Dictionary<ulong, UnitIcon.SpriteCache> spriteCache = UnitIcon.spriteCache;
    UnitIcon.spriteCache = cache.ToDictionary<KeyValuePair<int, UnitIcon.SpriteCache>, ulong, UnitIcon.SpriteCache>((Func<KeyValuePair<int, UnitIcon.SpriteCache>, ulong>) (v => UnitIcon.makeCacheKey(v.Key, 0)), (Func<KeyValuePair<int, UnitIcon.SpriteCache>, UnitIcon.SpriteCache>) (v => v.Value));
    this.SetUnitCache(unit, unit.GetElement(), job_id);
    UnitIcon.spriteCache = spriteCache;
    this.setLevelText(lv.ToString());
    this.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
  }

  public void SetIconBackColor(Color color) => this.background.color = color;

  public void SetIconBoxCollider(bool b) => this.buttonBoxCollider.enabled = b;

  public static bool IsCache(UnitUnit unit, int metamorId = 0) => UnitIcon.spriteCache.ContainsKey(UnitIcon.makeCacheKey(unit.ID, metamorId));

  public static UnityEngine.Sprite GetSprite(UnitUnit unit, int metamorId = 0)
  {
    if (unit == null)
      return (UnityEngine.Sprite) null;
    UnitIcon.SpriteCache spriteCache;
    return !UnitIcon.spriteCache.TryGetValue(UnitIcon.makeCacheKey(unit.ID, metamorId), out spriteCache) ? (UnityEngine.Sprite) null : spriteCache.thumbnail;
  }

  public static IEnumerator LoadSprite(UnitUnit unit, int metamorId = 0)
  {
    Dictionary<ulong, UnitIcon.SpriteCache> scache = UnitIcon.spriteCache;
    ulong dicKey = UnitIcon.makeCacheKey(unit.ID, metamorId);
    if (unit != null && !scache.ContainsKey(dicKey))
    {
      IEnumerator e = UnitIcon.doCreateSpriteCache(unit, metamorId, (System.Action<UnitIcon.SpriteCache>) (sc => scache[dicKey] = sc));
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator LoadSprite(
    System.Action<UnityEngine.Sprite> callbackLoaded,
    UnitUnit unit,
    int metamorId = 0)
  {
    if (unit != null)
    {
      Dictionary<ulong, UnitIcon.SpriteCache> scache = UnitIcon.spriteCache;
      ulong dicKey = UnitIcon.makeCacheKey(unit.ID, metamorId);
      UnitIcon.SpriteCache spriteCache;
      if (scache.TryGetValue(dicKey, out spriteCache))
      {
        callbackLoaded(spriteCache.thumbnail);
      }
      else
      {
        IEnumerator e = UnitIcon.doCreateSpriteCacheWithoutGearKind(unit, metamorId, (System.Action<UnitIcon.SpriteCache>) (sc =>
        {
          scache[dicKey] = sc;
          callbackLoaded(sc.thumbnail);
        }));
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
  }

  public static Dictionary<int, UnitIcon.SpriteCache> CopyCache() => UnitIcon.spriteCache.Where<KeyValuePair<ulong, UnitIcon.SpriteCache>>((Func<KeyValuePair<ulong, UnitIcon.SpriteCache>, bool>) (x => UnitIcon.splitCacheKey(x.Key).Item2 == 0)).ToDictionary<KeyValuePair<ulong, UnitIcon.SpriteCache>, int, UnitIcon.SpriteCache>((Func<KeyValuePair<ulong, UnitIcon.SpriteCache>, int>) (v => UnitIcon.splitCacheKey(v.Key).Item1), (Func<KeyValuePair<ulong, UnitIcon.SpriteCache>, UnitIcon.SpriteCache>) (v => v.Value));

  public static void RestoreCache(Dictionary<int, UnitIcon.SpriteCache> data) => UnitIcon.spriteCache = data.ToDictionary<KeyValuePair<int, UnitIcon.SpriteCache>, ulong, UnitIcon.SpriteCache>((Func<KeyValuePair<int, UnitIcon.SpriteCache>, ulong>) (k => UnitIcon.makeCacheKey(k.Key, 0)), (Func<KeyValuePair<int, UnitIcon.SpriteCache>, UnitIcon.SpriteCache>) (v => v.Value));

  private static ulong makeCacheKey(int unitId, int metamorId) => ((ulong) metamorId << 32) + (ulong) unitId;

  private static Tuple<int, int> splitCacheKey(ulong v) => Tuple.Create<int, int>((int) v, (int) (v >> 32));

  public IEnumerator SetUnit(
    PlayerUnit plUnit,
    SkillMetamorphosis metamorphosis,
    bool isGray)
  {
    SkillMetamorphosis skillMetamorphosis = metamorphosis;
    int metamorId = skillMetamorphosis != null ? skillMetamorphosis.metamorphosis_id : 0;
    UnitUnit u = plUnit.unit;
    CommonElement element = plUnit.GetElement();
    IEnumerator e = this._SetUnit(plUnit, u, element, isGray, metamorId);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = base.SetUnit(u, element);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override IEnumerator SetUnit(
    PlayerUnit playerUnit,
    CommonElement element,
    bool isGray = false)
  {
    IEnumerator e = this._SetUnit(playerUnit, playerUnit.unit, element, isGray);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = base.SetUnit(playerUnit, element);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override IEnumerator SetUnit(UnitUnit unit, CommonElement element, bool isGray = false)
  {
    IEnumerator e = this._SetUnit((PlayerUnit) null, unit, element, isGray);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = base.SetUnit(unit, element);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private IEnumerator _SetUnit(
    PlayerUnit playerUnit,
    UnitUnit unit,
    CommonElement element,
    bool isGray = false,
    int metamorId = 0)
  {
    UnitIcon unitIcon = this;
    if (unit == null)
    {
      unitIcon.ResetUnit();
    }
    else
    {
      unitIcon.unit = unit;
      Dictionary<ulong, UnitIcon.SpriteCache> scache = UnitIcon.spriteCache;
      ulong cKey = UnitIcon.makeCacheKey(unit.ID, metamorId);
      UnitIcon.SpriteCache s;
      if (!scache.TryGetValue(cKey, out s))
      {
        IEnumerator e = UnitIcon.doCreateSpriteCache(unit, metamorId, (System.Action<UnitIcon.SpriteCache>) (sc =>
        {
          s = sc;
          scache[cKey] = sc;
        }));
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      unitIcon.icon.sprite2D = s.thumbnail;
      unitIcon.icon.width = s.thumbWidth;
      unitIcon.icon.height = s.thumbHeight;
      GameObject gear = s.gear;
      if ((UnityEngine.Object) unitIcon.weaponIcon == (UnityEngine.Object) null && (UnityEngine.Object) gear != (UnityEngine.Object) null)
      {
        GameObject gameObject = gear.Clone(unitIcon.type.transform);
        unitIcon.weaponIcon = gameObject.GetComponent<GearKindIcon>();
      }
      unitIcon.type.gameObject.SetActive(true);
      unitIcon.weaponIcon.Init(unit.kind, element);
      if (playerUnit == (PlayerUnit) null)
        unitIcon.SetRarities(unit);
      else
        unitIcon.SetRarities(playerUnit);
      unitIcon.BackgroundModeValue = UnitIcon.GetBackgroundMode(unit, playerUnit);
      unitIcon.icon.enabled = true;
      if (!unitIcon.icon.gameObject.activeSelf)
        unitIcon.icon.gameObject.SetActive(true);
      if (unitIcon.unknown.activeSelf)
        unitIcon.unknown.SetActive(false);
      unitIcon.BottomModeValue = UnitIconBase.GetBottomMode(unit, playerUnit);
      unitIcon.setupUnityUpValue();
      unitIcon.SelectUnit = false;
      if (isGray)
        unitIcon.Gray = isGray;
      if (unitIcon.IsRecord)
        unitIcon.SetRecordNum();
    }
  }

  private static IEnumerator doCreateSpriteCache(
    UnitUnit unit,
    int metamorId,
    System.Action<UnitIcon.SpriteCache> eventCreated)
  {
    Future<UnityEngine.Sprite> spriteF = metamorId == 0 ? unit.LoadSpriteThumbnail() : unit.LoadSpriteThumbnail(metamorId);
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    int w = spriteF.Result.texture.width;
    int h = spriteF.Result.texture.height;
    Future<GameObject> SetGearPrefab = Res.Icons.GearKindIcon.Load<GameObject>();
    e = SetGearPrefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    eventCreated(new UnitIcon.SpriteCache(spriteF.Result, SetGearPrefab.Result, w, h));
  }

  private static IEnumerator doCreateSpriteCacheWithoutGearKind(
    UnitUnit unit,
    int metamorId,
    System.Action<UnitIcon.SpriteCache> eventCreated)
  {
    Future<UnityEngine.Sprite> spriteF = metamorId == 0 ? unit.LoadSpriteThumbnail() : unit.LoadSpriteThumbnail(metamorId);
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    eventCreated(new UnitIcon.SpriteCache(spriteF.Result, (GameObject) null, 0, 0));
  }

  public override IEnumerator SetUnitWithLongPressAction(
    UnitUnit unit,
    System.Action buttonEvent,
    bool isGray = false)
  {
    UnitIcon unitIcon = this;
    IEnumerator e = unitIcon.SetUnit(unit, unit.GetElement(), isGray);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    EventDelegate.Set(unitIcon.Button.onLongPress, new EventDelegate.Callback(buttonEvent.Invoke));
  }

  public void SetUnitCache(UnitUnit unit, CommonElement element, int job_id = 0)
  {
    this.unit = unit;
    if (unit != null)
    {
      UnitIcon.SpriteCache spriteCache;
      if (UnitIcon.spriteCache.TryGetValue(UnitIcon.makeCacheKey(unit.ID, 0), out spriteCache))
      {
        this.icon.sprite2D = spriteCache.thumbnail;
        this.icon.width = spriteCache.thumbWidth;
        this.icon.height = spriteCache.thumbHeight;
        GameObject gear = spriteCache.gear;
        if ((UnityEngine.Object) this.weaponIcon == (UnityEngine.Object) null && (UnityEngine.Object) gear != (UnityEngine.Object) null)
        {
          GameObject gameObject = gear.Clone(this.type.transform);
          this.weaponIcon = gameObject.GetComponent<GearKindIcon>();
          gameObject.AddComponent<TweenColor>();
        }
        this.type.gameObject.SetActive(true);
        this.weaponIcon.Init(unit.kind, element);
        if (job_id != 0)
        {
          PlayerUnit byUnitunit = PlayerUnit.create_by_unitunit(unit);
          byUnitunit.job_id = job_id;
          this.SetRarities(byUnitunit);
        }
        else
          this.SetRarities(unit);
        this.icon.enabled = true;
        if (!this.icon.gameObject.activeSelf)
          this.icon.gameObject.SetActive(true);
        if (this.unknown.activeSelf)
          this.unknown.SetActive(false);
        this.BackgroundModeValue = UnitIcon.GetBackgroundMode(unit, this.playerUnit);
        this.BottomModeValue = UnitIconBase.GetBottomMode(unit, this.playerUnit);
        this.setupUnityUpValue();
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
    if ((UnityEngine.Object) this.defaultIconSprite != (UnityEngine.Object) null)
    {
      this.icon.sprite2D = this.defaultIconSprite;
      this.icon.width = this.defaultIconSprite.texture.width;
      this.icon.height = this.defaultIconSprite.texture.height;
    }
    this.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    this.rarityStar.gameObject.SetActive(false);
    this.type.gameObject.SetActive(false);
    this.BottomModeValue = UnitIconBase.BottomMode.Nothing;
  }

  public void UnknownUnit()
  {
    this.rarityStar.gameObject.SetActive(false);
    this.favorite.SetActive(false);
    this.newUnit.SetActive(false);
    this.selectUnit.SetActive(false);
    this.unknown.SetActive(true);
    this.background.gameObject.SetActive(false);
    this.BottomBaseObject = true;
    this.icon.gameObject.SetActive(false);
    this.breakWeapon.SetActive(false);
    this.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    this.for_battle.SetActive(false);
    if ((UnityEngine.Object) this.colosseumResultParent != (UnityEngine.Object) null)
      this.colosseumResultParent.gameObject.SetActive(false);
    this.princessType.DispPrincessType(false);
    if ((UnityEngine.Object) this.can_awake != (UnityEngine.Object) null)
      this.can_awake.SetActive(false);
    this.setCombatText("---");
    if (!((UnityEngine.Object) this.weaponIcon != (UnityEngine.Object) null))
      return;
    this.weaponIcon.gameObject.SetActive(false);
  }

  public IEnumerator SetSelectUnit()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    UnitIcon unitIcon = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    unitIcon.SelectUnit = true;
    unitIcon.ResetUnit();
    unitIcon.unit = unitIcon.unit;
    return false;
  }

  public void RarityCenter() => this.rarityStar.transform.localPosition = (Vector3) new Vector2(14f, 1f);

  private void InitializeRemoveButton(bool enable)
  {
    this.background.gameObject.SetActive(!enable);
    this.BottomBaseObject = !enable;
    this.icon.gameObject.SetActive(!enable);
    if (enable)
      this.BackgroundModeValue = UnitIcon.BackgroundMode.Remove;
    else
      this.background.gameObject.SetActive(false);
    this.CanAwake = false;
    this.princessType.DispPrincessType(!enable);
    if ((UnityEngine.Object) this.getPieceObj != (UnityEngine.Object) null)
      this.getPieceObj.SetActive(false);
    if (!enable)
      return;
    this.unit = (UnitUnit) null;
  }

  public bool isViewBackObject
  {
    get => this.background.gameObject.activeSelf;
    set => this.background.gameObject.SetActive(value);
  }

  public void SetEmpty()
  {
    this.rarityStar.gameObject.SetActive(false);
    this.favorite.SetActive(false);
    this.newUnit.SetActive(false);
    this.selectUnit.SetActive(false);
    this.unknown.SetActive(false);
    this.background.gameObject.SetActive(false);
    this.BottomBaseObject = false;
    this.icon.gameObject.SetActive(false);
    this.breakWeapon.SetActive(false);
    this.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    this.for_battle.SetActive(false);
    if ((UnityEngine.Object) this.can_awake != (UnityEngine.Object) null)
      this.can_awake.SetActive(false);
    if ((UnityEngine.Object) this.colosseumResultParent != (UnityEngine.Object) null)
      this.colosseumResultParent.gameObject.SetActive(false);
    if ((UnityEngine.Object) this.dirUnityUpItem != (UnityEngine.Object) null)
      this.dirUnityUpItem.SetActive(false);
    this.princessType.DispPrincessType(false);
    this.SpecialIcon = false;
    this.SpecialIconType = -1;
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
      this.colosseumResultParent.gameObject.SetActive(false);
    }
    else
    {
      int index = (int) result;
      this.colosseumResultParent.gameObject.SetActive(true);
      this.colosseumResultParent.sprite2D = this.colosseumResultSprites[index];
      this.colosseumResultParent.SetDimensions((int) this.backgroundSprites[index].textureRect.width, (int) this.backgroundSprites[index].textureRect.height);
      if ((double) time <= 0.0)
        return;
      this.colosseumResultParent.transform.localScale = new Vector3(scale, scale, 1f);
      iTween.ScaleTo(this.colosseumResultParent.gameObject, iTween.Hash((object) "x", (object) 1f, (object) "y", (object) 1f, (object) nameof (time), (object) time, (object) "easetype", (object) iTween.EaseType.easeInCubic, (object) "oncomplete", (object) "ColosseumResultEnd", (object) "oncompletetarget", (object) this.gameObject));
    }
  }

  private void ColosseumResultEnd()
  {
    if (this.colosseumResultEndFunction == null)
      return;
    this.colosseumResultEndFunction();
  }

  public void SetColosseumResultAlphaLoop(float value = 0.5f, float time = 1f) => iTween.ValueTo(this.gameObject, iTween.Hash((object) "from", (object) 1f, (object) "to", (object) value, (object) nameof (time), (object) time, (object) "looptype", (object) iTween.LoopType.pingPong, (object) "onupdate", (object) "ColosseumResultAlphaLoopUpdate"));

  private void ColosseumResultAlphaLoopUpdate(float value)
  {
    if (!this.colosseumResultParent.gameObject.activeSelf)
      return;
    this.colosseumResultParent.gameObject.GetComponent<UIWidget>().alpha = value;
  }

  public void SetRegulation(UnitIcon.Regulation flg)
  {
    if (flg == UnitIcon.Regulation.None)
    {
      this.regulations.gameObject.SetActive(false);
    }
    else
    {
      this.regulations.transform.localPosition = this.regulationsPosList[(int) flg];
      this.regulations.gameObject.SetActive(true);
    }
  }

  public void SetRegulation(Vector2 localPos)
  {
    this.regulations.transform.localPosition = (Vector3) localPos;
    this.regulations.gameObject.SetActive(true);
  }

  public void HideSeaIcon()
  {
    if ((UnityEngine.Object) this.seaPickupObj != (UnityEngine.Object) null)
      this.seaPickupObj.SetActive(false);
    if ((UnityEngine.Object) this.seaGuestObj != (UnityEngine.Object) null)
      this.seaGuestObj.SetActive(false);
    if (!((UnityEngine.Object) this.getPieceObj != (UnityEngine.Object) null))
      return;
    this.getPieceObj.SetActive(false);
  }

  public void SetSeaPickup()
  {
    if ((UnityEngine.Object) this.seaPickupObj != (UnityEngine.Object) null)
      this.seaPickupObj.SetActive(true);
    if (!((UnityEngine.Object) this.seaGuestObj != (UnityEngine.Object) null))
      return;
    this.seaGuestObj.SetActive(false);
  }

  public void SetSeaGuest()
  {
    if ((UnityEngine.Object) this.seaPickupObj != (UnityEngine.Object) null)
      this.seaPickupObj.SetActive(false);
    if (!((UnityEngine.Object) this.seaGuestObj != (UnityEngine.Object) null))
      return;
    this.seaGuestObj.SetActive(true);
  }

  public void ResetPlayerUnit() => this.playerUnit = (PlayerUnit) null;

  public void SetSeaPiece(bool getablePiece)
  {
    if (!((UnityEngine.Object) this.getPieceObj != (UnityEngine.Object) null))
      return;
    this.getPieceObj.SetActive(getablePiece);
  }

  public void setBlinkUnityValue(int trueUnity, float buildupUnity)
  {
    int num = 0;
    if ((UnityEngine.Object) this.dirTrueUnity != (UnityEngine.Object) null && trueUnity > 0)
    {
      this.dirTrueUnity.SetActive(true);
      UILabel txtTrueUnityValue = this.txtTrueUnityValue;
      if (txtTrueUnityValue != null)
        txtTrueUnityValue.SetTextLocalize(trueUnity);
      ++num;
    }
    if ((UnityEngine.Object) this.dirBuildUpUnity != (UnityEngine.Object) null && (double) buildupUnity > 0.0)
    {
      this.dirBuildUpUnity.SetActive(true);
      UILabel buildUpUnityValue = this.txtBuildUpUnityValue;
      if (buildUpUnityValue != null)
        buildUpUnityValue.SetTextLocalize(PlayerUnit.UnityToPercent(buildupUnity).ToString() + "%");
      ++num;
    }
    if (num <= 0)
      return;
    this.dirUnity.SetActive(true);
    if (num <= 1)
      return;
    NGxBlinkEx component = this.dirUnity.GetComponent<NGxBlinkEx>();
    component?.SetChildren(new GameObject[2]
    {
      this.dirTrueUnity,
      this.dirBuildUpUnity
    });
    component?.ResetTween();
  }

  private void setupUnityUpValue()
  {
    if ((UnityEngine.Object) this.dirUnityUpItem == (UnityEngine.Object) null)
      return;
    if (!this.unit.is_unity_value_up || this.unit.IsPureValueUp)
    {
      this.dirUnityUpItem.SetActive(false);
    }
    else
    {
      this.dirUnityUpItem.SetActive(true);
      UnityValueUpPattern unityValueUpPattern = Array.Find<UnityValueUpPattern>(MasterData.UnityValueUpPatternList, (Predicate<UnityValueUpPattern>) (x => x.material_unit_UnitUnit == this.unit.ID));
      if (unityValueUpPattern == null)
        return;
      int percent = PlayerUnit.UnityToPercent(unityValueUpPattern.up_value);
      this.txtUnityUpValue.spacingX = percent >= 1000 ? 0 : 5;
      this.txtUnityUpValue.SetTextLocalize(percent);
    }
  }

  protected override void showBottomInfoEx(UnitSortAndFilter.SORT_TYPES sort, GameObject target)
  {
    if (!this.EnabledExpireDate || (UnityEngine.Object) this.bottomBlink == (UnityEngine.Object) null || (UnityEngine.Object) target == (UnityEngine.Object) null)
      return;
    if (this.bottomBlink.gameObject.activeSelf)
    {
      this.bottomBlink.gameObject.SetActive(false);
      this.bottomBlink.resetBlinks();
    }
    foreach (GameObject remainDay in this.remainDays)
      remainDay.SetActive(false);
    List<GameObject> gameObjectList = new List<GameObject>(2)
    {
      target
    };
    DateTime? nullable1;
    if (this.unit == null)
    {
      PlayerUnit playerUnit = this.playerUnit;
      nullable1 = (object) playerUnit != null ? playerUnit.unit?.expire_date?.end_at : new DateTime?();
    }
    else
      nullable1 = this.unit.expire_date?.end_at;
    DateTime? nullable2 = nullable1;
    if (nullable2.HasValue)
    {
      int index = sort == UnitSortAndFilter.SORT_TYPES.UnityValue || sort == UnitSortAndFilter.SORT_TYPES.PossessionNumber ? 1 : 0;
      DateTime dateTime1 = ServerTime.NowAppTimeAddDelta();
      DateTime? nullable3 = nullable2;
      DateTime dateTime2 = dateTime1;
      int num1;
      if ((nullable3.HasValue ? (nullable3.GetValueOrDefault() > dateTime2 ? 1 : 0) : 0) == 0)
      {
        num1 = 0;
      }
      else
      {
        nullable3 = nullable2;
        DateTime dateTime3 = dateTime1;
        num1 = Mathf.Min((int) (nullable3.HasValue ? new TimeSpan?(nullable3.GetValueOrDefault() - dateTime3) : new TimeSpan?()).Value.TotalDays, 99);
      }
      int num2 = num1;
      this.txtRemainDays[index].SetTextLocalize(num2);
      this.remainDays[index].SetActive(true);
      gameObjectList.Add(this.remainDays[index]);
    }
    GameObject[] array = gameObjectList.ToArray();
    if (array.Length <= 1)
      return;
    this.bottomBlink.gameObject.SetActive(true);
    this.bottomBlink.resetBlinks((IEnumerable<GameObject>) array);
  }

  public void clearBottomBlinks()
  {
    if ((UnityEngine.Object) this.bottomBlink == (UnityEngine.Object) null || !this.bottomBlink.gameObject.activeSelf)
      return;
    this.bottomBlink.gameObject.SetActive(false);
    this.bottomBlink.resetBlinks();
  }

  public class SpriteCache
  {
    public UnityEngine.Sprite thumbnail;
    public GameObject gear;
    public int thumbWidth;
    public int thumbHeight;

    public SpriteCache(UnityEngine.Sprite s, GameObject o, int w, int h)
    {
      this.thumbnail = s;
      this.gear = o;
      this.thumbWidth = w;
      this.thumbHeight = h;
    }
  }

  public enum ColosseumResult
  {
    WIN,
    DROW,
    LOSE,
    NONE,
  }

  public enum BackgroundMode
  {
    PlayerShadow,
    EnemyShadow,
    Visible,
    Empty,
    Earth,
    Remove,
    AwakeUnit,
    Call,
  }

  public enum Regulation
  {
    Default,
    WithBroken,
    None,
  }
}
