// Decompiled with JetBrains decompiler
// Type: MetapsAnalyticsDefaultBridge
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

#nullable disable
public class MetapsAnalyticsDefaultBridge : MetapsAnalyticsScript.IPlatformBridge
{
  public override void SetCallbackHandlerImpl(string handlerName)
  {
  }

  public override void InitializeImpl(string applicationId, int sessionTime, string gcmSenderId)
  {
  }

  public override void InitializeSettingsImpl()
  {
  }

  public override void StartSessionImpl()
  {
  }

  public override void StopSessionImpl()
  {
  }

  public override void TrackPurchaseImpl(string productId, double price, string currency)
  {
  }

  public override void TrackEventImpl(string category, string name, int value)
  {
  }

  public override void SendCustomLogImpl(string category, string value)
  {
  }

  public override void TrackSpendImpl(string category, string name, int value)
  {
  }

  public override void SetLogEnabledImpl(bool enabled)
  {
  }

  public override void SetAttributeImpl(string key, string value)
  {
  }

  public override void SetUserProfileImpl(string profileKey, string profileValue)
  {
  }

  public override void TrackActionImpl(string name)
  {
  }

  public override void TrackActionImpl(string name, string value)
  {
  }

  public override void SetDeviceTokenStringImpl(string deviceTokenString)
  {
  }

  public override void ReceiveNotificationIdImpl(string notificationId, string customText)
  {
  }

  public override string GetPushNotificationCustomTextImpl() => (string) null;

  public override bool IsPushNotificationEnabled() => false;

  public override bool SetPushNotificationEnabled(bool enabled) => false;

  public override void ShowIconImpl(string spotCode, int count, int position, int orientation)
  {
  }

  public override void DismissIconImpl()
  {
  }

  public override void LoadInterstitialImpl(string spotCode, bool useListener)
  {
  }

  public override void ShowInterstitialImpl()
  {
  }

  public override void DismissInterstitialImpl()
  {
  }

  public override void ShowBannerImpl(
    int typeBanner,
    string spotCode,
    int position,
    bool fitScreenWidth)
  {
  }

  public override void DismissBannerImpl(int typeBanner)
  {
  }

  public override void InitializeOfferwallImpl(string spotCode, bool useReceiver, bool testMode)
  {
  }

  public override bool IsInitializedOfferwallImpl() => false;

  public override void LaunchOfferwallImpl(string endUserId, string scenario)
  {
  }

  public override void ConfirmRewardsOfferwallImpl()
  {
  }

  public override MetapsAnalyticsScript.Offer BuildOfferFromJsonImpl(string offerJsonString)
  {
    return (MetapsAnalyticsScript.Offer) null;
  }
}
