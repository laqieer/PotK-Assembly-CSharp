// Decompiled with JetBrains decompiler
// Type: MetapsAnalyticsScript
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
public class MetapsAnalyticsScript : MonoBehaviour
{
  public const string ProfileKeyOriginalId = "ORIGINAL_ID";
  public const string ProfileKeyName = "NAME";
  public const string ProfileKeyAge = "AGE";
  public const string ProfileKeyAgeGroup = "AGE_GROUP";
  public const string ProfileKeyGender = "GENDER";
  public const string ProfileKeyLevel = "LEVEL";
  public const string ProfileKeyRank = "RANK";
  public const string ProfileKeyFriendsCount = "FRIENDS_COUNT";
  public const int IconOrientationHorizontal = 0;
  public const int IconOrientationVertical = 1;
  public const int IconPositionTopLeft = 0;
  public const int IconPositionTop = 1;
  public const int IconPositionTopRight = 2;
  public const int IconPositionLeft = 3;
  public const int IconPositionRight = 4;
  public const int IconPositionBottomLeft = 5;
  public const int IconPositionBottom = 6;
  public const int IconPositionBottomRight = 7;
  public const int BannerPositionTop = 1;
  public const int BannerPositionBottom = 6;
  public const int ShowErrorNoApplication = 0;
  public const int ShowErrorGUI = 1;
  public const int ShowNoticeNoQualifiedApp = 2;
  public const int ShowNoticeNotLoaded = 3;
  public const int DismissBackButton = 0;
  public const int DismissCloseButton = 1;
  public const int DismissOutside = 2;
  public const int DismissDownload = 3;
  public const int DismissMethodCall = 4;
  public const int DismissOpenUrl = 5;
  private const int TypeBanner = 3;
  private const int TypeBigBanner = 4;
  private const int TypeRectangleBanner = 5;
  public string iosApplicationId = string.Empty;
  public string androidApplicationId = string.Empty;
  private string applicationId;
  public bool useDebugLog;
  public string gcmSenderId = string.Empty;
  public bool useApns;
  private MetapsAnalyticsNotification notification;
  public int sessionTime = 60;
  private static MetapsAnalyticsScript.IPlatformBridge scriptBridge;
  private bool booted;

  public static event System.Action onShow;

  public static event Action<int> onShowNotPossible;

  public static event Action<int> onDismiss;

  public static event Action<int, MetapsAnalyticsScript.Offer> retrievePoints;

  public static event Action<MetapsAnalyticsScript.Offer> finalizeOfferOnError;

  public void Awake()
  {
    if (!Application.isPlaying)
      return;
    if (MetapsAnalyticsScript.scriptBridge != null)
    {
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      MetapsAnalyticsScript.scriptBridge = (MetapsAnalyticsScript.IPlatformBridge) new MetapsAnalyticsAndroidBridge();
      this.applicationId = this.androidApplicationId;
      MetapsAnalyticsScript.scriptBridge.SetLogEnabledImpl(this.useDebugLog);
      MetapsAnalyticsScript.scriptBridge.InitializeImpl(this.applicationId, this.sessionTime, this.gcmSenderId);
      MetapsAnalyticsScript.scriptBridge.InitializeSettingsImpl();
      ((Object) ((Component) this).gameObject).name = ((object) this).GetType().ToString();
      MetapsAnalyticsScript.scriptBridge.SetCallbackHandlerImpl(((Object) ((Component) this).gameObject).name);
      Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
      MetapsAnalyticsScript.scriptBridge.StartSessionImpl();
    }
  }

  private void OnApplicationPause(bool pauseStatus)
  {
    if (pauseStatus)
      MetapsAnalyticsScript.scriptBridge.StopSessionImpl();
    else if (this.booted)
      MetapsAnalyticsScript.scriptBridge.StartSessionImpl();
    else
      this.booted = true;
  }

  public static void TrackPurchase(string productId, double price, string currency)
  {
    MetapsAnalyticsScript.scriptBridge.TrackPurchaseImpl(productId, price, currency);
  }

  public static void TrackEvent(string category, string name)
  {
    MetapsAnalyticsScript.scriptBridge.TrackEventImpl(category, name, 1);
  }

  public static void TrackEvent(string category, string name, int value)
  {
    MetapsAnalyticsScript.scriptBridge.TrackEventImpl(category, name, value);
  }

  public static void SendCustomLog(string category, string value)
  {
    MetapsAnalyticsScript.scriptBridge.SendCustomLogImpl(category, value);
  }

  public static void TrackSpend(string category, string name, int value)
  {
    MetapsAnalyticsScript.scriptBridge.TrackSpendImpl(category, name, value);
  }

  public static void SetLogEnabled(bool enabled)
  {
    MetapsAnalyticsScript.scriptBridge.SetLogEnabledImpl(enabled);
  }

  public static void SetAttribute(string key, string value)
  {
    MetapsAnalyticsScript.scriptBridge.SetAttributeImpl(key, value);
  }

