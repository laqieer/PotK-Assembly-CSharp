// Decompiled with JetBrains decompiler
// Type: TextShake
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TextShake : MonoBehaviour
{
  public TextShake.State state;
  public float wieght = 15f;
  public float moveTime = 0.7f;
  public float timer;
  public GameObject obj;
  private float elapsedTime;
  private float posY;

  private void Start()
  {
    this.state = TextShake.State.None;
    this.posY = ((Component) this).gameObject.transform.localPosition.y;
  }

  private void Update()
  {
    float x = this.obj.transform.localPosition.x;
    if (this.state == TextShake.State.Start)
    {
      if ((double) x == 0.0 || (double) x <= -(double) this.wieght)
      {
        if (Object.op_Equality((Object) this.obj.GetComponent<TweenPosition>(), (Object) null))
        {
          TweenPosition tweenPosition = this.obj.AddComponent<TweenPosition>();
          tweenPosition.to = new Vector3(this.wieght, this.posY, 0.0f);
          tweenPosition.duration = this.moveTime;
          tweenPosition.method = UITweener.Method.EaseInOut;
          tweenPosition.PlayForward();
        }
        else
          TweenPosition.Begin(this.obj, this.moveTime, new Vector3(this.wieght, this.posY, 0.0f));
        this.state = TextShake.State.Wait;
      }
    }
    else if (this.state == TextShake.State.Wait)
    {
      if ((double) x >= (double) this.wieght)
      {
        TweenPosition.Begin(this.obj, this.moveTime, new Vector3(-this.wieght, this.posY, 0.0f));
        this.state = TextShake.State.Start;
      }
    }
    else if (this.state == TextShake.State.Stop)
    {
      TweenPosition.Begin(this.obj, 0.0f, new Vector3(0.0f, this.posY, 0.0f));
      this.elapsedTime = 0.0f;
      this.state = TextShake.State.None;
    }
    if ((double) this.timer == 0.0 || (double) x == 0.0)
      return;
    this.elapsedTime += Time.deltaTime;
    if ((double) this.elapsedTime <= (double) this.timer)
      return;
    this.elapsedTime = 0.0f;
    this.state = TextShake.State.Stop;
  }

  private void StartTextShake() => this.state = TextShake.State.Start;

  private void StopTextShake() => this.state = TextShake.State.Stop;

  public enum State
  {
    None,
    Start,
    Wait,
    Stop,
  }
}
