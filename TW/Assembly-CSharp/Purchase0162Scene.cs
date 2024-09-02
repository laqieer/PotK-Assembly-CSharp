// Decompiled with JetBrains decompiler
// Type: Purchase0162Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Purchase0162Scene.\u003ConStartSceneAsync\u003Ec__Iterator5D4()
    {
      \u003C\u003Ef__this = this
    };
  }
}