  public static void SetUserProfile(string profileKey, string profileValue)
  {
    MetapsAnalyticsScript.scriptBridge.SetUserProfileImpl(profileKey, profileValue);
  }

  public static void TrackAction(string name)
  {
    MetapsAnalyticsScript.scriptBridge.TrackActionImpl(name);
  }

  public static void TrackAction(string name, string value)
  {
    MetapsAnalyticsScript.scriptBridge.TrackActionImpl(name, value);
  }

  public static string GetPushNotificationCustomText()
  {
    return MetapsAnalyticsScript.scriptBridge.GetPushNotificationCustomTextImpl();
  }

  public static bool IsPushNotificationEnabled()
  {
    return MetapsAnalyticsScript.scriptBridge.IsPushNotificationEnabled();
  }

  public static bool SetPushNotificationEnabled(bool enabled)
  {
    return MetapsAnalyticsScript.scriptBridge.SetPushNotificationEnabled(enabled);
  }

  public void AdSpotListenerOnShow()
  {
    if (MetapsAnalyticsScript.onShow == null)
      return;
    MetapsAnalyticsScript.onShow();
  }

  public void AdSpotListenerOnShowNotPossible(string cause)
  {
    if (MetapsAnalyticsScript.onShowNotPossible == null)
      return;
    try
    {
      MetapsAnalyticsScript.onShowNotPossible(Convert.ToInt32(cause));
    }
    catch
    {
      Debug.Log((object) ("METAPS_UNITY Wrapper sends an incorrect cause [" + cause + "]"));
      MetapsAnalyticsScript.onShowNotPossible(0);
    }
  }

  public void AdSpotListenerOnDismiss(string cause)
  {
    if (MetapsAnalyticsScript.onDismiss == null)
      return;
    try
    {
      MetapsAnalyticsScript.onDismiss(Convert.ToInt32(cause));
    }
    catch
    {
      Debug.Log((object) ("METAPS_UNITY Wrapper sends an incorrect cause [" + cause + "]"));
      MetapsAnalyticsScript.onDismiss(1);
    }
  }

  public void ReceiverRetrieve(string offerJsonString)
  {
    if (MetapsAnalyticsScript.retrievePoints == null)
      return;
    MetapsAnalyticsScript.Offer offer = MetapsAnalyticsScript.scriptBridge.BuildOfferFromJsonImpl(offerJsonString);
    MetapsAnalyticsScript.retrievePoints(offer.RewardEndUser, offer);
  }

  public void ReceiverFinalizeOnError(string offerJsonString)
  {
    if (MetapsAnalyticsScript.finalizeOfferOnError == null)
      return;
    MetapsAnalyticsScript.Offer offer = MetapsAnalyticsScript.scriptBridge.BuildOfferFromJsonImpl(offerJsonString);
    MetapsAnalyticsScript.finalizeOfferOnError(offer);
  }

  public abstract class IPlatformBridge
  {
    public abstract void SetCallbackHandlerImpl(string handlerName);

    public abstract void InitializeImpl(string applicationId, int sessionTime, string gcmSenderId);

    public abstract void InitializeSettingsImpl();

    public abstract void StartSessionImpl();

    public abstract void StopSessionImpl();

    public abstract void TrackPurchaseImpl(string productId, double price, string currency);

    public abstract void TrackEventImpl(string category, string name, int value);

    public abstract void SendCustomLogImpl(string category, string value);

    public abstract void TrackSpendImpl(string category, string name, int value);

    public abstract void SetLogEnabledImpl(bool enabled);

    public abstract void SetAttributeImpl(string key, string value);

    public abstract void SetUserProfileImpl(string profileKey, string profileValue);

    public abstract void TrackActionImpl(string name);

    public abstract void TrackActionImpl(string name, string value);

    public abstract void SetDeviceTokenStringImpl(string deviceTokenString);

    public abstract void ReceiveNotificationIdImpl(string notificationId, string customText);

    public abstract string GetPushNotificationCustomTextImpl();

    public abstract bool IsPushNotificationEnabled();

    public abstract bool SetPushNotificationEnabled(bool enabled);

    public abstract void ShowIconImpl(string spotCode, int count, int position, int orientation);

    public abstract void DismissIconImpl();

    public abstract void LoadInterstitialImpl(string spotCode, bool useListener);

    public abstract void ShowInterstitialImpl();

    public abstract void DismissInterstitialImpl();

    public abstract void ShowBannerImpl(
      int typeBanner,
      string spotCode,
      int position,
      bool fitScreenWidth);

    public abstract void DismissBannerImpl(int typeBanner);

    public abstract void InitializeOfferwallImpl(string spotCode, bool useReceiver, bool testMode);

    public abstract bool IsInitializedOfferwallImpl();

    public abstract void LaunchOfferwallImpl(string endUserId, string scenario);

    public abstract void ConfirmRewardsOfferwallImpl();

