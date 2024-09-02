// Decompiled with JetBrains decompiler
// Type: OPMoviePlayScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class OPMoviePlayScene : MonoBehaviour
{
  [SerializeField]
  private string iosMoviePath;
  [SerializeField]
  private string androidMoviePath;
  public bool isFinish;

  private string moviePath() => this.androidMoviePath;

  private void Start() => this.StartCoroutine(this.PlayMovie());

  [DebuggerHidden]
  private IEnumerator PlayMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OPMoviePlayScene.\u003CPlayMovie\u003Ec__Iterator659()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitForFixingScreenOrientation()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OPMoviePlayScene.\u003CWaitForFixingScreenOrientation\u003Ec__Iterator65A orientationCIterator65A = new OPMoviePlayScene.\u003CWaitForFixingScreenOrientation\u003Ec__Iterator65A();
    return (IEnumerator) orientationCIterator65A;
  }
}
