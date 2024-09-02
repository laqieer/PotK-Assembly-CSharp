// Decompiled with JetBrains decompiler
// Type: Linear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Linear
{
  private float from;
  private float to;
  private float currentTime;
  private float endTime;

  public Linear(float f, float e, float t)
  {
    this.currentTime = 0.0f;
    this.from = f;
    this.to = e;
    this.endTime = t;
  }

  public void Update(float time)
  {
    this.currentTime += time;
    if ((double) this.currentTime <= (double) this.endTime)
      return;
    this.currentTime = this.endTime;
  }

  public float value
  {
    get
    {
      if ((double) this.currentTime > (double) this.endTime)
        this.currentTime = this.endTime;
      return Mathf.Lerp(this.from, this.to, this.currentTime / this.endTime);
    }
  }

  public bool isEnd => (double) this.currentTime >= (double) this.endTime;
}
