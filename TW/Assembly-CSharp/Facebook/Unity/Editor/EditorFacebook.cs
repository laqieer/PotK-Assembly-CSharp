// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.EditorFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    ICanvasFacebookCallbackHandler,
    ICanvasFacebookImplementation,
    IFacebook,
    IFacebookCallbackHandler,
    IMobileFacebook,
    IMobileFacebookCallbackHandler,
    IMobileFacebookImplementation
  {
    private const string WarningMessage = "You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.";
    private const string AccessTokenKey = "com.facebook.unity.editor.accesstoken";

    public EditorFacebook()
      : base(new CallbackManager())
    {
    }

    public override bool LimitEventUsage { get; set; }

    public ShareDialogMode ShareDialogMode { get; set; }

    public override string FacebookSdkVersion => "None";

    private IFacebookCallbackHandler EditorGameObject
    {
      get => (IFacebookCallbackHandler) ComponentFactory.GetComponent<EditorFacebookGameObject>();
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
      FacebookLogger.Warn("You are using the facebook SDK in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.");
      base.Init(appId, cookie, logging, status, xfbml, channelUrl, authResponse, frictionlessRequests, hideUnityDelegate, onInitComplete);
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
      component.Callback = new EditorFacebookMockDialog.OnComplete(this.EditorGameObject.OnLoginComplete);
      component.CallbackID = this.CallbackManager.AddFacebookDelegate<ILoginResult>(callback);
      component.Permissions = permissions == null ? (IEnumerable<string>) new List<string>() : permissions;
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
      this.ShowEmptyMockDialog<IAppRequestResult>(new EditorFacebookMockDialog.OnComplete(((FacebookBase) this).OnAppRequestsComplete), callback, "Mock App Request");
    }

    public override void ShareLink(
      Uri contentURL,
      string contentTitle,
      string contentDescription,
      Uri photoURL,
      FacebookDelegate<IShareResult> callback)
    {
      this.ShowEmptyMockDialog<IShareResult>(new EditorFacebookMockDialog.OnComplete(((FacebookBase) this).OnShareLinkComplete), callback, "Mock Share Link");
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
      this.ShowEmptyMockDialog<IShareResult>(new EditorFacebookMockDialog.OnComplete(((FacebookBase) this).OnShareLinkComplete), callback, "Mock Feed Share");
    }

    public override void GameGroupCreate(
      string name,
      string description,
      string privacy,
      FacebookDelegate<IGroupCreateResult> callback)
    {
      this.ShowEmptyMockDialog<IGroupCreateResult>(new EditorFacebookMockDialog.OnComplete(((FacebookBase) this).OnGroupCreateComplete), callback, "Mock Group Create");
    }

    public override void GameGroupJoin(string id, FacebookDelegate<IGroupJoinResult> callback)
    {
      this.ShowEmptyMockDialog<IGroupJoinResult>(new EditorFacebookMockDialog.OnComplete(((FacebookBase) this).OnGroupJoinComplete), callback, "Mock Group Join");
    }

    public override void ActivateApp(string appId)
    {
      FacebookLogger.Info("This only needs to be called for iOS or Android.");
    }

    public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      this.OnGetAppLinkComplete(Json.Serialize((object) new Dictionary<string, object>()
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
      this.ShowEmptyMockDialog<IAppInviteResult>(new EditorFacebookMockDialog.OnComplete(this.OnAppInviteComplete), callback, "Mock App Invite");
    }

    public void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
    {
      this.OnFetchDeferredAppLinkComplete(Json.Serialize((object) new Dictionary<string, object>()
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
      this.ShowEmptyMockDialog<IPayResult>(new EditorFacebookMockDialog.OnComplete(this.OnPayComplete), callback, "Mock Pay Dialog");
    }

    public override void OnAppRequestsComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(message));
    }

    public override void OnGetAppLinkComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(message));
    }

    public override void OnGroupCreateComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupCreateResult(message));
    }

    public override void OnGroupJoinComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new GroupJoinResult(message));
    }

    public override void OnLoginComplete(string message)
    {
      this.OnAuthResponse(new LoginResult(message));
    }

    public override void OnShareLinkComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(message));
    }

    public void OnAppInviteComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppInviteResult(message));
    }

    public void OnFetchDeferredAppLinkComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(message));
    }

    public void OnPayComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new PayResult(message));
    }

    public void OnFacebookAuthResponseChange(string message) => throw new NotSupportedException();

    public void OnUrlResponse(string message) => throw new NotSupportedException();

    private void ShowEmptyMockDialog<T>(
      EditorFacebookMockDialog.OnComplete callback,
      FacebookDelegate<T> userCallback,
      string title)
      where T : IResult
    {
      EmptyMockDialog component = ComponentFactory.GetComponent<EmptyMockDialog>();
      component.Callback = callback;
      component.CallbackID = this.CallbackManager.AddFacebookDelegate<T>(userCallback);
      component.EmptyDialogTitle = title;
    }
  }
}
