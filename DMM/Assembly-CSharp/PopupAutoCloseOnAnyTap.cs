// Decompiled with JetBrains decompiler
// Type: PopupAutoCloseOnAnyTap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class PopupAutoCloseOnAnyTap : BackButtonMenuBase
{
  protected void setEventOnAnyTap(Collider col = null)
  {
    if ((Object) col == (Object) null)
      col = (Collider) ((IEnumerable<BoxCollider>) this.transform.parent.GetComponentsInChildren<BoxCollider>()).FirstOrDefault<BoxCollider>();
    if (!((Object) col != (Object) null))
      return;
    EventDelegate.Set(col.gameObject.AddComponent<UIEventTrigger>().onRelease, new EventDelegate.Callback(this.onAnyTap));
  }

  public override void onBackButton() => this.onAnyTap();

  private void onAnyTap()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
