// Decompiled with JetBrains decompiler
// Type: Colosseum02351Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02351Scene : NGSceneBase
{
  [SerializeField]
  private Colosseum02351Menu menu;

  public static void ChangeScene(
    Colosseum0235Scene.Param param,
    ColosseumRank rank,
    int fromPoint,
    int nextPoint)
  {
    Colosseum02351Scene.Data data = new Colosseum02351Scene.Data(rank, fromPoint, nextPoint);
    Singleton<NGSceneManager>.GetInstance().changeScene("colosseum023_5_1", false, (object) param, (object) data);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351Scene.\u003ConInitSceneAsync\u003Ec__Iterator62C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Colosseum02351Scene.\u003ConStartSceneAsync\u003Ec__Iterator62D asyncCIterator62D = new Colosseum02351Scene.\u003ConStartSceneAsync\u003Ec__Iterator62D();
    return (IEnumerator) asyncCIterator62D;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    Colosseum0235Scene.Param param,
    Colosseum02351Scene.Data data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351Scene.\u003ConStartSceneAsync\u003Ec__Iterator62E()
    {
      param = param,
      data = data,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public class Data
  {
    public int fromPoint;
    public int nextPoint;

    public Data(ColosseumRank r, int fp, int np)
    {
      this.rank = r;
      this.fromPoint = fp;
      this.nextPoint = np;
    }

    public ColosseumRank rank { get; set; }
  }
}
