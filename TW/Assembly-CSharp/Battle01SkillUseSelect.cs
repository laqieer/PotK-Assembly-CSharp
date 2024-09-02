// Decompiled with JetBrains decompiler
// Type: Battle01SkillUseSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Battle01SkillUseSelect : BattleHorizontalSelect<BL.Unit>
{
  [SerializeField]
  private Battle01SkillSubject skillSubject;

  protected override void initialize(BE e)
  {
    this.skillSubject = NGUITools.FindInParents<Battle01SkillSubject>(((Component) this).transform);
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
    this.skillSubject.useUnit(unit);
  }

  public override void onClick()
  {
    if (!this.battleManager.isBattleEnable || this.modified == null)
      return;
    this.onSelect(NGUITools.FindInParents<Battle01PlayerUnit>(UICamera.selectedObject).getUnit());
  }

  public void setTargets(List<BL.Unit> targets, bool isOwn, List<BL.Unit> grayTargets)
  {
    this.modified = BL.Observe<BL.ClassValue<List<BL.Unit>>>(new BL.ClassValue<List<BL.Unit>>(targets));
    Singleton<NGBattleManager>.GetInstance().getController<BattleInputObserver>().setTargetSelectMode(targets, isOwn, grayTargets, new Action<BL.Unit>(this.onSelect));
  }
}
