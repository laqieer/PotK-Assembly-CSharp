// Decompiled with JetBrains decompiler
// Type: Unit0046Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit0046Scene : NGSceneBase
{
  public Unit0046Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_0822", stack);
  }

  public static void changeScene(bool stack, ColosseumUtility.Info colosseumInfo)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_0822", (stack ? 1 : 0) != 0, (object) colosseumInfo);
  }

  public static void changeSceneVersus(bool stack)
  {
    bool flag = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_6_0822", (stack ? 1 : 0) != 0, (object) flag);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator2EE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ColosseumUtility.Info colosseumInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator2EF()
    {
      colosseumInfo = colosseumInfo,
      \u003C\u0024\u003EcolosseumInfo = colosseumInfo,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool fromVersus)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator2F0()
    {
      fromVersus = fromVersus,
      \u003C\u0024\u003EfromVersus = fromVersus,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public override IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Scene.\u003ConEndSceneAsync\u003Ec__Iterator2F1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onEndScene()
  {
    this.menu.onEndScene();
    this.menu.stop = true;
  }
}
