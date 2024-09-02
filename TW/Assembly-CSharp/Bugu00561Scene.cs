// Decompiled with JetBrains decompiler
// Type: Bugu00561Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
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

  public static void changeScene(bool stack, ItemInfo item)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item);
  }

  public static void changeScene(bool stack, ItemInfo item, bool isNew, bool isScreenTouch)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item, (object) isNew, (object) isScreenTouch);
  }

  public static void changeScene(
    bool stack,
    ItemInfo item,
    bool isNew,
    bool isScreenTouch,
    bool isGacha)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_6_1", (stack ? 1 : 0) != 0, (object) item, (object) isNew, (object) isScreenTouch, (object) isGacha);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ItemInfo item)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3DE()
    {
      item = item,
      \u003C\u0024\u003Eitem = item,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ItemInfo item, bool isNew = false, bool isScreenTouch = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3DF()
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
    ItemInfo item,
    bool isNew,
    bool isScreenTouch,
    bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003ConStartSceneAsync\u003Ec__Iterator3E0()
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
  public IEnumerator startSceneAsync(ItemInfo item, bool isNew, bool isScreenTouch, bool isGacha)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00561Scene.\u003CstartSceneAsync\u003Ec__Iterator3E1()
    {
      isGacha = isGacha,
      item = item,
      isNew = isNew,
      isScreenTouch = isScreenTouch,
      \u003C\u0024\u003EisGacha = isGacha,
      \u003C\u0024\u003Eitem = item,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EisScreenTouch = isScreenTouch,
      \u003C\u003Ef__this = this
    };
  }
}
