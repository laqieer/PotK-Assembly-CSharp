// Decompiled with JetBrains decompiler
// Type: Mypage0017Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Mypage0017Scene : NGSceneBase
{
  public Mypage0017Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_7", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Scene.\u003ConStartSceneAsync\u003Ec__Iterator168()
    {
      \u003C\u003Ef__this = this
    };
  }
}
