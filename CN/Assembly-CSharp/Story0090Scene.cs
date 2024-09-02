// Decompiled with JetBrains decompiler
// Type: Story0090Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Story0090Scene.\u003ConStartSceneAsync\u003Ec__Iterator4FB()
    {
      \u003C\u003Ef__this = this
    };
  }
}
