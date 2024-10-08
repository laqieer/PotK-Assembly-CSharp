﻿// Decompiled with JetBrains decompiler
// Type: Unit004431Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using EquipmentRules;
using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Scenes/unit004_6_8/Unit004431Menu")]
public class Unit004431Menu : UnitMenuBase
{
  public Unit004431Menu.Param sendParam;
  private PlayerUnit[] PlayerUnits;
  private GameObject prefab_Result;
  protected PlayerItem choiceGear;
  private PlayerUnit TakeOffUnit;
  protected bool isEarthMode;
  private GameObject StatusChangePopupPrefab;

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public virtual void InitializeAllUnitInfosExtend()
  {
    GearGear gear = this.choiceGear.gear;
    PlayerUnitGearProficiency playerGearProficiency = (PlayerUnitGearProficiency) null;
    foreach (UnitIconInfo allUnitInfo in this.allUnitInfos)
    {
      if (!(allUnitInfo.playerUnit == (PlayerUnit) null))
      {
        if (gear.is_jingi)
        {
          int primaryGearKind = (int) allUnitInfo.playerUnit.unit.primaryGearKind;
          playerGearProficiency = Array.Find<PlayerUnitGearProficiency>(allUnitInfo.playerUnit.gear_proficiencies, (Predicate<PlayerUnitGearProficiency>) (y => y.gear_kind_id == primaryGearKind));
        }
        int id = allUnitInfo.playerUnit.id;
        PlayerUnit takeOffUnit = this.TakeOffUnit;
        int? nullable = (object) takeOffUnit != null ? new int?(takeOffUnit.id) : new int?();
        int valueOrDefault = nullable.GetValueOrDefault();
        if (id == valueOrDefault & nullable.HasValue)
          allUnitInfo.button_enable = false;
        else if (!gear.checkCanEquipByProficiency(allUnitInfo.playerUnit, playerGearProficiency))
        {
          allUnitInfo.gray = true;
          allUnitInfo.button_enable = false;
        }
      }
    }
  }

  public virtual IEnumerator Init(
    Player player,
    PlayerUnit[] playerUnits,
    Unit004431Menu.Param sendParam,
    bool isEquip)
  {
    Unit004431Menu unit004431Menu = this;
    IEnumerator e = unit004431Menu.Initialize();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Future<GameObject> popupPrefabF = Res.Prefabs.popup.popup_004_4_1__anim_popup01.Load<GameObject>();
    e = popupPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unit004431Menu.StatusChangePopupPrefab = popupPrefabF.Result;
    unit004431Menu.prefab_Result = (GameObject) null;
    Future<GameObject> popupF = Res.Prefabs.popup.popup_004_12_4__anim_popup01.Load<GameObject>();
    e = popupF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unit004431Menu.prefab_Result = popupF.Result;
    unit004431Menu.sendParam = sendParam;
    unit004431Menu.PlayerUnits = playerUnits;
    sendParam.index = 1;
    unit004431Menu.resetChoiceGear();
    unit004431Menu.resetTakeOffUnit(playerUnits);
    PlayerUnit[] canEquippedUnits = unit004431Menu.getCanEquippedUnits(playerUnits);
    if (unit004431Menu.choiceGear.ForBattle)
    {
      // ISSUE: reference to a compiler-generated method
      unit004431Menu.InitializeInfo((IEnumerable<PlayerUnit>) canEquippedUnits, (IEnumerable<PlayerMaterialUnit>) null, Persist.unit004431SortAndFilter, isEquip, true, !unit004431Menu.isEarthMode, !unit004431Menu.isEarthMode, false, new System.Action(unit004431Menu.\u003CInit\u003Eb__10_0));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      unit004431Menu.InitializeInfo((IEnumerable<PlayerUnit>) canEquippedUnits, (IEnumerable<PlayerMaterialUnit>) null, Persist.unit004431SortAndFilter, isEquip, false, !unit004431Menu.isEarthMode, !unit004431Menu.isEarthMode, false, new System.Action(unit004431Menu.\u003CInit\u003Eb__10_1));
    }
    e = unit004431Menu.CreateUnitIcon();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unit004431Menu.InitializeEnd();
  }

