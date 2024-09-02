// Decompiled with JetBrains decompiler
// Type: Unit0046Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator287()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ColosseumUtility.Info colosseumInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator288()
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
    return (IEnumerator) new Unit0046Scene.\u003ConStartSceneAsync\u003Ec__Iterator289()
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
    return (IEnumerator) new Unit0046Scene.\u003ConEndSceneAsync\u003Ec__Iterator28A()
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
