// Decompiled with JetBrains decompiler
// Type: Unit05443Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Unit05443Menu : Unit00443Menu
{
  [DebuggerHidden]
  public override IEnumerator FavoriteAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit05443Menu.\u003CFavoriteAPI\u003Ec__Iterator836()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void choiceUnitChangeScene() => Unit054431Scene.ChangeScene(true, this.sendParam);
}
