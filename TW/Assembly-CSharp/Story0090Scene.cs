// Decompiled with JetBrains decompiler
// Type: Story0090Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Story0090Scene : NGSceneBase
{
  public Story0090Menu menu;

  public override IEnumerator onInitSceneAsync() => base.onInitSceneAsync();

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0090Scene.\u003ConStartSceneAsync\u003Ec__Iterator54B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
