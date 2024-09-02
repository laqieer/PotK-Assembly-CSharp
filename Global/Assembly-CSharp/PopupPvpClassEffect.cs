// Decompiled with JetBrains decompiler
// Type: PopupPvpClassEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
