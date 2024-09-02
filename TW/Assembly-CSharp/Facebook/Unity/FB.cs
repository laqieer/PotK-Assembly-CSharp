// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.FB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.Unity.Canvas;
using Facebook.Unity.Mobile;
using Facebook.Unity.Mobile.Android;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  public sealed class FB : ScriptableObject
  {
    private static InitDelegate onInitComplete;
    private static HideUnityDelegate onHideUnity;
    private static FacebookGameObject facebook;
    private static string authResponse;
    private static bool isInitCalled;
    private static string appId;
    private static bool cookie;
    private static bool logging;
    private static bool status;
    private static bool xfbml;
    private static bool frictionlessRequests;

    public static string AppId => FB.appId;

    public static bool IsLoggedIn
    {
      get => Object.op_Inequality((Object) FB.facebook, (Object) null) && FB.FacebookImpl.LoggedIn;
    }

    public static bool IsInitialized
    {
      get => Object.op_Inequality((Object) FB.facebook, (Object) null) && FB.facebook.Initialized;
    }

    public static bool LimitAppEventUsage
    {
      get
      {
        return Object.op_Inequality((Object) FB.facebook, (Object) null) && FB.facebook.Facebook.LimitEventUsage;
      }
      set
      {
        if (!Object.op_Inequality((Object) FB.facebook, (Object) null))
          return;
        FB.facebook.Facebook.LimitEventUsage = value;
      }
    }

    internal static IFacebook FacebookImpl
    {
      get
      {
        return !Object.op_Equality((Object) FB.facebook, (Object) null) ? (IFacebook) FB.facebook.Facebook : throw new NullReferenceException("Facebook object is not yet loaded.  Did you call FB.Init()?");
      }
    }

    public static void Init(
      InitDelegate onInitComplete = null,
      HideUnityDelegate onHideUnity = null,
      string authResponse = null)
    {
      FB.Init(FacebookSettings.AppId, FacebookSettings.Cookie, FacebookSettings.Logging, FacebookSettings.Status, FacebookSettings.Xfbml, FacebookSettings.FrictionlessRequests, authResponse, onHideUnity, onInitComplete);
    }

    public static void Init(
      string appId,
      bool cookie = true,
      bool logging = true,
      bool status = true,
      bool xfbml = false,
      bool frictionlessRequests = true,
      string authResponse = null,
      HideUnityDelegate onHideUnity = null,
      InitDelegate onInitComplete = null)
    {
      FB.appId = !string.IsNullOrEmpty(appId) ? appId : throw new ArgumentException("appId cannot be null or empty!");
      FB.cookie = cookie;
      FB.logging = logging;
      FB.status = status;
      FB.xfbml = xfbml;
      FB.frictionlessRequests = frictionlessRequests;
      FB.authResponse = authResponse;
      FB.onInitComplete = onInitComplete;
      FB.onHideUnity = onHideUnity;
      if (!FB.isInitCalled)
      {
        FB.LogVersion();
        ComponentFactory.GetComponent<AndroidFacebookLoader>();
        FB.isInitCalled = true;
      }
      else
      {
        FacebookLogger.Warn("FB.Init() has already been called.  You only need to call this once and only once.");
        if (FB.FacebookImpl == null)
          return;
        FB.OnDllLoaded();
      }
    }

    public static void LogInWithPublishPermissions(
      IEnumerable<string> permissions = null,
      FacebookDelegate<ILoginResult> callback = null)
    {
      FB.FacebookImpl.LogInWithPublishPermissions(permissions, callback);
    }

    public static void LogInWithReadPermissions(
      IEnumerable<string> permissions = null,
      FacebookDelegate<ILoginResult> callback = null)
    {
      FB.FacebookImpl.LogInWithReadPermissions(permissions, callback);
    }

    public static void LogOut() => FB.FacebookImpl.LogOut();

    public static void AppRequest(
      string message,
      OGActionType actionType,
      string objectId,
      IEnumerable<string> to,
      string data = "",
      string title = "",
      FacebookDelegate<IAppRequestResult> callback = null)
    {
      FB.FacebookImpl.AppRequest(message, new OGActionType?(actionType), objectId, to, (IEnumerable<object>) null, (IEnumerable<string>) null, new int?(), data, title, callback);
    }

    public static void AppRequest(
      string message,
      OGActionType actionType,
      string objectId,
      IEnumerable<object> filters = null,
      IEnumerable<string> excludeIds = null,
      int? maxRecipients = null,
      string data = "",
      string title = "",
      FacebookDelegate<IAppRequestResult> callback = null)
    {
      FB.FacebookImpl.AppRequest(message, new OGActionType?(actionType), objectId, (IEnumerable<string>) null, filters, excludeIds, maxRecipients, data, title, callback);
    }

    public static void AppRequest(
      string message,
      IEnumerable<string> to = null,
      IEnumerable<object> filters = null,
      IEnumerable<string> excludeIds = null,
      int? maxRecipients = null,
      string data = "",
      string title = "",
      FacebookDelegate<IAppRequestResult> callback = null)
    {
      FB.FacebookImpl.AppRequest(message, new OGActionType?(), (string) null, to, filters, excludeIds, maxRecipients, data, title, callback);
    }

    public static void ShareLink(
      Uri contentURL = null,
      string contentTitle = "",
      string contentDescription = "",
      Uri photoURL = null,
      FacebookDelegate<IShareResult> callback = null)
    {
      FB.FacebookImpl.ShareLink(contentURL, contentTitle, contentDescription, photoURL, callback);
    }

    public static void FeedShare(
      string toId = "",
      Uri link = null,
      string linkName = "",
      string linkCaption = "",
      string linkDescription = "",
      Uri picture = null,
      string mediaSource = "",
      FacebookDelegate<IShareResult> callback = null)
    {
      FB.FacebookImpl.FeedShare(toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, callback);
    }

    public static void API(
      string query,
      HttpMethod method,
      FacebookDelegate<IGraphResult> callback = null,
      IDictionary<string, string> formData = null)
    {
      FB.FacebookImpl.API(query, method, formData, callback);
    }

    public static void API(
      string query,
      HttpMethod method,
      FacebookDelegate<IGraphResult> callback,
      WWWForm formData)
    {
      FB.FacebookImpl.API(query, method, formData, callback);
    }

    public static void ActivateApp() => FB.FacebookImpl.ActivateApp(FB.AppId);

    public static void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      if (callback == null)
        return;
      FB.FacebookImpl.GetAppLink(callback);
    }

    public static void GameGroupCreate(
      string name,
      string description,
      string privacy = "CLOSED",
      FacebookDelegate<IGroupCreateResult> callback = null)
    {
      FB.FacebookImpl.GameGroupCreate(name, description, privacy, callback);
    }

    public static void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback = null)
    {
      FB.FacebookImpl.GameGroupJoin(id, callback);
    }

    public static void LogAppEvent(
      string logEvent,
      float? valueToSum = null,
      Dictionary<string, object> parameters = null)
    {
      FB.FacebookImpl.AppEventsLogEvent(logEvent, valueToSum, parameters);
    }

    public static void LogPurchase(
      float logPurchase,
      string currency = null,
      Dictionary<string, object> parameters = null)
    {
      if (string.IsNullOrEmpty(currency))
        currency = "USD";
      FB.FacebookImpl.AppEventsLogPurchase(logPurchase, currency, parameters);
    }

    private static void OnDllLoaded()
    {
      FB.LogVersion();
      FB.FacebookImpl.Init(FB.appId, FB.cookie, FB.logging, FB.status, FB.xfbml, FacebookSettings.ChannelUrl, FB.authResponse, FB.frictionlessRequests, FB.onHideUnity, FB.onInitComplete);
    }

    private static void LogVersion()
    {
      if (Object.op_Inequality((Object) FB.facebook, (Object) null))
        FacebookLogger.Info(string.Format("Using Unity SDK v{0} with {1}", (object) FacebookSdkVersion.Build, (object) FB.FacebookImpl.FacebookSdkVersion));
      else
        FacebookLogger.Info(string.Format("Using Unity SDK v{0}", (object) FacebookSdkVersion.Build));
    }

    public sealed class Canvas
    {
      private static ICanvasFacebook CanvasFacebookImpl
      {
        get
        {
          return FB.FacebookImpl is ICanvasFacebook facebookImpl ? facebookImpl : throw new InvalidOperationException("Attempt to call Canvas interface on non canvas platform");
        }
      }

      public static void Pay(
        string product,
        string action = "purchaseitem",
        int quantity = 1,
        int? quantityMin = null,
        int? quantityMax = null,
        string requestId = null,
        string pricepointId = null,
        string testCurrency = null,
        FacebookDelegate<IPayResult> callback = null)
      {
        FB.Canvas.CanvasFacebookImpl.Pay(product, action, quantity, quantityMin, quantityMax, requestId, pricepointId, testCurrency, callback);
      }
    }

    public sealed class Mobile
    {
      public static ShareDialogMode ShareDialogMode
      {
        get => FB.Mobile.MobileFacebookImpl.ShareDialogMode;
        set => FB.Mobile.MobileFacebookImpl.ShareDialogMode = value;
      }

      private static IMobileFacebook MobileFacebookImpl
      {
        get
        {
          return FB.FacebookImpl is IMobileFacebook facebookImpl ? facebookImpl : throw new InvalidOperationException("Attempt to call Mobile interface on non mobile platform");
        }
      }

      public static void AppInvite(
        Uri appLinkUrl,
        Uri previewImageUrl = null,
        FacebookDelegate<IAppInviteResult> callback = null)
      {
        FB.Mobile.MobileFacebookImpl.AppInvite(appLinkUrl, previewImageUrl, callback);
      }

      public static void FetchDeferredAppLinkData(FacebookDelegate<IAppLinkResult> callback = null)
      {
        if (callback == null)
          return;
        FB.Mobile.MobileFacebookImpl.FetchDeferredAppLink(callback);
      }
    }

    public sealed class Android
    {
      public static string KeyHash
      {
        get
        {
          return FB.FacebookImpl is AndroidFacebook facebookImpl ? facebookImpl.KeyHash : string.Empty;
        }
      }
    }

    internal abstract class CompiledFacebookLoader : MonoBehaviour
    {
      protected abstract FacebookGameObject FBGameObject { get; }

      public void Start()
      {
        FB.facebook = this.FBGameObject;
        FB.OnDllLoaded();
        Object.Destroy((Object) this);
      }
    }
  }
}
