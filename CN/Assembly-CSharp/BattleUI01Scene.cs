// Decompiled with JetBrains decompiler
// Type: BattleUI01Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI01Scene : BattleSceneBase
{
  public override List<string> createResourceLoadList()
  {
    NGBattleManager instance = Singleton<NGBattleManager>.GetInstance();
    return instance.isError ? new List<string>() : instance.createResourceLoadList();
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI01Scene.\u003ConInitSceneAsync\u003Ec__Iterator877()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003ConStartSceneAsync\u003Ec__Iterator878 asyncCIterator878 = new BattleUI01Scene.\u003ConStartSceneAsync\u003Ec__Iterator878();
    return (IEnumerator) asyncCIterator878;
  }

  public void onStartScene()
  {
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    NGBattleManager instance1 = Singleton<NGBattleManager>.GetInstance();
    if (instance1.isError)
    {
      this.StartCoroutine(this.doErrorChangeScene());
    }
    else
    {
      NGBattle3DObjectManager manager = instance1.getManager<NGBattle3DObjectManager>();
      if (Object.op_Inequality((Object) manager, (Object) null))
        manager.setRootActive(true);
      BattleAIController controller = instance1.getController<BattleAIController>();
      CommonRoot instance2 = Singleton<CommonRoot>.GetInstance();
      instance2.isActiveBackground3DCamera = false;
      instance2.isActive3DUIMask = Object.op_Inequality((Object) controller, (Object) null) && controller.isAction;
      this.StartCoroutine(this.doSetBattleEnable());
      Singleton<CommonRoot>.GetInstance().isLoading = Singleton<CommonRoot>.GetInstance().isLoading && (instance1.environment.core.phaseState.state == BL.Phase.battle_start || instance1.environment.core.phaseState.state == BL.Phase.pvp_restart);
      stopwatch.Stop();
      Debug.LogWarning((object) ("BattleUI01Scene:onStartScene/" + (object) stopwatch.ElapsedMilliseconds));
    }
  }

  public override void onEndScene()
  {
    NGBattleManager instance1 = Singleton<NGBattleManager>.GetInstance();
    if (instance1.isError)
      return;
    instance1.isBattleEnable = false;
    CommonRoot instance2 = Singleton<CommonRoot>.GetInstance();
    instance2.isActiveBackground3DCamera = true;
    instance2.isActive3DUIMask = true;
    if (instance1.environment.core.phaseState.state == BL.Phase.enemy)
      this.bgmName = instance1.environment.core.stage.stage.field_enemy_bgm;
    else
      this.bgmName = instance1.environment.core.stage.stage.field_player_bgm;
  }

  [DebuggerHidden]
  public override IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003ConDestroySceneAsync\u003Ec__Iterator879 asyncCIterator879 = new BattleUI01Scene.\u003ConDestroySceneAsync\u003Ec__Iterator879();
    return (IEnumerator) asyncCIterator879;
  }

  [DebuggerHidden]
  private IEnumerator doSetBattleEnable()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003CdoSetBattleEnable\u003Ec__Iterator87A enableCIterator87A = new BattleUI01Scene.\u003CdoSetBattleEnable\u003Ec__Iterator87A();
    return (IEnumerator) enableCIterator87A;
  }

  [DebuggerHidden]
  private IEnumerator doErrorChangeScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003CdoErrorChangeScene\u003Ec__Iterator87B sceneCIterator87B = new BattleUI01Scene.\u003CdoErrorChangeScene\u003Ec__Iterator87B();
    return (IEnumerator) sceneCIterator87B;
  }
}
