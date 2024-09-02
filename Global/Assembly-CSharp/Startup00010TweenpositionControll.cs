// Decompiled with JetBrains decompiler
// Type: Startup00010TweenpositionControll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Startup00010TweenpositionControll : MonoBehaviour
{
  public List<Startup00010TweenPosition> TweenList;
  public bool play;
  public bool reverse;
  public bool reset;

  public void Play()
  {
    foreach (Startup00010TweenPosition tween in this.TweenList)
      tween.Play();
    this.play = false;
  }

  public void Reverse()
  {
    foreach (Startup00010TweenPosition tween in this.TweenList)
      tween.Reverse();
    this.reverse = false;
  }

  public void Reset()
  {
    foreach (Startup00010TweenPosition tween in this.TweenList)
      tween.Reset();
    this.reset = false;
  }

  private void Update()
  {
    if (this.play)
      this.Play();
    if (this.reverse)
      this.Reverse();
    if (!this.reset)
      return;
    this.Reset();
  }
}
