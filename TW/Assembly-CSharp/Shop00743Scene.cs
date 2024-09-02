// Decompiled with JetBrains decompiler
// Type: Shop00743Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Shop00743Scene : NGSceneBase
{
  public Shop00743Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_3", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00743Scene.\u003ConStartSceneAsync\u003Ec__Iterator4F2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
