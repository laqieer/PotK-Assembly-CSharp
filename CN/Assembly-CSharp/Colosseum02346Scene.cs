// Decompiled with JetBrains decompiler
// Type: Colosseum02346Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02346Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum02346Menu menu;
  [SerializeField]
  private GameObject touchToNext;
  private ColosseumUtility.Info info;
  private List<ResultMenuBase> sequences;
  private bool toNextSequence;
  private bool isStarted;
  private bool isTutorial;
  private Colosseum0234Scene.Param bootParam;

  public override void onEndScene() => this.sequences.Clear();

  public void IbtnTouchToNext() => this.toNextSequence = true;

  public static void ChangeScene(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4_6", false, (object) info, (object) result, (object) gladiator);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Scene.\u003ConInitSceneAsync\u003Ec__Iterator5CB()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Scene.\u003ConStartSceneAsync\u003Ec__Iterator5CC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    ColosseumUtility.Info info,
    GameCore.ColosseumResult result,
    Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Scene.\u003ConStartSceneAsync\u003Ec__Iterator5CD()
    {
      info = info,
      result = result,
      gladiator = gladiator,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eresult = result,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  public void onStartScene(ColosseumUtility.Info info, GameCore.ColosseumResult result, Gladiator gladiator)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    if (this.isStarted)
      return;
    this.isStarted = true;
    this.StartCoroutine(this.RunMenus());
  }

  [DebuggerHidden]
  private IEnumerator InitMenus(
    ColosseumUtility.Info info,
    ResultMenuBase.Param param,
    Gladiator gladiator)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Scene.\u003CInitMenus\u003Ec__Iterator5CE()
    {
      info = info,
      param = param,
      gladiator = gladiator,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Egladiator = gladiator,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator RunMenus()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02346Scene.\u003CRunMenus\u003Ec__Iterator5CF()
    {
      \u003C\u003Ef__this = this
    };
  }
}
