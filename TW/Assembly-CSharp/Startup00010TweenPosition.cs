// Decompiled with JetBrains decompiler
// Type: Startup00010TweenPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup00010TweenPosition : MonoBehaviour
{
  private UITweener tp;

  private bool GetTP()
  {
    this.tp = ((Component) this).gameObject.GetComponent<UITweener>();
    return Object.op_Implicit((Object) this.tp);
  }

  public void Play()
  {
    if (!this.GetTP())
      return;
    this.tp.PlayForward();
  }

  public void Reverse()
  {
    if (!this.GetTP())
      return;
    this.tp.PlayReverse();
  }

  public void Reset()
  {
    if (!this.GetTP())
      return;
    this.tp.ResetToBeginning();
  }
}
