// Decompiled with JetBrains decompiler
// Type: PurchaseLoadingLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    PurchaseLoadingLayer.\u003CEnable\u003Ec__Iterator88C enableCIterator88C = new PurchaseLoadingLayer.\u003CEnable\u003Ec__Iterator88C();
    return (IEnumerator) enableCIterator88C;
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
    PurchaseLoadingLayer.\u003CShowLoading\u003Ec__Iterator88D loadingCIterator88D = new PurchaseLoadingLayer.\u003CShowLoading\u003Ec__Iterator88D();
    return (IEnumerator) loadingCIterator88D;
  }
}
