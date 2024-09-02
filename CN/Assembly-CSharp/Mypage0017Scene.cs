// Decompiled with JetBrains decompiler
// Type: Mypage0017Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Mypage0017Scene.\u003ConStartSceneAsync\u003Ec__Iterator1A0()
    {
      \u003C\u003Ef__this = this
    };
  }
}
