// Decompiled with JetBrains decompiler
// Type: Appsflyer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public static class Appsflyer
{
  public static readonly string LOG_CATEGORY = "<color=#75b82c><b>[APPSFLYER]</b></color> ";

  public static void Setup()
  {
    bool isDebug = false;
    AppsFlyer.init("WMa4kPf8ZdvNhcpvdpwAvE");
    AppsFlyer.setAppID("jp.co.gu3.punkww");
    AppsFlyer.setIsDebug(isDebug);
    AppsFlyer.loadConversionData("AppsflyerTrackerCallbacks", "didReceiveConversionData", "didReceiveConversionDataWithError");
    AppsFlyer.trackAppLaunch();
  }

  public static void SetCustomerID(string customerID) => AppsFlyer.setCustomerUserID(customerID);

  public static void TrackPurchase(string productId, double price, string currency)
  {
    AppsFlyer.trackRichEvent("af_purchase", new Dictionary<string, string>()
    {
      {
        "af_currency",
        currency
      },
      {
        "af_revenue",
        string.Format("{0:0.00}", (object) price)
      },
      {
        "af_quantity",
        "1"
      }
    });
  }

  public static void TrackSimpleEvent(string key, string payload)
  {
    AppsFlyer.trackRichEvent(key, new Dictionary<string, string>()
    {
      {
        key,
        payload
      }
    });
  }

  public static void TrackEvent(string key, Dictionary<string, string> payload)
  {
    AppsFlyer.trackRichEvent(key, payload);
  }
}
