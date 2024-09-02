// Decompiled with JetBrains decompiler
// Type: Purchase0162Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Purchase0162Scene : NGSceneBase
{
  public Purchase0162Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("purchase016_2", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Purchase0162Scene.\u003ConStartSceneAsync\u003Ec__Iterator4DF()
    {
      \u003C\u003Ef__this = this
    };
  }
}
