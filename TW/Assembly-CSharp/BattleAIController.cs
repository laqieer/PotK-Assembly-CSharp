// Decompiled with JetBrains decompiler
// Type: BattleAIController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleAIController : BattleMonoBehaviour
{
  private const float waitTime = 0.5f;
  private NGBattleAIManager aiManager;
  private BattleTimeManager btm;
  private bool mIsAction;
  private bool isTerminate;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleAIController.\u003CStart_Battle\u003Ec__IteratorA72()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool isAction => this.mIsAction;

  public bool isCompleted
  {
    get
    {
      if (!this.battleManager.isPvp)
        return this.aiManager.ai.isCompleted;
      return this.env.core.aiActionOrder.value != null && this.env.core.aiActionOrder.value.Count > 0;
    }
  }

  public bool startAI(List<BL.UnitPosition> units, int max = 0)
  {
    if (this.mIsAction || this.aiManager.ai.isInitialized)
      return false;
    DeviceManager.SetAutoSleep(false);
    this.aiManager.ai.initUnits(units, max);
    Singleton<CommonRoot>.GetInstance().isActive3DUIMask = true;
    return true;
  }

  public void startAIAction(float waitForShowAiStopButton = 3f, System.Action endAction = null)
  {
    if (this.mIsAction || this.env.core.aiActionOrder.value == null)
      return;
    Singleton<CommonRoot>.GetInstance().isActive3DUIMask = true;
    this.isTerminate = false;
    this.StartCoroutine(this.actionAIUnits(waitForShowAiStopButton, endAction));
  }

  public void stopAIAction()
  {
    DeviceManager.SetAutoSleep(true);
    if (this.mIsAction)
    {
      Debug.LogWarning((object) " === stopAIAction");
      this.isTerminate = true;
    }
    this.aiManager.ai.cleanup();
    Singleton<CommonRoot>.GetInstance().isActive3DUIMask = false;
  }

  public void enqueueAIActionOrder(BL.AIUnit aiUnit)
  {
    if (this.env.core.aiActionOrder.value == null)
      this.env.core.aiActionOrder.value = new Queue<BL.AIUnit>();
    this.env.core.aiActionOrder.value.Enqueue(aiUnit);
    this.env.core.aiActionOrder.commit();
  }

  public void clearAIActionOrder()
  {
    this.env.core.aiActionOrder.value = (Queue<BL.AIUnit>) null;
    this.env.core.aiActionOrder.commit();
  }

  private bool enable
  {
    get
    {
      if (!this.battleManager.isPvp && !this.battleManager.isBattleEnable)
        return false;
      foreach (BL.UnitPosition up in this.env.core.unitPositions.value)
      {
        if (up.isMoving(this.env))
          return false;
      }
      return !this.btm.isRunning;
    }
  }

  private bool moveUnit(BL.UnitPosition up, int row, int column)
  {
    if (up.row == row && up.column == column)
      return false;
    List<BL.Panel> moveRoute = this.env.core.getRouteNonCache(up, this.env.core.getFieldPanel(up), this.env.core.getFieldPanel(row, column), up.movePanels);
    if (moveRoute.Count > 0)
      this.btm.setScheduleAction((System.Action) (() => up.startMoveRoute(moveRoute, this.battleManager.defaultUnitSpeed, this.env)), 0.5f, comleteCheckFunc: (Func<bool>) (() =>
      {
        foreach (BL.UnitPosition up1 in this.env.core.unitPositions.value)
        {
          if (up1.isMoving(this.env))
            return false;
        }
        return true;
      }));
    return true;
  }

  [DebuggerHidden]
  private IEnumerator actionAIUnits(float waitForShowAiStopButton, System.Action endAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleAIController.\u003CactionAIUnits\u003Ec__IteratorA73()
    {
      waitForShowAiStopButton = waitForShowAiStopButton,
      endAction = endAction,
      \u003C\u0024\u003EwaitForShowAiStopButton = waitForShowAiStopButton,
      \u003C\u0024\u003EendAction = endAction,
      \u003C\u003Ef__this = this
    };
  }

  public void clearCache() => this.aiManager.clearCache();
}
