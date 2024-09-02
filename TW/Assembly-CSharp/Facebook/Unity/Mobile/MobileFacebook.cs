// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.MobileFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Facebook.MiniJSON;
using System;
using System.Collections.Generic;

#nullable disable
namespace Facebook.Unity.Mobile
{
  internal abstract class MobileFacebook : 
    FacebookBase,
    IFacebook,
    IFacebookCallbackHandler,
    IMobileFacebook,
    IMobileFacebookCallbackHandler,
    IMobileFacebookImplementation
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

    public override void OnLoginComplete(string message)
    {
      this.OnAuthResponse(new LoginResult(message));
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

    public override void OnAppRequestsComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppRequestResult(message));
    }

    public void OnAppInviteComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppInviteResult(message));
    }

    public void OnFetchDeferredAppLinkComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new AppLinkResult(message));
    }

    public override void OnShareLinkComplete(string message)
    {
      this.CallbackManager.OnFacebookResponse((IInternalResult) new ShareResult(message));
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
