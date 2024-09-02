// Decompiled with JetBrains decompiler
// Type: AppsflyerTrackerCallbacks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AppsflyerTrackerCallbacks : MonoBehaviour
{
  public void didReceiveConversionData(string conversionData)
  {
    Debug.Log((object) (Appsflyer.LOG_CATEGORY + "Received conversion data: " + conversionData));
  }

  public void didReceiveConversionDataWithError(string error)
  {
    Debug.LogError((object) (Appsflyer.LOG_CATEGORY + "Error receiving conversion data: " + error));
  }

  public void onAppOpenAttribution(string validateResult)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onAppOpenAttribution = " + validateResult));
  }

  public void onAppOpenAttributionFailure(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error));
  }

  public void onInAppBillingSuccess()
  {
    MonoBehaviour.print((object) "AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess success");
  }

  public void onInAppBillingFailure(string error)
  {
    MonoBehaviour.print((object) ("AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = " + error));
  }
}
