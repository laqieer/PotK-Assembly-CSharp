// Decompiled with JetBrains decompiler
// Type: BattleUI55Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleUI55Scene : NGSceneBase
{
  [SerializeField]
  private GameObject touchToNext;
  private List<ResultMenuBase> sequences;
  private bool isInitialized;
  private bool isStarted;
  private bool toNextSequence;
  private BattleUI55Continue contineMenu;

  public override void onEndScene() => this.sequences.Clear();

  public override List<string> createResourceLoadList()
  {
    PlayerUnit[] source = SMManager.Get<PlayerUnit[]>();
    ResourceManager rm = Singleton<ResourceManager>.GetInstance();
    return ((IEnumerable<PlayerUnit>) source).SelectMany<PlayerUnit, string>((Func<PlayerUnit, IEnumerable<string>>) (x => (IEnumerable<string>) rm.PathsFromUnit(x.unit))).ToList<string>();
  }

  public void IbtnTouchToNext() => this.toNextSequence = true;

  public static void ChangeScene(BattleInfo info, bool isWin, BattleEnd result)
  {
    NGSceneManager instance = Singleton<NGSceneManager>.GetInstance();
    instance.clearStack();
    instance.destroyCurrentScene();
    instance.destroyLoadedScenes();
    if (Singleton<EarthDataManager>.GetInstance().isPrologue)
    {
      if (isWin)
        Singleton<EarthDataManager>.GetInstance().NextPrologueScene();
      else
        Singleton<EarthDataManager>.GetInstance().PrevPrologueScene();
    }
    else if (isWin)
      instance.changeScene("battleUI_55", false, (object) info, (object) isWin, (object) result);
    else
      Mypage051Scene.ChangeScene(false, false);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Scene.\u003ConStartSceneAsync\u003Ec__Iterator783()
    {
      info = info,
      isWin = isWin,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003EisWin = isWin,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setBackGround(BattleInfo info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Scene.\u003CsetBackGround\u003Ec__Iterator784()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(BattleInfo info, bool isWin, BattleEnd result)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus(info, isWin, result));
  }

  [DebuggerHidden]
  private IEnumerator InitMenus(BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Scene.\u003CInitMenus\u003Ec__Iterator785()
    {
      info = info,
      result = result,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RunMenus(BattleInfo info, bool isWin, BattleEnd result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI55Scene.\u003CRunMenus\u003Ec__Iterator786()
    {
      \u003C\u003Ef__this = this
    };
  }
}
