// Decompiled with JetBrains decompiler
// Type: PopupPvpClassEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
