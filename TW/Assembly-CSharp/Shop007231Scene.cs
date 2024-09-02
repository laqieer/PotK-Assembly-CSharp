// Decompiled with JetBrains decompiler
// Type: Shop007231Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Shop007231Scene : NGSceneBase
{
  private static readonly string NAME_SCENE = "shop007_23_1";
  private Shop007231Menu mainMenu_;

  public static void changeScene(bool isStack = true)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene(Shop007231Scene.NAME_SCENE, isStack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop007231Scene.\u003ConStartSceneAsync\u003Ec__Iterator4CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coEndSceneErrorCouponDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop007231Scene.\u003CcoEndSceneErrorCouponDateTime\u003Ec__Iterator4CF timeCIterator4Cf = new Shop007231Scene.\u003CcoEndSceneErrorCouponDateTime\u003Ec__Iterator4CF();
    return (IEnumerator) timeCIterator4Cf;
  }

  public override void onEndScene()
  {
    base.onEndScene();
    this.mainMenu_.onEndMenu();
  }
}
