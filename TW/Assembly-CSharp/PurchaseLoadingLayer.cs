// Decompiled with JetBrains decompiler
// Type: PurchaseLoadingLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
internal class PurchaseLoadingLayer
{
  private static bool isActive;
  private static GameObject layer;

  [DebuggerHidden]
  public static IEnumerator Enable()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PurchaseLoadingLayer.\u003CEnable\u003Ec__IteratorAE2 enableCIteratorAe2 = new PurchaseLoadingLayer.\u003CEnable\u003Ec__IteratorAE2();
    return (IEnumerator) enableCIteratorAe2;
  }

  public static void Disable()
  {
    PurchaseLoadingLayer.isActive = false;
    if (!Object.op_Inequality((Object) PurchaseLoadingLayer.layer, (Object) null))
      return;
    PaymentListener.PopupDismiss();
    PurchaseLoadingLayer.layer = (GameObject) null;
  }

  [DebuggerHidden]
  private static IEnumerator ShowLoading()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    PurchaseLoadingLayer.\u003CShowLoading\u003Ec__IteratorAE3 loadingCIteratorAe3 = new PurchaseLoadingLayer.\u003CShowLoading\u003Ec__IteratorAE3();
    return (IEnumerator) loadingCIteratorAe3;
  }
}
