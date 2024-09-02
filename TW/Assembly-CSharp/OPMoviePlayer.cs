// Decompiled with JetBrains decompiler
// Type: OPMoviePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class OPMoviePlayer
{
  private const string movieAsset = "op_fix_800x450.mp4";
  public const string toNextScene = "startup000_6";

  [DebuggerHidden]
  public IEnumerator Attach()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OPMoviePlayer.\u003CAttach\u003Ec__IteratorADA attachCIteratorAda = new OPMoviePlayer.\u003CAttach\u003Ec__IteratorADA();
    return (IEnumerator) attachCIteratorAda;
  }
}
