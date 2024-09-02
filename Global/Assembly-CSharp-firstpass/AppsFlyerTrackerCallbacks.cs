// Decompiled with JetBrains decompiler
// Type: AppsFlyerTrackerCallbacks
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class AppsFlyerTrackerCallbacks : MonoBehaviour
{
  private void Start() => MonoBehaviour.print((object) "AppsFlyerTrackerCallbacks on Start");

  private void Update()
  {
  }

  public void didReceiveConversionData(string conversionData)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData));
  }

  public void didReceiveConversionDataWithError(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got conversion data error = " + error));
  }

  public void didFinishValidateReceipt(string validateResult)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got didFinishValidateReceipt  = " + validateResult));
  }

  public void didFinishValidateReceiptWithError(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got idFinishValidateReceiptWithError error = " + error));
  }

  public void onAppOpenAttribution(string validateResult)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = " + validateResult));
  }

  public void onAppOpenAttributionFailure(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error));
  }

  public void onInAppBillingSuccess()
  {
    MonoBehaviour.print((object) "AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess succcess");
  }

  public void onInAppBillingFailure(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = " + error));
  }
}
