// Decompiled with JetBrains decompiler
// Type: PurchaseLoadingLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    PurchaseLoadingLayer.\u003CEnable\u003Ec__IteratorA07 enableCIteratorA07 = new PurchaseLoadingLayer.\u003CEnable\u003Ec__IteratorA07();
    return (IEnumerator) enableCIteratorA07;
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
    PurchaseLoadingLayer.\u003CShowLoading\u003Ec__IteratorA08 loadingCIteratorA08 = new PurchaseLoadingLayer.\u003CShowLoading\u003Ec__IteratorA08();
    return (IEnumerator) loadingCIteratorA08;
  }
}
