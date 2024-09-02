// Decompiled with JetBrains decompiler
// Type: OPMoviePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    OPMoviePlayer.\u003CAttach\u003Ec__Iterator884 attachCIterator884 = new OPMoviePlayer.\u003CAttach\u003Ec__Iterator884();
    return (IEnumerator) attachCIterator884;
  }
}
