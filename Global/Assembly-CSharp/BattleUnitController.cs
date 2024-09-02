// Decompiled with JetBrains decompiler
// Type: BattleUnitController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUnitController : BattleMonoBehaviour
{
  private BL.UnitPosition moveUnit;
  private BL.Panel startPanel;
  private BL.Panel lastTouchPanel;
  private BattleCameraController cameraController;
  private BattleTimeManager btm;
  private BattleInputObserver _inputObserver;

  public bool isMoving => this.moveUnit != null;

  private BattleInputObserver inputObserver
  {
    get
    {
      if (Object.op_Equality((Object) this._inputObserver, (Object) null))
        this._inputObserver = this.battleManager.getController<BattleInputObserver>();
      return this._inputObserver;
    }
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUnitController.\u003CStart_Battle\u003Ec__Iterator847()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool isDispositionMode => this.inputObserver.isDispositionMode;

  protected override void Update_Battle()
  {
    if (!this.battleManager.isBattleEnable || this.isDispositionMode || !this.isMoving)
      return;
    this.cameraController.setLookAtTarget(this.env.unitResource[this.moveUnit.unit].gameObject.transform.position);
  }

  public bool onPressMoveUnit(BL.UnitPosition up)
  {
    if (this.env.core.isAutoBattle.value || !up.unit.isPlayerControl || up.isCompleted || !this.env.core.currentPhaseUnitp(up))
      return false;
    if (this.moveUnit == up)
      return true;
    this.btm.setCurrentUnit(up.unit);
    this.moveUnit = up;
    this.lastTouchPanel = this.env.core.getFieldPanel(up);
    this.startPanel = this.env.core.getFieldPanel(up.originalRow, up.originalColumn);
    return true;
  }

  private void cleanup() => this.moveUnit = (BL.UnitPosition) null;

  public void onReleaseMoveUnit() => this.cleanup();

  public void onCancel()
  {
    if (this.moveUnit != null)
      this.moveUnit.cancelMove(this.env);
    this.cleanup();
  }

  public void onDrag(BL.Panel panel)
  {
    if (this.moveUnit == null || panel == null || panel == this.lastTouchPanel)
      return;
    HashSet<BL.Panel> movePanels = this.inputObserver.getMovePanels(this.moveUnit);
    this.lastTouchPanel = panel;
    HashSet<BL.Panel> completePanels = !this.inputObserver.isDispositionMode ? this.moveUnit.completePanels : BattleFuncs.moveCompletePanels_(movePanels, this.moveUnit.unit, isOriginal: false);
    if (!completePanels.Contains(panel) || this.env.core.getRouteNonCache(this.moveUnit, this.startPanel, panel, movePanels, completePanels) == null)
      return;
    this.moveUnit.startMoveRoute(this.env.core.getRouteNonCache(this.moveUnit, this.env.core.getFieldPanel(this.moveUnit.row, this.moveUnit.column), panel, movePanels, completePanels), this.battleManager.defaultUnitSpeed, this.env);
  }

  public bool isMoveUnit(GameObject o)
  {
    BL.Unit unit = this.env.core.unitCurrent.unit;
    return this.battleManager.isBattleEnable && unit != null && Object.op_Equality((Object) this.env.unitResource[unit].gameObject, (Object) o) && !this.env.core.isCompleted(unit) && this.env.core.currentPhaseUnitp(unit) && !unit.IsDontMove;
  }
}
