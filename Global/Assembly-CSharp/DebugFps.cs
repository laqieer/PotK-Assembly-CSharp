// Decompiled with JetBrains decompiler
// Type: DebugFps
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DebugFps : Singleton<DebugFps>
{
  public float fps;
  public float fpsCalcTime = 0.1f;
  private float time;
  private int fpsCount;

  protected override void Initialize()
  {
  }

  private void Start()
  {
    this.time = 0.0f;
    this.fps = 0.0f;
    this.fpsCount = 0;
  }

  private void LateUpdate()
  {
    this.time += Time.deltaTime;
    ++this.fpsCount;
    if ((double) this.time <= (double) this.fpsCalcTime)
      return;
    this.fps = (float) this.fpsCount / this.time;
    this.time = 0.0f;
    this.fpsCount = 0;
  }
}
