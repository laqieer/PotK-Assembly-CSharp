// Decompiled with JetBrains decompiler
// Type: OPMoviePlayScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new OPMoviePlayScene.\u003CPlayMovie\u003Ec__Iterator7A0()
    {
      \u003C\u003Ef__this = this
    };
  }
}
