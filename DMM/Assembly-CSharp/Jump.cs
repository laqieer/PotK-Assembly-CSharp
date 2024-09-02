// Decompiled with JetBrains decompiler
// Type: Jump
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Jump : MonoBehaviour
{
  public Jump.JumpEffect state;
  public float jump = 60f;
  public float time = 0.1f;
  private float afterPos;

  public void StartJump()
  {
  }

  private void Start() => this.state = Jump.JumpEffect.None;

  private void Update()
  {
    if (this.state != Jump.JumpEffect.Start)
      return;
    float y = this.transform.localPosition.y;
    float x = this.transform.localPosition.x;
    if ((double) y == (double) this.afterPos || (double) y <= (double) this.afterPos)
      TweenPosition.Begin(this.gameObject, this.time, new Vector3(x, this.jump, 0.0f));
    if ((double) y < (double) this.jump)
      return;
    TweenPosition.Begin(this.gameObject, this.time, new Vector3(x, this.afterPos, 0.0f));
    this.state = Jump.JumpEffect.None;
  }

  public enum JumpEffect
  {
    None,
    Start,
  }
}
