// Decompiled with JetBrains decompiler
// Type: Help0155Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Help0155Scene : NGSceneBase
{
  public Help0155Menu menu;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_5", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0155Scene.\u003ConInitSceneAsync\u003Ec__Iterator5CF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Help0155Scene.\u003ConStartSceneAsync\u003Ec__Iterator5D0 asyncCIterator5D0 = new Help0155Scene.\u003ConStartSceneAsync\u003Ec__Iterator5D0();
    return (IEnumerator) asyncCIterator5D0;
  }
}
