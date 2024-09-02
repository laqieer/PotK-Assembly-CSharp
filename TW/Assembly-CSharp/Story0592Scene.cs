// Decompiled with JetBrains decompiler
// Type: Story0592Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Story0592Scene : NGSceneBase
{
  private Story0592Menu menu;
  private bool isInit;

  public static void ChangeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("story059_2", stack);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0592Scene.\u003ConInitSceneAsync\u003Ec__Iterator865()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0592Scene.\u003ConStartSceneAsync\u003Ec__Iterator866()
    {
      \u003C\u003Ef__this = this
    };
  }
}
