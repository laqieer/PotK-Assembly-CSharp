// Decompiled with JetBrains decompiler
// Type: Story0592Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Story0592Scene.\u003ConInitSceneAsync\u003Ec__Iterator653()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0592Scene.\u003ConStartSceneAsync\u003Ec__Iterator654()
    {
      \u003C\u003Ef__this = this
    };
  }
}
