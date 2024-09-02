// Decompiled with JetBrains decompiler
// Type: Startup00010TweenPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
