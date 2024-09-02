// Decompiled with JetBrains decompiler
// Type: Battle01SkillUseSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return ResourceManager.Load<GameObject>("Prefabs/battle/Battle01 Player Unit");
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

  public void setTargets(List<BL.Unit> targets, bool isOwn)
  {
    this.modified = BL.Observe<BL.ClassValue<List<BL.Unit>>>(new BL.ClassValue<List<BL.Unit>>(targets));
    Singleton<NGBattleManager>.GetInstance().getController<BattleInputObserver>().setTargetSelectMode(targets, isOwn, new Action<BL.Unit>(this.onSelect));
  }
}
