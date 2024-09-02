// Decompiled with JetBrains decompiler
// Type: Colosseum0235Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum0235Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum0235Menu menu;

  public static void ChangeScene(Colosseum0235Scene.Param param)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_5", false, (object) param);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0235Scene.\u003ConInitSceneAsync\u003Ec__Iterator627()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0235Scene.\u003ConStartSceneAsync\u003Ec__Iterator628()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(Colosseum0235Scene.Param param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum0235Scene.\u003ConStartSceneAsync\u003Ec__Iterator629()
    {
      param = param,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  public class Param
  {
    public bool isInit = true;
    public int maxRank = 4;
    public int nowId = 3;
    public Vector2 scrollPos = Vector2.zero;
    public int viewUnlockId = 20;
    public int[] opponents;
    public ColosseumUtility.Info collosseumInfo = new ColosseumUtility.Info();

    public Param(int m, int n, int v, int[] o, ColosseumUtility.Info info)
    {
      this.maxRank = m;
      this.nowId = n;
      this.viewUnlockId = v;
      this.opponents = o;
      this.collosseumInfo = info;
    }
  }
}
