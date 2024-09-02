// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.IOS.IOSFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Facebook.Unity.Mobile.IOS
{
  internal class IOSFacebook : MobileFacebook
  {
    private const string CancelledResponse = "{\"cancelled\":true}";
    private bool limitEventUsage;

    public IOSFacebook()
      : this(new CallbackManager())
    {
    }

    public IOSFacebook(CallbackManager callbackManager)
      : base(callbackManager)
    {
    }

    public override bool LimitEventUsage
    {
      get => this.limitEventUsage;
      set
      {
        this.limitEventUsage = value;
        IOSFacebook.IOSFBAppEventsSetLimitEventUsage(value);
      }
    }

    public override string FacebookSdkVersion
    {
      get => string.Format("Facebook.iOS.SDK.{0}", (object) IOSFacebook.IOSFBSdkVersion());
    }

    public override void Init(
      string appId,
      bool cookie,
      bool logging,
      bool status,
      bool xfbml,
      string channelUrl,
      string authResponse,
      bool frictionlessRequests,
      HideUnityDelegate hideUnityDelegate,
      InitDelegate onInitComplete)
    {
      base.Init(appId, cookie, logging, status, xfbml, channelUrl, authResponse, frictionlessRequests, hideUnityDelegate, onInitComplete);
      string unityUserAgentSuffix = string.Format("Unity.{0}", (object) Facebook.Unity.FacebookSdkVersion.Build);
      IOSFacebook.IOSInit(appId, cookie, logging, status, frictionlessRequests, FacebookSettings.IosURLSuffix, unityUserAgentSuffix);
    }

    public override void LogInWithReadPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      IOSFacebook.IOSLogInWithReadPermissions(this.AddCallback<ILoginResult>(callback), permissions.ToCommaSeparateList());
    }

    public override void LogInWithPublishPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      IOSFacebook.IOSLogInWithPublishPermissions(this.AddCallback<ILoginResult>(callback), permissions.ToCommaSeparateList());
    }

    public override void LogOut()
    {
      base.LogOut();
      IOSFacebook.IOSLogOut();
    }

    public override void AppRequest(
      string message,
      OGActionType? actionType,
      string objectId,
      IEnumerable<string> to,
      IEnumerable<object> filters,
      IEnumerable<string> excludeIds,
      int? maxRecipients,
      string data,
      string title,
      FacebookDelegate<IAppRequestResult> callback)
    {
      this.ValidateAppRequestArgs(message, actionType, objectId, to, filters, excludeIds, maxRecipients, data, title, callback);
      string str = (string) null;
      if (filters != null && filters.Any<object>())
        str = filters.First<object>() as string;
      IOSFacebook.IOSAppRequest(this.AddCallback<IAppRequestResult>(callback), message, !actionType.HasValue ? string.Empty : actionType.ToString(), objectId == null ? string.Empty : objectId, to == null ? (string[]) null : to.ToArray<string>(), to == null ? 0 : to.Count<string>(), str == null ? string.Empty : str, excludeIds == null ? (string[]) null : excludeIds.ToArray<string>(), excludeIds == null ? 0 : excludeIds.Count<string>(), maxRecipients.HasValue, !maxRecipients.HasValue ? 0 : maxRecipients.Value, data, title);
    }

    public override void AppInvite(
      Uri appLinkUrl,
      Uri previewImageUrl,
      FacebookDelegate<IAppInviteResult> callback)
    {
      string appLinkUrl1 = string.Empty;
      string previewImageUrl1 = string.Empty;
      if (appLinkUrl != (Uri) null && !string.IsNullOrEmpty(appLinkUrl.AbsoluteUri))
        appLinkUrl1 = appLinkUrl.AbsoluteUri;
      if (previewImageUrl != (Uri) null && !string.IsNullOrEmpty(previewImageUrl.AbsoluteUri))
        previewImageUrl1 = previewImageUrl.AbsoluteUri;
      IOSFacebook.IOSAppInvite(this.AddCallback<IAppInviteResult>(callback), appLinkUrl1, previewImageUrl1);
    }

    public override void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback)
    {
      IOSFacebook.IOSShareLink(this.AddCallback<IShareResult>(callback), contentURL.AbsoluteUrlOrEmptyString(), contentTitle, contentDescription, photoURL.AbsoluteUrlOrEmptyString());
    }

    public override void FeedShare(
      string toId,
      Uri link,
      string linkName,
      string linkCaption,
      string linkDescription,
      Uri picture,
      string mediaSource,
      FacebookDelegate<IShareResult> callback)
    {
      string link1 = !(link != (Uri) null) ? string.Empty : link.ToString();
      string picture1 = !(picture != (Uri) null) ? string.Empty : picture.ToString();
      IOSFacebook.IOSFeedShare(this.AddCallback<IShareResult>(callback), toId, link1, linkName, linkCaption, linkDescription, picture1, mediaSource);
    }

    public override void GameGroupCreate(
      string name,
      string description,
      string privacy,
      FacebookDelegate<IGroupCreateResult> callback)
    {
      IOSFacebook.IOSCreateGameGroup(this.AddCallback<IGroupCreateResult>(callback), name, description, privacy);
    }

    public override void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback)
    {
      IOSFacebook.IOSJoinGameGroup(Convert.ToInt32(this.CallbackManager.AddFacebookDelegate<IGroupJoinResult>(callback)), id);
    }

    public override void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters)
    {
      IOSFacebook.NativeDict nativeDict = IOSFacebook.MarshallDict(parameters);
      if (valueToSum.HasValue)
        IOSFacebook.IOSFBAppEventsLogEvent(logEvent, (double) valueToSum.Value, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
      else
        IOSFacebook.IOSFBAppEventsLogEvent(logEvent, 0.0, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
    }

    public override void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters)
    {
      IOSFacebook.NativeDict nativeDict = IOSFacebook.MarshallDict(parameters);
      IOSFacebook.IOSFBAppEventsLogPurchase((double) logPurchase, currency, nativeDict.NumEntries, nativeDict.Keys, nativeDict.Values);
    }

    public override void ActivateApp(string appId) => IOSFacebook.IOSFBSettingsActivateApp(appId);

    public override void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      IOSFacebook.IOSFetchDeferredAppLink(this.AddCallback<IAppLinkResult>(callback));
    }

    public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      IOSFacebook.IOSGetAppLink(Convert.ToInt32(this.CallbackManager.AddFacebookDelegate<IAppLinkResult>(callback)));
    }

    protected override void SetShareDialogMode(ShareDialogMode mode)
    {
      IOSFacebook.IOSSetShareDialogMode((int) mode);
    }

    private static void IOSInit(
      string appId,
      bool cookie,
      bool logging,
      bool status,
      bool frictionlessRequests,
      string urlSuffix,
      string unityUserAgentSuffix)
    {
    }

    private static void IOSLogInWithReadPermissions(int requestId, string scope)
    {
    }

    private static void IOSLogInWithPublishPermissions(int requestId, string scope)
    {
    }

    private static void IOSLogOut()
    {
    }

    private static void IOSSetShareDialogMode(int mode)
    {
    }

    private static void IOSShareLink(
      int requestId,
      string contentURL,
      string contentTitle,
      string contentDescription,
      string photoURL)
    {
    }

    private static void IOSFeedShare(
      int requestId,
      string toId,
      string link,
      string linkName,
      string linkCaption,
      string linkDescription,
      string picture,
      string mediaSource)
    {
    }

    private static void IOSAppRequest(
      int requestId,
      string message,
      string actionType,
      string objectId,
      string[] to = null,
      int toLength = 0,
      string filters = "",
      string[] excludeIds = null,
      int excludeIdsLength = 0,
      bool hasMaxRecipients = false,
      int maxRecipients = 0,
      string data = "",
      string title = "")
    {
    }

    private static void IOSAppInvite(int requestId, string appLinkUrl, string previewImageUrl)
    {
    }

    private static void IOSCreateGameGroup(
      int requestId,
      string name,
      string description,
      string privacy)
    {
    }

    private static void IOSJoinGameGroup(int requestId, string groupId)
    {
    }

    private static void IOSFBSettingsPublishInstall(int requestId, string appId)
    {
    }

    private static void IOSFBSettingsActivateApp(string appId)
    {
    }

    private static void IOSFBAppEventsLogEvent(
      string logEvent,
      double valueToSum,
      int numParams,
      string[] paramKeys,
      string[] paramVals)
    {
    }

    private static void IOSFBAppEventsLogPurchase(
      double logPurchase,
      string currency,
      int numParams,
      string[] paramKeys,
      string[] paramVals)
    {
    }

    private static void IOSFBAppEventsSetLimitEventUsage(bool limitEventUsage)
    {
    }

    private static void IOSGetAppLink(int requestId)
    {
    }

    private static string IOSFBSdkVersion() => "NONE";

    private static void IOSFetchDeferredAppLink(int requestId)
    {
    }

    private static IOSFacebook.NativeDict MarshallDict(Dictionary<string, object> dict)
    {
      IOSFacebook.NativeDict nativeDict = new IOSFacebook.NativeDict();
      if (dict != null && dict.Count > 0)
      {
        nativeDict.Keys = new string[dict.Count];
        nativeDict.Values = new string[dict.Count];
        nativeDict.NumEntries = 0;
        foreach (KeyValuePair<string, object> keyValuePair in dict)
        {
          nativeDict.Keys[nativeDict.NumEntries] = keyValuePair.Key;
          nativeDict.Values[nativeDict.NumEntries] = keyValuePair.Value.ToString();
          ++nativeDict.NumEntries;
        }
      }
      return nativeDict;
    }

    private static IOSFacebook.NativeDict MarshallDict(Dictionary<string, string> dict)
    {
      IOSFacebook.NativeDict nativeDict = new IOSFacebook.NativeDict();
      if (dict != null && dict.Count > 0)
      {
        nativeDict.Keys = new string[dict.Count];
        nativeDict.Values = new string[dict.Count];
        nativeDict.NumEntries = 0;
        foreach (KeyValuePair<string, string> keyValuePair in dict)
        {
          nativeDict.Keys[nativeDict.NumEntries] = keyValuePair.Key;
          nativeDict.Values[nativeDict.NumEntries] = keyValuePair.Value;
          ++nativeDict.NumEntries;
        }
      }
      return nativeDict;
    }

    private int AddCallback<T>(FacebookDelegate<T> callback) where T : IResult
    {
      return Convert.ToInt32(this.CallbackManager.AddFacebookDelegate<T>(callback));
    }

    public enum FBInsightsFlushBehavior
    {
      FBInsightsFlushBehaviorAuto,
      FBInsightsFlushBehaviorExplicitOnly,
    }

    private class NativeDict
    {
      public NativeDict()
      {
        this.NumEntries = 0;
        this.Keys = (string[]) null;
        this.Values = (string[]) null;
      }

      public int NumEntries { get; set; }

      public string[] Keys { get; set; }

      public string[] Values { get; set; }
    }
  }
}
