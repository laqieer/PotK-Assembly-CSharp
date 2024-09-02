// Decompiled with JetBrains decompiler
// Type: BattleUI01Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new BattleUI01Scene.\u003ConInitSceneAsync\u003Ec__Iterator72D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003ConStartSceneAsync\u003Ec__Iterator72E asyncCIterator72E = new BattleUI01Scene.\u003ConStartSceneAsync\u003Ec__Iterator72E();
    return (IEnumerator) asyncCIterator72E;
  }

  public void onStartScene()
  {
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
    BattleUI01Scene.\u003ConDestroySceneAsync\u003Ec__Iterator72F asyncCIterator72F = new BattleUI01Scene.\u003ConDestroySceneAsync\u003Ec__Iterator72F();
    return (IEnumerator) asyncCIterator72F;
  }

  [DebuggerHidden]
  private IEnumerator doSetBattleEnable()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003CdoSetBattleEnable\u003Ec__Iterator730 enableCIterator730 = new BattleUI01Scene.\u003CdoSetBattleEnable\u003Ec__Iterator730();
    return (IEnumerator) enableCIterator730;
  }

  [DebuggerHidden]
  private IEnumerator doErrorChangeScene()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI01Scene.\u003CdoErrorChangeScene\u003Ec__Iterator731 sceneCIterator731 = new BattleUI01Scene.\u003CdoErrorChangeScene\u003Ec__Iterator731();
    return (IEnumerator) sceneCIterator731;
  }
}
