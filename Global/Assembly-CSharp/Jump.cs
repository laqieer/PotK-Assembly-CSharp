// Decompiled with JetBrains decompiler
// Type: Jump
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Jump : MonoBehaviour
{
  public Jump.JumpEffect state;
  public float jump = 60f;
  public float time = 0.1f;
  private float afterPos;

  private void Start() => this.state = Jump.JumpEffect.None;

  private void Update()
  {
    if (this.state != Jump.JumpEffect.Start)
      return;
    float y = ((Component) this).transform.localPosition.y;
    float x = ((Component) this).transform.localPosition.x;
    if ((double) y == (double) this.afterPos || (double) y <= (double) this.afterPos)
      TweenPosition.Begin(((Component) this).gameObject, this.time, new Vector3(x, this.jump, 0.0f));
    if ((double) y < (double) this.jump)
      return;
    TweenPosition.Begin(((Component) this).gameObject, this.time, new Vector3(x, this.afterPos, 0.0f));
    this.state = Jump.JumpEffect.None;
  }

  public enum JumpEffect
  {
    None,
    Start,
  }
}
