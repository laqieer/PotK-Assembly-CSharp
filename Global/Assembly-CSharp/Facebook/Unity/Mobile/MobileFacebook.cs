// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.MobileFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Mobile
{
  internal abstract class MobileFacebook : 
    FacebookBase,
    IFacebook,
    IFacebookResultHandler,
    IMobileFacebook,
    IMobileFacebookImplementation,
    IMobileFacebookResultHandler
  {
    private const string CallbackIdKey = "callback_id";
    private ShareDialogMode shareDialogMode;

    protected MobileFacebook(CallbackManager callbackManager)
      : base(callbackManager)
    {
    }

    public ShareDialogMode ShareDialogMode
    {
      get => this.shareDialogMode;
      set
      {
        this.shareDialogMode = value;
        this.SetShareDialogMode(this.shareDialogMode);
      }
    }

    public abstract void AppInvite(
      Uri appLinkUrl,
      Uri previewImageUrl,
      FacebookDelegate<IAppInviteResult> callback);

    public abstract void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback);

    public abstract void RefreshCurrentAccessToken(
      FacebookDelegate<IAccessTokenRefreshResult> callback);

    public override void OnLoginComplete(ResultContainer resultContainer)
    {
      this.OnAuthResponse(new LoginResult(resultContainer));
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

    public override void OnAppRequestsComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(resultContainer));
    }

    public void OnAppInviteComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppInviteResult(resultContainer));
    }

    public void OnFetchDeferredAppLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(resultContainer));
    }

    public override void OnShareLinkComplete(ResultContainer resultContainer)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(resultContainer));
    }

    public void OnRefreshCurrentAccessTokenComplete(ResultContainer resultContainer)
    {
      AccessTokenRefreshResult result = new AccessTokenRefreshResult(resultContainer);
      if (result.AccessToken != null)
        AccessToken.CurrentAccessToken = result.AccessToken;
      this.CallbackManager.OnFacebookResponse((IInternalResult) result);
    }

    protected abstract void SetShareDialogMode(ShareDialogMode mode);

    private static IDictionary<string, object> DeserializeMessage(string message)
    {
      return (IDictionary<string, object>) Json.Deserialize(message);
    }

    private static string SerializeDictionary(IDictionary<string, object> dict)
    {
      return Json.Serialize((object) dict);
    }

    private static bool TryGetCallbackId(IDictionary<string, object> result, out string callbackId)
    {
      callbackId = (string) null;
      object obj;
      if (!result.TryGetValue("callback_id", out obj))
        return false;
      callbackId = obj as string;
      return true;
    }

    private static bool TryGetError(IDictionary<string, object> result, out string errorMessage)
    {
      errorMessage = (string) null;
      object obj;
      if (!result.TryGetValue("error", out obj))
        return false;
      errorMessage = obj as string;
      return true;
    }
  }
}
