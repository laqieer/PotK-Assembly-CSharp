// Decompiled with JetBrains decompiler
// Type: UnitDetailIcon
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
public class UnitDetailIcon : UnitIconBase
{
  public GameObject unitIconPrefab;
  public GameObject unitIconParent;
  public UI2DSprite upiconSpriteAtk;
  public UI2DSprite upiconSpriteDef;
  public UI2DSprite upiconSpriteHp;
  public UI2DSprite upiconSpriteMatk;
  public UI2DSprite upiconSpriteMtl;
  public UI2DSprite upiconSpriteSpe;
  public UI2DSprite upiconSpriteTec;
  public UI2DSprite upiconSpriteLuck;
  public UI2DSprite[] upiconSprites;
  public GameObject[] upiconEffect;
  public GameObject blink;
  public GameObject skillUp;
  public static readonly int Width = 120;
  public static readonly int Height = 264;
  public static readonly int ColumnValue = 5;
  public static readonly int RowValue = 6;
  public static readonly int RowScreenValue = 3;
  public static readonly int ScreenValue = UnitDetailIcon.ColumnValue * UnitDetailIcon.RowScreenValue;
  public static readonly int MaxValue = UnitDetailIcon.ColumnValue * UnitDetailIcon.RowValue;
  public static readonly int SKILL_ID_ALL = 99;
  private static Dictionary<int, UnitDetailIcon.SpriteCache> spriteCache = new Dictionary<int, UnitDetailIcon.SpriteCache>();

  public static void ClearCache() => UnitDetailIcon.spriteCache.Clear();

  public static bool IsCache(UnitUnit unit) => UnitDetailIcon.spriteCache.ContainsKey(unit.ID);

