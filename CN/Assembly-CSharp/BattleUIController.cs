// Decompiled with JetBrains decompiler
// Type: BattleUIController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUIController : BattleMonoBehaviour
{
  public BattleInputObserver inputObserver;
  public BattleCameraController cameraController;
  public BattleUnitController unitController;
  private BL.BattleModified<BL.StructValue<bool>> isViewDengerAreaModified;
  private BL.BattleModified<BL.StructValue<int>> sightModified;
  private BL.BattleModified<BL.CurrentUnit> currentUnitModified;
  private BL.BattleModified<BL.UnitPosition> unitPositionModified;
  private List<IButtonEnableBeheviour> buttonBehaviours = new List<IButtonEnableBeheviour>();
  private bool mUIButtonEnable = true;

  private bool isCameraMoveMode => this.inputObserver.isCameraMoveMode;

  private bool isUnitMoveMode => this.inputObserver.isUnitMoveMode;

  private bool isDispositionMode => this.inputObserver.isDispositionMode;

  private void Awake()
  {
    this.inputObserver = ((Component) this).gameObject.AddComponent<BattleInputObserver>();
    this.cameraController = ((Component) this).gameObject.AddComponent<BattleCameraController>();
    this.unitController = ((Component) this).gameObject.AddComponent<BattleUnitController>();
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUIController.\u003CStart_Battle\u003Ec__Iterator9AC()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    if (this.isViewDengerAreaModified.isChangedOnce())
    {
      if (this.isViewDengerAreaModified.value.value)
      {
        this.env.core.createDangerAria();
        this.env.core.viewDangerAria();
      }
      else
        this.env.core.hideDangerAria();
    }
    if (this.sightModified.isChangedOnce())
      this.cameraController.sightDistance = this.battleManager.sightDistances[this.sightModified.value.value];
    if (this.currentUnitModified.isChangedOnce() && this.currentUnitModified.value.unit != null)
    {
      this.unitPositionModified.value = this.env.core.currentUnitPosition;
      this.unitPositionModified.notifyChanged();
    }
    if (this.isDispositionMode || !this.unitPositionModified.isChangedOnce() || this.isCameraMoveMode || this.isUnitMoveMode || this.env.core.unitCurrent.unit == null)
      return;
    this.cameraController.setLookAtTarget(this.env.core.getFieldPanel(this.unitPositionModified.value));
  }

  public void setButtonBehaviour(IButtonEnableBeheviour behaviour)
  {
    if (this.buttonBehaviours.Contains(behaviour))
      return;
    this.buttonBehaviours.Add(behaviour);
    behaviour.buttonEnable = this.mUIButtonEnable;
  }

  public bool uiButtonEnable
  {
    get => this.mUIButtonEnable;
    set
    {
      this.mUIButtonEnable = value;
      foreach (IButtonEnableBeheviour buttonBehaviour in this.buttonBehaviours)
        buttonBehaviour.buttonEnable = value;
    }
  }

  public void uiWait()
  {
    if (this.env.core.unitCurrent.unit == null)
      return;
    BL.UnitPosition unitPosition = this.env.core.getUnitPosition(this.env.core.unitCurrent.unit);
    if (this.battleManager.useGameEngine)
      this.battleManager.gameEngine.moveUnit(unitPosition);
    else
      unitPosition.completeActionUnit(this.env.core);
  }

  public void startPreDuel(BL.UnitPosition attack, BL.UnitPosition defense)
  {
    this.battleManager.isBattleEnable = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("BattleUI_04", true, (object) attack, (object) defense);
  }

  public void startHeal(BL.UnitPosition src, BL.UnitPosition dst)
  {
    this.battleManager.isBattleEnable = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("battle019_6_1", true, (object) src, (object) dst);
  }
}
