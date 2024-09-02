// Decompiled with JetBrains decompiler
// Type: Unit05443Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05443Menu : Unit00443Menu
{
  [DebuggerHidden]
  public override IEnumerator FavoriteAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05443Menu.\u003CFavoriteAPI\u003Ec__Iterator76F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void choiceUnitChangeScene() => Unit054431Scene.ChangeScene(true, this.sendParam);
}
