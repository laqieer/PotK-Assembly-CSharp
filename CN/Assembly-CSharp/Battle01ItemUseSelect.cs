// Decompiled with JetBrains decompiler
// Type: Battle01ItemUseSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01ItemUseSelect : BattleHorizontalSelect<BL.Unit>
{
  [SerializeField]
  private Battle01ItemSubject itemSubject;

  protected override void initialize(BE e)
  {
    this.itemSubject = NGUITools.FindInParents<Battle01ItemSubject>(((Component) this).transform);
  }

  protected override Future<GameObject> resPrefab()
  {
    return Res.Prefabs.battle.Battle01_Player_Unit.Load<GameObject>();
  }

  protected override void setParts(GameObject o, BL.Unit parts)
  {
    Battle01PlayerUnit component = o.GetComponent<Battle01PlayerUnit>();
    component.setUnit(parts);
    component.isViewCounter = false;
  }

  private void onSelect(BL.Unit unit)
  {
    if (unit == null)
      return;
    this.itemSubject.useUnit(unit);
  }

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.modified == null)
      return;
    this.onSelect(NGUITools.FindInParents<Battle01PlayerUnit>(UICamera.selectedObject).getUnit());
  }

  public void setTargets(List<BL.Unit> targets, bool isHeal)
  {
    this.modified = BL.Observe<BL.ClassValue<List<BL.Unit>>>(new BL.ClassValue<List<BL.Unit>>(targets));
    Singleton<NGBattleManager>.GetInstance().getController<BattleInputObserver>().setTargetSelectMode(targets, isHeal, new Action<BL.Unit>(this.onSelect));
  }
}