  [DebuggerHidden]
  public static IEnumerator LoadSprite(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CLoadSprite\u003Ec__Iterator92D()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit
    };
  }

  private void Awake()
  {
    this.UnitIcon = this.unitIconPrefab.CloneAndGetComponent<UnitIcon>(this.unitIconParent);
    ((Collider) this.UnitIcon.buttonBoxCollider).enabled = false;
    this.txtNum = this.UnitIcon.txtNum;
    this.bottomNum = ((Component) ((Component) this.UnitIcon.txtNum).transform.parent).gameObject;
    this.bottomCost = ((Component) ((Component) this.UnitIcon.txtCost).transform.parent).gameObject;
    this.bottomLevel = ((Component) ((Component) this.UnitIcon.textLevels[0]).transform.parent).gameObject;
    this.bottomRarity = ((Component) ((Component) this.UnitIcon.rarityStar).transform.parent).gameObject;
    this.for_battle = this.UnitIcon.for_battle;
    this.equip = this.UnitIcon.equip;
    this.numberBase = this.UnitIcon.numberBase;
    this.numbers = this.UnitIcon.numbers;
  }

  public bool SkillUp
  {
    get => this.skillUp.activeSelf;
    set => this.skillUp.SetActive(value);
  }

  public void SetSprite(UnitUnit unit)
  {
    ((IEnumerable<UI2DSprite>) this.upiconSprites).ForEach<UI2DSprite>((Action<UI2DSprite>) (x => ((Component) x).gameObject.SetActive(true)));
    ((IEnumerable<GameObject>) this.upiconEffect).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    int num = 0;
    if (!unit.IsBuildup)
    {
      if (num < 4 && unit.hp_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteHp.sprite2D;
      if (num < 4 && unit.strength_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteAtk.sprite2D;
      if (num < 4 && unit.vitality_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteDef.sprite2D;
      if (num < 4 && unit.intelligence_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMatk.sprite2D;
      if (num < 4 && unit.mind_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMtl.sprite2D;
      if (num < 4 && unit.agility_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteSpe.sprite2D;
      if (num < 4 && unit.dexterity_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteTec.sprite2D;
      if (num < 4 && unit.lucky_compose != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteLuck.sprite2D;
    }
    else
    {
      if (num < 4 && unit.hp_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteHp.sprite2D;
      if (num < 4 && unit.strength_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteAtk.sprite2D;
      if (num < 4 && unit.vitality_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteDef.sprite2D;
      if (num < 4 && unit.intelligence_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMatk.sprite2D;
      if (num < 4 && unit.mind_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteMtl.sprite2D;
      if (num < 4 && unit.agility_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteSpe.sprite2D;
      if (num < 4 && unit.dexterity_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteTec.sprite2D;
      if (num < 4 && unit.lucky_buildup != 0)
        this.upiconSprites[num++].sprite2D = this.upiconSpriteLuck.sprite2D;
      for (int index = 0; index < num; ++index)
      {
        this.upiconEffect[index].SetActive(true);
        TweenColor component = this.upiconEffect[index].GetComponent<TweenColor>();
        component.ResetToBeginning();
        component.PlayForward();
      }
    }
    while (num < 4)
      ((Component) this.upiconSprites[num++]).gameObject.SetActive(false);
  }

  private void InitializeLabel()
  {
    this.blink.SetActive(false);
    this.BreakThrough = false;
    this.SkillUp = false;
  }

  private void SetLabel(PlayerUnit playerUnit, PlayerUnit basePlayerUnit)
  {
    this.InitializeLabel();
    bool flag1 = basePlayerUnit.unit.ID == playerUnit.unit.ID && basePlayerUnit.breakthrough_count < basePlayerUnit.unit.breakthrough_limit;
    IEnumerable<PlayerUnitSkills> source = ((IEnumerable<PlayerUnitSkills>) basePlayerUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.level < x.skill.upper_level));
    bool flag2 = source.Any<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (unitBase => ((IEnumerable<PlayerUnitSkills>) playerUnit.skills).Count<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (unit => unitBase.skill_id == unit.skill_id)) > 0));
    if (playerUnit.unit.same_character_id == basePlayerUnit.unit.same_character_id && source.Count<PlayerUnitSkills>() > 0)
      flag2 = true;
    if (flag1 && flag2)
      this.blink.SetActive(true);
    else if (flag1)
      this.BreakThrough = true;
    else
      this.SkillUp |= flag2;
  }

  [DebuggerHidden]
  public override IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CSetMaterialUnit\u003Ec__Iterator92E()
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
  public override IEnumerator SetMaterialUnit(
    PlayerUnit playerUnit,
    PlayerUnit basePlayerUnit,
    bool isNew,
    PlayerUnit[] playerUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CSetMaterialUnit\u003Ec__Iterator92F()
    {
      playerUnit = playerUnit,
      isNew = isNew,
      playerUnits = playerUnits,
      basePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u003Ef__this = this
    };
  }

  public static bool IsSkillUpMaterial(PlayerUnit unit, PlayerUnit baseUnit)
  {
    bool flag;
    if (unit.unit.skillup_type != 0)
    {
      int[] array = ((IEnumerable<PlayerUnitSkills>) baseUnit.skills).Where<PlayerUnitSkills>((Func<PlayerUnitSkills, bool>) (x => x.level < x.skill.upper_level)).Select<PlayerUnitSkills, int>((Func<PlayerUnitSkills, int>) (y => (int) y.skill.skill_type)).ToArray<int>();
      int materialSkillUpType = unit.unit.skillup_type;
      flag = array.Length > 0 && materialSkillUpType == UnitDetailIcon.SKILL_ID_ALL || ((IEnumerable<int>) array).Any<int>((Func<int, bool>) (target => target == materialSkillUpType));
    }
    else
      flag = false;
    return flag;
  }

  [DebuggerHidden]
  public override IEnumerator SetPlayerUnit(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CSetPlayerUnit\u003Ec__Iterator930()
    {
      playerUnit = playerUnit,
      playerUnits = playerUnits,
      basePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
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
    return (IEnumerator) new UnitDetailIcon.\u003CSetPlayerUnitEvolution\u003Ec__Iterator931()
    {
      playerUnit = playerUnit,
      playerUnits = playerUnits,
      basePlayerUnit = basePlayerUnit,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EbasePlayerUnit = basePlayerUnit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator SetUnit(UnitUnit unit, CommonElement element, bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CSetUnit\u003Ec__Iterator932()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnit(PlayerUnit unit, bool isGray = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitDetailIcon.\u003CSetUnit\u003Ec__Iterator933()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
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
    this.UnitIcon.BackgroundModeValue = UnitIcon.BackgroundMode.PlayerShadow;
    ((Component) this.UnitIcon.rarityStar).gameObject.SetActive(false);
    ((Component) this.UnitIcon.type).gameObject.SetActive(false);
    this.UnitIcon.BottomModeValue = UnitIcon.BottomMode.Nothing;
  }

  public IEnumerator SetSelectUnit()
  {
    int num = 0;
    while (num < 4)
      ((Component) this.upiconSprites[num++]).gameObject.SetActive(false);
    this.UnitIcon.SetEmpty();
    this.UnitIcon.SelectUnit = true;
    return this.UnitIcon.SetSelectUnit();
  }

  public void SetMaterialUnitCache(PlayerUnit playerUnit, bool isNew, PlayerUnit[] playerUnits)
  {
    this.playerUnit = playerUnit;
    if (playerUnit != (PlayerUnit) null)
      EventDelegate.Set(this.button.onLongPress, (EventDelegate.Callback) (() =>
      {
        if (this.pressEvent != null)
          this.pressEvent();
        Unit0042Scene.changeScene(true, playerUnit, playerUnits);
      }));
    this.UnitIcon.princessType.DispPrincessType(false);
    this.InitializeLabel();
    this.SetUnitCache(this.playerUnit);
    this.BreakThrough |= playerUnit.unit.IsBreakThrough;
    this.SkillUp |= playerUnit.unit.IsMaterialUnitSkillUp;
  }

  public void SetPlayerUnitCache(
    PlayerUnit playerUnit,
    PlayerUnit[] playerUnits,
    PlayerUnit basePlayerUnit = null)
  {
    this.playerUnit = playerUnit;
    if (playerUnit != (PlayerUnit) null)
      EventDelegate.Set(this.button.onLongPress, (EventDelegate.Callback) (() =>
      {
        if (this.pressEvent != null)
          this.pressEvent();
        Unit0042Scene.changeScene(true, playerUnit, playerUnits);
      }));
    this.SetSprite(playerUnit.unit);
    this.UnitIcon.princessType.SetPrincessType(playerUnit);
    if (basePlayerUnit != (PlayerUnit) null)
    {
      this.SetLabel(playerUnit, basePlayerUnit);
      NGTween.playTweens(((Component) this).GetComponentsInChildren<UITweener>(true), NGTween.Kind.GRAYOUT, true);
    }
    this.SetUnitCache(this.playerUnit);
  }

  public void SetUnitCache(PlayerUnit unit, bool isGray = false)
  {
    this.UnitIcon.SetUnitCache(unit.unit, unit.GetElement());
    this.unit = unit.unit;
    this.UnitIcon.setLevelText(this.playerUnit);
    this.UnitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.BranchOfAnArmy);
    this.UnitIcon.setCostText(this.playerUnit);
    this.UnitIcon.Favorite = this.playerUnit.favorite;
    this.SetSprite(unit.unit);
  }

  private class SpriteCache
  {
    public Sprite thumbnail;
    public GameObject gear;

    public SpriteCache(Sprite s, GameObject o)
    {
      this.thumbnail = s;
      this.gear = o;
    }
  }
}
