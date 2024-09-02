// Decompiled with JetBrains decompiler
// Type: OPMoviePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    OPMoviePlayer.\u003CAttach\u003Ec__Iterator9FF attachCIterator9Ff = new OPMoviePlayer.\u003CAttach\u003Ec__Iterator9FF();
    return (IEnumerator) attachCIterator9Ff;
  }
}
