// Decompiled with JetBrains decompiler
// Type: Help0155Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Help0155Scene.\u003ConInitSceneAsync\u003Ec__Iterator57E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Help0155Scene.\u003ConStartSceneAsync\u003Ec__Iterator57F asyncCIterator57F = new Help0155Scene.\u003ConStartSceneAsync\u003Ec__Iterator57F();
    return (IEnumerator) asyncCIterator57F;
  }
}
