// Decompiled with JetBrains decompiler
// Type: Transfer01272Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Transfer01272Scene : NGSceneBase
{
  public Transfer01272Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("transfer012_7_2", stack);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Transfer01272Scene.\u003ConStartSceneAsync\u003Ec__Iterator5BF()
    {
      \u003C\u003Ef__this = this
    };
  }
}
