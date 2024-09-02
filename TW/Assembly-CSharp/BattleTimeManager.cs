// Decompiled with JetBrains decompiler
// Type: BattleTimeManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleTimeManager : BattleManagerBase
{
  private Queue<Schedule> sQueue;
  private BE environment;
  private bool _isRunning;
  private bool _insertMode;
  private Queue<Schedule> _insertQueue;

  [DebuggerHidden]
  public override IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleTimeManager.\u003Cinitialize\u003Ec__IteratorA94()
    {
      env_ = env_,
      \u003C\u0024\u003Eenv_ = env_,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator cleanup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleTimeManager.\u003Ccleanup\u003Ec__IteratorA95()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool insertMode
  {
    set
    {
      if (value == this._insertMode)
        return;
      if (value && this._insertQueue == null)
        this._insertQueue = new Queue<Schedule>();
      this._insertMode = value;
    }
    get => this._insertMode;
  }

  [DebuggerHidden]
  private IEnumerator exec()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleTimeManager.\u003Cexec\u003Ec__IteratorA96()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool isRunning => this.sQueue.Count > 0 || this._isRunning;

  private Schedule doStart(Schedule s)
  {
    s.startTime = Time.time;
    if (s.isSetBattleEnable)
      Singleton<NGBattleManager>.GetInstance().isBattleEnable = s.isBattleEnable;
    if (!s.completedp() && s.state != BL.Phase.unset)
      this.environment.core.phaseState.setState_(BL.Phase.none, this.environment.core);
    s.execBody();
    return s;
  }

  private Schedule doEnd(Schedule s)
  {
    if (s.endAction != null)
      s.endAction();
    if (s.state != BL.Phase.unset)
      this.environment.core.phaseState.setState_(s.state, this.environment.core);
    return s;
  }

  private bool checkDuplicationState(BL.Phase state)
  {
    if (this._insertQueue != null)
    {
      foreach (Schedule insert in this._insertQueue)
      {
        if (insert.state == state)
          return true;
      }
    }
    foreach (Schedule s in this.sQueue)
    {
      if (s.state == state)
        return true;
    }
    return false;
  }

  public void setSchedule(Schedule s)
  {
    if (this._insertQueue != null)
      this._insertQueue.Enqueue(s);
    else
      this.sQueue.Enqueue(s);
  }

  public void setPhaseState(BL.Phase state, bool isOnce = false)
  {
    if (isOnce && this.checkDuplicationState(state))
      return;
    this.setSchedule(new Schedule() { state = state });
  }

  public void setEnableWait(float wait)
  {
    this.setSchedule((Schedule) new ScheduleEnableWait(wait));
    this.setSchedule(new Schedule()
    {
      isSetBattleEnable = true,
      isBattleEnable = true
    });
  }

  public void setEnableWait(Func<bool> waitF)
  {
    this.setSchedule((Schedule) new ScheduleEnableFuncWait(waitF));
    this.setSchedule(new Schedule()
    {
      isSetBattleEnable = true,
      isBattleEnable = true
    });
  }

  public void setTargetPanel(
    BL.Panel panel,
    float wait,
    System.Action func = null,
    System.Action endAction = null,
    bool isWaitCameraMove = false)
  {
    this.setSchedule((Schedule) new BattleTimeManager.TargetCamera(panel, wait, func, endAction, isWaitCameraMove));
  }

  public void setTargetUnit(
    BL.UnitPosition up,
    float wait,
    GameObject effect = null,
    System.Action func = null,
    System.Action endAction = null,
    bool isWaitCameraMove = false)
  {
    this.setSchedule((Schedule) new BattleTimeManager.TargetCamera(this.environment.core.getFieldPanel(up), wait, func, (System.Action) (() =>
    {
      if (Object.op_Inequality((Object) effect, (Object) null))
        Singleton<NGBattleManager>.GetInstance().battleEffects.fieldEffectsStart(effect, up.unit);
      if (endAction == null)
        return;
      endAction();
    }), isWaitCameraMove));
  }

  public void setCurrentUnit(BL.UnitPosition up, float wait = 0.0f, bool isWaitCameraMove = false)
  {
    Debug.LogWarning((object) (" ======= setCurrentUnit:" + (up != null ? up.unit.unit.name : "null")));
    if (up != null)
    {
      if (this.environment.core.phaseState.state == BL.Phase.pvp_disposition)
        this.environment.setCurrentUnit_(up.unit);
      else
        this.setTargetUnit(up, wait, func: (System.Action) (() => this.environment.setCurrentUnit_(up.unit)), isWaitCameraMove: isWaitCameraMove);
    }
    else
      this.setScheduleAction((System.Action) (() => this.environment.setCurrentUnit_((BL.Unit) null)), wait);
  }

  public void setCurrentUnit(BL.Unit unit, float wait = 0.1f, bool isWaitCameraMove = false)
  {
    if (unit != null)
    {
      if (this.environment.core.phaseState.state == BL.Phase.pvp_disposition)
        this.environment.setCurrentUnit_(unit);
      else
        this.setTargetUnit(this.environment.core.getUnitPosition(unit), wait, func: (System.Action) (() => this.environment.setCurrentUnit_(unit)), isWaitCameraMove: isWaitCameraMove);
    }
    else
      this.setScheduleAction((System.Action) (() => this.environment.setCurrentUnit_((BL.Unit) null)), wait);
  }

  public void setScheduleAction(
    System.Action action,
    float wait = 0.0f,
    System.Action endAction = null,
    Func<bool> comleteCheckFunc = null,
    bool isInsertMode = false)
  {
    this.setSchedule((Schedule) new BattleTimeManager.ScheduleAction(action, wait, endAction, comleteCheckFunc, isInsertMode));
  }

  public void changeSceneWithReturnWait(
    string sceneName,
    bool isStack = false,
    System.Action initAction = null,
    System.Action endAction = null,
    params object[] args)
  {
    NGBattleManager bm = Singleton<NGBattleManager>.GetInstance();
    NGSceneManager sm = Singleton<NGSceneManager>.GetInstance();
    this.setSchedule((Schedule) new BattleTimeManager.ScheduleAction((System.Action) (() =>
    {
      if (initAction != null)
        initAction();
      bm.popupCloseAll(true);
      bm.isBattleEnable = false;
      this.StartCoroutine(this.ChangeScene(sceneName, isStack, args));
    }), 0.0f, (System.Action) (() =>
    {
      if (!(bm.topScene != sm.sceneName))
        return;
      bm.isBattleEnable = false;
    }), (Func<bool>) (() => (!sm.isSceneInitialized ? 1 : (sm.changeSceneQueueCount > 0 ? 1 : 0)) == 0), false));
    this.setSchedule((Schedule) new BattleTimeManager.ScheduleAction((System.Action) null, 0.0f, endAction, (Func<bool>) (() => bm.isBattleEnable), false));
  }

  [DebuggerHidden]
  private IEnumerator ChangeScene(string sceneName, bool isStack = false, params object[] args)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleTimeManager.\u003CChangeScene\u003Ec__IteratorA97()
    {
      sceneName = sceneName,
      isStack = isStack,
      args = args,
      \u003C\u0024\u003EsceneName = sceneName,
      \u003C\u0024\u003EisStack = isStack,
      \u003C\u0024\u003Eargs = args
    };
  }

  public void backSceneWithReturnWait(bool isStack = false, System.Action initAction = null)
  {
    NGBattleManager bm = Singleton<NGBattleManager>.GetInstance();
    NGSceneManager sm = Singleton<NGSceneManager>.GetInstance();
    this.setSchedule((Schedule) new BattleTimeManager.ScheduleAction((System.Action) (() =>
    {
      if (initAction != null)
        initAction();
      bm.popupCloseAll(true);
      bm.isBattleEnable = false;
      sm.backScene();
    }), 0.0f, (System.Action) (() =>
    {
      if (!(bm.topScene != sm.sceneName))
        return;
      bm.isBattleEnable = false;
    }), (Func<bool>) (() => (!sm.isSceneInitialized ? 1 : (sm.changeSceneQueueCount > 0 ? 1 : 0)) == 0), false));
    this.setSchedule((Schedule) new BattleTimeManager.ScheduleAction((System.Action) null, 0.0f, (System.Action) null, (Func<bool>) (() => bm.isBattleEnable), false));
  }

  private class TargetCamera : Schedule
  {
    private BL.Panel panel;
    private float wait;
    private System.Action func;
    private bool isWaitCameraMove;
    private NGBattleManager bm;
    private BattleCameraController cc;

    public TargetCamera(
      BL.Panel panel,
      float wait,
      System.Action func,
      System.Action endAction,
      bool isWaitCameraMove)
    {
      this.panel = panel;
      this.wait = wait;
      this.func = func;
      this.endAction = endAction;
      this.isWaitCameraMove = isWaitCameraMove;
      this.bm = Singleton<NGBattleManager>.GetInstance();
      this.cc = this.bm.getController<BattleCameraController>();
    }

    public override bool body()
    {
      this.cc.setLookAtTarget(this.panel);
      this.bm.environment.core.setCurrentField(this.panel);
      if (this.func != null)
        this.func();
      return true;
    }

    public override bool completedp()
    {
      bool flag = (double) this.deltaTime >= (double) this.wait;
      if (flag && this.isWaitCameraMove)
        flag = !this.cc.isCameraMove;
      return flag;
    }
  }

  private class ScheduleAction : Schedule
  {
    private System.Action action;
    private float wait;
    private Func<bool> comleteCheckFunc;

    public ScheduleAction(
      System.Action action,
      float wait,
      System.Action endAction,
      Func<bool> comleteCheckFunc,
      bool isInsertMode)
    {
      this.action = action;
      this.wait = wait;
      this.endAction = endAction;
      this.comleteCheckFunc = comleteCheckFunc;
      this.isInsertMode = isInsertMode;
    }

    public override bool body()
    {
      if (this.action != null)
        this.action();
      return true;
    }

    public override bool completedp()
    {
      bool flag = (double) this.deltaTime >= (double) this.wait;
      if (flag && this.comleteCheckFunc != null)
        flag = this.comleteCheckFunc();
      return flag;
    }
  }
}
