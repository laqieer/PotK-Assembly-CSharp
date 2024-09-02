// Decompiled with JetBrains decompiler
// Type: MetapsAnalyticsAndroidBridge
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class MetapsAnalyticsAndroidBridge : MetapsAnalyticsScript.IPlatformBridge
{
  private static AndroidJavaClass analyticsAndroid;

  private static AndroidJavaClass AnalyticsAndroid
  {
    get
    {
      if (MetapsAnalyticsAndroidBridge.analyticsAndroid == null)
        MetapsAnalyticsAndroidBridge.analyticsAndroid = new AndroidJavaClass("com.metaps.common.UnityWrapper");
      return MetapsAnalyticsAndroidBridge.analyticsAndroid;
    }
  }

  public override void SetCallbackHandlerImpl(string handlerName)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("setHandlerName", new object[1]
    {
      (object) handlerName
    });
  }

  public override void InitializeImpl(string applicationId, int sessionTime, string gcmSenderId)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("initialize", new object[3]
    {
      (object) applicationId,
      (object) sessionTime,
      (object) gcmSenderId
    });
  }

  public override void InitializeSettingsImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("initializeSettings", new object[0]);
  }

  public override void StartSessionImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("startSession", new object[0]);
  }

  public override void StopSessionImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("stopSession", new object[0]);
  }

  public override void TrackPurchaseImpl(string productId, double price, string currency)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("trackPurchase", new object[3]
    {
      (object) productId,
      (object) price,
      (object) currency
    });
  }

  public override void TrackEventImpl(string category, string name, int value)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("trackEvent", new object[3]
    {
      (object) category,
      (object) name,
      (object) value
    });
  }

  public override void SendCustomLogImpl(string category, string value)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("sendCustomLog", new object[2]
    {
      (object) category,
      (object) value
    });
  }

  public override void TrackSpendImpl(string category, string name, int value)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("trackSpend", new object[3]
    {
      (object) category,
      (object) name,
      (object) value
    });
  }

  public override void SetLogEnabledImpl(bool enabled)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("setLogEnabled", new object[1]
    {
      (object) enabled
    });
  }

  public override void SetAttributeImpl(string key, string value)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("setAttribute", new object[2]
    {
      (object) key,
      (object) value
    });
  }

  public override void SetUserProfileImpl(string profileKey, string profileValue)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("setUserProfile", new object[2]
    {
      (object) profileKey,
      (object) profileValue
    });
  }

  public override void TrackActionImpl(string name)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("trackAction", new object[1]
    {
      (object) name
    });
  }

  public override void TrackActionImpl(string name, string value)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("trackAction", new object[2]
    {
      (object) name,
      (object) value
    });
  }

  public override void SetDeviceTokenStringImpl(string deviceTokenString)
  {
  }

  public override void ReceiveNotificationIdImpl(string notificationId, string customText)
  {
  }

  public override string GetPushNotificationCustomTextImpl()
  {
    return ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic<string>("getPushNotificationCustomText", new object[0]);
  }

  public override bool IsPushNotificationEnabled()
  {
    return ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic<bool>("isPushNotificationEnabled", new object[0]);
  }

  public override bool SetPushNotificationEnabled(bool enabled)
  {
    return ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic<bool>("setPushNotificationEnabled", new object[1]
    {
      (object) enabled
    });
  }

  public override void ShowIconImpl(string spotCode, int count, int position, int orientation)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("showIcon", new object[4]
    {
      (object) spotCode,
      (object) count,
      (object) position,
      (object) orientation
    });
  }

  public override void DismissIconImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("dismissIcon", new object[0]);
  }

  public override void LoadInterstitialImpl(string spotCode, bool useListener)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("loadInterstitial", new object[2]
    {
      (object) spotCode,
      (object) useListener
    });
  }

  public override void ShowInterstitialImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("showInterstitial", new object[0]);
  }

  public override void DismissInterstitialImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("dismissInterstitial", new object[0]);
  }

  public override void ShowBannerImpl(
    int typeBanner,
    string spotCode,
    int position,
    bool fitScreenWidth)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("showBanner", new object[4]
    {
      (object) typeBanner,
      (object) spotCode,
      (object) position,
      (object) fitScreenWidth
    });
  }

  public override void DismissBannerImpl(int typeBanner)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("dismissBanner", new object[1]
    {
      (object) typeBanner
    });
  }

  public override void InitializeOfferwallImpl(string spotCode, bool useReceiver, bool testMode)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("initializeOfferwall", new object[3]
    {
      (object) spotCode,
      (object) useReceiver,
      (object) testMode
    });
  }

  public override bool IsInitializedOfferwallImpl()
  {
    return ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic<bool>("isInitializedOfferwall", new object[0]);
  }

  public override void LaunchOfferwallImpl(string endUserId, string scenario)
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("launchOfferwall", new object[2]
    {
      (object) endUserId,
      (object) scenario
    });
  }

  public override void ConfirmRewardsOfferwallImpl()
  {
    ((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic("confirmRewardsOfferwall", new object[0]);
  }

  public override MetapsAnalyticsScript.Offer BuildOfferFromJsonImpl(string offerJsonString)
  {
    return (MetapsAnalyticsScript.Offer) new MetapsAnalyticsAndroidBridge.AndroidOffer(((AndroidJavaObject) MetapsAnalyticsAndroidBridge.AnalyticsAndroid).CallStatic<AndroidJavaObject>("buildOfferFromJson", new object[1]
    {
      (object) offerJsonString
    }));
  }

  public class AndroidOffer : MetapsAnalyticsScript.Offer
  {
    public AndroidOffer(AndroidJavaObject androidOffer)
    {
      this.AppId = androidOffer.Call<string>("getAppId", new object[0]);
      this.CampaignId = androidOffer.Call<string>("getCampaignId", new object[0]);
      this.PackageName = androidOffer.Call<string>("getPackageName", new object[0]);
      this.Scenario = androidOffer.Call<string>("getScenario", new object[0]);
      this.AppName = androidOffer.Call<string>("getAppName", new object[0]);
      this.RewardEndUser = androidOffer.Call<int>("getRewardForUser", new object[0]);
      this.RewardDeveloper = androidOffer.Call<int>("getRewardForMedia", new object[0]);
      this.OfferStatus = androidOffer.Call<int>("getStatus", new object[0]);
    }
  }
}
