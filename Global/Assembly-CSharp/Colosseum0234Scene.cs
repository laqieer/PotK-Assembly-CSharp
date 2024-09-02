// Decompiled with JetBrains decompiler
// Type: Colosseum0234Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum0234Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum0234Menu menu;
  private ColosseumUtility.Info collosseumInfo = new ColosseumUtility.Info();
  private RankingPlayer MyRanking;
  private bool isConnect;
  private bool isInit;

  public static void ChangeScene(bool connect = false)
  {
    Colosseum0234Scene.Param obj = new Colosseum0234Scene.Param(connect, (int[]) null, (ColosseumUtility.Info) null);
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4", false, (object) obj, (object) false);
  }

  public static void ChangeScene(int[] opponents, ColosseumUtility.Info collosseumInfo)
  {
    Colosseum0234Scene.Param obj = new Colosseum0234Scene.Param(false, opponents, collosseumInfo);
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4", false, (object) obj, (object) false);
  }

  public static void ChangeScene(ColosseumUtility.Info collosseumInfo)
  {
    Colosseum0234Scene.Param obj = new Colosseum0234Scene.Param(false, (int[]) null, collosseumInfo);
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4", false, (object) obj, (object) false);
  }

  public static void ChangeSceneFromBattleResult(Colosseum0234Scene.Param param, bool isTutorial)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_4", false, (object) param, (object) isTutorial);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Scene.\u003ConInitSceneAsync\u003Ec__Iterator4EC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Scene.\u003ConStartSceneAsync\u003Ec__Iterator4ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Colosseum0234Scene.Param param, bool isTutorial)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Scene.\u003ConStartSceneAsync\u003Ec__Iterator4EE()
    {
      param = param,
      isTutorial = isTutorial,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003EisTutorial = isTutorial,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Restart(Colosseum0234Scene.Param param, bool isTutorial)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0234Scene.\u003CRestart\u003Ec__Iterator4EF()
    {
      param = param,
      isTutorial = isTutorial,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003EisTutorial = isTutorial,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum0234Scene.\u003ConEndSceneAsync\u003Ec__Iterator4F0 asyncCIterator4F0 = new Colosseum0234Scene.\u003ConEndSceneAsync\u003Ec__Iterator4F0();
    return (IEnumerator) asyncCIterator4F0;
  }

  public override void onEndScene()
  {
    base.onEndScene();
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  public class Param
  {
    public bool connect;
    public int[] opponents;
    public ColosseumUtility.Info collosseumInfo = new ColosseumUtility.Info();

    public Param(bool c, int[] o, ColosseumUtility.Info info)
    {
      this.connect = c;
      this.opponents = o;
      this.collosseumInfo = info;
    }
  }
}