    public abstract MetapsAnalyticsScript.Offer BuildOfferFromJsonImpl(string offerJsonString);
  }

  public class Icon
  {
    private string spotCode = string.Empty;
    private int count = -1;
    private int position = -1;
    private int orientation = -1;

    public Icon(string androidSpotCode, string iosSpotCode) => this.spotCode = androidSpotCode;

    public MetapsAnalyticsScript.Icon SetCount(int count)
    {
      this.count = count;
      return this;
    }

    public MetapsAnalyticsScript.Icon SetPosition(int position)
    {
      this.position = position;
      return this;
    }

    public MetapsAnalyticsScript.Icon SetOrientation(int orientation)
    {
      this.orientation = orientation;
      return this;
    }

    public void Show()
    {
      MetapsAnalyticsScript.scriptBridge.ShowIconImpl(this.spotCode, this.count, this.position, this.orientation);
    }

    public static void Dismiss() => MetapsAnalyticsScript.scriptBridge.DismissIconImpl();
  }

  public class Interstitial
  {
    private string spotCode = string.Empty;
    private bool useListener;

    public Interstitial(string androidSpotCode, string iosSpotCode)
    {
      this.spotCode = androidSpotCode;
    }

    public MetapsAnalyticsScript.Interstitial SetUseListener(bool useListener)
    {
      this.useListener = useListener;
      return this;
    }

    public void Load()
    {
      MetapsAnalyticsScript.scriptBridge.LoadInterstitialImpl(this.spotCode, this.useListener);
    }

    public static void Show() => MetapsAnalyticsScript.scriptBridge.ShowInterstitialImpl();

    public static void Dismiss() => MetapsAnalyticsScript.scriptBridge.DismissInterstitialImpl();
  }

  public abstract class BannerBase
  {
    private string spotCode = string.Empty;
    private int typeBanner = 3;
    private int position = -1;
    private bool fitScreenWidth;

    public BannerBase(int typeBanner, string androidSpotCode, string iosSpotCode)
    {
      this.typeBanner = typeBanner;
      this.spotCode = androidSpotCode;
    }

    public MetapsAnalyticsScript.BannerBase SetFitScreenWidth(bool fitScreenWidth)
    {
      this.fitScreenWidth = fitScreenWidth;
      return this;
    }

    public MetapsAnalyticsScript.BannerBase SetPosition(int position)
    {
      this.position = position;
      return this;
    }

    public void Show()
    {
      MetapsAnalyticsScript.scriptBridge.ShowBannerImpl(this.typeBanner, this.spotCode, this.position, this.fitScreenWidth);
    }
  }

  public class Banner : MetapsAnalyticsScript.BannerBase
  {
    public Banner(string androidSpotCode, string iosSpotCode)
      : base(3, androidSpotCode, iosSpotCode)
    {
    }

    public static void Dismiss() => MetapsAnalyticsScript.scriptBridge.DismissBannerImpl(3);
  }

  public class BigBanner : MetapsAnalyticsScript.BannerBase
  {
    public BigBanner(string androidSpotCode, string iosSpotCode)
      : base(4, androidSpotCode, iosSpotCode)
    {
    }

    public static void Dismiss() => MetapsAnalyticsScript.scriptBridge.DismissBannerImpl(4);
  }

  public class RectangleBanner : MetapsAnalyticsScript.BannerBase
  {
    public RectangleBanner(string androidSpotCode, string iosSpotCode)
      : base(5, androidSpotCode, iosSpotCode)
    {
    }

    public static void Dismiss() => MetapsAnalyticsScript.scriptBridge.DismissBannerImpl(5);
  }

  public class Offerwall
  {
    private string spotCode = string.Empty;
    private bool useReceiver;
    private bool testMode;

    public Offerwall(string spotCode) => this.spotCode = spotCode;

    public MetapsAnalyticsScript.Offerwall SetUseReceiver(bool useReceiver)
    {
      this.useReceiver = useReceiver;
      return this;
    }

    public MetapsAnalyticsScript.Offerwall SetTestMode(bool testMode)
    {
      this.testMode = testMode;
      return this;
    }

    public void Initialize()
    {
      MetapsAnalyticsScript.scriptBridge.InitializeOfferwallImpl(this.spotCode, this.useReceiver, this.testMode);
    }

    public static bool IsInitialized()
    {
      return MetapsAnalyticsScript.scriptBridge.IsInitializedOfferwallImpl();
    }

    public static void Launch(string endUserId, string scenario)
    {
      MetapsAnalyticsScript.scriptBridge.LaunchOfferwallImpl(endUserId, scenario);
    }

    public static void ConfirmRewards()
    {
      MetapsAnalyticsScript.scriptBridge.ConfirmRewardsOfferwallImpl();
    }
  }

  public class Offer
  {
    public string AppId;
    public string CampaignId;
    public string PackageName;
    public string Scenario;
    public string AppName;
    public int RewardEndUser;
    public int RewardDeveloper;
    public int OfferStatus;
  }
}