  public IEnumerator updateMenu(PlayerUnit[] playerUnits)
  {
    Unit004431Menu unit004431Menu = this;
    unit004431Menu.PlayerUnits = playerUnits;
    unit004431Menu.resetChoiceGear();
    unit004431Menu.resetTakeOffUnit(playerUnits);
    PlayerUnit[] canEquippedUnits = unit004431Menu.getCanEquippedUnits(playerUnits);
    IEnumerator e = unit004431Menu.UpdateInfoAndScroll(canEquippedUnits);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void resetChoiceGear() => this.choiceGear = Array.Find<PlayerItem>(this.GetAllGears(SMManager.Get<PlayerItem[]>()), (Predicate<PlayerItem>) (x => x.id == this.sendParam.gearId));

  private void resetTakeOffUnit(PlayerUnit[] playerUnits)
  {
    this.TakeOffUnit = Array.Find<PlayerUnit>(playerUnits, (Predicate<PlayerUnit>) (x =>
    {
      PlayerItem equippedGear = x.equippedGear;
      int? nullable1 = (object) equippedGear != null ? new int?(equippedGear.id) : new int?();
      int gearId1 = this.sendParam.gearId;
      if (!(nullable1.GetValueOrDefault() == gearId1 & nullable1.HasValue))
      {
        PlayerItem equippedGear2 = x.equippedGear2;
        int? nullable2 = (object) equippedGear2 != null ? new int?(equippedGear2.id) : new int?();
        int gearId2 = this.sendParam.gearId;
        if (!(nullable2.GetValueOrDefault() == gearId2 & nullable2.HasValue))
        {
          PlayerItem equippedGear3 = x.equippedGear3;
          int? nullable3 = (object) equippedGear3 != null ? new int?(equippedGear3.id) : new int?();
          int gearId3 = this.sendParam.gearId;
          return nullable3.GetValueOrDefault() == gearId3 & nullable3.HasValue;
        }
      }
      return true;
    }));
    List<int> intList;
    if (!(this.TakeOffUnit != (PlayerUnit) null))
    {
      intList = (List<int>) null;
    }
    else
    {
      intList = new List<int>();
      intList.Add(this.TakeOffUnit.id);
    }
    this.firstPositionUnitIds = intList;
  }

  protected virtual PlayerUnit[] getCanEquippedUnits(PlayerUnit[] playerUnits)
  {
    if (this.choiceGear == (PlayerItem) null)
      return new PlayerUnit[0];
    Func<PlayerUnit, int> getEquipNo = this.funcGetEquipNo;
    return ((IEnumerable<PlayerUnit>) playerUnits).Where<PlayerUnit>((Func<PlayerUnit, bool>) (x => this.TakeOffUnit == x || Gears.createFuncPossibleEquipped(x, getEquipNo(x) - 1)(this.choiceGear))).ToArray<PlayerUnit>();
  }

  private Func<PlayerUnit, int> funcGetEquipNo => this.choiceGear.gear.kind.is_attack ? (Func<PlayerUnit, int>) (_ => 1) : (Func<PlayerUnit, int>) (x => !x.unit.awake_unit_flag ? 1 : 2);

  protected virtual PlayerItem[] GetAllGears(PlayerItem[] items) => items;

  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    IEnumerator e = base.CreateUnitIcon(info_index, unit_index, baseUnit);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.CreateUnitIconAction(info_index, unit_index);
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.CreateUnitIconAction(info_index, unit_index);
  }

