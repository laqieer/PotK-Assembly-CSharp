// Decompiled with JetBrains decompiler
// Type: Mypage00182Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Mypage00182Menu : Startup00012Menu
{
  protected override int GetWidth() => 580;

  protected override bool DeleteTitle() => true;

  [DebuggerHidden]
  public static IEnumerator LoadSprite(UI2DSprite sprite, string str, int count = 3, System.Action action = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00182Menu.\u003CLoadSprite\u003Ec__Iterator1AC()
    {
      count = count,
      str = str,
      sprite = sprite,
      action = action,
      \u003C\u0024\u003Ecount = count,
      \u003C\u0024\u003Estr = str,
      \u003C\u0024\u003Esprite = sprite,
      \u003C\u0024\u003Eaction = action
    };
  }
}
