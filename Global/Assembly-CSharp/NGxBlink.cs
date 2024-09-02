// Decompiled with JetBrains decompiler
// Type: NGxBlink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGxBlink : MonoBehaviour
{
  public float waitTime;
  public float durationTime;
  public TweenAlpha animationApply;

  private NGxBlink.Pair[] GetPairs()
  {
    Transform[] children = ((Component) this).gameObject.transform.GetChildren().ToArray<Transform>();
    return children.Length == 0 ? (NGxBlink.Pair[]) null : ((IEnumerable<Transform>) children).Select<Transform, NGxBlink.Pair>((Func<Transform, int, NGxBlink.Pair>) ((t, n) => new NGxBlink.Pair()
    {
      first = ((Component) t).gameObject,
      second = ((Component) children[(n + 1) % children.Length]).gameObject
    })).ToArray<NGxBlink.Pair>();
  }

  public void OnEnable() => this.StartCoroutine(this.RunBlink());

  [DebuggerHidden]
  private IEnumerator RunBlink()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGxBlink.\u003CRunBlink\u003Ec__Iterator8F7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class Pair
  {
    public GameObject first;
    public GameObject second;
  }
}
