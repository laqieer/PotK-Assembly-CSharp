// Decompiled with JetBrains decompiler
// Type: Quest00217Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Quest00217Scene : NGSceneBase
{
  public Quest00217Menu menu;
  private bool IsInit;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_17", stack);
  }

  public static void ChangeScene(bool stack, bool needInit)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("quest002_17", (stack ? 1 : 0) != 0, (object) needInit);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003ConStartSceneAsync\u003Ec__Iterator1A7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool needInit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003ConStartSceneAsync\u003Ec__Iterator1A8()
    {
      needInit = needInit,
      \u003C\u0024\u003EneedInit = needInit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ProgressExtra()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scene.\u003CProgressExtra\u003Ec__Iterator1A9()
    {
      \u003C\u003Ef__this = this
    };
  }
}
