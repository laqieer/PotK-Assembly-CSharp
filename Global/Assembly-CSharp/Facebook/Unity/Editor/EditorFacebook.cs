// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.EditorFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using Facebook.Unity.Canvas;
using Facebook.Unity.Editor.Dialogs;
using Facebook.Unity.Mobile;
using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Editor
{
  internal class EditorFacebook : 
    FacebookBase,
    ICanvasFacebook,
    ICanvasFacebookImplementation,
    ICanvasFacebookResultHandler,
    IFacebook,
    IFacebookResultHandler,
    IPayFacebook,
    IMobileFacebook,
    IMobileFacebookImplementation,
    IMobileFacebookResultHandler
  {
    private const string WarningMessage = "You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.";
    private const string AccessTokenKey = "com.facebook.unity.editor.accesstoken";

    public EditorFacebook()
      : base(new CallbackManager())
    {
    }

    public override bool LimitEventUsage { get; set; }

    public ShareDialogMode ShareDialogMode { get; set; }

    public override string SDKName => "FBUnityEditorSDK";

    public override string SDKVersion => FacebookSdkVersion.Build;

    private IFacebookCallbackHandler EditorGameObject
    {
      get => (IFacebookCallbackHandler) ComponentFactory.GetComponent<EditorFacebookGameObject>();
    }

    public override void Init(HideUnityDelegate hideUnityDelegate, InitDelegate onInitComplete)
    {
      FacebookLogger.Warn("You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.");
      base.Init(hideUnityDelegate, onInitComplete);
      this.EditorGameObject.OnInitComplete(string.Empty);
    }

    public override void LogInWithReadPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      this.LogInWithPublishPermissions(permissions, callback);
    }

    public override void LogInWithPublishPermissions(
      IEnumerable<string> permissions,
      FacebookDelegate<ILoginResult> callback)
    {
      MockLoginDialog component = ComponentFactory.GetComponent<MockLoginDialog>();
      component.Callback = new Utilities.Callback<ResultContainer>(this.OnLoginComplete);
      component.CallbackID = this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback);
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
      this.ShowEmptyMockDialog<IAppRequestResult>(new Utilities.Callback<ResultContainer>(((FacebookBase) this).OnAppRequestsComplete), callback, "Mock App Request");
    }

    public override void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback)
    {
      this.ShowMockShareDialog(nameof (ShareLink), callback);
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
      this.ShowMockShareDialog(nameof (FeedShare), callback);
    }

    public override void GameGroupCreate(
      string name,
      string description,
      string privacy,
      FacebookDelegate<IGroupCreateResult> callback)
    {
      this.ShowEmptyMockDialog<IGroupCreateResult>(new Utilities.Callback<ResultContainer>(((FacebookBase) this).OnGroupCreateComplete), callback, "Mock Group Create");
    }

    public override void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback)
    {
      this.ShowEmptyMockDialog<IGroupJoinResult>(new Utilities.Callback<ResultContainer>(((FacebookBase) this).OnGroupJoinComplete), callback, "Mock Group Join");
    }

    public override void ActivateApp(string appId)
    {
      FacebookLogger.Info("This only needs to be called for iOS or Android.");
    }

    public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      this.OnGetAppLinkComplete(new ResultContainer((IDictionary<string, object>) new Dictionary<string, object>()
      {
        ["url"] = (object) "mockurl://testing.url",
        ["callback_id"] = (object) this.CallbackManager.AddFacebookDelegate<IAppLinkResult>(callback)
      }));
    }

    public override void AppEventsLogEvent(
      string logEvent,
      float? valueToSum,
      Dictionary<string, object> parameters)
    {
      FacebookLogger.Log("Pew! Pretending to send this off.  Doesn't actually work in the editor");
    }

    public override void AppEventsLogPurchase(
      float logPurchase,
      string currency,
      Dictionary<string, object> parameters)
    {
      FacebookLogger.Log("Pew! Pretending to send this off.  Doesn't actually work in the editor");
    }

    public void AppInvite(
      Uri appLinkUrl,
      Uri previewImageUrl,
      FacebookDelegate<IAppInviteResult> callback)
    {
      this.ShowEmptyMockDialog<IAppInviteResult>(new Utilities.Callback<ResultContainer>(this.OnAppInviteComplete), callback, "Mock App Invite");
    }

    public void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      this.OnFetchDeferredAppLinkComplete(new ResultContainer((IDictionary<string, object>) new Dictionary<string, object>()
      {
        ["url"] = (object) "mockurl://testing.url",
        ["ref"] = (object) "mock ref",
        ["extras"] = (object) new Dictionary<string, object>()
        {
          {
            "mock extra key",
            (object) "mock extra value"
          }
        },
        ["target_url"] = (object) "mocktargeturl://mocktarget.url",
        ["callback_id"] = (object) this.CallbackManager.AddFacebookDelegate<IAppLinkResult>(callback)
      }));
    }

    public void Pay(
      string product,
      string action,
      int quantity,
      int? quantityMin,
      int? quantityMax,
      string requestId,
      string pricepointId,
      string testCurrency,
      FacebookDelegate<IPayResult> callback)
    {
      this.ShowEmptyMockDialog<IPayResult>(new Utilities.Callback<ResultContainer>(this.OnPayComplete), callback, "Mock Pay Dialog");
    }

    public void RefreshCurrentAccessToken(
      FacebookDelegate<IAccessTokenRefreshResult> callback)
    {
      if (callback == null)
        return;
      Dictionary<string, object> dest = new Dictionary<string, object>()
      {
        {
          "callback_id",
          (object) this.CallbackManager.AddFacebookDelegate<IAccessTokenRefreshResult>(callback)
        }
      };
      if (AccessToken.CurrentAccessToken == null)
      {
        dest["error"] = (object) "No current access token";
      }
      else
      {
        IDictionary<string, object> source = (IDictionary<string, object>) Json.Deserialize(AccessToken.CurrentAccessToken.ToJson());
        dest.AddAllKVPFrom<string, object>(source);
      }
      this.OnRefreshCurrentAccessTokenComplete(new ResultContainer((IDictionary<string, object>) dest));
    }

    public override void OnAppRequestsComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(resultContainer));
    }

    public override void OnGetAppLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(resultContainer));
    }

    public override void OnGroupCreateComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupCreateResult(resultContainer));
    }

    public override void OnGroupJoinComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupJoinResult(resultContainer));
    }

    public override void OnLoginComplete(ResultContainer resultContainer)
    {
      this.OnAuthResponse(new LoginResult(resultContainer));
    }

    public override void OnShareLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(resultContainer));
    }

    public void OnAppInviteComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppInviteResult(resultContainer));
    }

    public void OnFetchDeferredAppLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(resultContainer));
    }

    public void OnPayComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new PayResult(resultContainer));
    }

    public void OnRefreshCurrentAccessTokenComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AccessTokenRefreshResult(resultContainer));
    }

    public void OnFacebookAuthResponseChange(ResultContainer resultContainer)
    {
      throw new NotSupportedException();
    }

    public void OnUrlResponse(string message) => throw new NotSupportedException();

    private void ShowEmptyMockDialog<T>(
      Utilities.Callback<ResultContainer> callback,
      FacebookDelegate<T> userCallback,
      string title)
      where T : IResult
    {
      EmptyMockDialog component = ComponentFactory.GetComponent<EmptyMockDialog>();
      component.Callback = callback;
      component.CallbackID = this.CallbackManager.AddFacebookDelegate<T>(userCallback);
      component.EmptyDialogTitle = title;
    }

    private void ShowMockShareDialog(string subTitle, FacebookDelegate<IShareResult> userCallback)
    {
      MockShareDialog component = ComponentFactory.GetComponent<MockShareDialog>();
      component.SubTitle = subTitle;
      component.Callback = new Utilities.Callback<ResultContainer>(this.OnShareLinkComplete);
      component.CallbackID = this.CallbackManager.AddFacebookDelegate<IShareResult>(userCallback);
    }
  }
}