  private IEnumerator StatusPopup(
    PlayerUnit baseUnit,
    PlayerItem beforeGear,
    PlayerItem afterGear,
    int gearIndex)
  {
    Future<GameObject> iconPrefabF = Res.Prefabs.ItemIcon.prefab.Load<GameObject>();
    IEnumerator e = iconPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject iconPrefab = iconPrefabF.Result;
    GameObject beforeGearIcon = UnityEngine.Object.Instantiate<GameObject>(iconPrefab);
    ItemIcon beforeGearIconScript = beforeGearIcon.GetComponent<ItemIcon>();
    if (beforeGear != (PlayerItem) null)
    {
      ItemIcon itemIcon = beforeGearIconScript;
      GearGear gear = beforeGear.gear;
      int element = (int) beforeGear.GetElement();
      PlayerItem equipReisou = beforeGear.equipReisou;
      GearGear setReisou = (object) equipReisou != null ? equipReisou.gear : (GearGear) null;
      e = itemIcon.InitByGear(gear, (CommonElement) element, setReisou: setReisou);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else
    {
      e = beforeGearIconScript.InitByGear((GearGear) null);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      beforeGearIconScript.SetEmpty(true);
    }
    GameObject afterGearIcon = UnityEngine.Object.Instantiate<GameObject>(iconPrefab);
    ItemIcon afterGearIconScript = afterGearIcon.GetComponent<ItemIcon>();
    if (afterGear != (PlayerItem) null)
    {
      ItemIcon itemIcon = afterGearIconScript;
      GearGear gear = afterGear.gear;
      int element = (int) afterGear.GetElement();
      PlayerItem equipReisou = afterGear.equipReisou;
      GearGear setReisou = (object) equipReisou != null ? equipReisou.gear : (GearGear) null;
      e = itemIcon.InitByGear(gear, (CommonElement) element, setReisou: setReisou);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else
    {
      e = afterGearIconScript.InitByGear((GearGear) null);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      afterGearIconScript.SetEmpty(true);
    }
    Future<GameObject> skillTypeIconLoader = Res.Prefabs.BattleSkillIcon._battleSkillIcon.Load<GameObject>();
    e = skillTypeIconLoader.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject skillTypeIconPrefab = skillTypeIconLoader.Result;
    List<GameObject> beforeSkillTypeIcons = new List<GameObject>();
    GearGearSkill[] gearGearSkillArray;
    int index;
    GameObject beforeSkillTypeIcon;
    if (beforeGear != (PlayerItem) null)
    {
      gearGearSkillArray = beforeGear.skills;
      for (index = 0; index < gearGearSkillArray.Length; ++index)
      {
        GearGearSkill gearGearSkill = gearGearSkillArray[index];
        beforeSkillTypeIcon = UnityEngine.Object.Instantiate<GameObject>(skillTypeIconPrefab);
        e = beforeSkillTypeIcon.GetComponent<BattleSkillIcon>().Init(gearGearSkill.skill);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        beforeSkillTypeIcons.Add(beforeSkillTypeIcon);
        beforeSkillTypeIcon = (GameObject) null;
      }
      gearGearSkillArray = (GearGearSkill[]) null;
    }
    List<GameObject> afterSkillTypeIcons = new List<GameObject>();
    if (afterGear != (PlayerItem) null && afterGear.skills.Length != 0)
    {
      gearGearSkillArray = afterGear.skills;
      for (index = 0; index < gearGearSkillArray.Length; ++index)
      {
        GearGearSkill gearGearSkill = gearGearSkillArray[index];
        beforeSkillTypeIcon = UnityEngine.Object.Instantiate<GameObject>(skillTypeIconPrefab);
        e = beforeSkillTypeIcon.GetComponent<BattleSkillIcon>().Init(gearGearSkill.skill);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        afterSkillTypeIcons.Add(beforeSkillTypeIcon);
        beforeSkillTypeIcon = (GameObject) null;
      }
      gearGearSkillArray = (GearGearSkill[]) null;
    }
    GameObject statusPopup = this.StatusChangePopupPrefab.Clone();
    Unit00441Menu component = statusPopup.GetComponent<Unit00441Menu>();
    statusPopup.SetActive(false);
    beforeGearIcon.SetActive(false);
    afterGearIcon.SetActive(false);
    e = component.SetGear((PlayerUnit) null, baseUnit, beforeGear, afterGear, beforeGearIcon, afterGearIcon, beforeSkillTypeIcons.ToArray(), afterSkillTypeIcons.ToArray(), gearIndex, this.isEarthMode);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Singleton<PopupManager>.GetInstance().open(statusPopup, isCloned: true);
    statusPopup.SetActive(true);
    beforeGearIcon.SetActive(true);
    afterGearIcon.SetActive(true);
  }

  private void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo unitInfo = this.displayUnitInfos[info_index];
    if (unitInfo.removeButton)
    {
      unitIcon.onClick = (System.Action<UnitIconBase>) (_ => this.RemoveGear(this.TakeOffUnit));
    }
    else
    {
      if (unitInfo.button_enable)
      {
        unitIcon.onClick = (System.Action<UnitIconBase>) (ui =>
        {
          if (!(unitIcon.PlayerUnit != (PlayerUnit) null))
            return;
          int num = this.funcGetEquipNo(unitIcon.PlayerUnit);
          PlayerItem beforeGear = num == 1 ? unitIcon.PlayerUnit.equippedGear : unitIcon.PlayerUnit.equippedGear2;
          if (this.TakeOffUnit != (PlayerUnit) null)
            Singleton<PopupManager>.GetInstance().open(this.prefab_Result).GetComponent<Unit004431Popup>().Init(this.PlayerUnits, unitIcon.PlayerUnit, this.choiceGear, num, this.isEarthMode);
          else
            this.StartCoroutine(this.StatusPopup(unitIcon.PlayerUnit, beforeGear, this.choiceGear, num));
        });
      }
      else
      {
        unitIcon.onClick = (System.Action<UnitIconBase>) (_ => {});
        unitIcon.Gray = true;
      }
      EventDelegate.Set(unitIcon.Button.onLongPress, (EventDelegate.Callback) (() => this.ChangeDetailScene(unitInfo.playerUnit)));
    }
  }

  protected virtual void ChangeDetailScene(PlayerUnit unit) => Unit0042Scene.changeSceneEvolutionUnit(true, unit, this.getUnits());

  private void RemoveGear(PlayerUnit baseUnit)
  {
    int?[] nullableArray = new int?[3];
    PlayerItem equippedGear = baseUnit.equippedGear;
    nullableArray[0] = (object) equippedGear != null ? new int?(equippedGear.id) : new int?();
    PlayerItem equippedGear2 = baseUnit.equippedGear2;
    nullableArray[1] = (object) equippedGear2 != null ? new int?(equippedGear2.id) : new int?();
    PlayerItem equippedGear3 = baseUnit.equippedGear3;
    nullableArray[2] = (object) equippedGear3 != null ? new int?(equippedGear3.id) : new int?();
    this.sendParam.index = ((IEnumerable<int?>) nullableArray).FirstIndexOrNull<int?>((Func<int?, bool>) (i =>
    {
      int id = this.choiceGear.id;
      int? nullable = i;
      int valueOrDefault = nullable.GetValueOrDefault();
      return id == valueOrDefault & nullable.HasValue;
    })).Value + 1;
    this.StartCoroutine(this.RemoveGearAsync(baseUnit));
  }

  private IEnumerator RemoveGearAsync(PlayerUnit baseUnit)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    IEnumerator e = RequestDispatcher.EquipGear(this.sendParam.index, new int?(0), baseUnit.id, (System.Action<WebAPI.Response.UserError>) (error =>
    {
      if (error == null)
        return;
      WebAPI.DefaultUserErrorCallback(error);
    }), this.isEarthMode);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    // ISSUE: reference to a compiler-generated method
    this.\u003C\u003En__1();
  }

  public class Param
  {
    public int gearKindId;
    public int gearId;
    public int index;
  }
}
