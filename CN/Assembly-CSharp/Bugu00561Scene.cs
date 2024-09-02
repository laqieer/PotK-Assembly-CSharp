// Decompiled with JetBrains decompiler
// Type: Bugu00561Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Bugu00561Scene : NGSceneBase
{
  public Bugu00561Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", stack);
  }

  public static void changeScene(bool stack, PlayerItem item)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item);
  }

  public static void changeScene(bool stack, PlayerItem item, bool isNew, bool isScreenTouch)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item, (object) isNew, (object) isScreenTouch);
  }

  public static void changeScene(
    bool stack,
    PlayerItem item,
    bool isNew,
    bool isScreenTouch,
    bool isGacha)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item, (object) isNew, (object) isScreenTouch, (object) isGacha);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem item)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3B3()
    {
      item = item,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem item, bool isNew = false, bool isScreenTouch = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3B4()
    {
      item = item,
      isNew = isNew,
      isScreenTouch = isScreenTouch,
      \u003C\u0024\u003Eitem = item,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EisScreenTouch = isScreenTouch,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    PlayerItem item,
    bool isNew,
    bool isScreenTouch,
    bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3B5()
    {
      item = item,
      isNew = isNew,
      isScreenTouch = isScreenTouch,
      isGacha = isGacha,
      \u003C\u0024\u003Eitem = item,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EisScreenTouch = isScreenTouch,
      \u003C\u0024\u003EisGacha = isGacha,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator startSceneAsync(
    PlayerItem supply,
    bool isNew,
    bool isScreenTouch,
    bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003CstartSceneAsync\u003Ec__Iterator3B6()
    {
      isGacha = isGacha,
      supply = supply,
      isNew = isNew,
      isScreenTouch = isScreenTouch,
      \u003C\u0024\u003EisGacha = isGacha,
      \u003C\u0024\u003Esupply = supply,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EisScreenTouch = isScreenTouch,
      \u003C\u003Ef__this = this
    };
  }
}
