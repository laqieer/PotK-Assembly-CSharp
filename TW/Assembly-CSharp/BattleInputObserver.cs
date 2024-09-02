// Decompiled with JetBrains decompiler
// Type: BattleInputObserver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleInputObserver : BattleMonoBehaviour
{
  private BattleInputObserver.Mode mode;
  public bool isCameraMoveMode;
  public bool isDispositionMode;
  private BattleCameraController cameraController;
  private BattleUnitController unitController;
  private NGBattle3DObjectManager objectManager;
  private BattleTimeManager btm;
  private BattleInputObserver.SelectTarget mSelectTargets;
  private HashSet<BL.Panel> dispositionPanels;
  private BL.Panel mDownPanel;

  public bool isUnitMoveMode => this.mode == BattleInputObserver.Mode.unitmove;

  public bool isTargetSelectMode => this.mode == BattleInputObserver.Mode.targetselect;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleInputObserver.\u003CStart_Battle\u003Ec__IteratorA76()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDisable() => UICamera.fallThrough = (GameObject) null;

  private void OnHover(bool isOver)
  {
  }

  public bool isCurrentUnitAction
  {
    get
    {
      BL.UnitPosition currentUnitPosition = this.env.core.currentUnitPosition;
      if (currentUnitPosition.unit == null)
        return false;
      if (this.isDispositionMode)
        return true;
      return !currentUnitPosition.isCompleted && currentUnitPosition.unit.isPlayerControl && this.env.core.currentPhaseUnitp(currentUnitPosition);
    }
  }

  private void setUnitMoveMode(BL.UnitPosition up)
  {
    if (this.isCurrentUnitAction && up.unit != this.env.core.unitCurrent.unit || this.isTargetSelectMode || !this.unitController.onPressMoveUnit(up))
      return;
    if (this.isCameraMoveMode)
    {
      this.cameraController.onCancel();
      this.isCameraMoveMode = false;
    }
    this.mode = BattleInputObserver.Mode.unitmove;
    this.selectTargets = (BattleInputObserver.SelectTarget) null;
  }

  private void setCameraMoveMode()
  {
    if (this.isUnitMoveMode)
      this.unitController.onCancel();
    this.isCameraMoveMode = true;
    this.cameraController.onPress();
  }

  private BattleInputObserver.SelectTarget selectTargets
  {
    get => this.mSelectTargets;
    set
    {
      if (this.mSelectTargets != null && this.mSelectTargets.Equals((object) value))
        return;
      if (this.mSelectTargets != null)
      {
        foreach (BL.Unit target in this.mSelectTargets.targets)
        {
          BL.Panel fieldPanel = this.env.core.getFieldPanel(this.env.core.getUnitPosition(target));
          fieldPanel.unsetAttribute(!this.mSelectTargets.isHeal ? BL.PanelAttribute.target_attack : BL.PanelAttribute.target_heal);
          if (this.mSelectTargets.selectFunc != null)
            this.objectManager.hideButton(fieldPanel);
        }
        foreach (BL.Unit grayTarget in this.mSelectTargets.grayTargets)
        {
          BL.Panel fieldPanel = this.env.core.getFieldPanel(this.env.core.getUnitPosition(grayTarget));
          fieldPanel.unsetAttribute(!this.mSelectTargets.isHeal ? BL.PanelAttribute.target_attack : BL.PanelAttribute.target_heal);
          if (this.mSelectTargets.selectFunc != null)
            this.objectManager.hideButton(fieldPanel);
        }
      }
      if (value != null)
      {
        foreach (BL.Unit target in value.targets)
        {
          BL.Panel fieldPanel = this.env.core.getFieldPanel(this.env.core.getUnitPosition(target));
          fieldPanel.setAttribute(!value.isHeal ? BL.PanelAttribute.target_attack : BL.PanelAttribute.target_heal);
          if (value.selectFunc != null)
            this.objectManager.setButton(fieldPanel, value.isHeal, false);
        }
        foreach (BL.Unit grayTarget in value.grayTargets)
        {
          BL.Panel fieldPanel = this.env.core.getFieldPanel(this.env.core.getUnitPosition(grayTarget));
          fieldPanel.setAttribute(!value.isHeal ? BL.PanelAttribute.target_attack : BL.PanelAttribute.target_heal);
          if (value.selectFunc != null)
            this.objectManager.setButton(fieldPanel, value.isHeal, true);
        }
      }
      this.mSelectTargets = value;
    }
  }

  public bool containsTargetSelect(BL.Unit unit)
  {
    return this.isTargetSelectMode && this.selectTargets.targets.Contains(unit);
  }

  public bool containsGrayTargetSelect(BL.Unit unit)
  {
    return this.isTargetSelectMode && this.selectTargets.grayTargets.Contains(unit);
  }

  public void setTargetSelectMode(
    List<BL.Unit> targets,
    bool isOwn,
    List<BL.Unit> grayTargets,
    Action<BL.Unit> func)
  {
    targets = targets.Where<BL.Unit>((Func<BL.Unit, bool>) (u => u.isEnable && !u.isDead)).ToList<BL.Unit>();
    grayTargets = grayTargets.Where<BL.Unit>((Func<BL.Unit, bool>) (u => u.isEnable && !u.isDead)).ToList<BL.Unit>();
    this.mode = BattleInputObserver.Mode.targetselect;
    this.selectTargets = new BattleInputObserver.SelectTarget(targets, grayTargets, isOwn, func);
    this.cameraController.onCancel();
    this.unitController.onCancel();
    this.env.core.currentUnitPosition.commit();
  }

  public void cancelTargetSelect()
  {
    if (!this.isTargetSelectMode)
      return;
    this.selectTargets = (BattleInputObserver.SelectTarget) null;
    this.mode = BattleInputObserver.Mode.none;
    this.env.core.currentUnitPosition.commit();
  }

  private void delegateSelectTargets(BL.Unit unit)
  {
    if (!this.isTargetSelectMode || this.selectTargets.selectFunc == null || !this.selectTargets.targets.Contains(unit))
      return;
    this.selectTargets.selectFunc(unit);
  }

  public void setDispositionMode(HashSet<BL.Panel> pl)
  {
    Debug.LogWarning((object) (" === setDispositionMode:" + (object) pl));
    if (pl == null)
    {
      this.isDispositionMode = false;
      this.dispositionPanels = (HashSet<BL.Panel>) null;
    }
    else
    {
      this.isDispositionMode = true;
      this.dispositionPanels = pl;
    }
  }

  public HashSet<BL.Panel> getMovePanels(BL.UnitPosition up)
  {
    return this.isDispositionMode ? this.dispositionPanels : up.movePanels;
  }

  private bool containsMovePanels(BL.Panel panel, BL.UnitPosition up)
  {
    return (!this.isDispositionMode ? up.completePanels : BattleFuncs.moveCompletePanels_(this.dispositionPanels, up.unit, isOriginal: false)).Contains(panel);
  }

  public void onCancel(bool isTargetSelectCancel = false)
  {
    if (isTargetSelectCancel)
      this.cancelTargetSelect();
    if (this.isCameraMoveMode)
    {
      this.cameraController.onCancel();
      this.isCameraMoveMode = false;
    }
    if (!this.isUnitMoveMode)
      return;
    this.unitController.onCancel();
    this.mode = BattleInputObserver.Mode.none;
  }

  private BL.Panel downPanel
  {
    set
    {
      if (this.mDownPanel == value)
        return;
      if (this.mDownPanel != null)
        this.env.panelResource[this.mDownPanel].gameObject.GetComponent<BattlePanelParts>().buttonDown(false);
      this.mDownPanel = value;
      if (this.mDownPanel == null)
        return;
      this.env.panelResource[this.mDownPanel].gameObject.GetComponent<BattlePanelParts>().buttonDown(true);
    }
  }

  private void OnPress(bool pressed)
  {
    if (!this.battleManager.isBattleEnable)
      return;
    if (pressed)
    {
      BL.Panel panel = NGBattle3DObjectManager.hitPanel(UICamera.lastTouchPosition);
      if (panel != null)
      {
        if (!this.isTargetSelectMode)
        {
          BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(panel);
          if (fieldUnit != null)
            this.setUnitMoveMode(fieldUnit);
          if (!this.isUnitMoveMode && this.env.core.currentUnitPosition.movePanels.Contains(panel))
            this.setUnitMoveMode(this.env.core.currentUnitPosition);
        }
        if (!this.isDispositionMode && (this.isTargetSelectMode || !this.isCurrentUnitAction))
        {
          HashSet<BL.Panel> attackTargetPanels = BattleFuncs.getAttackTargetPanels(this.env.core.currentUnitPosition);
          if (attackTargetPanels == null || !attackTargetPanels.Contains(panel))
            this.setCameraMoveMode();
        }
        this.downPanel = panel;
      }
      else
      {
        if (this.isDispositionMode || this.isCurrentUnitAction)
          return;
        this.setCameraMoveMode();
      }
    }
    else
    {
      this.downPanel = (BL.Panel) null;
      if (this.isCameraMoveMode)
      {
        this.cameraController.onRelease();
        this.isCameraMoveMode = false;
      }
      if (!this.isUnitMoveMode)
        return;
      this.unitController.onReleaseMoveUnit();
      this.mode = BattleInputObserver.Mode.none;
    }
  }

  private void OnClick_(BL.Panel panel)
  {
    if (this.isTargetSelectMode)
    {
      BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(panel);
      if (fieldUnit == null || !this.selectTargets.targets.Contains(fieldUnit.unit))
        return;
      this.delegateSelectTargets(fieldUnit.unit);
    }
    else
    {
      BL.UnitPosition currentUnitPosition = this.env.core.currentUnitPosition;
      if (this.isCurrentUnitAction)
      {
        if (currentUnitPosition.unit.isPlayerControl && this.containsMovePanels(panel, currentUnitPosition))
        {
          currentUnitPosition.startMoveRoute(this.env.core.getRouteNonCache(currentUnitPosition, this.env.core.getFieldPanel(currentUnitPosition), panel, this.getMovePanels(currentUnitPosition)), this.battleManager.defaultUnitSpeed, this.env);
        }
        else
        {
          if (this.isDispositionMode || currentUnitPosition.isActionComleted)
            return;
          BattleUIController controller = this.battleManager.getController<BattleUIController>();
          if (!controller.uiButtonEnable)
            return;
          HashSet<BL.Panel> attackTargetPanels = BattleFuncs.getAttackTargetPanels(currentUnitPosition);
          if (attackTargetPanels != null && attackTargetPanels.Contains(panel))
          {
            BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(panel);
            this.env.core.lookDirection(currentUnitPosition, fieldUnit);
            controller.startPreDuel(currentUnitPosition, fieldUnit);
          }
          HashSet<BL.Panel> healTargetPanels = BattleFuncs.getHealTargetPanels(currentUnitPosition);
          if (healTargetPanels == null || !healTargetPanels.Contains(panel))
            return;
          BL.UnitPosition fieldUnit1 = this.env.core.getFieldUnit(panel);
          this.env.core.lookDirection(currentUnitPosition, fieldUnit1);
          controller.startHeal(currentUnitPosition, fieldUnit1);
        }
      }
      else
      {
        BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(panel);
        if (!this.isDispositionMode)
        {
          foreach (BL.UnitPosition up in this.env.core.unitPositions.value)
          {
            if (up.isLocalMoved)
              up.cancelMove(this.env);
          }
          this.cameraController.setLookAtTarget(panel);
          this.env.core.fieldCurrent.value = panel;
          if (fieldUnit == null || fieldUnit.unit.isDead)
            return;
          this.btm.setCurrentUnit(fieldUnit.unit);
        }
        else
        {
          if (fieldUnit == null)
            return;
          this.env.core.fieldCurrent.value = panel;
          this.btm.setCurrentUnit(fieldUnit.unit);
        }
      }
    }
  }

  private void OnClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    BL.Panel panel = NGBattle3DObjectManager.hitPanel(UICamera.lastTouchPosition);
    if (panel == null)
      return;
    this.OnClick_(panel);
  }

  private void OnDoubleClick()
  {
  }

  private void OnSelect(bool selected)
  {
    if (!this.battleManager.isBattleEnable)
      return;
    this.onCancel();
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.battleManager.isBattleEnable)
      return;
    this.downPanel = NGBattle3DObjectManager.hitPanel(UICamera.lastTouchPosition);
    if (this.isCameraMoveMode)
      this.cameraController.onDrag(delta);
    if (!this.isUnitMoveMode)
      return;
    this.unitController.onDrag(this.mDownPanel);
  }

  private void OnDrop(GameObject go)
  {
  }

  private void OnInput(string text)
  {
  }

  private void OnSubmit()
  {
  }

  private void OnScroll(float delta)
  {
  }

  private enum Mode
  {
    none,
    unitmove,
    targetselect,
  }

  private class SelectTarget
  {
    public List<BL.Unit> targets;
    public List<BL.Unit> grayTargets;
    public bool isHeal;
    public Action<BL.Unit> selectFunc;

    public SelectTarget(
      List<BL.Unit> targets,
      List<BL.Unit> grayTargets,
      bool isHeal,
      Action<BL.Unit> selectFunc)
    {
      this.targets = targets;
      this.grayTargets = grayTargets;
      this.isHeal = isHeal;
      this.selectFunc = selectFunc;
    }
  }
}
