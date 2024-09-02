// Decompiled with JetBrains decompiler
// Type: PopupPvpClassEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PopupPvpClassEffect : MonoBehaviour
{
  private System.Action actEnd;
  private System.Action actTouch;

  public void Init(System.Action actEnd, System.Action actTouch)
  {
    this.actEnd = actEnd;
    this.actTouch = actTouch;
  }

  public void End()
  {
    if (this.actEnd == null)
      return;
    this.actEnd();
  }

  public void Touch()
  {
    if (this.actTouch == null)
      return;
    this.actTouch();
  }
}
