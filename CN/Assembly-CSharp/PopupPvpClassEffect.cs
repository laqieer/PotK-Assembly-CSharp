// Decompiled with JetBrains decompiler
// Type: PopupPvpClassEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
