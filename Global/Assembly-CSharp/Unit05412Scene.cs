// Decompiled with JetBrains decompiler
// Type: Unit05412Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05412Scene : NGSceneBase
{
  public Unit05412Menu menu;
  private bool isInit = true;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("unit054_12", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05412Scene.\u003ConStartSceneAsync\u003Ec__Iterator61D()
    {
      \u003C\u003Ef__this = this
    };
  }
}
