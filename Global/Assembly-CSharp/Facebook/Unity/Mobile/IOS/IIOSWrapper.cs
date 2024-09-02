// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.IOS.IIOSWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Mobile.IOS
{
  internal interface IIOSWrapper
  {
    void Init(
      string appId,
      bool frictionlessRequests,
      string urlSuffix,
      string unityUserAgentSuffix);

    void LogInWithReadPermissions(int requestId, string scope);

    void LogInWithPublishPermissions(int requestId, string scope);

    void LogOut();

    void SetShareDialogMode(int mode);

    void ShareLink(
      int requestId,
      string contentURL,
      string contentTitle,
      string contentDescription,
      string photoURL);

    void FeedShare(
      int requestId,
      string toId,
      string link,
      string linkName,
      string linkCaption,
      string linkDescription,
      string picture,
      string mediaSource);

    void AppRequest(
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
      string title = "");

    void AppInvite(int requestId, string appLinkUrl, string previewImageUrl);

    void CreateGameGroup(int requestId, string name, string description, string privacy);

    void JoinGameGroup(int requestId, string groupId);

    void FBSettingsActivateApp(string appId);

    void LogAppEvent(
      string logEvent,
      double valueToSum,
      int numParams,
      string[] paramKeys,
      string[] paramVals);

    void LogPurchaseAppEvent(
      double logPurchase,
      string currency,
      int numParams,
      string[] paramKeys,
      string[] paramVals);

    void FBAppEventsSetLimitEventUsage(bool limitEventUsage);

    void GetAppLink(int requestId);

    void RefreshCurrentAccessToken(int requestId);

    string FBSdkVersion();

    void FetchDeferredAppLink(int requestId);
  }
}
