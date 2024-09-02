// Decompiled with JetBrains decompiler
// Type: Unit004431Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit004431Menu : UnitMenuBase
{
  public Unit004431Menu.Param sendParam;
  private PlayerUnit[] PlayerUnits;
  private GameObject prefab_Result;
  private PlayerItem choiceGear;
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
    this.allUnitInfos.ForEach((Action<UnitIconInfo>) (x =>
    {
      if (!(x.playerUnit != (PlayerUnit) null) || this.choiceGear.gear.isEquipment(x.playerUnit))
        return;
      x.gray = true;
      x.button_enable = false;
    }));
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(
    Player player,
    PlayerUnit[] playerUnits,
    Unit004431Menu.Param sendParam,
    bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Menu.\u003CInit\u003Ec__Iterator344()
    {
      sendParam = sendParam,
      playerUnits = playerUnits,
      isEquip = isEquip,
      \u003C\u0024\u003EsendParam = sendParam,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u003Ef__this = this
    };
  }

  protected virtual PlayerItem[] GetAllGears(PlayerItem[] items) => items.AllGearsWithEquip();

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Menu.\u003CCreateUnitIcon\u003Ec__Iterator345()
    {
      info_index = info_index,
      unit_index = unit_index,
      baseUnit = baseUnit,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  protected override void CreateUnitIconCache(int info_index, int unit_index, PlayerUnit baseUnit = null)
  {
    base.CreateUnitIconCache(info_index, unit_index);
    this.CreateUnitIconAction(info_index, unit_index);
  }

  [DebuggerHidden]
  private IEnumerator StatusPopup(PlayerUnit baseUnit, PlayerItem beforeGear, PlayerItem afterGear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Menu.\u003CStatusPopup\u003Ec__Iterator346()
    {
      beforeGear = beforeGear,
      afterGear = afterGear,
      baseUnit = baseUnit,
      \u003C\u0024\u003EbeforeGear = beforeGear,
      \u003C\u0024\u003EafterGear = afterGear,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  private void CreateUnitIconAction(int info_index, int unit_index)
  {
    UnitIconBase unitIcon = this.allUnitIcons[unit_index];
    UnitIconInfo unitInfo = this.displayUnitInfos[info_index];
    if (unitInfo.removeButton)
    {
      unitIcon.onClick = (Action<UnitIconBase>) (iconBase => this.RemoveGear(this.TakeOffUnit));
    }
    else
    {
      if (this.TakeOffUnit != (PlayerUnit) null && this.TakeOffUnit.id == unitInfo.playerUnit.id)
        unitInfo.button_enable = false;
      unitIcon.onClick = (Action<UnitIconBase>) (ui =>
      {
        if (unitIcon.PlayerUnit != (PlayerUnit) null)
        {
          PlayerItem beforeGear = (PlayerItem) null;
          if (unitIcon.PlayerUnit.equippedGear != (PlayerItem) null)
          {
            int? beforeEquip = unitIcon.PlayerUnit.equip_gear_ids[0];
            beforeGear = ((IEnumerable<PlayerItem>) this.GetAllGears(SMManager.Get<PlayerItem[]>())).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.id == beforeEquip.GetValueOrDefault() && beforeEquip.HasValue)).First<PlayerItem>();
          }
          if (this.TakeOffUnit != (PlayerUnit) null)
            Singleton<PopupManager>.GetInstance().open(this.prefab_Result).GetComponent<Unit004431Popup>().Init(this.PlayerUnits, unitIcon.PlayerUnit, this.choiceGear, 1, this.isEarthMode);
          else
            this.StartCoroutine(this.StatusPopup(unitIcon.PlayerUnit, beforeGear, this.choiceGear));
        }
        else
          Debug.LogWarning((object) "PlayerUnit Null : Unit004431Menu");
      });
      EventDelegate.Set(unitIcon.button.onLongPress, (EventDelegate.Callback) (() => this.ChangeDetailScehe(unitInfo.playerUnit)));
    }
    if (unitInfo.button_enable)
      return;
    unitIcon.onClick = (Action<UnitIconBase>) (_ => { });
    unitIcon.Gray = true;
  }

  private bool CheckProficiencie(PlayerUnit unit, PlayerItem gear)
  {
    return gear.gear.kind.Enum == GearKindEnum.accessories || ((IEnumerable<PlayerUnitGearProficiency>) unit.gear_proficiencies).Any<PlayerUnitGearProficiency>((Func<PlayerUnitGearProficiency, bool>) (x => x.gear_kind_id == gear.gear.kind_GearKind && x.level >= gear.gear.rarity.index));
  }

  protected virtual void ChangeDetailScehe(PlayerUnit unit)
  {
    Unit0042Scene.changeSceneEvolutionUnit(true, unit, this.getUnits());
  }

  private void RemoveGear(PlayerUnit baseUnit)
  {
    this.StartCoroutine(this.RemoveGearAsync(baseUnit));
  }

  [DebuggerHidden]
  private IEnumerator RemoveGearAsync(PlayerUnit baseUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit004431Menu.\u003CRemoveGearAsync\u003Ec__Iterator347()
    {
      baseUnit = baseUnit,
      \u003C\u0024\u003EbaseUnit = baseUnit,
      \u003C\u003Ef__this = this
    };
  }

  public class Param
  {
    public int gearKindId;
    public int gearId;
    public int index;
  }
}
