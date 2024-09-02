// Decompiled with JetBrains decompiler
// Type: Unit0048Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Unit0048Menu : UnitMenuBase
{
  private const int SOZAI_MAX = 5;
  protected int unitCount;

  public Unit00468Scene.Mode mode { get; set; }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public bool IsInit()
  {
    return ((IEnumerable<PlayerUnit>) SMManager.Get<PlayerUnit[]>()).Count<PlayerUnit>() != this.unitCount;
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(Player player, PlayerUnit[] playerUnits, bool isEquip)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0048Menu.\u003CInit\u003Ec__Iterator31F()
    {
      playerUnits = playerUnits,
      isEquip = isEquip,
      player = player,
      \u003C\u0024\u003EplayerUnits = playerUnits,
      \u003C\u0024\u003EisEquip = isEquip,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  private void ChangeScene(UnitIconBase unitIcon)
  {
    if (unitIcon.PlayerUnit != (PlayerUnit) null)
    {
      this.lastReferenceUnitID = unitIcon.PlayerUnit.id;
      this.lastReferenceUnitIndex = this.GetUnitInfoDisplayIndex(unitIcon.PlayerUnit);
      if (this.mode == Unit00468Scene.Mode.Unit0048)
        Unit00484Scene.changeScene(true, unitIcon.PlayerUnit, new PlayerUnit[5], Unit00468Scene.Mode.Unit0048);
      else
        Unit00420Scene.changeScene(true, unitIcon.PlayerUnit, new PlayerUnit[5]);
    }
    else
      Debug.LogWarning((object) "PlayerUnit Null : Unit0048Menu");
  }

  [DebuggerHidden]
  protected override IEnumerator CreateUnitIcon(
    int info_index,
    int unit_index,
    PlayerUnit baseUnit = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0048Menu.\u003CCreateUnitIcon\u003Ec__Iterator320()
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

  private void CreateUnitIconAction(int info_index, int unit_index)
  {
    this.allUnitIcons[unit_index].onClick = (Action<UnitIconBase>) (ui => this.ChangeScene(ui));
  }
}
